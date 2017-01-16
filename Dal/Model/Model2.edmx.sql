
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/15/2017 20:50:53
-- Generated from EDMX file: C:\Users\orang\Documents\Visual Studio 2015\Projects\WebApplication1\WebApplication1\Dal\Model\Model2.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Brand] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [PricePerDay] float  NOT NULL,
    [PriceExtra] float  NOT NULL,
    [Year] datetime  NOT NULL,
    [IsManual] bit  NOT NULL,
    [KM] smallint  NOT NULL,
    [Picture] nvarchar(max)  NOT NULL,
    [IsCarReadyToRent] bit  NOT NULL,
    [IsCarAvailable] bit  NOT NULL,
    [CarNum] smallint  NOT NULL,
    [BranchID] nvarchar(max)  NOT NULL,
    [Branch_BranchId] int  NOT NULL
);
GO

-- Creating table 'Branches'
CREATE TABLE [dbo].[Branches] (
    [BranchId] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [GeoLocation] float  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BranchId] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [PK_Branches]
    PRIMARY KEY CLUSTERED ([BranchId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Branch_BranchId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_BranchCar]
    FOREIGN KEY ([Branch_BranchId])
    REFERENCES [dbo].[Branches]
        ([BranchId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchCar'
CREATE INDEX [IX_FK_BranchCar]
ON [dbo].[Cars]
    ([Branch_BranchId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------