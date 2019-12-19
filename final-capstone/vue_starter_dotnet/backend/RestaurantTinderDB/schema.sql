
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the RestaurantTinderDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='RestaurantTinderDB')
DROP DATABASE RestaurantTinderDB;
GO

-- Create a new RestaurantTinderDB Database
CREATE DATABASE RestaurantTinderDB;
GO

-- Switch to the RestaurantTinderDB Database
USE RestaurantTinderDB
GO

CREATE TABLE [dbo].[users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [username] VARCHAR(50) NULL, 
    [password] VARCHAR(50) NULL, 
    [salt] VARCHAR(50) NULL, 
    [role] VARCHAR(50) NULL
)
CREATE TABLE [dbo].[preferences]
(
    [users_id] INT NOT NULL, 
    [location] VARCHAR(50) NOT NULL, 
    [search_text] VARCHAR(MAX) NOT NULL, 
    [price] VARCHAR(4) NOT NULL, 
    [radius] FLOAT NOT NULL, 
    PRIMARY KEY ([users_id]), 
    CONSTRAINT FK_users_id FOREIGN KEY (users_id) REFERENCES users(Id)
)
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
CREATE TABLE [dbo].[favorites]
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
	CONSTRAINT favorites_compPK PRIMARY KEY (users_id, restaurant_id),
    CONSTRAINT [FK_favorites_users] FOREIGN KEY (users_id) REFERENCES users(id)
)
CREATE TABLE [dbo].[likesAndDislikes]
(
	[swipe_id] INT NOT NULL PRIMARY KEY IDENTITY, 
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
    CONSTRAINT [FK_likesAndDislikes_users] FOREIGN KEY (users_id) REFERENCES users(Id)
)


select * from users
select * from preferences