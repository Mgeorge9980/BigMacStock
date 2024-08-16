using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;


namespace BigMacStock
{
    public class StockDataAccess
    {
        private string connectionString = "Server=MERLIN\\SQLEXPRESS19;Database=BigMacStock;User Id=sa;Password=Conestoga1;TrustServerCertificate=True;";

        // Method to fetch all stock items from the database
        public List<Stock> GetAllStockItems()
        {
            List<Stock> stocks = new List<Stock>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Stock", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Stock stock = new Stock()
                    {
                        StockCode = Convert.ToInt32(reader["StockCode"]),
                        ItemName = reader["ItemName"].ToString(),
                        SupplierName = reader["SupplierName"].ToString(),
                        UnitCost = Convert.ToDecimal(reader["UnitCost"]),
                        NumberRequired = Convert.ToInt32(reader["NumberRequired"]),
                        CurrentStockLevel = Convert.ToInt32(reader["CurrentStockLevel"])
                    };
                    stocks.Add(stock);
                }
            }
            return stocks;
        }

        // Method to add new stock item
        public void AddStock(Stock stock)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Stock (ItemName, SupplierName, UnitCost, NumberRequired, CurrentStockLevel) VALUES (@ItemName, @SupplierName, @UnitCost, @NumberRequired, @CurrentStockLevel)", conn);
                cmd.Parameters.AddWithValue("@ItemName", stock.ItemName);
                cmd.Parameters.AddWithValue("@SupplierName", stock.SupplierName);
                cmd.Parameters.AddWithValue("@UnitCost", stock.UnitCost);
                cmd.Parameters.AddWithValue("@NumberRequired", stock.NumberRequired);
                cmd.Parameters.AddWithValue("@CurrentStockLevel", stock.CurrentStockLevel);
                cmd.ExecuteNonQuery();
            }
        }

        // Method to update stock item
        public void UpdateStock(Stock stock)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Stock SET ItemName = @ItemName, SupplierName = @SupplierName, UnitCost = @UnitCost, NumberRequired = @NumberRequired, CurrentStockLevel = @CurrentStockLevel WHERE StockCode = @StockCode", conn);
                cmd.Parameters.AddWithValue("@StockCode", stock.StockCode);
                cmd.Parameters.AddWithValue("@ItemName", stock.ItemName);
                cmd.Parameters.AddWithValue("@SupplierName", stock.SupplierName);
                cmd.Parameters.AddWithValue("@UnitCost", stock.UnitCost);
                cmd.Parameters.AddWithValue("@NumberRequired", stock.NumberRequired);
                cmd.Parameters.AddWithValue("@CurrentStockLevel", stock.CurrentStockLevel);
                cmd.ExecuteNonQuery();
            }
        }

        // Method to delete stock item
        public void DeleteStock(int stockCode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Stock WHERE StockCode = @StockCode", conn);
                cmd.Parameters.AddWithValue("@StockCode", stockCode);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
