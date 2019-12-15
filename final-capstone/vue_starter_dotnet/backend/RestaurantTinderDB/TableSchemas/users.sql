CREATE TABLE [dbo].[users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [username] VARCHAR(50) NULL, 
    [password] VARCHAR(50) NULL, 
    [salt] VARCHAR(50) NULL, 
    [role] VARCHAR(50) NULL
)
