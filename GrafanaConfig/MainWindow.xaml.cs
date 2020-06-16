using GrafanaConfig.Commands;
using GrafanaConfig.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace GrafanaConfig
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary> Конфигурация </summary>
        private readonly IList<ConfigLine> _configs = new ObservableCollection<ConfigLine>();

        public MainWindow()
        {
            InitializeComponent();

            #region Тестовые первоначальные данные

            _configs.Add(new ConfigLine
            {
                Name = "Novospasskoe",
                Num = 3,
                Status = 81686,
                Link = 81686, //IsChanged = false,
                A = 81689,
                B = 81686,
                C = 81666,
                D = 81690,
                E = 81691,
                F = 81665,
                G = 0,
                H = 0,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Novospasskoe",
                Num = 7,
                Status = 80367,
                Link = 80367, //IsChanged = false,
                A = 0,
                B = 80367,
                C = 0,
                D = 0,
                E = 0,
                F = 0,
                G = 0,
                H = 0,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Novospasskoe",
                Num = 20,
                Status = 40992,
                Link = 40992, //IsChanged = false,
                A = 40995,
                B = 40992,
                C = 40969,
                D = 58900,
                E = 58901,
                F = 40958,
                G = 39255,
                H = 0,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Novospasskoe",
                Num = 21,
                Status = 81376,
                Link = 81376, //IsChanged = false,
                A = 81379,
                B = 81376,
                C = 81356,
                D = 81380,
                E = 81381,
                F = 81355,
                G = 0,
                H = 0,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Golodyaevskoe",
                Num = 1,
                Status = 73508,
                Link = 73508, //IsChanged = false,
                A = 0,
                B = 73508,
                C = 0,
                D = 0,
                E = 0,
                F = 0,
                G = 0,
                H = 0,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Golodyaevskoe",
                Num = 2,
                Status = 408689,
                Link = 408689, //IsChanged = false,
                A = 0,
                B = 408689,
                C = 0,
                D = 0,
                E = 0,
                F = 0,
                G = 0,
                H = 0,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Golodyaevskoe",
                Num = 3,
                Status = 74223,
                Link = 74223, //IsChanged = false,
                A = 0,
                B = 74223,
                C = 0,
                D = 0,
                E = 0,
                F = 0,
                G = 0,
                H = 0,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Golodyaevskoe",
                Num = 8,
                Status = 73576,
                Link = 73576, //IsChanged = false,
                A = 0,
                B = 73576,
                C = 0,
                D = 0,
                E = 0,
                F = 0,
                G = 0,
                H = 0,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Golodyaevskoe",
                Num = 10,
                Status = 83805,
                Link = 83805, //IsChanged = false,
                A = 83808,
                B = 83805,
                C = 83785,
                D = 83809,
                E = 83810,
                F = 83784,
                G = 0,
                H = 408340,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Golodyaevskoe",
                Num = 11,
                Status = 41583,
                Link = 41583, //IsChanged = false,
                A = 41586,
                B = 41583,
                C = 41560,
                D = 41895,
                E = 58896,
                F = 41559,
                G = 0,
                H = 413171,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Golodyaevskoe",
                Num = 12,
                Status = 82223,
                Link = 82223, //IsChanged = false,
                A = 82226,
                B = 82223,
                C = 82203,
                D = 82227,
                E = 82228,
                F = 82202,
                G = 82236,
                H = 82233,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Golodyaevskoe",
                Num = 13,
                Status = 411527,
                Link = 411527, //IsChanged = false,
                A = 411530,
                B = 411527,
                C = 411507,
                D = 411531,
                E = 411532,
                F = 411506,
                G = 413713,
                H = 0,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Golodyaevskoe",
                Num = 25,
                Status = 83490,
                Link = 83490, //IsChanged = false,
                A = 0,
                B = 83490,
                C = 0,
                D = 0,
                E = 0,
                F = 0,
                G = 0,
                H = 0,
                I = 0,
                K = 0,
            });
            _configs.Add(new ConfigLine
            {
                Name = "Golodyaevskoe",
                Num = 26,
                Status = 62502,
                Link = 62502, //IsChanged = false,
                A = 62505,
                B = 62502,
                C = 62482,
                D = 62506,
                E = 62507,
                F = 62481,
                G = 62896,
                H = 62877,
                I = 0,
                K = 0,
            });

            #endregion Тестовые первоначальные данные

            ListViewConfigs.ItemsSource = _configs;
        }

        #region Команды
        private MiniCommand addLineCommand = null;
        public MiniCommand AddLineCommand => addLineCommand ?? (addLineCommand = new MiniCommand(
            () =>
            {
                _configs?.Add(new ConfigLine
                {
                    Name = "Vvedite",
                    Num = 1,
                    Status = 0,
                    Link = 0,
                    A = 0,
                    B = 0,
                    C = 0,
                    D = 0,
                    E = 0,
                    F = 0,
                    G = 0,
                    H = 0,
                    I = 0,
                    K = 0,
                });
            }));
        private MiniCommand<ConfigLine> deleteLineCommand = null;
        public MiniCommand<ConfigLine> DeleteLineCommand => deleteLineCommand ?? (deleteLineCommand = new MiniCommand<ConfigLine>(
            (line) =>
            {
                _configs?.Remove(line);
            },
            (line) => line != null));
        private MiniCommand<ConfigLine> upLineCommand = null;
        public MiniCommand<ConfigLine> UpLineCommand => upLineCommand ?? (upLineCommand = new MiniCommand<ConfigLine>(
            (line) =>
            {
                int targetIndex = _configs.IndexOf(line);
                ConfigLine tmp = _configs[targetIndex];
                _configs[targetIndex] = _configs[targetIndex - 1];
                _configs[targetIndex - 1] = line;
                ListViewConfigs.SelectedIndex = targetIndex - 1;
            },
            (line) => line != null && _configs.IndexOf(line) >= 1));
        private MiniCommand<ConfigLine> downLineCommand = null;
        public MiniCommand<ConfigLine> DownLineCommand => downLineCommand ?? (upLineCommand = new MiniCommand<ConfigLine>(
            (line) =>
            {
                int targetIndex = _configs.IndexOf(line);
                ConfigLine tmp = _configs[targetIndex];
                _configs[targetIndex] = _configs[targetIndex + 1];
                _configs[targetIndex + 1] = line;
                ListViewConfigs.SelectedIndex = targetIndex + 1;
            },
            (line) => line != null && _configs.IndexOf(line) <= _configs.Count - 2));

        private MiniCommand getSqlCommand = null;
        public MiniCommand GetSqlCommand => getSqlCommand ?? (getSqlCommand = new MiniCommand(
            () =>
            {
                string sql = GenSQL.GetTopSql(_configs, "Novospasskoe");
                WindowSQL window = new WindowSQL();
                window.textSQL = sql;
                window.ShowDialog();
            }));
        private MiniCommand getTrendSqlCommand = null;
        public MiniCommand GetTrendSqlCommand => getTrendSqlCommand ?? (getTrendSqlCommand = new MiniCommand(
            () =>
            {
                string sql = GenSQL.GetTrendSql(_configs);
                WindowSQL window = new WindowSQL();
                window.textSQL = sql;
                window.ShowDialog();
            }));


        
        
        #endregion Команды

        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}