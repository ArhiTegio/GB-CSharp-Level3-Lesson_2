using MailSenderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailSenderWF
{
    class Control
    {
        public void Send (string user, string password)
        {
            try { (new EmailSender()).Send(user, password); }
            catch (Exception exception) { MessageBox.Show(exception.Message, "При отправке сообщения возникла ошибка"); }
        }
    }
}
