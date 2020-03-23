/****************
Arrangements by Ange Database - Version 1
Script: ArrangementsAnge.sql
Description: Creates and populates the ArrangementsAnge database
DB Server: SqlServer
Author: Angelica Velez
******************/

/*****************
Create Tables
*****************/

CREATE TABLE [dbo].[Product]
(
    [ProductID] int NOT NULL PRIMARY KEY,
    [ProductName] NVARCHAR(100) NOT NULL,
    [ProductPrice] money NOT NULL
);
GO
CREATE TABLE [dbo].[Customer]
(
    [CustomerID] int NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Username] NVARCHAR(100) NOT NULL
);
GO
CREATE TABLE [dbo].[Store]
(
    [StoreID] int NOT NULL PRIMARY KEY,
    [StoreName] NVARCHAR(50),
    [Address] NVARCHAR(200),
    [City] NVARCHAR(150),
    [State] NVARCHAR(50),
    [PostalCode] int NOT NULL,
);
GO
CREATE TABLE [dbo].[Sale] 
(
    [SaleID] int NOT NULL PRIMARY KEY,
    [CustomerID] int NOT NULL FOREIGN KEY REFERENCES [dbo].[Customer],
    [SaleDate] datetime2 NOT NULL,
    [StoreID] int NOT NULL FOREIGN KEY REFERENCES [dbo].[Store],
    [OrderTotal] money NOT NULL
);
GO
CREATE TABLE [dbo].[SaleLine]
(
    [SaleLineID] int NOT NULL PRIMARY KEY,
    [SaleID] int NOT NULL FOREIGN KEY REFERENCES [dbo].[Sale],
    [ProductID] int NOT NULL FOREIGN KEY REFERENCES [dbo].[Product],
    [ProductPrice] money NOT NULL,
    [ProductQuantity] int NOT NULL
);
GO
CREATE TABLE [dbo].[Inventory]
(
    InventoryID int NOT NULL PRIMARY KEY,
    StoreID int NOT NULL FOREIGN KEY REFERENCES [dbo].[Store],
    ProductID int NOT NULL FOREIGN KEY REFERENCES [dbo].[Product],
    InventoryCount int NOT NULL
);
GO

/***************
Populate tables
***************/
INSERT INTO [dbo].[Product] ([ProductID],[ProductName],[ProductPrice]) VALUES (1, 'Rose', 4.99);
INSERT INTO [dbo].[Product] ([ProductID],[ProductName],[ProductPrice]) VALUES (2, 'Daisy', 1.99);
INSERT INTO [dbo].[Product] ([ProductID],[ProductName],[ProductPrice]) VALUES (3, 'Sunflower', 3.99);
INSERT INTO [dbo].[Product] ([ProductID],[ProductName],[ProductPrice]) VALUES (4, 'Daffodil', 0.99);
INSERT INTO [dbo].[Product] ([ProductID],[ProductName],[ProductPrice]) VALUES (5, 'Tulip', 2.99 );
INSERT INTO [dbo].[Product] ([ProductID],[ProductName],[ProductPrice]) VALUES (6, 'Lily', 3.99);

INSERT INTO [dbo].[Customer] ([CustomerID],[FirstName],[LastName],[Username]) VALUES (1, 'Angelica', 'Velez', 'anvelez');
INSERT INTO [dbo].[Customer] ([CustomerID],[FirstName],[LastName],[Username]) VALUES (2, 'Nick', 'Escalona', 'nescalona');
INSERT INTO [dbo].[Customer] ([CustomerID],[FirstName],[LastName],[Username]) VALUES (3, 'Mark', 'Moore', 'mmoore');

INSERT INTO [dbo].[Store] ([StoreID], [StoreName], [Address], [City], [State], [PostalCode]) VALUES (1, 'Arrangements by Ange', '749 S Cooper St', 'Arlington','Texas','76010');
INSERT INTO [dbo].[Store] ([StoreID], [StoreName], [Address], [City], [State], [PostalCode]) VALUES (2, 'Arrangements by Ange', '51 Franklin St', 'Franklin Square','New York', '11010'); 

INSERT INTO [dbo].[Sale] ([SaleID], [CustomerID], [SaleDate], [StoreID], [OrderTotal]) VALUES (1, 1, '2020/23/03', 1, 4.99);
INSERT INTO [dbo].[Sale] ([SaleID], [CustomerID], [SaleDate], [StoreID], [OrderTotal]) VALUES (2, 2, '2020/21/03', 2, 3.99);
INSERT INTO [dbo].[Sale] ([SaleID], [CustomerID], [SaleDate], [StoreID], [OrderTotal]) VALUES (3, 3, '2020/22/03', 1, 0.99);
 
INSERT INTO [dbo].[SaleLine] ([SaleLineID], [SaleID], [ProductID], [ProductPrice], [ProductQuantity]) VALUES (1, 1, 1, 4.99, 1);
INSERT INTO [dbo].[SaleLine] ([SaleLineID], [SaleID], [ProductID], [ProductPrice], [ProductQuantity]) VALUES (2, 2, 3, 3.99, 1);
INSERT INTO [dbo].[SaleLine] ([SaleLineID], [SaleID], [ProductID], [ProductPrice], [ProductQuantity]) VALUES (3, 3, 4, 0.99, 1);

INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (1, 1, 1, 100);
INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (2, 1, 2, 200);
INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (3, 1, 3, 150);
INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (4, 1, 4, 500);
INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (5, 1, 5, 250);
INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (6, 1, 6, 200);
INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (7, 2, 1, 75);
INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (8, 2, 2, 250);
INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (9, 2, 3, 200);
INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (10, 2, 4, 600);
INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (11, 2, 5, 200);
INSERT INTO [dbo].[Inventory] ([InventoryID], [StoreID], [ProductID], [InventoryCount]) VALUES (12, 2, 6, 250);

