CREATE TABLE [dbo].[MilkTbl] (
    [MId]       INT          IDENTITY (1, 1) NOT NULL,
    [CowId]     INT          NOT NULL,
    [CowName]   VARCHAR (50) NOT NULL,
    [AmMilk]    INT          NOT NULL,
    [NoonMilk]  INT          NOT NULL,
    [PmMilk]    INT          NOT NULL,
    [TotalMilk] INT          NOT NULL,
    [DateProd]  DATE         NOT NULL,
    PRIMARY KEY CLUSTERED ([MId] ASC)
);

