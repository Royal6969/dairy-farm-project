CREATE TABLE [dbo].[BreedTbl] (
    [BrId]         INT           IDENTITY (2000, 1) NOT NULL,
    [HeatDate]     DATE          NOT NULL,
    [BreedDate]    DATE          NOT NULL,
    [CowId]        INT           NOT NULL,
    [CowName]      VARCHAR (50)  NOT NULL,
    [PregDate]     DATE          NOT NULL,
    [ExpDateCalve] DATE          NOT NULL,
    [DateCalved]   DATE          NOT NULL,
    [CowAge]       INT           NOT NULL,
    [Remarks]      VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([BrId] ASC)
);

