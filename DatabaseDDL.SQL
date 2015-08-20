CREATE DATABASE IF NOT EXISTS `db_trackvideowatching`;
USE `db_trackvideowatching`;
CREATE TABLE IF NOT EXISTS `tbl_users` (
	`PK_UserID` int NOT NULL AUTO_INCREMENT,
	`Username` text NOT NULL,
	`Password_Hash` text NOT NULL,
	`Salt` char(8) NOT NULL,
	`EmailAddress` text NOT NULL,
	Primary Key(`PK_UserID`)
);
CREATE TABLE IF NOT EXISTS `tbl_records` (
	`PK_ID` int NOT NULL AUTO_INCREMENT,
	`FK_UserID` int NOT NULL,
	`Video_Platform` text NOT NULL,
	`Date_Watched` date NOT NULL,
	`Channel` text NOT NULL,
	`Length` time NOT NULL,
	Primary Key(`PK_ID`)
);