
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

CREATE TABLE Favorites
(
	users_id	int not null,
	restaurant_id varchar(75) not null,
);


CREATE TABLE Blacklist
(
	users_id	int not null,
	restaurant_id varchar(75) not null,
);

CREATE TABLE Preferences
(
	id int,
	users_id int not null,
	"location" varchar(50) not null,
	categories varchar(max) not null,
	price varchar not null,
	radius float not null
);

COMMIT TRANSACTION;