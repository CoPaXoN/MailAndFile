using System;
using System.Windows.Input;

namespace WPF.MVVM
{
    public abstract class Tab : Model, ITab
    {
        public Tab()
        {
            CloseCommand = new ActionCommand(p => CloseRequested?.Invoke(this, EventArgs.Empty));
        }
        private string _tabName;

        public string TabName
        {
            get { return _tabName; }
            set 
            {
                _tabName = value;
                OnProperyChanged("TabName");
            }
        }

        public ICommand CloseCommand { get; }
        public event EventHandler CloseRequested;
    }
}