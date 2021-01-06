using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.WPF.Models
{
    /// <summary>
    /// Represents one row in the Excel file that suppose to be loaded.
    /// </summary>
    public class ExcelDataRow
    {
        private string _itemName;

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _stock;

        public string Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
    }
}
