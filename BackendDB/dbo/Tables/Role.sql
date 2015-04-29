CREATE TABLE [dbo].[Role]
(
	[RoleId] INT NOT NULL PRIMARY KEY IDENTITY , 
    [Symbol] CHAR NOT NULL, 
    [Description] NVARCHAR(50) NULL 
)
