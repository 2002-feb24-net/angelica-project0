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

CREATE TABLE [dbo].[Orders] 
(
    OrderID int NOT NULL PRIMARY KEY,
    CustomerID int NOT NULL ,
    StoreID int NOT NULL ,
    OrderTotal money,
    OrderTime datetime2,
    Product NVARCHAR(100),
    ProductQuantity int NOT NULL
);
GO
CREATE TABLE [dbo].[Store]
(
    StoreID int NOT NULL PRIMARY KEY,
    StoreName NVARCHAR(50),
    Street NVARCHAR(200),
    City NVARCHAR(150),
    State NVARCHAR(50),
    Zip int NOT NULL,
    
);
GO
CREATE TABLE [dbo].[Customer]
(
    CustomerID int NOT NULL PRIMARY KEY, 
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Username NVARCHAR(100)
);
GO
CREATE TABLE [dbo].[Product]
(
    ProductID int NOT NULL PRIMARY KEY,
    ProductName NVARCHAR(100),
    ProductPrice money
);
GO
CREATE TABLE [dbo].[Inventory]
(
    InventoryID int NOT NULL PRIMARY KEY,
    StoreID int NOT NULL,
    ProductID NVARCHAR(100),
    InventoryCount int NOT NULL
);
GO



