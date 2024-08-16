using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMacStock
{
    public class Stock
    {
        public int StockCode { get; set; }
        public string ItemName { get; set; }
        public string SupplierName { get; set; }
        public decimal UnitCost { get; set; }
        public int NumberRequired { get; set; }
        public int CurrentStockLevel { get; set; }

        // Constructor
        public Stock() { }

        public Stock(string itemName, string supplierName, decimal unitCost, int numberRequired, int currentStockLevel)
        {
            ItemName = itemName;
            SupplierName = supplierName;
            UnitCost = unitCost;
            NumberRequired = numberRequired;
            CurrentStockLevel = currentStockLevel;
        }
    }
}
