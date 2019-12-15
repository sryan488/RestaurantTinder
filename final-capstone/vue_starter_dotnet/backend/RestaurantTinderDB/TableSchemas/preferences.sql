CREATE TABLE [dbo].[preferences]
(
    [users_id] INT NOT NULL, 
    [location] VARCHAR(50) NOT NULL, 
    [categories] VARCHAR(MAX) NOT NULL, 
    [price] VARCHAR(4) NOT NULL, 
    [radius] FLOAT NOT NULL, 
    PRIMARY KEY ([users_id]), 
    CONSTRAINT FK_users_id FOREIGN KEY (users_id) REFERENCES users(Id)
)
