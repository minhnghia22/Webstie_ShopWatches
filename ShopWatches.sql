CREATE DATABASE ShopWatches
GO
USE ShopWatches
GO
	CREATE TABLE Categories(
	ID int IDENTITY(1,1) PRIMARY KEY,
	name varchar(50),
	descrption text
	);
	GO
	CREATE TABLE Suppliers(
	IDSup int IDENTITY(1,1) PRIMARY KEY,
	nameSup varchar(50),
	phoneSup varchar(15),
	emailSup varchar(150),
	addressSup text,
	);
	GO
	CREATE TABLE Product(
	ID int IDENTITY(1,1) PRIMARY KEY,
	SupplierID int,
	name varchar(255),
	price float,
	quantities int,
	status int,
	warrantyTime  varchar(10),
	originName varchar(50),
	img varchar(255),
	detail text,
	FOREIGN KEY (SupplierID) REFERENCES Suppliers(IDSup)
	);
	GO
	CREATE TABLE Picture (
	ID int IDENTITY(1,1) PRIMARY KEY,
	productID int,
	url varchar(255),
	name varchar(150),
	FOREIGN KEY (productID) REFERENCES Product(ID)
	);
	GO 
	CREATE TABLE Categories_Product(
	ID int IDENTITY(1,1) PRIMARY KEY,
	CategoriesID int,
	ProductID int,
	FOREIGN KEY (CategoriesID) REFERENCES Categories(ID),
	FOREIGN KEY (ProductID) REFERENCES Product(ID)
	);
	GO
	CREATE TABLE Customer(
	IDCtm int IDENTITY(1,1) PRIMARY KEY,
	emailCtm varchar(150),
	passwordCtm varchar(32),
	nameCtm varchar(70),
	phoneCtm varchar(15),
	addressCtm text,
	birthdayCtm date,
	genderCtm varchar(7),
	created_at smalldatetime
	);
	GO
	CREATE TABLE Role(
	ID int IDENTITY(1,1) PRIMARY KEY,
	name varchar(20)
	);

	GO
	CREATE TABLE Employee(
	IDEmp int IDENTITY(1,1) PRIMARY KEY,
	roleID int,
	emailEmp varchar(150),
	passwordEmp varchar(32),
	nameEmp varchar(50),
	phoneEmp varchar(15),
	IDcard int,
	addressEmp text,
	birthdayEmp date,
	genderEmp varchar(7),
	created_at smalldatetime,
	FOREIGN KEY(roleID) REFERENCES Role(ID)
	);
	GO
	CREATE TABLE Orders(
	ID int IDENTITY(1,1) PRIMARY KEY,
	employeeID int,
	customerID int,
	requested date,
	totalMoney float(15),
	statusOrder varchar(25),
	statusPayment varchar(25),
	FOREIGN KEY(employeeID) REFERENCES Employee(IDEmp),
	FOREIGN KEY(customerID) REFERENCES Customer(IDCtm),
	);
	GO
	CREATE TABLE Orders_Details(
	ID int IDENTITY(1,1) PRIMARY KEY,
	ProductID int,
	OrderID int,
	price float(10),
	quantities int,
	FOREIGN KEY(ProductID) REFERENCES Product(ID),
	FOREIGN KEY(OrderID) REFERENCES Orders(ID),
	);
	GO
	CREATE TABLE Voucher(
	ID int IDENTITY(1,1) PRIMARY KEY,
	code varchar(100),
	status varchar(10),
	exprityDate date,
	value float(10)
	);
	GO
	CREATE TABLE Cart(
	ID int IDENTITY(1,1) PRIMARY KEY,
	ProductID int,
	customerID int,
	quantities int,
	FOREIGN KEY(ProductID) REFERENCES Product(ID),
	FOREIGN KEY(customerID) REFERENCES Customer(IDCtm),
	);
	GO
	INSERT INTO Role(name) values('Admin');
	INSERT INTO Role(name) values('Employee');
	INSERT INTO Categories(name, descrption) values('Analog Watches', 'This one is undeniably the most traditional display type of watches. It’s the one with an hour hand, a minute hand and sometimes the second hand.');
	INSERT INTO Categories(name, descrption) values('Digital Watches', 'Digital is the one that uses LCD screen to display the time and other information that may be available in the watch. It needs electric power so it is only available among quartz watches.');
	INSERT INTO Categories(name, descrption) values('Hybrid Watches', 'From the term itself, this is the type that combines the first two types. At first glance, it looks like an analog watch, with the hour, minute and second hands. Yet hybrid watches offer much more on their LCD screen. Many wearers prefer to have the classic look of an analog face combined with the modern convenience of apps, notifications and other features that smartwatches offer. ');
	INSERT INTO Categories(name, descrption) values('Casual, Dress, Fashion and Luxury', 'This category pertains to the overall visual appeal of the watch, Does the watch seem for everyday wear or for formal wear? Or maybe it has the overall appeal that outshines the crowd.');

	INSERT INTO Employee(roleID,emailEmp,passwordEmp,nameEmp,phoneEmp,IDcard,addressEmp,birthdayEmp,genderEmp,created_at) 
	values(1, 'admin@fpt.com','ICy5YqxZB1uWSwcVLSNLcA==','admin','01208471','22','123','2020-10-02','Female','2020-10-31 15:51:00');