CREATE TABLE [dbo].[Order] (
    [OrderID]         INT      IDENTITY (1, 1) NOT NULL,
    [OrderDate]       DATETIME NOT NULL,
    [Status]          INT      NOT NULL,
    [OnlineOrderFlag] BIT      CONSTRAINT [DF_Order_OnlineOrderFlag] DEFAULT ((0)) NOT NULL,
    [SubTotal]        MONEY    NOT NULL,
    [TaxAmt]          MONEY    NULL,
    [OrderTotal]      MONEY    NOT NULL,
    [CustomerID]      INT      NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
);

