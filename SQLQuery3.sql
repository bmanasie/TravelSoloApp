
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/06/2019 22:58:56
-- Generated from EDMX file: C:\Users\manasie\source\repos\TravelSoloApp\TravelSoloApp\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-TravelSoloApp-20191003015014];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookingBookingFeedback]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingFeedbacks] DROP CONSTRAINT [FK_BookingBookingFeedback];
GO
IF OBJECT_ID(N'[dbo].[FK_TripBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_TripBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserTrip_AspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserTrip] DROP CONSTRAINT [FK_AspNetUserTrip_AspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserTrip_Trip]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserTrip] DROP CONSTRAINT [FK_AspNetUserTrip_Trip];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_AspNetUserBooking];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Trips]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trips];
GO
IF OBJECT_ID(N'[dbo].[BookingFeedbacks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingFeedbacks];
GO
IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[ContactUs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactUs];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserTrip]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserTrip];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Trips'
CREATE TABLE [dbo].[Trips] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Destination] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [TripCrafterId] nvarchar(max)  NOT NULL,
    [Category] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BookingFeedbacks'
CREATE TABLE [dbo].[BookingFeedbacks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rating] smallint  NOT NULL,
    [BookingId] nvarchar(max)  NOT NULL,
    [Booking_Id] int  NOT NULL
);
GO

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BookingDate] datetime  NOT NULL,
    [TripId] int  NOT NULL,
    [AspNetUserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'ContactUs'
CREATE TABLE [dbo].[ContactUs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [UserEmailId] nvarchar(max)  NOT NULL,
    [Message] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [Name] varchar(255)  NULL,
    [UserRole] varchar(255)  NULL
);
GO

-- Creating table 'Points'
CREATE TABLE [dbo].[Points] (
    [x] nvarchar(max)  NOT NULL,
    [y] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AspNetUserTrip'
CREATE TABLE [dbo].[AspNetUserTrip] (
    [AspNetUsers_Id] nvarchar(128)  NOT NULL,
    [Trips_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Trips'
ALTER TABLE [dbo].[Trips]
ADD CONSTRAINT [PK_Trips]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BookingFeedbacks'
ALTER TABLE [dbo].[BookingFeedbacks]
ADD CONSTRAINT [PK_BookingFeedbacks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContactUs'
ALTER TABLE [dbo].[ContactUs]
ADD CONSTRAINT [PK_ContactUs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [x] in table 'Points'
ALTER TABLE [dbo].[Points]
ADD CONSTRAINT [PK_Points]
    PRIMARY KEY CLUSTERED ([x] ASC);
GO

-- Creating primary key on [AspNetUsers_Id], [Trips_Id] in table 'AspNetUserTrip'
ALTER TABLE [dbo].[AspNetUserTrip]
ADD CONSTRAINT [PK_AspNetUserTrip]
    PRIMARY KEY CLUSTERED ([AspNetUsers_Id], [Trips_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Booking_Id] in table 'BookingFeedbacks'
ALTER TABLE [dbo].[BookingFeedbacks]
ADD CONSTRAINT [FK_BookingBookingFeedback]
    FOREIGN KEY ([Booking_Id])
    REFERENCES [dbo].[Bookings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingBookingFeedback'
CREATE INDEX [IX_FK_BookingBookingFeedback]
ON [dbo].[BookingFeedbacks]
    ([Booking_Id]);
GO

-- Creating foreign key on [TripId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_TripBooking]
    FOREIGN KEY ([TripId])
    REFERENCES [dbo].[Trips]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TripBooking'
CREATE INDEX [IX_FK_TripBooking]
ON [dbo].[Bookings]
    ([TripId]);
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserTrip'
ALTER TABLE [dbo].[AspNetUserTrip]
ADD CONSTRAINT [FK_AspNetUserTrip_AspNetUser]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Trips_Id] in table 'AspNetUserTrip'
ALTER TABLE [dbo].[AspNetUserTrip]
ADD CONSTRAINT [FK_AspNetUserTrip_Trip]
    FOREIGN KEY ([Trips_Id])
    REFERENCES [dbo].[Trips]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserTrip_Trip'
CREATE INDEX [IX_FK_AspNetUserTrip_Trip]
ON [dbo].[AspNetUserTrip]
    ([Trips_Id]);
GO

-- Creating foreign key on [AspNetUserId] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_AspNetUserBooking]
    FOREIGN KEY ([AspNetUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserBooking'
CREATE INDEX [IX_FK_AspNetUserBooking]
ON [dbo].[Bookings]
    ([AspNetUserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------