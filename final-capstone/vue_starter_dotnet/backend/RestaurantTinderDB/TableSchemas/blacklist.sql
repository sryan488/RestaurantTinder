CREATE TABLE [dbo].[blacklist]
(
	[users_id] INT NOT NULL, 
    [restaurant_id] VARCHAR(75) NOT NULL,
	CONSTRAINT blacklist_compPK PRIMARY KEY (users_id, restaurant_id),
    CONSTRAINT [FK_blacklist_ToTable] FOREIGN KEY (users_id) REFERENCES users(id)
)
