using System.Windows;

namespace GrafanaConfig
{
    /// <summary>
    /// Логика взаимодействия для WindowSQL.xaml
    /// </summary>
    public partial class WindowSQL : Window
    {
        public string textSQL { get; set; }
        public WindowSQL()
        {
            InitializeComponent();
        }
        private void ButtonCopy_OnClick(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textSQL);
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void WindowSQL_OnLoaded(object sender, RoutedEventArgs e)
        {
            resultTextBox.Text = textSQL;
        }



    }
}
