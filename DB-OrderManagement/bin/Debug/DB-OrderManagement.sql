﻿/*
Deployment script for DB-OrderManagement

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB-OrderManagement"
:setvar DefaultFilePrefix "DB-OrderManagement"
:setvar DefaultDataPath "C:\Users\SOHY\AppData\Local\Microsoft\VisualStudio\SSDT\SalesSolution\"
:setvar DefaultLogPath "C:\Users\SOHY\AppData\Local\Microsoft\VisualStudio\SSDT\SalesSolution\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating [dbo].[Customer]...';


GO
CREATE TABLE [dbo].[Customer] (
    [CustomerID] INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [LastName]   NVARCHAR (50) NOT NULL,
    [Address]    NVARCHAR (50) NULL,
    [Phone]      VARCHAR (50)  NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);


GO
PRINT N'Creating [dbo].[Order]...';


GO
CREATE TABLE [dbo].[Order] (
    [OrderID]         INT      IDENTITY (1, 1) NOT NULL,
    [OrderDate]       DATETIME NOT NULL,
    [Status]          INT      NOT NULL,
    [OnlineOrderFlag] BIT      NOT NULL,
    [SubTotal]        MONEY    NOT NULL,
    [TaxAmt]          MONEY    NULL,
    [OrderTotal]      MONEY    NOT NULL,
    [CustomerID]      INT      NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderID] ASC)
);


GO
PRINT N'Creating [dbo].[OrderItem]...';


GO
CREATE TABLE [dbo].[OrderItem] (
    [OrderItemID]       INT   IDENTITY (1, 1) NOT NULL,
    [ProductID]         INT   NOT NULL,
    [OrderID]           INT   NOT NULL,
    [OrderQty]          INT   NOT NULL,
    [UnitPrice]         MONEY NOT NULL,
    [UnitPriceDiscount] MONEY NULL,
    [LineTotal]         MONEY NOT NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED ([OrderItemID] ASC)
);


GO
PRINT N'Creating [dbo].[Product]...';


GO
CREATE TABLE [dbo].[Product] (
    [ProductID]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [Code]          VARCHAR (50)  NOT NULL,
    [StandardPrice] MONEY         NOT NULL,
    [Comment]       TEXT          NULL,
    [OnlineFlag]    BIT           NOT NULL,
    [ColorID]       INT           NULL,
    [SizeID]        INT           NULL,
    [ProductTypeID] INT           NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductID] ASC)
);


GO
PRINT N'Creating [dbo].[ProductColor]...';


GO
CREATE TABLE [dbo].[ProductColor] (
    [ColorID] INT           IDENTITY (1, 1) NOT NULL,
    [Color]   NVARCHAR (50) NOT NULL,
    [Comment] TEXT          NULL,
    CONSTRAINT [PK_ProductColor] PRIMARY KEY CLUSTERED ([ColorID] ASC)
);


GO
PRINT N'Creating [dbo].[ProductSize]...';


GO
CREATE TABLE [dbo].[ProductSize] (
    [SizeID]  INT           IDENTITY (1, 1) NOT NULL,
    [Size]    NVARCHAR (50) NOT NULL,
    [Comment] TEXT          NULL,
    CONSTRAINT [PK_ProductSize] PRIMARY KEY CLUSTERED ([SizeID] ASC)
);


GO
PRINT N'Creating [dbo].[ProductType]...';


GO
CREATE TABLE [dbo].[ProductType] (
    [ProductTypeID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [Code]          VARCHAR (50)  NULL,
    [Comment]       TEXT          NULL,
    CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED ([ProductTypeID] ASC)
);


GO
PRINT N'Creating DF_Order_OnlineOrderFlag...';


GO
ALTER TABLE [dbo].[Order]
    ADD CONSTRAINT [DF_Order_OnlineOrderFlag] DEFAULT ((0)) FOR [OnlineOrderFlag];


GO
PRINT N'Creating DF_OrderItem_OrderQty...';


GO
ALTER TABLE [dbo].[OrderItem]
    ADD CONSTRAINT [DF_OrderItem_OrderQty] DEFAULT ((1)) FOR [OrderQty];


GO
PRINT N'Creating DF_OrderItem_UnitPriceDiscount...';


GO
ALTER TABLE [dbo].[OrderItem]
    ADD CONSTRAINT [DF_OrderItem_UnitPriceDiscount] DEFAULT ((0)) FOR [UnitPriceDiscount];


GO
PRINT N'Creating DF_Product_OnlineFlag...';


GO
ALTER TABLE [dbo].[Product]
    ADD CONSTRAINT [DF_Product_OnlineFlag] DEFAULT ((0)) FOR [OnlineFlag];


GO
PRINT N'Creating FK_Order_Customer...';


GO
ALTER TABLE [dbo].[Order] WITH NOCHECK
    ADD CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID]);


GO
PRINT N'Creating FK_OrderItem_Order...';


GO
ALTER TABLE [dbo].[OrderItem] WITH NOCHECK
    ADD CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([OrderID]);


GO
PRINT N'Creating FK_OrderItem_Product...';


GO
ALTER TABLE [dbo].[OrderItem] WITH NOCHECK
    ADD CONSTRAINT [FK_OrderItem_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID]);


GO
PRINT N'Creating FK_Product_ProductColor...';


GO
ALTER TABLE [dbo].[Product] WITH NOCHECK
    ADD CONSTRAINT [FK_Product_ProductColor] FOREIGN KEY ([ColorID]) REFERENCES [dbo].[ProductColor] ([ColorID]);


GO
PRINT N'Creating FK_Product_ProductSize...';


GO
ALTER TABLE [dbo].[Product] WITH NOCHECK
    ADD CONSTRAINT [FK_Product_ProductSize] FOREIGN KEY ([SizeID]) REFERENCES [dbo].[ProductSize] ([SizeID]);


GO
PRINT N'Creating FK_Product_ProductType...';


GO
ALTER TABLE [dbo].[Product] WITH NOCHECK
    ADD CONSTRAINT [FK_Product_ProductType] FOREIGN KEY ([ProductTypeID]) REFERENCES [dbo].[ProductType] ([ProductTypeID]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Order] WITH CHECK CHECK CONSTRAINT [FK_Order_Customer];

ALTER TABLE [dbo].[OrderItem] WITH CHECK CHECK CONSTRAINT [FK_OrderItem_Order];

ALTER TABLE [dbo].[OrderItem] WITH CHECK CHECK CONSTRAINT [FK_OrderItem_Product];

ALTER TABLE [dbo].[Product] WITH CHECK CHECK CONSTRAINT [FK_Product_ProductColor];

ALTER TABLE [dbo].[Product] WITH CHECK CHECK CONSTRAINT [FK_Product_ProductSize];

ALTER TABLE [dbo].[Product] WITH CHECK CHECK CONSTRAINT [FK_Product_ProductType];


GO
PRINT N'Update complete.';


GO
