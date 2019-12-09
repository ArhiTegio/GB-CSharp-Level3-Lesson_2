using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib
{
    public static class GlobalValue
    {
        private static string mailFromSent = "Arhiaovich@yandex.ru";
        private static string mailToSent = "arhio@yandex.ru";
        private static string massageSubject = "Test message";
        private static string massageBody = "Test message body";
        private static string server = "smtp.yandex.ru";
        private static int port = 25;

        public static string MailFromSent { get => mailFromSent; set => mailFromSent = value; }
        public static string MailToSent { get => mailToSent; set => mailToSent = value; }
        public static string Server { get => server; set => server = value; }
        public static string MassageSubject { get => massageSubject; set => massageSubject = value; }
        public static string MassageBody { get => massageBody; set => massageBody = value; }
        public static int Port { get => port; set => port = value; }
    }
}
