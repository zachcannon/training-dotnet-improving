CREATE TABLE [dbo].[TeamMemberAgileTasks]
(
	[TeamMemberId] INT NOT NULL, 
    [AgileTaskId] INT NOT NULL, 
    CONSTRAINT [TaskMemberAgileTasksPK] PRIMARY KEY NONCLUSTERED ([TeamMemberId], [AgileTaskId])
)
