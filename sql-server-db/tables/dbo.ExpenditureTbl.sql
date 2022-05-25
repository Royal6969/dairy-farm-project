CREATE TABLE [dbo].[ExpenditureTbl] (
    [ExpId]      INT          IDENTITY (1, 1) NOT NULL,
    [ExpDate]    DATE         NOT NULL,
    [ExpPurpose] VARCHAR (50) NOT NULL,
    [ExpAmount]  INT          NOT NULL,
    [EmpId]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([ExpId] ASC)
);

