using System;
using System.Windows;
using System.Windows.Controls;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MessageSendCompletedDlg.xaml
    /// </summary>
    public partial class MessageSendCompletedDlg : Window
    {
		
        public MessageSendCompletedDlg(string mess)
        {
            InitializeComponent();
	        MainLabel.Content = mess;
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (((Button) sender).Content.ToString() == "Ok")
                DialogResult = true;

            Close();
        }
    }
}
