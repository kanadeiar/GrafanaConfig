using System.Collections.Generic;
using System.Text;
using GrafanaConfig.Models;

namespace GrafanaConfig
{
    static class GenSQL
    {
        public static string GetTopSql(IList<ConfigLine> configs, params string[] names)
        {
            StringBuilder sb = new StringBuilder();
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
VALUES \n");

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

            sb.Append(@";
DECLARE @countsetdata INT;
SET @countsetdata = 94;
IF OBJECT_ID('tempdb..#tempdata' ) IS NOT NULL DROP TABLE #tempdata;
SELECT tmr.ItemID, tmi.Name, tmr.Value, tmr.[Time], tmr.Quality, tmr.Flags
INTO #tempdata
FROM riannon.telemetry.dbo.MasterSCADADataRaw tmr INNER JOIN riannon.telemetry.dbo.MasterSCADADataItems tmi
	ON (tmr.ProjectID=tmi.ProjectID AND tmr.Layer=1 AND tmi.ItemID=tmr.ItemID AND tmi.LastTime=tmr.[Time]);
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
		--SET @ttmp = (SELECT [Time] FROM #tempdata WHERE ItemID=@link);
		--IF (@ttmp >= dateadd(hh,-48,getdate())) SET @linkv=1; ELSE SET @linkv=0;
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
FROM #tempresultdata");

            foreach (var el in names)
            {
                sb.AppendLine($"WHERE name LIKE '%{el}%'");
            }

            sb.Append("ORDER BY id;");
            return sb.ToString();
        }
    }
}
