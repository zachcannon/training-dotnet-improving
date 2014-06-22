CREATE TABLE [dbo].[AgileTasks] (
    [Title] NVARCHAR (128) NOT NULL,
    [Body]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AgileTasks] PRIMARY KEY CLUSTERED ([Title] ASC)
);

