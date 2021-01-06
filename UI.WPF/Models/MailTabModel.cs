using System;
using System.Collections.Generic;
using System.Text;
using WPF.MVVM;

namespace UI.WPF.Models
{
    public class MailTabModel : Tab
    {

        private string _addressee;

        public string Addressee
        {
            get { return _addressee; }
            set 
            { 
                _addressee = value;
                OnProperyChanged("Addressee");  
            }
        }

        private string _subject;

        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                TabName = value;
                OnProperyChanged("Subject");
            }
        }

        private string _content;

        public string Content
        {
            get { return _content; }
            set 
            { 
                _content = value;
                OnProperyChanged("Content");
            }
        }
        private static int num = 0;
        public MailTabModel()
        {
            num++;
            this.TabName = $"Mail{num}";
        }
    }
}
