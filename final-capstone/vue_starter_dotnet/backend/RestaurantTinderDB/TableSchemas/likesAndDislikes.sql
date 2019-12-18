CREATE TABLE [dbo].[likesAndDislikes]
(
	[swipe_id] INT NOT NULL , 
    [users_id] INT NOT NULL, 
    [is_like] BIT NOT NULL, 
    [restaurant_id] VARCHAR(75) NOT NULL,
	[name] VARCHAR(50) NULL, 
    [address] VARCHAR(50) NULL, 
    [city] VARCHAR(50) NULL, 
    [state] VARCHAR(15) NULL, 
    [zip] VARCHAR(20) NULL, 
    [categories] VARCHAR(MAX) NULL, 
    [img_url] VARCHAR(MAX) NULL,
    PRIMARY KEY ([swipe_id]), 
    CONSTRAINT [FK_likesAndDislikes_users] FOREIGN KEY (users_id) REFERENCES users(Id)
)
