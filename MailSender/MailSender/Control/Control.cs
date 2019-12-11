using MailSenderLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Encryption;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;

namespace MailSender
{
    class Control
    {
        public static bool close = false;
        public static Dictionary<string, int> TabSwitcherDictionary { get; } = new Dictionary<string, int>();

        public static Dictionary<string, int> SmtpServerDictionary { get; } = new Dictionary<string, int>
        {
            { "smtp.yandex.ru", 25 },
            { "smtp.mail.ru", 25 },
            { "smtp.rambler.ru", 25 },
            { "smtp.gmail.com", 25 },
            { "smtp.qip.ru", 25 },
        };

        public static Dictionary<string, string> SendersDictionary { get; } = new Dictionary<string, string>
        {
            {"Arhiaovich@yandex.ru", Encryption.Cryption.Decrypt_ASE( "EAAAAGvyuJ4+EmzUU+WuIpQqFjeyCL2sX/xJFlCLMY6+Ep0E", EncrypterDll.Encrypter.Encrypt("1234"))},
        };

        static EmailSender EmailSender = new EmailSender();

        public static void Send(string user, string password) => EmailSender.Send(user, password);

        public static void TabDict(TabControl tab)
        {
            var pos = 0;
            foreach(TabItem e in tab.Items)
            {
                TabSwitcherDictionary.Add((string)e.Header, pos);
                pos++;
            }
        }


    }

    [ValueConversion(typeof(string), typeof(FlowDocument))]
    public class FlowDocumentConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var flowDocument = new FlowDocument();
            if (value != null)
            {
                var xamlText = (string)value;
                flowDocument = (FlowDocument)XamlReader.Parse(xamlText);
            }
            return flowDocument;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return string.Empty;
            var flowDocument = (FlowDocument)value;

            return XamlWriter.Save(flowDocument);
        }

        #endregion
    }
}
