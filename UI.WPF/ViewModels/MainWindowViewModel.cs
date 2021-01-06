  using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WPF.MVVM;
using System.Collections.Specialized;
using UI.WPF.Models;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UI.WPF.ViewModels
{
    class MainWindowViewModel
    {
        public ICommand NewMailTabCommand { get; }

        public ICommand NewFileTabCommand { get; }

        public static ObservableCollection<ITab> Tabs { get; set; }
        public MainWindowViewModel()
        {
            NewMailTabCommand = new ActionCommand(p => NewMailTab());
            NewFileTabCommand = new ActionCommand(p => NewFileTab());

            Tabs = new ObservableCollection<ITab>();
            Tabs.CollectionChanged += Tabs_CollectionChanged;
            
        }

        private void NewMailTab()
        {
            Tabs.Add(new MailTabModel());
        }

        private async void NewFileTab()
        {
            Task<string> getFilePath = new Task<string>(GetFilePath);
            getFilePath.Start();
            ExcelTabModel.path = await getFilePath;

            Tabs.Add(new ExcelTabModel());
        }
        private void Tabs_CollectionChanged(object sender,  NotifyCollectionChangedEventArgs e)
        {
            ITab tab;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (ITab)e.NewItems[0];
                    tab.CloseRequested += onTabCloseRequested;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    tab = (ITab)e.OldItems[0];
                    tab.CloseRequested += onTabCloseRequested;
                    break;
            }
        }

        private void onTabCloseRequested(object sender, EventArgs e)
        {
            Tabs.Remove((ITab)sender);
        }

        public string GetFilePath()
        {
            //open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XLSX Files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return "";
        }
    }
}
