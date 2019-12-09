using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MailSender
{
    public class View: PropertyChanged_
    {

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
