CREATE TABLE [dbo].[CowTbl] (
    [CowId]         INT          IDENTITY (1000, 1) NOT NULL,
    [CowName]       VARCHAR (50) NOT NULL,
    [EarTag]        VARCHAR (50) NOT NULL,
    [Color]         VARCHAR (50) NOT NULL,
    [Breed]         VARCHAR (50) NOT NULL,
    [Age]           INT          NOT NULL,
    [WeightAtBirth] INT          NOT NULL,
    [Pasture]       VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CowId] ASC)
);

