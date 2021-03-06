USE [ShopWatches]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 11/20/2020 12:19:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[customerID] [int] NULL,
	[quantities] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/20/2020 12:19:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[descrption] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories_Product]    Script Date: 11/20/2020 12:19:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories_Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoriesID] [int] NULL,
	[ProductID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/20/2020 12:19:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IDCtm] [int] IDENTITY(1,1) NOT NULL,
	[emailCtm] [varchar](150) NULL,
	[passwordCtm] [varchar](32) NULL,
	[nameCtm] [varchar](70) NULL,
	[phoneCtm] [varchar](15) NULL,
	[addressCtm] [text] NULL,
	[birthdayCtm] [date] NULL,
	[genderCtm] [varchar](7) NULL,
	[created_at] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCtm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/20/2020 12:19:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[IDEmp] [int] IDENTITY(1,1) NOT NULL,
	[roleID] [int] NULL,
	[emailEmp] [varchar](150) NULL,
	[passwordEmp] [varchar](32) NULL,
	[nameEmp] [varchar](50) NULL,
	[phoneEmp] [varchar](15) NULL,
	[IDcard] [int] NULL,
	[addressEmp] [text] NULL,
	[birthdayEmp] [date] NULL,
	[genderEmp] [varchar](7) NULL,
	[created_at] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEmp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/20/2020 12:19:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[employeeID] [int] NULL,
	[customerID] [int] NULL,
	[totalMoney] [real] NULL,
	[statusOrder] [varchar](25) NULL,
	[statusPayment] [varchar](25) NULL,
	[requested] [datetime] NULL,
	[discount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders_Details]    Script Date: 11/20/2020 12:19:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders_Details](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[OrderID] [int] NULL,
	[price] [real] NULL,
	[quantities] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Picture]    Script Date: 11/20/2020 12:19:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Picture](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[productID] [int] NULL,
	[url] [varchar](255) NULL,
	[name] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/20/2020 12:19:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NULL,
	[name] [varchar](255) NULL,
	[price] [float] NULL,
	[quantities] [int] NULL,
	[status] [int] NULL,
	[warrantyTime] [varchar](10) NULL,
	[originName] [varchar](50) NULL,
	[img] [varchar](255) NULL,
	[detail] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/20/2020 12:19:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 11/20/2020 12:19:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[IDSup] [int] IDENTITY(1,1) NOT NULL,
	[nameSup] [varchar](50) NULL,
	[phoneSup] [varchar](15) NULL,
	[emailSup] [varchar](150) NULL,
	[addressSup] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDSup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 11/20/2020 12:19:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](100) NULL,
	[status] [varchar](10) NULL,
	[exprityDate] [date] NULL,
	[value] [real] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([ID], [ProductID], [customerID], [quantities]) VALUES (2, 1, 1, 12)
INSERT [dbo].[Cart] ([ID], [ProductID], [customerID], [quantities]) VALUES (3, 2, 1, 5)
INSERT [dbo].[Cart] ([ID], [ProductID], [customerID], [quantities]) VALUES (4, 3, 1, 13)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [name], [descrption]) VALUES (1, N'Analog Watches', N'This one is undeniably the most traditional display type of watches. It’s the one with an hour hand, a minute hand and sometimes the second hand.')
INSERT [dbo].[Categories] ([ID], [name], [descrption]) VALUES (2, N'Digital Watches', N'Digital is the one that uses LCD screen to display the time and other information that may be available in the watch. It needs electric power so it is only available among quartz watches.')
INSERT [dbo].[Categories] ([ID], [name], [descrption]) VALUES (3, N'Hybrid Watches', N'From the term itself, this is the type that combines the first two types. At first glance, it looks like an analog watch, with the hour, minute and second hands. Yet hybrid watches offer much more on their LCD screen. Many wearers prefer to have the classic look of an analog face combined with the modern convenience of apps, notifications and other features that smartwatches offer. ')
INSERT [dbo].[Categories] ([ID], [name], [descrption]) VALUES (4, N'Casual, Dress, Fashion and Luxury', N'This category pertains to the overall visual appeal of the watch, Does the watch seem for everyday wear or for formal wear? Or maybe it has the overall appeal that outshines the crowd.')
INSERT [dbo].[Categories] ([ID], [name], [descrption]) VALUES (5, N'Unisex', N'Danh cho nam va nu')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories_Product] ON 

INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (1, 3, 1)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (2, 4, 1)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (3, 5, 1)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (4, 2, 2)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (5, 1, 4)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (6, 3, 7)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (7, 5, 10)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (8, 4, 11)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (9, 5, 11)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (10, 2, 5)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (11, 3, 5)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (12, 1, 9)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (13, 4, 9)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (14, 5, 9)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (15, 1, 3)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (16, 4, 3)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (17, 5, 3)
INSERT [dbo].[Categories_Product] ([ID], [CategoriesID], [ProductID]) VALUES (18, 2, 12)
SET IDENTITY_INSERT [dbo].[Categories_Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([IDCtm], [emailCtm], [passwordCtm], [nameCtm], [phoneCtm], [addressCtm], [birthdayCtm], [genderCtm], [created_at]) VALUES (1, N'admin2@fpt.com', N'Qpf0SxOVUjUkWySXOZ16kw==', N'Minh Nghia', N'0989242222', N'Soc Trang', CAST(N'2000-01-01' AS Date), N'male', CAST(N'2000-05-05T00:00:00' AS SmallDateTime))
INSERT [dbo].[Customer] ([IDCtm], [emailCtm], [passwordCtm], [nameCtm], [phoneCtm], [addressCtm], [birthdayCtm], [genderCtm], [created_at]) VALUES (2, N'admin@fpt.com', N'/fg+6Tha9IsyaZZXCcPA8Q==', N'Nhat Minh', N'01232511369', N'can tho', CAST(N'2020-11-23' AS Date), N'female', CAST(N'2000-02-02T00:00:00' AS SmallDateTime))
INSERT [dbo].[Customer] ([IDCtm], [emailCtm], [passwordCtm], [nameCtm], [phoneCtm], [addressCtm], [birthdayCtm], [genderCtm], [created_at]) VALUES (4, N'cus@cus.com', N'/fg+6Tha9IsyaZZXCcPA8Q==', N'Minh Nghia', N'01248400961', N'Soc Trang', CAST(N'2000-02-22' AS Date), N'Female', CAST(N'2020-11-19T00:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([IDEmp], [roleID], [emailEmp], [passwordEmp], [nameEmp], [phoneEmp], [IDcard], [addressEmp], [birthdayEmp], [genderEmp], [created_at]) VALUES (1, 1, N'admin@fpt.com', N'ICy5YqxZB1uWSwcVLSNLcA==', N'admin', N'01208471', 2261276, N'tra vinh', CAST(N'2020-11-04' AS Date), N'Female', CAST(N'2020-10-31T15:51:00' AS SmallDateTime))
INSERT [dbo].[Employee] ([IDEmp], [roleID], [emailEmp], [passwordEmp], [nameEmp], [phoneEmp], [IDcard], [addressEmp], [birthdayEmp], [genderEmp], [created_at]) VALUES (2, 1, N'abc@gmail.com', N'ICy5YqxZB1uWSwcVLSNLcA==', N'employee', N'08438273', 2261277, N'can tho', CAST(N'2000-05-05' AS Date), N'Male', CAST(N'2000-05-05T00:00:00' AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [employeeID], [customerID], [totalMoney], [statusOrder], [statusPayment], [requested], [discount]) VALUES (11, 1, 4, 257, N'Pending', N'Paymented', CAST(N'2020-11-19T16:54:58.203' AS DateTime), 0)
INSERT [dbo].[Orders] ([ID], [employeeID], [customerID], [totalMoney], [statusOrder], [statusPayment], [requested], [discount]) VALUES (12, 1, 2, 168360, N'Pending', N'Paymented', CAST(N'2020-11-19T16:54:58.203' AS DateTime), 0)
INSERT [dbo].[Orders] ([ID], [employeeID], [customerID], [totalMoney], [statusOrder], [statusPayment], [requested], [discount]) VALUES (13, 1, 2, 1526, N'Pending', N'Paymented', CAST(N'2020-11-19T16:54:58.203' AS DateTime), 0)
INSERT [dbo].[Orders] ([ID], [employeeID], [customerID], [totalMoney], [statusOrder], [statusPayment], [requested], [discount]) VALUES (14, 1, 2, 6000, N'Pending', N'Paymented', CAST(N'2020-11-19T16:54:58.203' AS DateTime), 0)
INSERT [dbo].[Orders] ([ID], [employeeID], [customerID], [totalMoney], [statusOrder], [statusPayment], [requested], [discount]) VALUES (15, 1, 2, 6000, N'Pending', N'Paymented', CAST(N'2020-11-19T16:54:58.203' AS DateTime), 0)
INSERT [dbo].[Orders] ([ID], [employeeID], [customerID], [totalMoney], [statusOrder], [statusPayment], [requested], [discount]) VALUES (16, 1, 2, 6000, N'Pending', N'Paymented', CAST(N'2020-11-19T16:54:58.203' AS DateTime), 0)
INSERT [dbo].[Orders] ([ID], [employeeID], [customerID], [totalMoney], [statusOrder], [statusPayment], [requested], [discount]) VALUES (17, 1, 4, 530, N'Pending', N'Paymented', CAST(N'2020-11-19T17:08:41.667' AS DateTime), 0)
INSERT [dbo].[Orders] ([ID], [employeeID], [customerID], [totalMoney], [statusOrder], [statusPayment], [requested], [discount]) VALUES (18, 1, 4, 48090, N'Pending', N'Paymented', CAST(N'2020-11-19T21:10:09.373' AS DateTime), 0)
INSERT [dbo].[Orders] ([ID], [employeeID], [customerID], [totalMoney], [statusOrder], [statusPayment], [requested], [discount]) VALUES (19, 1, 4, 48000, N'Pending', N'Paymented', CAST(N'2020-11-19T21:57:18.003' AS DateTime), 10)
INSERT [dbo].[Orders] ([ID], [employeeID], [customerID], [totalMoney], [statusOrder], [statusPayment], [requested], [discount]) VALUES (20, 1, 4, 1000, N'Pending', N'Paymented', CAST(N'2020-11-19T22:18:14.960' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders_Details] ON 

INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (2, 2, 11, 15, 1)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (3, 3, 11, 42, 1)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (4, 5, 11, 200, 1)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (5, 7, 12, 2000, 12)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (6, 8, 12, 30, 12)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (7, 9, 12, 12000, 12)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (8, 1, 13, 1526, 1)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (9, 13, 14, 6000, 1)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (10, 13, 15, 6000, 1)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (11, 13, 16, 6000, 1)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (12, 8, 17, 30, 1)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (13, 12, 17, 500, 1)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (14, 11, 18, 12000, 4)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (15, 8, 18, 30, 3)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (16, 11, 19, 12000, 4)
INSERT [dbo].[Orders_Details] ([ID], [ProductID], [OrderID], [price], [quantities]) VALUES (17, 12, 20, 500, 2)
SET IDENTITY_INSERT [dbo].[Orders_Details] OFF
GO
SET IDENTITY_INSERT [dbo].[Picture] ON 

INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (1, 1, N'https://i.ibb.co/CvxkMr3/popular6.png', N'CALVIN KLEIN K2G2G1C1 - MALE - QUARTZ (PIN) - LEATHER STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (2, 1, N'https://i.ibb.co/gr9NtbW/CITIZEN-AR0015-68-A-AR0019-67-A-4-699x699.jpg', N'CALVIN KLEIN K2G2G1C1 - MALE - QUARTZ (PIN) - LEATHER STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (3, 1, N'https://i.ibb.co/tCD9t42/CITIZEN-AR0015-68-A-AR0019-67-A-3-699x699.jpg', N'CALVIN KLEIN K2G2G1C1 - MALE - QUARTZ (PIN) - LEATHER STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (4, 1, N'https://i.ibb.co/DbLdfgh/CITIZEN-AR0015-68-A-AR0019-67-A-0-699x699.jpg', N'CALVIN KLEIN K2G2G1C1 - MALE - QUARTZ (PIN) - LEATHER STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (5, 2, N'https://i.ibb.co/Fbd4gW6/CITIZEN-EQ0603-59-P-4-699x699.jpg', N'TISSOT T101.451.11.051.00 - MALE - SAPPHIRE GLASSES - QUARTZ (PIN) - METAL STRINGS')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (6, 2, N'https://i.ibb.co/8K29km3/CITIZEN-EQ0603-59-P-3-699x699.jpg', N'TISSOT T101.451.11.051.00 - MALE - SAPPHIRE GLASSES - QUARTZ (PIN) - METAL STRINGS')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (7, 2, N'https://i.ibb.co/0tz3CKV/CITIZEN-EQ0603-59-P-1-699x699.jpg', N'TISSOT T101.451.11.051.00 - MALE - SAPPHIRE GLASSES - QUARTZ (PIN) - METAL STRINGS')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (8, 2, N'https://i.ibb.co/0tz3CKV/CITIZEN-EQ0603-59-P-1-699x699.jpg', N'TISSOT T101.451.11.051.00 - MALE - SAPPHIRE GLASSES - QUARTZ (PIN) - METAL STRINGS')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (9, 3, N'https://i.ibb.co/GQBzBzR/SEIKO-SUT370-J1-3-699x699.jpg', N'TISSOT T063.907.16.058.00 - MALE - SAPPHIRE GLASSES - AUTOMATIC (AUTOMATION) - LEATHER STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (10, 3, N'https://i.ibb.co/XJLqHMK/SEIKO-SUT370-J1-1-699x699.jpg', N'TISSOT T063.907.16.058.00 - MALE - SAPPHIRE GLASSES - AUTOMATIC (AUTOMATION) - LEATHER STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (11, 3, N'https://i.ibb.co/zVftW8M/142-SUT370-J1-699x699.jpg', N'TISSOT T063.907.16.058.00 - MALE - SAPPHIRE GLASSES - AUTOMATIC (AUTOMATION) - LEATHER STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (12, 3, N'https://i.ibb.co/60pNQ1N/hop-tissot-699x699.jpg', N'TISSOT T063.907.16.058.00 - MALE - SAPPHIRE GLASSES - AUTOMATIC (AUTOMATION) - LEATHER STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (13, 4, N'https://i.ibb.co/wC74TzY/134-T084-210-11-057-00-2-699x699.jpg', N'CASIO SHE-4056PG-4AUDF - WOMEN - QUARTZ (PIN) - METAL STRIP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (14, 4, N'https://i.ibb.co/Tm7zXLy/T084-210-11-057-00-699x699.jpg', N'CASIO SHE-4056PG-4AUDF - WOMEN - QUARTZ (PIN) - METAL STRIP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (15, 4, N'https://i.ibb.co/Tm7zXLy/T084-210-11-057-00-699x699.jpg', N'CASIO SHE-4056PG-4AUDF - WOMEN - QUARTZ (PIN) - METAL STRIP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (16, 4, N'https://i.ibb.co/pQBXHSY/HOP1-699x699.jpg', N'CASIO SHE-4056PG-4AUDF - WOMEN - QUARTZ (PIN) - METAL STRIP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (17, 5, N'https://i.ibb.co/y0byN9n/31-0606-DW-5-699x699.jpg', N'CASIO LTP-1130N-1ARDF - WOMEN - QUARTZ (PIN) - METAL STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (18, 5, N'https://i.ibb.co/wCDbxwQ/31-0606-DW-2-699x699.jpg', N'CASIO LTP-1130N-1ARDF - WOMEN - QUARTZ (PIN) - METAL STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (19, 5, N'https://i.ibb.co/wY5SPqB/31-0606-DW-3-699x699.jpg', N'CASIO LTP-1130N-1ARDF - WOMEN - QUARTZ (PIN) - METAL STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (20, 5, N'https://i.ibb.co/rZDrnLC/90-DW00100051-699x699.jpg', N'CASIO LTP-1130N-1ARDF - WOMEN - QUARTZ (PIN) - METAL STRAP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (21, 6, N'https://i.ibb.co/2hSDRyx/Casio-EF-550-D-7-AVUDF-2-699x699.jpg', N'CASIO LTP-1302SG-7AVDF - WOMEN - QUARTZ (PIN) - METAL STRIP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (22, 6, N'https://i.ibb.co/4FJ5Lq7/Casio-EF-550-D-7-AVUDF-3-699x699.jpg', N'CASIO LTP-1302SG-7AVDF - WOMEN - QUARTZ (PIN) - METAL STRIP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (23, 6, N'https://i.ibb.co/gtq8sbP/Casio-EF-550-D-7-AVUDF-4-699x699.jpg', N'CASIO LTP-1302SG-7AVDF - WOMEN - QUARTZ (PIN) - METAL STRIP')
INSERT [dbo].[Picture] ([ID], [productID], [url], [name]) VALUES (24, 6, N'https://i.ibb.co/f05zwTv/Casio-EF-550-D-7-AVUDF-1-399x399.jpg', N'CASIO LTP-1302SG-7AVDF - WOMEN - QUARTZ (PIN) - METAL STRIP')
SET IDENTITY_INSERT [dbo].[Picture] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (1, 5, N'CALVIN KLEIN K2G2G1C1 - MALE - QUARTZ (PIN) - LEATHER STRAP', 1526, 122, NULL, N'12', N'USA', N'https://i.ibb.co/0tz3CKV/CITIZEN-EQ0603-59-P-1-699x699.jpg', N'The simple look comes from the 3-hand Calvin Klein K3M21123 model with a slim-gauge design for a sophisticated look with a youthful look combined with a masculine black leather strap model.')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (2, 2, N'TISSOT T101.451.11.051.00 - MALE - SAPPHIRE GLASSES - QUARTZ (PIN) - METAL STRINGS', 15, 500, NULL, N'12', N'THAI', N'https://i.ibb.co/F7zFMKY/CITIZEN-AR0015-68-A-AR0019-67-A-3-699x699.jpg', N'The Tissot T101.451.11.051.00 model impresses with 100 meters of water resistance for a strong look, the numerals are all machined with a bold design that stands out on a masculine black tone dial.')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (3, 3, N'TISSOT T063.907.16.058.00 - MALE - SAPPHIRE GLASSES - AUTOMATIC (AUTOMATION) - LEATHER STRAP', 42, 100, NULL, N'6', N'US', N'https://i.ibb.co/LnZStxx/image.png', N'The Tissot T063.907.16.058.00 mechanical version reveals a unique design on the 40mm dial background with Guilloche patterned in fashion for men.')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (4, 4, N'CASIO SHE-4056PG-4AUDF - WOMEN - QUARTZ (PIN) - METAL STRIP', 500, 50, NULL, N'6', N'USA', N'https://i.ibb.co/cgN9mkf/CITIZEN-EQ0603-59-P-2-699x699.jpg', N'The Casio SHE-4056PG-4AUDF model has a crystal attached version corresponding to the time zones creating a luxurious look on the 30mm dial.')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (5, 5, N'CASIO LTP-1130N-1ARDF - WOMEN - QUARTZ (PIN) - METAL STRAP', 200, 1000, NULL, N'8', N'THUY SY', N'https://i.ibb.co/BNTsjcL/popular4.png', N'The Casio LTP-1130N-1ARDF fashion watch for high-end women, delicate black background with gold-plated stainless steel case, also comes with 3 small hands')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (6, 2, N'CASIO LTP-1302SG-7AVDF - WOMEN - QUARTZ (PIN) - METAL STRIP', 5600, 15, NULL, N'6', N'ITALYA', N'https://i.ibb.co/zVftW8M/142-SUT370-J1-699x699.jpg', N'Casio LTP-1302SG-7AVDF watch with a feminine rounded bezel, inside the dial with a white background with accentuated gold-plated index and hour markers, metal band with 2 subtle white gold colors .')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (7, 4, N'WOMEN CASIO - QUARTZ (PIN) - METAL STRAP (LTP-V002G-9AUDF)', 2000, 988, NULL, N'5', N'JAPAN', N'https://i.ibb.co/Sf6NGDQ/EF-550-D-7-AVUDF.jpg', N'The stylish Casio LTP-V002G-9AUDF fashion watch is easy for women with a delicate gold-plated material design, and the dial also has a synchronized gold background.')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (8, 1, N'CASIO MTP-V300L-7A2UDF - MEN - QUARTZ (PIN) - LEATHER STRAP', 30, 84, NULL, N'6', N'PHAP', N'https://i.ibb.co/XWW58xQ/GA-120-1-ADR.jpg', N'The Casio MTP-V300L-7A2UDF model features calendar functions for a 6-hand watch style, a youthful thin Roman numeric base version with a smooth leather strap.')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (9, 4, N'CITIZEN DOUBLE - QUARTZ (PIN) - METAL STRAP (BI5034-51E - EU6034-55E)', 12000, 88, NULL, N'12', N'PHAP', N'https://i.ibb.co/0h9B7kR/image.png', N'Citizen Doubles have luxurious Swarovski crystal encrusted metal frames around a unique black dial, prominent luxurious hands and numerals, and a metal strap that brings comfort to the wearer.')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (10, 4, N'CITIZEN DOUBLE - QUARTZ (PIN) - METAL STRAP (BI5032-56A - EU6032-51D)', 1000, 11, NULL, N'12', N'THUY SY', N'https://i.ibb.co/Fx7khmL/image.png', N'Citizen couple watches have metal bezel with unique Swarovski crystal, crystal numerals and hands stand out on an elegant white number background, luxurious gold-plated metal strap, for a chic touch Calendar for couples.')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (11, 3, N'CITIZEN ĐÔI – QUARTZ (PIN) – DÂY KIM LO?I (BD0040-57E – ER0200-59E)', 12000, 4, NULL, N'5', N'USA', N'https://i.ibb.co/KsBC41f/image.png', N'Citizen Couple Watches are designed with high-end fashion with strong black background dials, high-grade stainless steel and delicate 3 hands.')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (12, 2, N'CITIZEN DOUBLE - QUARTZ (PIN) - METAL STRAP (BI5032-56A - EU6032-51D)', 500, 9, NULL, N'5', N'JAPAN', N'https://i.ibb.co/0ZG7zhw/image.png', N'Citizen couple watches have metal bezel with unique Swarovski crystal, crystal numerals and hands stand out on an elegant white number background, luxurious gold-plated metal strap, for a chic touch Calendar for couples.')
INSERT [dbo].[Product] ([ID], [SupplierID], [name], [price], [quantities], [status], [warrantyTime], [originName], [img], [detail]) VALUES (13, 4, N'CITIZEN DOUBLE - QUARTZ (PIN) - METAL STRAP (BD0022-59A - ER0182-59A)', 6000, 0, NULL, N'24', N'THUY SY', N'https://i.ibb.co/RHjdZWt/image.png', N'Citizen watch high-end fashion with delicate gold dial, toughened glass, luxurious gold-plated stainless steel.')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([ID], [name]) VALUES (2, N'Employee')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([IDSup], [nameSup], [phoneSup], [emailSup], [addressSup]) VALUES (1, N'AVC', N'213123', N'123123', N'123')
INSERT [dbo].[Suppliers] ([IDSup], [nameSup], [phoneSup], [emailSup], [addressSup]) VALUES (2, N'POP', N'086865888', N'pop@gmail.com', N'can tho')
INSERT [dbo].[Suppliers] ([IDSup], [nameSup], [phoneSup], [emailSup], [addressSup]) VALUES (3, N'RVR', N'079647655', N'rvr@gmail.com', N'cang long')
INSERT [dbo].[Suppliers] ([IDSup], [nameSup], [phoneSup], [emailSup], [addressSup]) VALUES (4, N'SES', N'0747677777', N'ses@gmail.com', N'vinh long')
INSERT [dbo].[Suppliers] ([IDSup], [nameSup], [phoneSup], [emailSup], [addressSup]) VALUES (5, N'LPL', N'0575778867', N'lpl@gmail.com', N'can tho')
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([customerID])
REFERENCES [dbo].[Customer] ([IDCtm])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Categories_Product]  WITH CHECK ADD FOREIGN KEY([CategoriesID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Categories_Product]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([roleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([customerID])
REFERENCES [dbo].[Customer] ([IDCtm])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([employeeID])
REFERENCES [dbo].[Employee] ([IDEmp])
GO
ALTER TABLE [dbo].[Orders_Details]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([ID])
GO
ALTER TABLE [dbo].[Orders_Details]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Picture]  WITH CHECK ADD FOREIGN KEY([productID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([IDSup])
GO
