CREATE TABLE [dbo].[TeamMembers]
(
	[TeamMemberId] INT NOT NULL IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
	CONSTRAINT [PK_dbo.TeamMembers] PRIMARY KEY ([TeamMemberId])
)
