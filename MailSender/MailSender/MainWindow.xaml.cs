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
        public MainWindow()
        {
            InitializeComponent();
            if (Control.TabSwitcherDictionary.Count == 0)
                control.TabDict(MainTabControl);
        }

        private void OnWindowClosing(object sender, CancelEventArgs e) { if (!Model.close) { (new MassageExit(this)).Show(); e.Cancel = true; } }
        
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
                MessageBox.Show("Письмо не заполнено");
                MainTabControl.SelectedIndex = Control.TabSwitcherDictionary["Редактор сообщений"];
            }
            else
            {
                if (string.IsNullOrEmpty(item.Key)) MessageBox.Show("Выберите отправителя");
                else if (string.IsNullOrEmpty(item.Value)) MessageBox.Show("Укажите пароль отправителя");
                else control.Send(item.Key, item.Value);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void PropertyChangedN(string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void OnWindowClosing(object sender, RoutedEventArgs e) => Close();
    }
}