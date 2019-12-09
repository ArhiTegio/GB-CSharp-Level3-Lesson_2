using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MailSender
{
    public abstract class PropertyChanged_: INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void PropertyChangedN(string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
        public void Dispose() => DisposeInProcess();

        public abstract void DisposeInProcess();
    }
}
