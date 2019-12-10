
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the DemoDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='DemoDB')
DROP DATABASE DemoDB;
GO

-- Create a new DemoDB Database
CREATE DATABASE DemoDB;
GO

-- Switch to the DemoDB Database
USE DemoDB
GO

BEGIN TRANSACTION;

CREATE TABLE users
(
	id			int			identity(1,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	constraint pk_users primary key (id)
);
COMMIT TRANSACTION;

BEGIN TRANSACTION;

CREATE TABLE Favorites
(
	users_id	int not null,
	restaurant_id int not null,
);
COMMIT TRANSACTION;

BEGIN TRANSACTION;

CREATE TABLE Blacklist
(
	users_id	int not null,
	restaurant_id int not null,
);
COMMIT TRANSACTION;

BEGIN TRANSACTION;

CREATE TABLE Preferences
(
	id int identity(1,1),
	users_id int not null,
	city varchar(50) not null,
	cuisine varchar(50) not null,
	price int not null,
	distance float not null

	constraint pk_Preferences primary key (id)
);

COMMIT TRANSACTION;

DROP TABLE Preferences