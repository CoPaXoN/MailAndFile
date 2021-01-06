using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.WPF.Models;

namespace UI.WPF.ViewModels
{
    class ExcelTabViewModel
    {
        public ExcelTabModel fileTab;
        public ExcelTabViewModel()
        {
            fileTab = new ExcelTabModel();
        }
    }
}