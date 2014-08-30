CREATE TABLE [dbo].[TeamMembersAgileTasks]
(
	[TeamMemberId] INT NOT NULL, 
    [AgileTaskId] INT NOT NULL, 
    CONSTRAINT TaskMemberPK PRIMARY KEY (TeamMemberId, AgileTaskId),
	CONSTRAINT TeamMemberFK FOREIGN KEY ([TeamMemberId]) REFERENCES [TeamMembers]([TeamMemberId]),
	CONSTRAINT AgileTaskFK FOREIGN KEY ([AgileTaskId]) REFERENCES [AgileTasks]([AgileTaskId])
)
