CREATE TABLE [dbo].[TeamMemberAgileTasks]
(
	[TeamMember_TeamMemberId] INT NOT NULL, 
    [AgileTask_AgileTaskId] INT NOT NULL, 
    CONSTRAINT [TaskMemberAgileTasksPK] PRIMARY KEY NONCLUSTERED ([TeamMember_TeamMemberId], [AgileTask_AgileTaskId]),
	CONSTRAINT [TeamMemberFK] FOREIGN KEY ([TeamMember_TeamMemberId]) REFERENCES [TeamMembers]([TeamMemberId]),
	CONSTRAINT [AgileTaskFK] FOREIGN KEY ([AgileTask_AgileTaskId]) REFERENCES [AgileTasks]([AgileTaskId])
)
