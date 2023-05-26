
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/14/2020 00:01:24
-- Generated from EDMX file: C:\Users\Radi\source\repos\Courses-Center-App-master\Center Application\DB\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbCoursesCenter];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StudentsDetails_tbCourses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentsDetails] DROP CONSTRAINT [FK_StudentsDetails_tbCourses];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentsDetails_tbStudents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentsDetails] DROP CONSTRAINT [FK_StudentsDetails_tbStudents];
GO
IF OBJECT_ID(N'[dbo].[FK_tbCourses_tbCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbCourses] DROP CONSTRAINT [FK_tbCourses_tbCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_tbCourses_tbEmployees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbCourses] DROP CONSTRAINT [FK_tbCourses_tbEmployees];
GO
IF OBJECT_ID(N'[dbo].[FK_tbCourses_tbUsers1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tbCourses] DROP CONSTRAINT [FK_tbCourses_tbUsers1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StudentsDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentsDetails];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[tbCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbCategory];
GO
IF OBJECT_ID(N'[dbo].[tbCourses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbCourses];
GO
IF OBJECT_ID(N'[dbo].[tbEmployees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbEmployees];
GO
IF OBJECT_ID(N'[dbo].[tbStudents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbStudents];
GO
IF OBJECT_ID(N'[dbo].[tbUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbUsers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tbCategories'
CREATE TABLE [dbo].[tbCategories] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [categoryName] nvarchar(50)  NULL
);
GO

-- Creating table 'tbCourses'
CREATE TABLE [dbo].[tbCourses] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Price] decimal(18,0)  NULL,
    [Instructor] nvarchar(50)  NULL,
    [Notes] nvarchar(50)  NULL,
    [Image] nvarchar(max)  NULL,
    [Categoryid] int  NULL,
    [Employeesid] int  NULL,
    [Usersid] int  NULL,
    [courseName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tbEmployees'
CREATE TABLE [dbo].[tbEmployees] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Notes] nvarchar(max)  NULL,
    [Occuption] nvarchar(50)  NULL,
    [Salary] decimal(18,0)  NULL,
    [Image] nvarchar(max)  NULL,
    [employeeName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tbStudents'
CREATE TABLE [dbo].[tbStudents] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Notes] nvarchar(max)  NULL,
    [Image] nvarchar(max)  NULL,
    [studentName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'tbUsers'
CREATE TABLE [dbo].[tbUsers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [Image] nvarchar(max)  NULL,
    [Email] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'StudentsDetails'
CREATE TABLE [dbo].[StudentsDetails] (
    [StudentId] int  NULL,
    [CoursesId] int  NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'tbCategories'
ALTER TABLE [dbo].[tbCategories]
ADD CONSTRAINT [PK_tbCategories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tbCourses'
ALTER TABLE [dbo].[tbCourses]
ADD CONSTRAINT [PK_tbCourses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tbEmployees'
ALTER TABLE [dbo].[tbEmployees]
ADD CONSTRAINT [PK_tbEmployees]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tbStudents'
ALTER TABLE [dbo].[tbStudents]
ADD CONSTRAINT [PK_tbStudents]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tbUsers'
ALTER TABLE [dbo].[tbUsers]
ADD CONSTRAINT [PK_tbUsers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'StudentsDetails'
ALTER TABLE [dbo].[StudentsDetails]
ADD CONSTRAINT [PK_StudentsDetails]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Categoryid] in table 'tbCourses'
ALTER TABLE [dbo].[tbCourses]
ADD CONSTRAINT [FK_tbCourses_tbCategory]
    FOREIGN KEY ([Categoryid])
    REFERENCES [dbo].[tbCategories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbCourses_tbCategory'
CREATE INDEX [IX_FK_tbCourses_tbCategory]
ON [dbo].[tbCourses]
    ([Categoryid]);
GO

-- Creating foreign key on [CoursesId] in table 'StudentsDetails'
ALTER TABLE [dbo].[StudentsDetails]
ADD CONSTRAINT [FK_StudentsDetails_tbCourses]
    FOREIGN KEY ([CoursesId])
    REFERENCES [dbo].[tbCourses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentsDetails_tbCourses'
CREATE INDEX [IX_FK_StudentsDetails_tbCourses]
ON [dbo].[StudentsDetails]
    ([CoursesId]);
GO

-- Creating foreign key on [StudentId] in table 'StudentsDetails'
ALTER TABLE [dbo].[StudentsDetails]
ADD CONSTRAINT [FK_StudentsDetails_tbStudents]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[tbStudents]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentsDetails_tbStudents'
CREATE INDEX [IX_FK_StudentsDetails_tbStudents]
ON [dbo].[StudentsDetails]
    ([StudentId]);
GO

-- Creating foreign key on [Employeesid] in table 'tbCourses'
ALTER TABLE [dbo].[tbCourses]
ADD CONSTRAINT [FK_tbCourses_tbEmployees]
    FOREIGN KEY ([Employeesid])
    REFERENCES [dbo].[tbEmployees]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbCourses_tbEmployees'
CREATE INDEX [IX_FK_tbCourses_tbEmployees]
ON [dbo].[tbCourses]
    ([Employeesid]);
GO

-- Creating foreign key on [Usersid] in table 'tbCourses'
ALTER TABLE [dbo].[tbCourses]
ADD CONSTRAINT [FK_tbCourses_tbUsers1]
    FOREIGN KEY ([Usersid])
    REFERENCES [dbo].[tbUsers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tbCourses_tbUsers1'
CREATE INDEX [IX_FK_tbCourses_tbUsers1]
ON [dbo].[tbCourses]
    ([Usersid]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------