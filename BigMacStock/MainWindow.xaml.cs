using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BigMacStock
{
    public partial class MainWindow : Window
    {
        private StockDataAccess stockDataAccess = new StockDataAccess();

        public MainWindow()
        {
            InitializeComponent();
            LoadStockData();
        }

        private void LoadStockData()
        {
            List<Stock> stocks = stockDataAccess.GetAllStockItems();
            stockDataGrid.ItemsSource = stocks;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Code to open a new window for adding stock
            AddStockWindow addStockWindow = new AddStockWindow();
            // Open the AddStockWindow, and check if the user saved the stock item
            if (addStockWindow.ShowDialog() == true)
            {
                stockDataAccess.AddStock(addStockWindow.StockItem);
                // Refresh the data in the DataGrid
                LoadStockData();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Code to edit the selected stock
            Stock selectedStock = (Stock)stockDataGrid.SelectedItem;
            if (selectedStock != null)
            {
                AddStockWindow editStockWindow = new AddStockWindow(selectedStock);
                if (editStockWindow.ShowDialog() == true)
                {
                    stockDataAccess.UpdateStock(editStockWindow.StockItem);
                    LoadStockData();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Code to delete the selected stock
            Stock selectedStock = (Stock)stockDataGrid.SelectedItem;
            if (selectedStock != null)
            {
                stockDataAccess.DeleteStock(selectedStock.StockCode);
                LoadStockData();
            }
        }
    }
}