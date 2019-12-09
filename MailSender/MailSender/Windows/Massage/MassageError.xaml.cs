using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Runtime.CompilerServices;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MassageError.xaml
    /// </summary>
    public partial class MessageError : Window, INotifyPropertyChanged
    {
        private string message = "";
        public string Message 
        {
            get { return message; }
            set 
            {
                message = value;
                NotifyPropertyChanged("Message");
            }
        }
        public MessageError(string message)
        {
            DataContext = this;
            InitializeComponent();
            Message = message;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void Exit(object sender, RoutedEventArgs e) => Close();        
    }
}
