CREATE TABLE [dbo].[AgileTasks] (
    [Title] NVARCHAR (128) NOT NULL,
    [Body]  NVARCHAR (MAX) NULL,
    [TaskStatusId] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_dbo.AgileTasks] PRIMARY KEY CLUSTERED ([Title] ASC), 
    CONSTRAINT [FK_AgileTasks_TaskStatus] FOREIGN KEY ([TaskStatusId]) REFERENCES [TaskStatus]([TaskStatusId])
);

