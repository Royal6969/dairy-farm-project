CREATE TABLE [dbo].[IncomeTbl] (
    [IncId]      INT          IDENTITY (1, 1) NOT NULL,
    [IncDate]    DATE         NOT NULL,
    [IncPurpose] VARCHAR (50) NOT NULL,
    [IncAmt]     INT          NOT NULL,
    [EmpId]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([IncId] ASC)
);

