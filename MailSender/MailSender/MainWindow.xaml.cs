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

namespace MailSender
{
    partial class MainWindow : Window, INotifyPropertyChanged
    {
        Control control = new Control();
        View view = new View();

        public string Subject
        {
            get => view.Subject;
            set 
            {
                if (value != view.Subject)
                {
                    view.Subject = value;
                    PropertyChangedN("Subject");
                }
            }
        }

        public string Body
        {
            get => view.Body;
            set 
            {
                if (value != view.Body)
                {
                    view.Body = value;
                    PropertyChangedN("Body");
                }
            }
        }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (!Model.close)
            {
                (new MassageExit(this)).Show();
                e.Cancel = true;
            }
        }

        void Button_Click(object sender, RoutedEventArgs e) => control.Send(UserNameTextBox.Text, PasswordEdit.Password);


        public event PropertyChangedEventHandler PropertyChanged;

        public void PropertyChangedN(string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}