USE [LINQ-Joins]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/14/2016 5:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustID] [int] NOT NULL,
	[Name] [varchar](100) NULL,
	[Address] [varchar](200) NULL,
	[ContactNo] [varchar](20) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2/14/2016 5:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NULL,
	[Price] [float] NULL,
	[CustomerID] [int] NULL,
	[ContactNo] [varchar](20) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2/14/2016 5:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] NOT NULL,
	[Name] [varchar](100) NULL,
	[UnitPrice] [float] NULL,
	[CatID] [int] NULL,
	[EntryDate] [datetime] NULL CONSTRAINT [DF_Product_EntryDate]  DEFAULT (getdate()),
	[ExpiryDate] [datetime] NULL CONSTRAINT [DF_Product_ExpiryDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Customer] ([CustID], [Name], [Address], [ContactNo]) VALUES (1, N'Sam', N'New Delhi', N'9555555555')
GO
INSERT [dbo].[Customer] ([CustID], [Name], [Address], [ContactNo]) VALUES (2, N'Rahul', N'Gurgaon', N'9666666666')
GO
INSERT [dbo].[Customer] ([CustID], [Name], [Address], [ContactNo]) VALUES (3, N'Hans', N'Noida', N'9444444444')
GO
INSERT [dbo].[Customer] ([CustID], [Name], [Address], [ContactNo]) VALUES (4, N'Jeetu', N'Delhi', N'9333333333')
GO
INSERT [dbo].[Customer] ([CustID], [Name], [Address], [ContactNo]) VALUES (5, N'Ankit', N'Noida', N'9222222222')
GO
INSERT [dbo].[Customer] ([CustID], [Name], [Address], [ContactNo]) VALUES (6, N'Deepak', N'Delhi', N'9222222222')
GO
INSERT [dbo].[Order] ([OrderID], [ProductID], [Quantity], [Price], [CustomerID], [ContactNo]) VALUES (1, 1, 6, 80000, 1, N'9555555555')
GO
INSERT [dbo].[Order] ([OrderID], [ProductID], [Quantity], [Price], [CustomerID], [ContactNo]) VALUES (2, 2, 4, 80000, 2, N'7676565656')
GO
INSERT [dbo].[Order] ([OrderID], [ProductID], [Quantity], [Price], [CustomerID], [ContactNo]) VALUES (3, 2, 2, 40000, 3, N'9444444444')
GO
INSERT [dbo].[Order] ([OrderID], [ProductID], [Quantity], [Price], [CustomerID], [ContactNo]) VALUES (4, 3, 5, 60000, 4, N'9333333333')
GO
INSERT [dbo].[Order] ([OrderID], [ProductID], [Quantity], [Price], [CustomerID], [ContactNo]) VALUES (5, 5, 1, 35000, 5, N'9666666666')
GO
INSERT [dbo].[Order] ([OrderID], [ProductID], [Quantity], [Price], [CustomerID], [ContactNo]) VALUES (6, 8, 1, 60000, 1, N'9666666666')
GO
INSERT [dbo].[Order] ([OrderID], [ProductID], [Quantity], [Price], [CustomerID], [ContactNo]) VALUES (7, 6, 3, 60000, 2, N'9666666666')
GO
INSERT [dbo].[Product] ([ProductID], [Name], [UnitPrice], [CatID], [EntryDate], [ExpiryDate]) VALUES (1, N'Dell Computer', 25000, 1, CAST(N'2012-10-16 23:05:05.550' AS DateTime), CAST(N'2012-10-16 23:05:05.550' AS DateTime))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [UnitPrice], [CatID], [EntryDate], [ExpiryDate]) VALUES (2, N'HCL Computer', 20000, 1, CAST(N'2012-10-16 23:05:46.990' AS DateTime), CAST(N'2012-10-16 23:05:46.990' AS DateTime))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [UnitPrice], [CatID], [EntryDate], [ExpiryDate]) VALUES (3, N'Apple Mobile', 40000, 3, CAST(N'2012-10-16 23:06:11.283' AS DateTime), CAST(N'2012-10-16 23:06:11.283' AS DateTime))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [UnitPrice], [CatID], [EntryDate], [ExpiryDate]) VALUES (4, N'Samsung Mobile', 25000, 3, CAST(N'2012-10-16 23:06:28.727' AS DateTime), CAST(N'2012-10-16 23:06:28.727' AS DateTime))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [UnitPrice], [CatID], [EntryDate], [ExpiryDate]) VALUES (5, N'Sony Laptop', 35000, 2, CAST(N'2012-10-16 23:06:52.143' AS DateTime), CAST(N'2012-10-16 23:06:52.143' AS DateTime))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [UnitPrice], [CatID], [EntryDate], [ExpiryDate]) VALUES (6, N'Dell Laptop', 36000, 2, CAST(N'2012-10-16 23:07:07.380' AS DateTime), CAST(N'2012-10-16 23:07:07.380' AS DateTime))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [UnitPrice], [CatID], [EntryDate], [ExpiryDate]) VALUES (7, N'HP Printer', 12000, 4, CAST(N'2012-10-16 23:07:35.010' AS DateTime), CAST(N'2012-10-16 23:07:35.010' AS DateTime))
GO
INSERT [dbo].[Product] ([ProductID], [Name], [UnitPrice], [CatID], [EntryDate], [ExpiryDate]) VALUES (8, N'Canon Printer', 10000, 4, CAST(N'2012-10-16 23:07:54.213' AS DateTime), CAST(N'2012-10-16 23:07:54.213' AS DateTime))
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
