CREATE TABLE [dbo].[SalesTbl] (
    [SId]         INT          IDENTITY (1, 1) NOT NULL,
    [Date]        DATE         NOT NULL,
    [Uprice]      INT          NOT NULL,
    [ClientName]  VARCHAR (50) NOT NULL,
    [ClientPhone] VARCHAR (50) NOT NULL,
    [EmpId]       INT          NOT NULL,
    [Quantity]    INT          NOT NULL,
    [Amount]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([SId] ASC)
);

