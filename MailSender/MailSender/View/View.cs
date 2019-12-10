using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Data;
using System.Globalization;

namespace MailSender
{
    public class View: PropertyChanged_
    {
        Control control = new Control();

        string subject = "";
        string body = "";

        public string Subject
        {
            get => subject;
            set
            {
                if (value != subject)
                {
                    subject = value;
                    PropertyChangedN("Subject");
                }
            }
        }

        public string Body
        {
            get => body;
            set
            {
                if (value != body)
                {
                    body = value;
                    PropertyChangedN("Body");
                }
            }
        }

        public override void DisposeInProcess()
        {
            subject = null;
            body = null;
        }
    }
}
