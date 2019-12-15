CREATE TABLE [dbo].[favorites]
(
	[users_id] INT NOT NULL, 
    [restaurant_id] VARCHAR(75) NOT NULL,
	CONSTRAINT favorites_compPK PRIMARY KEY (users_id, restaurant_id),
    CONSTRAINT [FK_favorites_ToTable] FOREIGN KEY (users_id) REFERENCES users(id)
)
