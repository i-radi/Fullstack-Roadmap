CREATE DATABASE NLog
GO

USE NLog
CREATE TABLE Logs(
    Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
    CreatedOn datetime NOT NULL,
    Message nvarchar(max),
);