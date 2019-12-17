CREATE TABLE [dbo].[blacklist]
(
	[users_id] INT NOT NULL, 
    [restaurant_id] VARCHAR(75) NOT NULL,
	[name] VARCHAR(50) NULL, 
    [address] VARCHAR(50) NULL, 
    [city] VARCHAR(50) NULL, 
    [state] VARCHAR(15) NULL, 
    [zip] VARCHAR(20) NULL, 
    [categories] VARCHAR(MAX) NULL, 
    [img_url] VARCHAR(MAX) NULL, 
	CONSTRAINT blacklist_compPK PRIMARY KEY (users_id, restaurant_id),
    CONSTRAINT [FK_blacklist_ToTable] FOREIGN KEY (users_id) REFERENCES users(id)
)
