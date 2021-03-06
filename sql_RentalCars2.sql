USE [master]
GO
/****** Object:  Database [RentalCars]    Script Date: 11/11/2020 20:00:13 ******/
CREATE DATABASE [RentalCars]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RentalCars', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RentalCars.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RentalCars_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\RentalCars_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RentalCars] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RentalCars].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RentalCars] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RentalCars] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RentalCars] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RentalCars] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RentalCars] SET ARITHABORT OFF 
GO
ALTER DATABASE [RentalCars] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RentalCars] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RentalCars] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RentalCars] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RentalCars] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RentalCars] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RentalCars] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RentalCars] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RentalCars] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RentalCars] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RentalCars] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RentalCars] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RentalCars] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RentalCars] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RentalCars] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RentalCars] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RentalCars] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RentalCars] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RentalCars] SET  MULTI_USER 
GO
ALTER DATABASE [RentalCars] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RentalCars] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RentalCars] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RentalCars] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RentalCars] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RentalCars] SET QUERY_STORE = OFF
GO
USE [RentalCars]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 11/11/2020 20:00:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[BranchAddress] [nvarchar](50) NOT NULL,
	[BranchLocation] [int] NOT NULL,
	[BranchName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 11/11/2020 20:00:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[RentalCode] [int] IDENTITY(1,1) NOT NULL,
	[PickupDate] [date] NOT NULL,
	[EstimatedReturnDate] [date] NOT NULL,
	[ActualReturnDate] [date] NULL,
	[UserID] [int] NOT NULL,
	[VehicleID] [int] NOT NULL,
	[Model] [nvarchar](50) NULL,
	[Manufacturer] [nvarchar](50) NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED 
(
	[RentalCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/11/2020 20:00:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleTitle] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/11/2020 20:00:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[FirstName] [nchar](10) NOT NULL,
	[LastName] [nchar](10) NOT NULL,
	[UserIDNumber] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Gender] [nchar](10) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 11/11/2020 20:00:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleID] [int] IDENTITY(1,1) NOT NULL,
	[VehicleTypeID] [int] NOT NULL,
	[Mileage] [int] NOT NULL,
	[RentingProper] [bit] NOT NULL,
	[RentingAvailibility] [bit] NOT NULL,
	[RegistrationNumber] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
	[CarImage] [nvarchar](50) NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleTypes]    Script Date: 11/11/2020 20:00:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleTypes](
	[VehicleTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Manufacturer] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[DailyFee] [money] NOT NULL,
	[OverdueFee] [money] NOT NULL,
	[ProductionYear] [date] NOT NULL,
	[GearType] [nchar](10) NOT NULL,
 CONSTRAINT [PK_VehicleTypes] PRIMARY KEY CLUSTERED 
(
	[VehicleTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Branches] ON 

INSERT [dbo].[Branches] ([BranchID], [BranchAddress], [BranchLocation], [BranchName]) VALUES (1, N'Ben Gurion Airport, Terminal 1', 78, N'Tropic Trip Airport')
INSERT [dbo].[Branches] ([BranchID], [BranchAddress], [BranchLocation], [BranchName]) VALUES (5, N'Yeffet', 98, N'Tropical Car Jaffa')
INSERT [dbo].[Branches] ([BranchID], [BranchAddress], [BranchLocation], [BranchName]) VALUES (6, N'Herbert Samuel ', 56, N'Tropical Port TLV')
INSERT [dbo].[Branches] ([BranchID], [BranchAddress], [BranchLocation], [BranchName]) VALUES (7, N'Kalaniyot', 12, N'Tropical Aqua Eilat')
SET IDENTITY_INSERT [dbo].[Branches] OFF
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([RentalCode], [PickupDate], [EstimatedReturnDate], [ActualReturnDate], [UserID], [VehicleID], [Model], [Manufacturer]) VALUES (1024, CAST(N'2020-05-01' AS Date), CAST(N'2020-05-06' AS Date), CAST(N'2020-05-08' AS Date), 19, 2, NULL, NULL)
INSERT [dbo].[Rentals] ([RentalCode], [PickupDate], [EstimatedReturnDate], [ActualReturnDate], [UserID], [VehicleID], [Model], [Manufacturer]) VALUES (1029, CAST(N'2020-04-03' AS Date), CAST(N'2020-04-06' AS Date), NULL, 1028, 4, NULL, NULL)
INSERT [dbo].[Rentals] ([RentalCode], [PickupDate], [EstimatedReturnDate], [ActualReturnDate], [UserID], [VehicleID], [Model], [Manufacturer]) VALUES (1035, CAST(N'2020-04-18' AS Date), CAST(N'2020-04-17' AS Date), NULL, 19, 2, NULL, NULL)
INSERT [dbo].[Rentals] ([RentalCode], [PickupDate], [EstimatedReturnDate], [ActualReturnDate], [UserID], [VehicleID], [Model], [Manufacturer]) VALUES (1036, CAST(N'2020-02-02' AS Date), CAST(N'2020-02-02' AS Date), NULL, 8, 1, NULL, NULL)
INSERT [dbo].[Rentals] ([RentalCode], [PickupDate], [EstimatedReturnDate], [ActualReturnDate], [UserID], [VehicleID], [Model], [Manufacturer]) VALUES (1037, CAST(N'2020-02-02' AS Date), CAST(N'2020-02-02' AS Date), NULL, 1031, 1, NULL, NULL)
INSERT [dbo].[Rentals] ([RentalCode], [PickupDate], [EstimatedReturnDate], [ActualReturnDate], [UserID], [VehicleID], [Model], [Manufacturer]) VALUES (1038, CAST(N'2020-02-18' AS Date), CAST(N'2020-02-16' AS Date), NULL, 8, 0, NULL, N'Toyota')
INSERT [dbo].[Rentals] ([RentalCode], [PickupDate], [EstimatedReturnDate], [ActualReturnDate], [UserID], [VehicleID], [Model], [Manufacturer]) VALUES (1039, CAST(N'2020-08-04' AS Date), CAST(N'2020-08-02' AS Date), NULL, 9, 0, N'Corolla', N'BMW')
INSERT [dbo].[Rentals] ([RentalCode], [PickupDate], [EstimatedReturnDate], [ActualReturnDate], [UserID], [VehicleID], [Model], [Manufacturer]) VALUES (1040, CAST(N'2020-02-16' AS Date), CAST(N'2020-02-10' AS Date), NULL, 15, 0, NULL, N'Chevrolet')
INSERT [dbo].[Rentals] ([RentalCode], [PickupDate], [EstimatedReturnDate], [ActualReturnDate], [UserID], [VehicleID], [Model], [Manufacturer]) VALUES (1041, CAST(N'2020-05-06' AS Date), CAST(N'2020-05-09' AS Date), NULL, 8, 0, NULL, N'Toyota')
INSERT [dbo].[Rentals] ([RentalCode], [PickupDate], [EstimatedReturnDate], [ActualReturnDate], [UserID], [VehicleID], [Model], [Manufacturer]) VALUES (1042, CAST(N'2020-02-02' AS Date), CAST(N'2020-02-02' AS Date), NULL, 1028, 0, NULL, N'Ferrari')
INSERT [dbo].[Rentals] ([RentalCode], [PickupDate], [EstimatedReturnDate], [ActualReturnDate], [UserID], [VehicleID], [Model], [Manufacturer]) VALUES (1043, CAST(N'2020-04-04' AS Date), CAST(N'2020-02-02' AS Date), NULL, 1028, 0, NULL, N'Porsche')
SET IDENTITY_INSERT [dbo].[Rentals] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleTitle]) VALUES (1, N'User')
INSERT [dbo].[Roles] ([RoleID], [RoleTitle]) VALUES (2, N'Employee')
INSERT [dbo].[Roles] ([RoleID], [RoleTitle]) VALUES (3, N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (8, 1, N'Mary      ', N'Dance     ', 0, N'maryd', CAST(N'1980-01-31' AS Date), N'male      ', N'mary@gmail.com', N'123456', NULL)
INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (9, 1, N'Otto      ', N'Anderson  ', 0, N'ottoanderson', CAST(N'1985-01-31' AS Date), N'female    ', N'otto_and@gmail.com', N'123456', NULL)
INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (15, 1, N'Chloe     ', N'France    ', 0, N'ooollll', CAST(N'1955-05-05' AS Date), N'male      ', N'oo@gmail.com', N'123456', NULL)
INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (18, 2, N'Chloe     ', N'Dance     ', 0, N'ooollll', CAST(N'1933-03-03' AS Date), N'male      ', N'kk.france@gmail.com', N'123456', NULL)
INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (19, 2, N'kk        ', N'Dance     ', 0, N'ginaf', CAST(N'1955-05-05' AS Date), N'male      ', N'rr@gmail.com', N'123456', NULL)
INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (20, 1, N'kk        ', N'Dance     ', 0, N'ooollll', CAST(N'1966-06-06' AS Date), N'male      ', N'tommy@gmail.com', N'125478', NULL)
INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (23, 1, N'kk        ', N'Dance     ', 0, N'maryd', CAST(N'1999-09-09' AS Date), N'female    ', N'tommy@gmail.com', N'123456', NULL)
INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (1027, 3, N'Rose      ', N'Menta     ', 0, N'menta', CAST(N'1986-09-07' AS Date), N'male      ', N'rose@gmail.com', N'123456', NULL)
INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (1028, 3, N'Admin2    ', N'AdminsLN  ', 0, N'AdminsFN', CAST(N'1987-07-07' AS Date), N'female    ', N'admin@gmail.com', N'7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL)
INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (1031, 1, N'newUserFN ', N'newUserLN ', 0, N'newUser', CAST(N'1966-06-06' AS Date), N'male      ', N'newUser@gmail.com', N'7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL)
INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (1032, 1, N'user5     ', N'user5     ', 0, N'user5', CAST(N'1966-06-06' AS Date), N'male      ', N'user5@gmail.com', N'7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL)
INSERT [dbo].[Users] ([UserID], [RoleID], [FirstName], [LastName], [UserIDNumber], [UserName], [BirthDate], [Gender], [Email], [Password], [Image]) VALUES (1033, 1, N'ginger    ', N'ginger    ', 0, N'ginger', CAST(N'1965-06-08' AS Date), N'female    ', N'ginger@gmail.com', N'7C4A8D09CA3762AF61E59520943DC26494F8941B', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Vehicles] ON 

INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [Mileage], [RentingProper], [RentingAvailibility], [RegistrationNumber], [BranchID], [CarImage]) VALUES (1, 1, 1500, 1, 1, 659874, 1, NULL)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [Mileage], [RentingProper], [RentingAvailibility], [RegistrationNumber], [BranchID], [CarImage]) VALUES (2, 4, 1600, 1, 1, 235689, 5, NULL)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [Mileage], [RentingProper], [RentingAvailibility], [RegistrationNumber], [BranchID], [CarImage]) VALUES (3, 5, 1700, 1, 1, 124578, 1, NULL)
INSERT [dbo].[Vehicles] ([VehicleID], [VehicleTypeID], [Mileage], [RentingProper], [RentingAvailibility], [RegistrationNumber], [BranchID], [CarImage]) VALUES (4, 6, 1800, 1, 1, 987654, 7, NULL)
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
SET IDENTITY_INSERT [dbo].[VehicleTypes] ON 

INSERT [dbo].[VehicleTypes] ([VehicleTypeID], [Manufacturer], [Model], [DailyFee], [OverdueFee], [ProductionYear], [GearType]) VALUES (1, N'Toyota', N'Corolla', 350.0000, 150.0000, CAST(N'2017-01-01' AS Date), N'auto      ')
INSERT [dbo].[VehicleTypes] ([VehicleTypeID], [Manufacturer], [Model], [DailyFee], [OverdueFee], [ProductionYear], [GearType]) VALUES (4, N'BMW', N'i8', 1000.0000, 1300.0000, CAST(N'2017-02-02' AS Date), N'auto      ')
INSERT [dbo].[VehicleTypes] ([VehicleTypeID], [Manufacturer], [Model], [DailyFee], [OverdueFee], [ProductionYear], [GearType]) VALUES (5, N'Mercedes Benz', N'SLS', 1500.0000, 1800.0000, CAST(N'2018-05-05' AS Date), N'auto      ')
INSERT [dbo].[VehicleTypes] ([VehicleTypeID], [Manufacturer], [Model], [DailyFee], [OverdueFee], [ProductionYear], [GearType]) VALUES (6, N'Chevrolet', N'Corvett C6', 1000.0000, 1300.0000, CAST(N'2019-01-01' AS Date), N'auto      ')
INSERT [dbo].[VehicleTypes] ([VehicleTypeID], [Manufacturer], [Model], [DailyFee], [OverdueFee], [ProductionYear], [GearType]) VALUES (1004, N'Ferrari', N'GTC4Lusso T', 1800.0000, 2300.0000, CAST(N'2016-01-01' AS Date), N'auto      ')
INSERT [dbo].[VehicleTypes] ([VehicleTypeID], [Manufacturer], [Model], [DailyFee], [OverdueFee], [ProductionYear], [GearType]) VALUES (2007, N'Porsche', N'Carrera', 2800.0000, 3500.0000, CAST(N'2017-08-08' AS Date), N'auto      ')
INSERT [dbo].[VehicleTypes] ([VehicleTypeID], [Manufacturer], [Model], [DailyFee], [OverdueFee], [ProductionYear], [GearType]) VALUES (2008, N'Ferrari', N'Testa Rosa', 2000.0000, 2300.0000, CAST(N'1958-01-01' AS Date), N'manual    ')
INSERT [dbo].[VehicleTypes] ([VehicleTypeID], [Manufacturer], [Model], [DailyFee], [OverdueFee], [ProductionYear], [GearType]) VALUES (2009, N'Bugatti', N'Atlantic 157 SC', 25000.0000, 25000.0000, CAST(N'1938-01-01' AS Date), N'manual    ')
INSERT [dbo].[VehicleTypes] ([VehicleTypeID], [Manufacturer], [Model], [DailyFee], [OverdueFee], [ProductionYear], [GearType]) VALUES (2010, N'Toyota', N'Lexus LC', 1850.0000, 2000.0000, CAST(N'2020-01-01' AS Date), N'hybrid    ')
SET IDENTITY_INSERT [dbo].[VehicleTypes] OFF
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD  CONSTRAINT [FK_Roles_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Roles] CHECK CONSTRAINT [FK_Roles_Roles]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Branches] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branches] ([BranchID])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Branches]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_VehicleTypes] FOREIGN KEY([VehicleTypeID])
REFERENCES [dbo].[VehicleTypes] ([VehicleTypeID])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_VehicleTypes]
GO
/****** Object:  StoredProcedure [dbo].[GetAvailableCars]    Script Date: 11/11/2020 20:00:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAvailableCars] (@startDate date ,@endDate date) as
select [VehicleID], [ProductionYear], [DailyFee], [OverdueFee], [Model], [Manufacturer], [GearType], [CarImage]
from [dbo].[Vehicles] join [dbo].[VehicleTypes] on VehicleTypes.VehicleTypeID = Vehicles.VehicleTypeID
where [RentingProper] = 1
and VehicleID not in ( select VehicleID from Rentals where
( [PickupDate] <= @startDate and [EstimatedReturnDate] >= @startDate)
or ([PickupDate] <= @endDate and [EstimatedReturnDate] >= @endDate)
or ([PickupDate] >= @startDate and [EstimatedReturnDate] <= @endDate))
GO
/****** Object:  StoredProcedure [dbo].[GetAvailableCars2]    Script Date: 11/11/2020 20:00:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAvailableCars2](@pickupDate date, @estimatedReturnDate date) as
select GearType, Manufacturer, ProductionYear, Model, VehicleID, CarImage, DailyFee, OverdueFee, BranchID 
from VehicleTypes join Vehicles on VehicleTypes.VehicleTypeID=Vehicles.VehicleTypeID

where RentingProper=1 and VehicleID not in (Select VehicleID from Rentals where
(pickupDate <= @pickupDate and estimatedReturnDate >= @estimatedReturnDate) or
(pickupDate <= @estimatedReturnDate and estimatedReturnDate >= @estimatedReturnDate) or
(pickupDate >= @pickupDate and estimatedReturnDate <= @estimatedReturnDate))
GO
USE [master]
GO
ALTER DATABASE [RentalCars] SET  READ_WRITE 
GO
