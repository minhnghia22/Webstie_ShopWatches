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
	phoneSup varchar(50),
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
	nameCtm varchar(50),
	phoneCtm varchar(15),
	addressCtm text,
	birthdayCtm date,
	genderCtm varchar(5),
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
	genderEmp varchar(5),
	created_at smalldatetime,
	FOREIGN KEY(roleID) REFERENCES Role(ID)
	);
	GO
	CREATE TABLE Orders(
	ID int IDENTITY(1,1) PRIMARY KEY,
	employeeID int,
	customerID int,
	requested time,
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
	code varchar(15),
	status varchar(10),
	exprityDate date,
	value float(10)
	);
	GO
