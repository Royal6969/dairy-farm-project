CREATE TABLE [dbo].[HealthTbl] (
    [RepId]     INT          IDENTITY (500, 1) NOT NULL,
    [CowId]     INT          NOT NULL,
    [CowName]   VARCHAR (50) NOT NULL,
    [RepDate]   DATE         NOT NULL,
    [Event]     VARCHAR (50) NOT NULL,
    [Diagnosis] VARCHAR (50) NOT NULL,
    [Treatment] VARCHAR (50) NOT NULL,
    [Cost]      INT          NOT NULL,
    [VetName]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([RepId] ASC)
);

