
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/16/2017 10:37:16
-- Generated from EDMX file: C:\Users\esergiex\Source\Repos\Cars\Dal\Model\Model2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RentCar];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserRentCar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_UserRentCar];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchCar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Branches] DROP CONSTRAINT [FK_BranchCar];
GO
IF OBJECT_ID(N'[dbo].[FK_CarTypeCar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_CarTypeCar];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Branches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Branches];
GO
IF OBJECT_ID(N'[dbo].[CarTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CarTypes];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Branches'
CREATE TABLE [dbo].[Branches] (
    [BranchId] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [GeoLocation] float  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Cars_CarId] int  NOT NULL
);
GO

-- Creating table 'CarTypes'
CREATE TABLE [dbo].[CarTypes] (
    [CarTypeID] int IDENTITY(1,1) NOT NULL,
    [Brand] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [PricePerDay] float  NOT NULL,
    [PriceExtra] float  NOT NULL,
    [Year] smallint  NOT NULL,
    [IsManual] bit  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [ID] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Birthday] datetime  NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [PicPath] nvarchar(max)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderID] int IDENTITY(1,1) NOT NULL,
    [Start] datetime  NOT NULL,
    [Finish] datetime  NULL,
    [Returned] datetime  NULL,
    [UserID] nvarchar(max)  NOT NULL,
    [User_UserId] int  NOT NULL
);
GO

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [CarId] int IDENTITY(1,1) NOT NULL,
    [KM] nvarchar(max)  NOT NULL,
    [CarPic] nvarchar(max)  NULL,
    [IsFix] bit  NOT NULL,
    [IsRentable] bit  NOT NULL,
    [CarNum] smallint  NOT NULL,
    [CarType_CarTypeID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BranchId] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [PK_Branches]
    PRIMARY KEY CLUSTERED ([BranchId] ASC);
GO

-- Creating primary key on [CarTypeID] in table 'CarTypes'
ALTER TABLE [dbo].[CarTypes]
ADD CONSTRAINT [PK_CarTypes]
    PRIMARY KEY CLUSTERED ([CarTypeID] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [OrderID] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderID] ASC);
GO

-- Creating primary key on [CarId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([CarId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_UserId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_UserRentCar]
    FOREIGN KEY ([User_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRentCar'
CREATE INDEX [IX_FK_UserRentCar]
ON [dbo].[Orders]
    ([User_UserId]);
GO

-- Creating foreign key on [Cars_CarId] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [FK_BranchCar]
    FOREIGN KEY ([Cars_CarId])
    REFERENCES [dbo].[Cars]
        ([CarId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchCar'
CREATE INDEX [IX_FK_BranchCar]
ON [dbo].[Branches]
    ([Cars_CarId]);
GO

-- Creating foreign key on [CarType_CarTypeID] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_CarTypeCar]
    FOREIGN KEY ([CarType_CarTypeID])
    REFERENCES [dbo].[CarTypes]
        ([CarTypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarTypeCar'
CREATE INDEX [IX_FK_CarTypeCar]
ON [dbo].[Cars]
    ([CarType_CarTypeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------