using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BigMacStock
{
    public partial class AddStockWindow : Window
    {
        public Stock StockItem { get; set; }

        public AddStockWindow(Stock stock = null)
        {
            InitializeComponent();
            if (stock != null)
            {
                StockItem = stock;
                txtItemName.Text = StockItem.ItemName;
                txtSupplierName.Text = StockItem.SupplierName;
                txtUnitCost.Text = StockItem.UnitCost.ToString("N2");
                txtNumberRequired.Text = StockItem.NumberRequired.ToString();
                txtCurrentStockLevel.Text = StockItem.CurrentStockLevel.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            // Validation can be added here
            if (StockItem == null)
            {
                StockItem = new Stock();
            }


            StockItem.ItemName = txtItemName.Text;
            StockItem.SupplierName = txtSupplierName.Text;
            StockItem.UnitCost = decimal.Parse(txtUnitCost.Text);
            StockItem.NumberRequired = int.Parse(txtNumberRequired.Text);
            StockItem.CurrentStockLevel = int.Parse(txtCurrentStockLevel.Text);

            // Save or update the StockItem in the database
            StockDataAccess dataAccess = new StockDataAccess();

            if (StockItem.StockCode > 0) 
            {
                // If StockCode exists, update the existing item
                dataAccess.UpdateStock(StockItem); 
            }
            else
            {
                // If no StockCode, insert a new item
                dataAccess.AddStock(StockItem);
            }

            // Close the window and return success
            this.DialogResult = true;
            this.Close();
        }
    }
}
