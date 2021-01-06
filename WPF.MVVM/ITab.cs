using System;
using System.Windows.Input;

namespace WPF.MVVM
{
    public interface ITab
    {
        string TabName { get; set; }
        ICommand CloseCommand { get; }
        event EventHandler CloseRequested;
    }
}