/// <summary>
/// Grafana Config.
/// Конфигуратор SQL-скриптов программного пакета Графана.
/// Copyright © Рассахатский А.В. 2020.
/// </summary>

using GrafanaConfig.Commands;
using GrafanaConfig.Models;
using GrafanaConfig.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;

namespace GrafanaConfig
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary> Конфигурация </summary>
        private IList<ConfigLine> _configs = new ObservableCollection<ConfigLine>();
        /// <summary> Работа с xml файлами </summary>
        private XmlFileSaver<ObservableCollection<ConfigLine>> xmlFileSaver = new XmlFileSaver<ObservableCollection<ConfigLine>>();

        private string[] ConfigNames()
        {
            var sarr = _configs.GroupBy(g => g.Name).Select(s => s.Key).ToArray();
            return sarr;
        }

        public MainWindow()
        {
            InitializeComponent();

            #region Тестовые первоначальные данные при запуске приложения

            _configs.Add(new ConfigLine
            {
                Name = "Novospasskoe",
                Num = 1,
                Status = 10001,
                Link = 10002,
                A = 10003,
                B = 10004,
                C = 10005,
                D = 10006,
                E = 10007,
                F = 10008,
                G = 0,
                H = 0,
                I = 0,
                K = 0,
            });

            #endregion Тестовые первоначальные данные

            ListViewConfigs.ItemsSource = _configs;




        }

        #region Команды
        private MiniCommand newFileCommand = null;
        public MiniCommand NewFileCommand => newFileCommand ?? (newFileCommand = new MiniCommand(
            () =>
            {
                _configs.Clear();
                xmlFileSaver.FilePath = string.Empty;
                textFilePath.Text = string.Empty;
            }));
        private MiniCommand openFileCommand = null;
        public MiniCommand OpenFileCommand => openFileCommand ?? (openFileCommand = new MiniCommand(
            () =>
            {
                try
                {
                    var tmpConfigs = xmlFileSaver.OpenFromFile();
                    _configs.Clear();
                    foreach (var el in tmpConfigs)
                        _configs.Add(el);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка! Не удалось открыть файл!\n" + ex.Message);
                }
                textFilePath.Text = xmlFileSaver.FilePath;
            }));
        private MiniCommand saveFileCommand = null;
        public MiniCommand SaveFileCommand => saveFileCommand ?? (saveFileCommand = new MiniCommand(
            () =>
            {
                try
                {
                    xmlFileSaver.SaveToFile((ObservableCollection<ConfigLine>)_configs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка! Не удалось сохранить файл!\n" + ex.Message);
                }
                textFilePath.Text = xmlFileSaver.FilePath;
            }));
        private MiniCommand saveFileAsCommand = null;
        public MiniCommand SaveFileAsCommand => saveFileAsCommand ?? (saveFileAsCommand = new MiniCommand(
            () =>
            {
                try
                {
                    xmlFileSaver.SaveToFileAs((ObservableCollection<ConfigLine>)_configs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка! Не удалось сохранить файл!\n" + ex.Message);
                }
                textFilePath.Text = xmlFileSaver.FilePath;
            }));

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
                ListViewConfigs.SelectedIndex = _configs.Count - 1;
            }));
        private MiniCommand<ConfigLine> deleteLineCommand = null;
        public MiniCommand<ConfigLine> DeleteLineCommand => deleteLineCommand ?? (deleteLineCommand = new MiniCommand<ConfigLine>(
            (line) =>
            {
                int pos = _configs.IndexOf(line);
                _configs?.Remove(line);
                ListViewConfigs.SelectedIndex = (pos < _configs.Count) ? pos : _configs.Count - 1;
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
        public MiniCommand<ConfigLine> DownLineCommand => downLineCommand ?? (downLineCommand = new MiniCommand<ConfigLine>(
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
                string name = ComboBoxNames.Text;
                string sql = GenSQL.GetTopSql(_configs, name);
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
        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }
    }
}