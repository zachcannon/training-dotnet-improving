CREATE TABLE [dbo].[AgileTasks] (
    [Title] NVARCHAR (128) NULL,
    [Body]  NVARCHAR (MAX) NULL,
    [TaskStatusId] INT NOT NULL DEFAULT 0, 
    [AgileTaskId] INT NOT NULL IDENTITY, 
    CONSTRAINT [PK_dbo.AgileTasks] PRIMARY KEY ([AgileTaskId]), 
    CONSTRAINT [FK_AgileTasks_TaskStatus] FOREIGN KEY ([TaskStatusId]) REFERENCES [TaskStatus]([TaskStatusId]), 
);

