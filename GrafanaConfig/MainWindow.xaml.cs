using System.Windows;

namespace GrafanaConfig
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }




        private void MenuItemExit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}