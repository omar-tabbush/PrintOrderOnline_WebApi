CREATE TABLE [dbo].[PrintOrders] (
    [OrderID]        INT         IDENTITY (1, 1) NOT NULL,
    [isBlack]        BIT         NOT NULL,
    [isHightQuality] BIT         DEFAULT ((0)) NOT NULL,
    [isBorderless]   BIT         DEFAULT ((0)) NOT NULL,
    [size]           VARCHAR (1) NULL,
    [isDoubleSide]   BIT         DEFAULT ((0)) NOT NULL,
    [PaperType]      VARCHAR (1) NULL,
    [OrderStatus]    VARCHAR (1) NULL,
    [price]          INT         NULL,
    [WhoOrdered]     INT         NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
    FOREIGN KEY ([WhoOrdered]) REFERENCES [dbo].[CustomerAccounts] ([AccountID]),
    UNIQUE NONCLUSTERED ([OrderID] ASC)
);

