La BD
-- Crear la base de datos
CREATE DATABASE FamilyFinancesDb;
USE FamilyFinancesDb;

-- Crear la tabla Roles
CREATE TABLE [dbo].[Roles] (
    [RolId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(250) NULL,
    [CreationDate] DATETIME NULL DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1
);

-- Crear la tabla Users
CREATE TABLE [dbo].[Users] (
    [UserName] VARCHAR(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY,
    [Password] NVARCHAR(500) NULL,
    [Email] VARCHAR(70) NOT NULL UNIQUE,
    [JwtToken] NVARCHAR(500) NULL,
    [CreationDate] DATETIME NULL DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1,
    [RolId] INT NOT NULL
);

-- Crear la tabla Families
CREATE TABLE [dbo].[Families] (
    [FamilyId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL,
    [Address] VARCHAR(250) NULL,
    [PhoneNumber] VARCHAR(20) NULL,
    [CreationDate] DATETIME DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1
);

-- Crear la tabla Members
CREATE TABLE [dbo].[Members] (
    [MemberId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(70) NOT NULL,
    [Gender] VARCHAR(20) NULL,
    [PhoneNumber] VARCHAR(20) NULL,
    [Position] VARCHAR(20) NULL,
    [Occupation] VARCHAR(50) NULL,
    [CreationDate] DATETIME DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1,
    [Userid] VARCHAR(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL UNIQUE,
    [FamilyId] INT NOT NULL
);

-- Crear la tabla IncomeSources
CREATE TABLE [dbo].[IncomeSources] (
    [IncomeSourceId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Description] NVARCHAR(500) NOT NULL,
    [Icon] VARCHAR(10) NULL DEFAULT 'IncomeSource.png',
    [CreationDate] DATETIME NULL DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1
);

-- Crear la tabla Incomes
CREATE TABLE [dbo].[Incomes] (
    [IncomeId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Date] DATETIME NULL,
    [Name] VARCHAR(100) NOT NULL,
    [Amount] DECIMAL(18,2) NOT NULL,
    [Details] NVARCHAR(250) NULL,
    [CreationDate] DATETIME NULL DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1,
    [MemberId] INT NOT NULL,
    [IncomeSourceId] INT NOT NULL
   
);

-- Crear la tabla ExpenseCategories
CREATE TABLE [dbo].[ExpenseCategories] (
    [ExpenseCategoryId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Description] NVARCHAR(500) NOT NULL,
    [Icon] VARCHAR(10) NULL DEFAULT 'Category.png',
    [CreationDate] DATETIME NULL DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1
);

-- Crear la tabla Expenses
CREATE TABLE [dbo].[Expenses] (
    [ExpenseId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Date] DATETIME NULL,
    [Name] VARCHAR(100) NOT NULL,
    [Amount] DECIMAL(18,2) NOT NULL,
    [Details] NVARCHAR(250) NULL,
    [CreationDate] DATETIME NULL DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1,
    [MemberId] INT NOT NULL,
    [ExpenseCategoryId] INT NOT NULL

);

-- Crear la tabla SavingsBags
CREATE TABLE [dbo].[SavingsBags] (
    [SavingBagId] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE,
    [IdealAmount] DECIMAL(18, 2) NOT NULL,
    [Purpose] NVARCHAR(255),
    [Status] NVARCHAR(50),
    [CreationDate] DATETIME NULL DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1,
    [FamilyId] INT NOT NULL
);

-- Crear la tabla Contributions
CREATE TABLE [dbo].[Contributions] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,    
    [Amount] DECIMAL(18, 2) NOT NULL,  
    [DateContributed] DATE NOT NULL,
    [CreationDate] DATETIME NULL DEFAULT GETDATE(),
    [IsActive] BIT NOT NULL DEFAULT 1,
    [SavingsBagId] INT NOT NULL,
    [MemberId] INT NOT NULL,
    [IncomeId] INT NOT NULL,
    [ExpenseId] INT NULL,
  
);

-- Crear la clave foránea entre Users y Roles
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Roles FOREIGN KEY (RolId)
REFERENCES Roles(RolId);

-- Crear la clave foránea opcional entre Members y Users
ALTER TABLE Members
ADD CONSTRAINT FK_Members_Users FOREIGN KEY (UserId)
REFERENCES Users(UserName);

-- Crear la clave foránea entre Members y Families
ALTER TABLE Members
ADD CONSTRAINT FK_Members_Families FOREIGN KEY (FamilyId)
REFERENCES Families(FamilyId);

-- Crear la clave foránea entre Incomes y Members
ALTER TABLE Incomes
ADD CONSTRAINT FK_Incomes_Members FOREIGN KEY (MemberId)
REFERENCES Members(MemberId);

-- Crear la clave foránea entre Incomes y IncomeSources
ALTER TABLE Incomes
ADD CONSTRAINT FK_Incomes_IncomeSources FOREIGN KEY (IncomeSourceId)
REFERENCES IncomeSources(IncomeSourceId);

-- Crear la clave foránea entre Expenses y Members
ALTER TABLE Expenses
ADD CONSTRAINT FK_Expenses_Members FOREIGN KEY (MemberId)
REFERENCES Members(MemberId);

-- Crear la clave foránea entre Expenses y ExpenseCategories
ALTER TABLE Expenses
ADD CONSTRAINT FK_Expenses_ExpenseCategories FOREIGN KEY (ExpenseCategoryId)
REFERENCES ExpenseCategories(ExpenseCategoryId);

-- Crear la clave foránea entre SavingsBags y Families
ALTER TABLE SavingsBags
ADD CONSTRAINT FK_SavingsBags_Families FOREIGN KEY (FamilyId)
REFERENCES Families(FamilyId);

-- Crear clave única compuesta para Incomes (MemberId + IncomeId)
ALTER TABLE Incomes
ADD CONSTRAINT UQ_Member_Income UNIQUE (MemberId, IncomeId);

-- Crear clave única compuesta para Expenses (MemberId + ExpenseId)
ALTER TABLE Expenses
ADD CONSTRAINT UQ_Member_Expense UNIQUE (MemberId, ExpenseId);

-- Crear la clave foránea compuesta para Contributions (Incomes)
ALTER TABLE Contributions
ADD CONSTRAINT FK_Contributions_Incomes FOREIGN KEY (MemberId, IncomeId)
REFERENCES Incomes(MemberId, IncomeId);

-- Crear la clave foránea compuesta para Contributions (Expenses)
ALTER TABLE Contributions
ADD CONSTRAINT FK_Contributions_Expenses FOREIGN KEY (MemberId, ExpenseId)
REFERENCES Expenses(MemberId, ExpenseId);

-- Crear la clave foránea entre Contributions y Members
ALTER TABLE Contributions
ADD CONSTRAINT FK_Contributions_Members FOREIGN KEY (MemberId)
REFERENCES Members(MemberId);

-- Crear la clave foránea entre Contributions y SavingsBags
ALTER TABLE Contributions
ADD CONSTRAINT FK_Contributions_SavingsBags FOREIGN KEY (SavingsBagId)
REFERENCES SavingsBags(SavingBagId);
