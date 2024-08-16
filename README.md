# BigMacStock

## SQL COMMANDS USED
1. Create table 
```sql
CREATE DATABASE BigMacStock;

2. Create the table with StockCode as primary key ( auto-increment field)
```sql
CREATE TABLE Stock (
    StockCode INT IDENTITY(1001,1) PRIMARY KEY, -- Starts from 1001, increments by 1
    ItemName NVARCHAR(50),
    SupplierName NVARCHAR(50),
    UnitCost DECIMAL(10, 2),
    NumberRequired INT,
    CurrentStockLevel INT
);

3.Insert sample data (StockCode primary key - not added)
```sql
INSERT INTO Stock (ItemName, SupplierName, UnitCost, NumberRequired, CurrentStockLevel)
VALUES 
('Pen', 'Staples', 2.00, 10, 5),
('Binder', 'Walmart', 5.00, 20, 2),
('Notepad', 'Staples', 1.00, 50, 10),
('Pencil', 'Walmart', 0.50, 20, 5),
('Bookmark', 'Staples', 1.00, 15, 10);

4. Add one more data
```sql
INSERT INTO Stock (ItemName, SupplierName, UnitCost, NumberRequired, CurrentStockLevel)
VALUES ('Notebook', 'ClassMate', 3.50, 15, 0);

5. Update the stock table
```sql
UPDATE Stock
SET 
    ItemName = 'Notebook',
    SupplierName = 'ClassMate',
    UnitCost = 3.50,
    NumberRequired = 15,
    CurrentStockLevel = 5
WHERE StockCode = 1006;
