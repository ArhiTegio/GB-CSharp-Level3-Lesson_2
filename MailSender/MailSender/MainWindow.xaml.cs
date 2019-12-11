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
        public MainWindow()
        {
            InitializeComponent();
            if (Control.TabSwitcherDictionary.Count == 0)
                Control.TabDict(MainTabControl);
        }

        private void OnWindowClosing(object sender, CancelEventArgs e) { if (!Control.close) { (new MassageExit(this)).Show(); e.Cancel = true; } }
        
        private void TabSwitcherControl_OnBack(object sender, RoutedEventArgs e)
        {
            if (MainTabControl.SelectedIndex == 0) return;
            MainTabControl.SelectedIndex--;
        }

        private void TabSwitcherControl_OnScheduler(object sender, RoutedEventArgs e) => MainTabControl.SelectedIndex = Control.TabSwitcherDictionary["Планировщик"];
        
        private void TabSwitcherControl_OnForward(object sender, RoutedEventArgs e)
        {
            if (MainTabControl.SelectedIndex == MainTabControl.Items.Count - 1) return;
            MainTabControl.SelectedIndex++;
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            KeyValuePair<string, string> item = (KeyValuePair<string, string>)cbSenderSelect.SelectionBoxItem;

            if (EditBox.Text == "")
            {
                (new MessageError("Письмо не заполнено")).Show();
                MainTabControl.SelectedIndex = Control.TabSwitcherDictionary["Редактор сообщений"];
            }
            else
            {
                if (string.IsNullOrEmpty(item.Key)) (new MessageError("Выберите отправителя")).Show();
                else if (string.IsNullOrEmpty(item.Value)) (new MessageError("Укажите пароль отправителя")).Show();
                else Control.Send(item.Key, item.Value);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void PropertyChangedN(string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void OnWindowClosing(object sender, RoutedEventArgs e) => Close();
    }
}