using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MVVM;
using ExcelClassLibrary;
using UI.WPF.ViewModels;

namespace UI.WPF.Models
{
    public class ExcelTabModel : Tab
    {
        
        private ExcelFile _excel;

        public ExcelFile Excel
        {
            get { return _excel; }
            set 
            { 
                _excel = value;
                OnProperyChanged("Excel");  
            }
        }

        private List<ExcelDataRow> _fileDataModels;

        public List<ExcelDataRow> FileDataModels
        {
            get { return _fileDataModels; }
            set 
            { 
                _fileDataModels = value;
                OnProperyChanged("FileDataModels");
            }
        }
        /// <summary>
        /// Fills the file data list and sets the tab name to the path.
        /// </summary>
        /// <param name="path">the path of the file </param>
        
        public static string path="";
        private static int num = 0;
        public ExcelTabModel()
        {
            this.FileDataModels = new List<ExcelDataRow>();
            Excel = new ExcelFile(ExcelTabModel.path);
            this.TabName = ExcelTabModel.path + num++.ToString();
            ExcelFile excel = Excel;

            int lastRow = ExcelUtil.GetLastRow(excel.worksheet);

            for (int i = 2; i < lastRow; i++)
            {
                FileDataModels.Add(new ExcelDataRow
                {
                    ItemName = ExcelUtil.GetStringValue(excel.range, i, 1),
                    Price = ExcelUtil.GetStringValue(excel.range, i, 2),
                    Stock = ExcelUtil.GetStringValue(excel.range, i, 3),
                });
            }
        }
    }
}
