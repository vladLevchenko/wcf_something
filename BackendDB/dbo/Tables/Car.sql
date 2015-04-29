CREATE TABLE [dbo].[Car] (
    [CarId]             UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [License]           NVARCHAR (MAX)   NOT NULL,
    [AccountId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED ([CarId] ASC),
    CONSTRAINT [FK_AccountCar] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_AccountCar]
    ON [dbo].[Car]([AccountId] ASC);

