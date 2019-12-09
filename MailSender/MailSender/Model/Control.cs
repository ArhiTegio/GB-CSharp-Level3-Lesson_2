using MailSenderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MailSender
{
    class Control
    {
        EmailSender EmailSender = new EmailSender();

        public void Send(string user, string password) => EmailSender.Send(user, password);
    }
}
