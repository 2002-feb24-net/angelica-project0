CREATE TABLE [dbo].[Customer]
(
    [CustomerId] int IDENTITY NOT NULL PRIMARY KEY,
    [Username] NVARCHAR(100) NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
);
GO
CREATE TABLE [dbo].[Store]
(
    [StoreID] INT IDENTITY NOT NULL PRIMARY KEY,
    [StoreName] NVARCHAR(100),
    [Address] NVARCHAR(200),
    [City] NVARCHAR(150),
    [State] NVARCHAR(50),
    [PostalCode] int NOT NULL,
);
GO
CREATE TABLE [dbo].[Product]
(
    [ProductID] int IDENTITY NOT NULL PRIMARY KEY,
    [ProductName] NVARCHAR(100) NOT NULL,
    [ProductPrice] money NOT NULL
);
GO
CREATE TABLE [dbo].[Inventory]
(
    [InventoryID] int IDENTITY NOT NULL PRIMARY KEY,
    [StoreID] int NOT NULL FOREIGN KEY REFERENCES [dbo].[Store],
    [ProductID] int NOT NULL FOREIGN KEY REFERENCES [dbo].[Product],
    [InventoryCount] int NOT NULL
);
GO
CREATE TABLE [dbo].[Order] 
(
    [SaleID] int IDENTITY NOT NULL PRIMARY KEY,
    [CustomerID] int NOT NULL FOREIGN KEY REFERENCES [dbo].[Customer],
    [SaleDate] datetime2 NOT NULL,
    [StoreID] int NOT NULL FOREIGN KEY REFERENCES [dbo].[Store],
    [OrderTotal] money NOT NULL
);
GO






INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice]) VALUES ('Rose', 4.99);
INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice]) VALUES ('Daisy', 1.99);
INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice]) VALUES ('Sunflower', 3.99);
INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice]) VALUES ('Daffodil', 0.99);
INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice]) VALUES ('Tulip', 2.99 );
INSERT INTO [dbo].[Product] ([ProductName],[ProductPrice]) VALUES ('Lily', 3.99);

INSERT INTO [dbo].[Customer] ([FirstName],[LastName],[Username]) VALUES ('Angelica', 'Velez', 'anvelez');
INSERT INTO [dbo].[Customer] ([FirstName],[LastName],[Username]) VALUES ('Nick', 'Escalona', 'nescalona');
INSERT INTO [dbo].[Customer] ([FirstName],[LastName],[Username]) VALUES ('Mark', 'Moore', 'mmoore');

INSERT INTO [dbo].[Store] ([StoreName], [Address], [City], [State], [PostalCode]) VALUES ('Flower Shop', '749 S Cooper St', 'Arlington','Texas','76010');
INSERT INTO [dbo].[Store] ([StoreName], [Address], [City], [State], [PostalCode]) VALUES ('Flower Shop', '51 Franklin St', 'Franklin Square','New York', '11010'); 

INSERT INTO [dbo].[Order] ([CustomerID], [SaleDate], [StoreID], [OrderTotal]) VALUES (1, '2020-3-23', 1, 4.99);
INSERT INTO [dbo].[Order] ([CustomerID], [SaleDate], [StoreID], [OrderTotal]) VALUES (2, '2020-3-21', 2, 3.99);
INSERT INTO [dbo].[Order] ([CustomerID], [SaleDate], [StoreID], [OrderTotal]) VALUES (3, '2020-3-22', 1, 0.99);

INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (1, 1, 100);
INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (1, 2, 200);
INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (1, 3, 150);
INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (1, 4, 500);
INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (1, 5, 250);
INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (1, 6, 200);
INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (2, 1, 75);
INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (2, 2, 250);
INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (2, 3, 200);
INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (2, 4, 600);
INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (2, 5, 200);
INSERT INTO [dbo].[Inventory] ([StoreID], [ProductID], [InventoryCount]) VALUES (2, 6, 250);