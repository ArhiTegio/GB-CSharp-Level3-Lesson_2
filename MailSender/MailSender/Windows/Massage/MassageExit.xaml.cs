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

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MassageExit.xaml
    /// </summary>
    public partial class MassageExit : Window
    {
        MainWindow main = new MainWindow();

        public MassageExit(MainWindow m)
        {
            InitializeComponent();
            main = m;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Control.close = true;
            main.Close();
            Close();
            Application.Current.Shutdown();
        }

        private void Wait(object sender, RoutedEventArgs e)
        {
            Control.close = false;
            Close();
        }
    }
}
