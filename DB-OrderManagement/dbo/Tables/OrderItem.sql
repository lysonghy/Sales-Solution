CREATE TABLE [dbo].[OrderItem] (
    [OrderItemID]       INT   IDENTITY (1, 1) NOT NULL,
    [ProductID]         INT   NOT NULL,
    [OrderID]           INT   NOT NULL,
    [OrderQty]          INT   CONSTRAINT [DF_OrderItem_OrderQty] DEFAULT ((1)) NOT NULL,
    [UnitPrice]         MONEY NOT NULL,
    [UnitPriceDiscount] MONEY CONSTRAINT [DF_OrderItem_UnitPriceDiscount] DEFAULT ((0)) NULL,
    [LineTotal]         MONEY NOT NULL,
    CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED ([OrderItemID] ASC),
    CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([OrderID]),
    CONSTRAINT [FK_OrderItem_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID])
);

