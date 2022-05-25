CREATE TABLE [dbo].[EmployeeTbl] (
    [EmpId]   INT          IDENTITY (300, 1) NOT NULL,
    [EmpName] VARCHAR (50) NOT NULL,
    [EmpDob]  DATE         NOT NULL,
    [Gender]  VARCHAR (50) NOT NULL,
    [Phone]   VARCHAR (50) NOT NULL,
    [Address] VARCHAR (50) NOT NULL,
    [EmpPass] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([EmpId] ASC)
);

