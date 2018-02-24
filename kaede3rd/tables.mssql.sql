--CREATE DATABASE ennichidb;

CREATE TABLE operator (
	operator_id INT PRIMARY KEY identity(1,1)  NOT NULL,
	operator_name NVARCHAR(255) UNIQUE NOT NULL,
	operator_comment NVARCHAR(255) default NULL
);

CREATE TABLE config (
	config_name NVARCHAR(128) PRIMARY KEY NOT NULL,
	config_value NVARCHAR(255) NOT NULL
);

CREATE TABLE receipt (
	receipt_id INT PRIMARY KEY identity(1,1)  NOT NULL,
	receipt_pass CHAR(8) default NULL,
	receipt_seller CHAR(4) NOT NULL default 9999,
	receipt_seller_exname NVARCHAR(64) default NULL,
	receipt_time DATETIME default NULL,
	receipt_operator INT default NULL,
	receipt_payback bit default 0,
	receipt_comment NVARCHAR(255) default NULL,

	FOREIGN KEY ( receipt_operator ) REFERENCES operator(operator_id) ON DELETE SET NULL
);

CREATE TABLE box(
	box_id INT PRIMARY KEY identity(1,1) NOT NULL,
	box_genre INT default NULL,
	box_comment NVARCHAR(255) default NULL
);	

CREATE TABLE genre(
	genre_id INT PRIMARY KEY identity(1,1) NOT NULL,
	genre_name NVARCHAR(255) NOT NULL
);

CREATE TABLE item (
	item_id INT PRIMARY KEY identity(1,1)  NOT NULL,
	item_receipt_id INT NOT NULL,
	item_name NVARCHAR(255) NOT NULL,
	item_tagprice INT NOT NULL default 0,
	item_tataki BIT NOT NULL default 0,
	item_return BIT NOT NULL default 1,
	item_tag_printed BIT NOT NULL default 0,
	item_genre INT default NULL,
	item_sellway NVARCHAR(255) default NULL,

	item_receipt_time DATETIME default NULL,
	item_receipt_operator INT default NULL,

	item_sellprice INT default NULL,
	item_selltime DATETIME default NULL,
	item_sell_operator INT default NULL,

	item_kansa_end DATETIME default NULL,
	item_kansa_flag1 INT default NULL,
	
	item_adjust INT default NULL,

	item_isbn NVARCHAR(255) default NULL,
	item_volumes INT default NULL,

	item_comment NVARCHAR(255) default NULL,
	item_sellcomment NVARCHAR(255) default NULL,
	item_userspace NVARCHAR(255) default NULL,
	item_box_id INT default NULL,
	item_number INT default NULL,

	FOREIGN KEY ( item_receipt_id ) REFERENCES receipt(receipt_id) ON DELETE CASCADE,
	FOREIGN KEY ( item_sell_operator ) REFERENCES operator(operator_id) ON DELETE SET NULL,
	
);
