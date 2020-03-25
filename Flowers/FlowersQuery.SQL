CREATE TABLE [dbo].[Product]
(
    [ProductID] int NOT NULL,
    [ProductName] NVARCHAR(100) NOT NULL PRIMARY KEY,
    [ProductPrice] money NOT NULL
);

CREATE TABLE [dbo].[Customer]
(
    [Username] NVARCHAR(100) NOT NULL PRIMARY KEY,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
);

CREATE TABLE [dbo].[Store]
(
    [StoreName] NVARCHAR(50) NOT NULL,
    [Address] NVARCHAR(200),
    [City] NVARCHAR(150),
    [State] NVARCHAR(50) PRIMARY KEY,
    [PostalCode] int NOT NULL,
);

CREATE TABLE [dbo].[Sale] 
(
    [SaleID] int NOT NULL PRIMARY KEY,
    [CustomerID] int NOT NULL FOREIGN KEY REFERENCES [dbo].[Customer],
    [SaleDate] datetime2 NOT NULL,
    [StoreID] int NOT NULL FOREIGN KEY REFERENCES [dbo].[Store],
    [OrderTotal] money NOT NULL
);

CREATE TABLE [dbo].[Inventory]
(
    InventoryID int NOT NULL PRIMARY KEY,
    StoreID int NOT NULL FOREIGN KEY REFERENCES [dbo].[Store],
    ProductID int NOT NULL FOREIGN KEY REFERENCES [dbo].[Product],
    InventoryCount int NOT NULL
);
