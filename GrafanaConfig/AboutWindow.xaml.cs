using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textName.Text = "Grafana Config";
            textVersion.Text = $"Версия: {Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
            textCopyright.Text = "Copyright © Рассахатский А.В. 2020";
            textDescription.Text = @"Эта программа является свободным программным обеспечением. Вы можете
распространять и/или модифицировать её согласно условиям Стандартной
Общественной Лицензии GNU, опубликованной Фондом Свободного Программного
Обеспечения, версии 3 или, по Вашему желанию, любой более поздней версии.
Эта программа распространяется в надежде, что она будет полезной, но БЕЗ
ВСЯКИХ ГАРАНТИЙ, в том числе подразумеваемых гарантий ТОВАРНОГО СОСТОЯНИЯ ПРИ
ПРОДАЖЕ и ГОДНОСТИ ДЛЯ ОПРЕДЕЛЁННОГО ПРИМЕНЕНИЯ. Смотрите Стандартную
Общественную Лицензию GNU для получения дополнительной информации.
Вы должны были получить копию Стандартной Общественной Лицензии GNU вместе
с программой. В случае её отсутствия, посмотрите http://www.gnu.org/licenses/.";
            


        }
    }
}
