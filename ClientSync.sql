IF EXISTS (SELECT * FROM sys.databases WHERE name = 'ClientSync')
BEGIN
    DROP DATABASE ClientSync;
END;
GO

CREATE DATABASE ClientSync;
GO

USE ClientSync;
GO

IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Customers;
END;
GO

CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    LastPurchaseDate DATETIME NULL,
    LastUpdateDate DATETIME NULL,
    Password NVARCHAR(128) NULL,
    Salt NVARCHAR(32) NULL
);

-- Insert sample data
INSERT INTO Customers (FirstName, LastName, Age, Location, LastPurchaseDate, LastUpdateDate, Password, Salt)
VALUES 
('John', 'Doe', 30, 'New York', '2024-03-01', '2024-03-10', NULL, NULL),
('Jane', 'Smith', 25, 'Los Angeles', '2024-02-15', '2024-03-05', NULL, NULL),
('Michael', 'Johnson', 40, 'Chicago', '2024-01-20', '2024-02-25', NULL, NULL);
('John', 'Miller', 28, 'New York', '2024-03-01', '2024-03-10', NULL, NULL), 
('Alice', 'Smith', 34, 'Los Angeles', '2024-02-25', '2024-03-12', NULL, NULL), 
('Michael', 'Michael', 40, 'Chicago', '2024-02-15', '2024-03-09', NULL, NULL), 
('Emma', 'Williams', 22, 'Houston', '2024-03-05', '2024-03-10', NULL, NULL), 
('Daniel', 'Brown', 30, 'San Francisco', '2024-03-08', '2024-03-12', NULL, NULL), 
('Sophia', 'Davis', 29, 'Seattle', '2025-02-18', '2025-03-11', NULL, NULL), 
('James', 'Miller', 36, 'Austin', '2025-03-03', '2025-03-13', NULL, NULL), 
('Olivia', 'Wilson', 25, 'Denver', '2025-03-07', '2025-03-14', NULL, NULL), 
('William', 'Moore', 45, 'Boston', '2025-01-29', '2025-03-08', NULL, NULL), 
('Isabella', 'Taylor', 32, 'Miami', '2025-02-10', '2025-03-12', NULL, NULL);
('Ethan', 'Anderson', 38, 'Dallas', '2024-03-02', '2024-03-13', NULL, NULL), 
('Charlotte', 'Thomas', 27, 'Philadelphia', '2024-03-06', '2024-03-10', NULL, NULL), 
('Mason', 'White', 35, 'San Diego', '2024-02-20', '2024-03-11', NULL, NULL), 
('Amelia', 'Harris', 23, 'Portland', '2024-03-09', '2024-03-15', NULL, NULL), 
('Lucas', 'Martin', 41, 'Phoenix', '2024-02-28', '2024-03-10', NULL, NULL), 
('Harper', 'Thompson', 26, 'San Antonio', '2024-03-04', '2024-03-12', NULL, NULL), 
('Henry', 'Garcia', 50, 'Las Vegas', '2024-02-14', '2024-03-09', NULL, NULL), 
('Evelyn', 'Martinez', 33, 'Orlando', '2024-02-26', '2024-03-11', NULL, NULL), 
('Alexander', 'Robinson', 37, 'Charlotte', '2024-03-08', '2024-03-14', NULL, NULL), 
('Scarlett', 'Clark', 28, 'Columbus', '2024-03-01', '2024-03-10', NULL, NULL), 

SELECT * FROM Customers;