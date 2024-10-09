-- 1. Crear la base de datos
CREATE DATABASE FamilyFinancesDb;

-- 2. Usar la base de datos
USE FamilyFinancesDb;

-- 3. Crear las tablas

-- Tabla Roles
CREATE TABLE [dbo].[Roles] (
    [RolId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(250) NULL
);

-- Tabla Users
CREATE TABLE [dbo].[Users] (
    [UserName] VARCHAR(30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL PRIMARY KEY,
    [Password] NVARCHAR(500) NULL,
    [JwtToken] NVARCHAR(1000) NULL,
    [RolId] INT NOT NULL,  -- Relación con Roles
    [CreateOnDate] DATETIME NULL DEFAULT GETDATE() 
);

-- Tabla Families
CREATE TABLE [dbo].[Families] (
    [FamilyId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL,
    [Address] VARCHAR(250) NULL,
    [PhoneNumber] VARCHAR(20) NULL
);

-- Tabla Members
CREATE TABLE [dbo].[Members] (
    [MemberId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [FirtsName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(70) NOT NULL,
    [Gender] VARCHAR(20) NULL,
    [PhoneNumber] VARCHAR(20) NULL,
    [Position] VARCHAR(20) NULL,
    [Occupation] VARCHAR(50) NULL,
    [CreateOnDate] DATETIME DEFAULT GETDATE(),
    [UserName] VARCHAR(30) COLLATE SQL_Latin1_General_CP1_CI_AS, -- Relación opcional con Users
    [FamilyId] INT NOT NULL  -- Relación con Families
);

-- Tabla IncomeSources
CREATE TABLE [dbo].[IncomeSources] (
    [IncomeSourceId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Description] NVARCHAR(500) NOT NULL,
    [Icon] VARCHAR(10) NULL DEFAULT 'IncomeSource.png',
    [CreateOnDate] DATETIME NULL DEFAULT GETDATE()
);

-- Tabla Incomes
CREATE TABLE [dbo].[Incomes] (
    [IncomeId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Date] DATETIME NULL,
    [Name] VARCHAR(100) NOT NULL,
    [Amount] DECIMAL(18,2) NOT NULL,
    [Datails] NVARCHAR(250) NULL,
    [CreateOnDate] DATETIME NULL DEFAULT GETDATE(),
    [MemberId] INT NOT NULL,  -- Relación con Members
    [IncomeSourceId] INT NOT NULL  -- Relación con IncomeSources
);

-- Tabla ExpenseCategories
CREATE TABLE [dbo].[ExpenseCategories] (
    [ExpenseCategoryId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    [Description] NVARCHAR(500) NOT NULL,
    [Icon] VARCHAR(10) NULL DEFAULT 'Category.png',
    [CreateOnDate] DATETIME NULL DEFAULT GETDATE()
);

-- Tabla Expenses
CREATE TABLE [dbo].[Expenses] (
    [ExpenseId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Date] DATETIME NULL,
    [Name] VARCHAR(100) NOT NULL,
    [Amount] DECIMAL(18,2) NOT NULL,
    [Datails] NVARCHAR(250) NULL,
    [CreateOnDate] DATETIME NULL DEFAULT GETDATE(),
    [MemberId] INT NOT NULL,  -- Relación con Members
    [ExpenseCategoryId] INT NOT NULL  -- Relación con ExpenseCategories
);

-- Tabla SavingsBags
CREATE TABLE [dbo].[SavingsBags] (
    [SavingBagId] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE,
    [IdealAmount] DECIMAL(18, 2) NOT NULL,
    [Purpose] NVARCHAR(255),
    [Status] NVARCHAR(50),
    [CreationDate] DATETIME DEFAULT GETDATE(),
    [FamilyId] INT NOT NULL  -- Relación con Families
);

-- Tabla Contributions
CREATE TABLE [dbo].[Contributions] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [SavingsBagId] INT NOT NULL,  -- Relación con SavingsBags
    [MemberId] INT NOT NULL,  -- Relación con Members
    [IncomeId] INT NOT NULL,  -- Relación con Incomes (compuesta con el mismo Miembro)
    [ExpenseId] INT NULL,  -- Relación con Expenses (compuesta con el mismo Miembro)
    [Amount] DECIMAL(18, 2) NOT NULL,
    [DateContributed] DATE NOT NULL
);

-- 4. Crear las claves foráneas (FK)

-- Relación entre Users y Roles
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Roles FOREIGN KEY (RolId)
REFERENCES Roles(RolId);

-- Relación opcional entre Members y Users
ALTER TABLE Members
ADD CONSTRAINT FK_Members_Users FOREIGN KEY (UserName)
REFERENCES Users(UserName);

-- Relación entre Members y Families
ALTER TABLE Members
ADD CONSTRAINT FK_Members_Families FOREIGN KEY (FamilyId)
REFERENCES Families(FamilyId);

-- Relación entre Incomes y Members
ALTER TABLE Incomes
ADD CONSTRAINT FK_Incomes_Members FOREIGN KEY (MemberId)
REFERENCES Members(MemberId);

-- Relación entre Incomes y IncomeSources
ALTER TABLE Incomes
ADD CONSTRAINT FK_Incomes_IncomeSources FOREIGN KEY (IncomeSourceId)
REFERENCES IncomeSources(IncomeSourceId);

-- Relación entre Expenses y Members
ALTER TABLE Expenses
ADD CONSTRAINT FK_Expenses_Members FOREIGN KEY (MemberId)
REFERENCES Members(MemberId);

-- Relación entre Expenses y ExpenseCategories
ALTER TABLE Expenses
ADD CONSTRAINT FK_Expenses_ExpenseCategories FOREIGN KEY (ExpenseCategoryId)
REFERENCES ExpenseCategories(ExpenseCategoryId);

-- Relación entre SavingsBags y Families
ALTER TABLE SavingsBags
ADD CONSTRAINT FK_SavingsBags_Families FOREIGN KEY (FamilyId)
REFERENCES Families(FamilyId);

-- Crear claves únicas compuestas
-- Clave única en Incomes para MemberId + IncomeId
ALTER TABLE Incomes
ADD CONSTRAINT UQ_Member_Income UNIQUE (MemberId, IncomeId);

-- Clave única en Expenses para MemberId + ExpenseId
ALTER TABLE Expenses
ADD CONSTRAINT UQ_Member_Expense UNIQUE (MemberId, ExpenseId);

-- Relación compuesta en Contributions para Incomes
ALTER TABLE Contributions
ADD CONSTRAINT FK_Contributions_Incomes FOREIGN KEY (MemberId, IncomeId)
REFERENCES Incomes(MemberId, IncomeId);

-- Relación compuesta en Contributions para Expenses
ALTER TABLE Contributions
ADD CONSTRAINT FK_Contributions_Expenses FOREIGN KEY (MemberId, ExpenseId)
REFERENCES Expenses(MemberId, ExpenseId);

-- Relación entre Contributions y Members
ALTER TABLE Contributions
ADD CONSTRAINT FK_Contributions_Members FOREIGN KEY (MemberId)
REFERENCES Members(MemberId);

-- Relación entre Contributions y SavingsBags
ALTER TABLE Contributions
ADD CONSTRAINT FK_Contributions_SavingsBags FOREIGN KEY (SavingsBagId)
REFERENCES SavingsBags(SavingBagId);
