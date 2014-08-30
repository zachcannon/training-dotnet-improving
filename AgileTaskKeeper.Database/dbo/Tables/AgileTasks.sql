CREATE TABLE [dbo].[AgileTasks] (
    [Title] NVARCHAR (128) NOT NULL,
    [Body]  NVARCHAR (MAX) NULL,
    [TaskStatusId] INT NOT NULL DEFAULT 0, 
    [AgileTaskId] INT NOT NULL IDENTITY, 
    CONSTRAINT [PK_dbo.AgileTasks] PRIMARY KEY CLUSTERED ([AgileTaskId]), 
    CONSTRAINT [FK_AgileTasks_TaskStatus] FOREIGN KEY ([TaskStatusId]) REFERENCES [TaskStatus]([TaskStatusId]), 
);

