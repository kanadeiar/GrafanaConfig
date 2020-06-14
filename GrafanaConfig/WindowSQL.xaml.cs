using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
