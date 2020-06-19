using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using GrafanaConfig.Models;
using GrafanaConfig.Tools;

namespace GrafanaConfig
{
    /// <summary> Генератор SQL кода </summary>
    static class GenSQL
    {
        static private Secrets secrets;
        static GenSQL()
        {
            secrets = new Secrets();
            secrets.textRaw = "notwork";
            secrets.textItems = "notwork";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Secrets));
            string fileName = "secret.xml";
            if (File.Exists(fileName))
            {
                try
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        secrets = (Secrets)xmlSerializer.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не прочитать секретные настройки приложения из файла \"secret.xml\"!");
                }
            }
        }
        /// <summary> Генератор SQL кода фонда скважин </summary>
        /// <param name="configs">конфигурация</param>
        /// <param name="names">название</param>
        /// <returns>SQL запрос</returns>
        public static string GetTopSql(IList<ConfigLine> configs, params string[] names)
        {
            StringBuilder sb = new StringBuilder();
            GenHeadSql(configs, sb);

            sb.Append(@"
IF OBJECT_ID('tempdb..#tempdata' ) IS NOT NULL DROP TABLE #tempdata;
SELECT tmr.ItemID, tmi.Name, tmr.Value, tmr.[Time], tmr.Quality, tmr.Flags
INTO #tempdata
");
            sb.AppendLine($"FROM {secrets.textRaw} tmr INNER JOIN {secrets.textItems} tmi");

            sb.Append(@"    ON (tmr.ProjectID=tmi.ProjectID AND tmr.Layer=1 AND tmi.ItemID=tmr.ItemID AND tmi.LastTime=tmr.[Time]);
DECLARE @id INT;
DECLARE @name VARCHAR(64);
DECLARE @number INT;
DECLARE @status INT, @link INT;
DECLARE @a INT, @b INT, @c INT, @d INT, @e INT, @f INT, @g INT, @h INT, @i INT, @k INT;
DECLARE @statusv INT, @linkv INT;
DECLARE @av FLOAT=NULL, @bv FLOAT=NULL, @cv FLOAT=NULL, @dv FLOAT=NULL, @ev FLOAT=NULL;
DECLARE @fv FLOAT=NULL, @gv FLOAT=NULL, @hv FLOAT=NULL, @iv FLOAT=NULL, @kv FLOAT=NULL;
DECLARE @ftmp FLOAT;
DECLARE @itmp INT;
DECLARE @ttmp DATETIME;
IF OBJECT_ID('tempdb..#tempresultdata' ) IS NOT NULL DROP TABLE #tempresultdata;
CREATE TABLE #tempresultdata
(
id INT NOT NULL,
name VARCHAR(64) NOT NULL,
number INT NULL,
[status] INT NULL,
[link] INT NULL,
a FLOAT NULL,
b FLOAT NULL, 
c FLOAT NULL,
d FLOAT NULL,
e FLOAT NULL,
f FLOAT NULL,
g FLOAT NULL,
h FLOAT NULL,
i FLOAT NULL,
k FLOAT NULL,
CONSTRAINT PK_idTempResultData PRIMARY KEY (id),
);
DECLARE @ik INT;
SET @ik=1;
WHILE @ik<=@countsetdata 
BEGIN
	SELECT @id=id,@name=name,@number=number,@status=[status],@link=link,@a=a,@b=b,@c=c,@d=d,@e=e,@f=f,@g=g,@h=h,@i=i,@k=k FROM #tempsetdata WHERE id=@ik;
	SET @statusv = NULL;
	IF (@status IS NOT NULL)
	BEGIN
		SET @ftmp = (SELECT Value FROM #tempdata WHERE ItemID=@status);
		IF (@ftmp>1) SET @statusv=1; ELSE SET @statusv=0;
	END
	SET @linkv=NULL;
	IF (@link IS NOT NULL)
	BEGIN
		SET @itmp = (SELECT Quality FROM #tempdata WHERE ItemID=@link);
		IF (@itmp = 192) SET @linkv=1; ELSE SET @linkv=0;
	END
	SET @av = (SELECT Value FROM #tempdata WHERE ItemID=@a);
	SET @bv = (SELECT Value FROM #tempdata WHERE ItemID=@b);
	SET @cv = (SELECT Value FROM #tempdata WHERE ItemID=@c);
	SET @dv = (SELECT Value FROM #tempdata WHERE ItemID=@d);
	SET @ev = (SELECT Value FROM #tempdata WHERE ItemID=@e);
	SET @fv = (SELECT Value FROM #tempdata WHERE ItemID=@f);
	SET @gv = (SELECT Value FROM #tempdata WHERE ItemID=@g);
	SET @hv = (SELECT Value FROM #tempdata WHERE ItemID=@h);
	SET @iv = (SELECT Value FROM #tempdata WHERE ItemID=@i);
	SET @kv = (SELECT Value FROM #tempdata WHERE ItemID=@k);
	INSERT INTO #tempresultdata(id,name,number,[status],link,a,b,c,d,e,f,g,h,i,k)
	VALUES (@id,@name,@number,@statusv,@linkv,@av,@bv,@cv,@dv,@ev,@fv,@gv,@hv,@iv,@kv);
	SET @ik=@ik+1;
END
SELECT name,number,[status],link,ROUND(a,1)AS a,ROUND(b,1)AS b,ROUND(c,1)AS c,ROUND(d,1)AS d,ROUND(e,1)AS e,ROUND(f,1)AS f,ROUND(g,1)AS g,ROUND(h,1)AS h 
FROM #tempresultdata
");

            bool firstWhere = true;
            foreach (var el in names)
            {
                if (firstWhere)
                {
                    sb.Append($"WHERE (name LIKE '%{el}%')");
                    firstWhere = false;
                }
                else
                {
                    sb.Append($" OR (name LIKE '%{el}%')");
                }
            }
            sb.Append("\n");

            sb.Append("ORDER BY id;");
            return sb.ToString();
        }
        /// <summary> Генератор SQL кода запроса на тренд параметра </summary>
        /// <param name="configs"></param>
        /// <returns></returns>
        public static string GetTrendSql(IList<ConfigLine> configs)
        {
            StringBuilder sb = new StringBuilder();
            GenHeadSql(configs, sb);
            sb.Append(@"
DECLARE @ItemID INT;
SET @ItemID = (SELECT TOP 1 $col FROM #tempsetdata WHERE number=$num AND name='$name');

IF OBJECT_ID('tempdb..#temptrenddata' ) IS NOT NULL DROP TABLE #temptrenddata;
SELECT IIF(tmr.Quality=192,tmr.Value,NULL) as [Value], tmr.[Time] as time
INTO #temptrenddata
");
            sb.AppendLine($"FROM {secrets.textRaw} tmr");
            sb.Append(@"WHERE (tmr.ProjectID=1) and (tmr.Layer=2 or tmr.Layer=1) and (tmr.ItemID = @ItemID) and ($__timeFilter(tmr.[Time]))
ORDER BY tmr.Time;

DECLARE @description varchar(256);
SET @description = (SELECT tmi.Name");

            sb.AppendLine($"FROM riannon.telemetry.dbo.MasterSCADADataItems tmi");
            sb.Append(@"WHERE tmi.ItemID = @ItemID);

DECLARE @SQL varchar(8000);
SET @SQL = 'SELECT Value as "); sb.Append("\"'+@description+'\", time\n");
            sb.Append(@"FROM #temptrenddata
ORDER BY time;';
exec(@SQL);");

            return sb.ToString();
        }

        /// <summary> Генерация верхней части SQL запроса </summary>
        /// <param name="configs"></param>
        /// <param name="sb"></param>
        private static void GenHeadSql(IList<ConfigLine> configs, StringBuilder sb)
        {
            sb.Append(@"IF OBJECT_ID('tempdb..#tempsetdata' ) IS NOT NULL DROP TABLE #tempsetdata;
CREATE TABLE #tempsetdata
(
id INT NOT NULL,
name VARCHAR(64) NOT NULL,
number INT NULL,
[status] INT NULL,
[link] INT NULL,
a INT NULL,
b INT NULL, 
c INT NULL,
d INT NULL,
e INT NULL,
f INT NULL,
g INT NULL,
h INT NULL,
i INT NULL,
k INT NULL,
CONSTRAINT PK_idTempSetDataId PRIMARY KEY (id),
);
INSERT INTO #tempsetdata(id,name,number,[status],link, a,b,c,d,e,f,g,h,i,k)
VALUES
");

            for (int i = 0; i < configs.Count; i++)
            {
                if (i > 0)
                    sb.Append(",");
                sb.Append($"({i + 1},");
                sb.Append($"'{configs[i].Name}',");
                sb.Append($"{configs[i].Num},");
                sb.Append($"{((configs[i].Status != 0) ? configs[i].Status.ToString() : "NULL")},");
                sb.Append($"{((configs[i].Link != 0) ? configs[i].Link.ToString() : "NULL")},");
                sb.Append($"{((configs[i].A != 0) ? configs[i].A.ToString() : "NULL")},");
                sb.Append($"{((configs[i].B != 0) ? configs[i].B.ToString() : "NULL")},");
                sb.Append($"{((configs[i].C != 0) ? configs[i].C.ToString() : "NULL")},");
                sb.Append($"{((configs[i].D != 0) ? configs[i].D.ToString() : "NULL")},");
                sb.Append($"{((configs[i].E != 0) ? configs[i].E.ToString() : "NULL")},");
                sb.Append($"{((configs[i].F != 0) ? configs[i].F.ToString() : "NULL")},");
                sb.Append($"{((configs[i].G != 0) ? configs[i].G.ToString() : "NULL")},");
                sb.Append($"{((configs[i].H != 0) ? configs[i].H.ToString() : "NULL")},");
                sb.Append($"{((configs[i].I != 0) ? configs[i].I.ToString() : "NULL")},");
                sb.Append($"{((configs[i].K != 0) ? configs[i].K.ToString() : "NULL")})\n");
            }

            sb.Append($@";
DECLARE @countsetdata INT;
SET @countsetdata = {configs.Count};
");
        }


    }
}
