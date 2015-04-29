CREATE TABLE [dbo].[Account] (
    [AccountId] UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [Name]      NVARCHAR (MAX)   NOT NULL,
	[Age] INT,
    [PasswordHash] NVARCHAR(50) NOT NULL, 
    [PasswordSalt] NVARCHAR(50) NOT NULL, 
    [RoleId] INT NOT NULL, 
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([AccountId] ASC), 
    CONSTRAINT [FK_RoleToAccount] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role]([RoleId])
);


GO

CREATE INDEX [IX_AccountRole] ON [dbo].[Account] ([RoleId])
