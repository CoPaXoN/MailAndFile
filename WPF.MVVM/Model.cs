using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.MVVM
{
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnProperyChanged(string property)
        {
            PropertyChangedEventHandler propertyChangedEventHandler = PropertyChanged;
            if (propertyChangedEventHandler != null)
                propertyChangedEventHandler(this, new PropertyChangedEventArgs(property));
        }

    }
}
