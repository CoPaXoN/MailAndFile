using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI.WPF.Models;
using WPF.MVVM;

namespace UI.WPF.ViewModels
{
    class MailTabViewModel 
    {
        private ICommand _sendCommand;

        public ICommand SendCommand
        {
            get { return _sendCommand; }
            set { _sendCommand = value; }
        }

        private MailTabModel _mail;

        public MailTabModel Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public MailTabViewModel()
        {
            Mail = (MailTabModel)MainWindowViewModel.Tabs[MainWindowViewModel.Tabs.Count-1];
            SendCommand = new ActionCommand(p => Send());
        }

        public void Send()
        {
            try
            {
                MessageBox.Show($"Mail Sent Succefully! {Mail.Addressee} {Mail.Subject} {Mail.Content}");
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong...");
            }
        }
    }
}
