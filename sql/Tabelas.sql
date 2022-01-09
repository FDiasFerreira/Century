IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Tb_Categories] (
    [Id] uniqueidentifier NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Active] bit NOT NULL,
    [Name] varchar(200) NOT NULL,
    [Product] uniqueidentifier NOT NULL,
    [InsertDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NULL,
    CONSTRAINT [PK_Tb_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Tb_Suppliers] (
    [Id] uniqueidentifier NOT NULL,
    [Active] varchar(200) NOT NULL,
    [FantasyName] varchar(200) NOT NULL,
    [Name] varchar(200) NOT NULL,
    [SupplierType] varchar(200) NOT NULL,
    [Document] varchar(14) NOT NULL,
    [BirthDate] varchar(200) NOT NULL,
    [InsertDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NULL,
    CONSTRAINT [PK_Tb_Suppliers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Tb_Addresses] (
    [Id] uniqueidentifier NOT NULL,
    [SupplierId] uniqueidentifier NOT NULL,
    [ZipCode] varchar(8) NOT NULL,
    [Street] varchar(200) NOT NULL,
    [Number] varchar(10) NOT NULL,
    [Complement] varchar(200) NULL,
    [Reference] varchar(200) NULL,
    [Neighborhood] varchar(50) NOT NULL,
    [City] varchar(50) NOT NULL,
    [State] varchar(50) NOT NULL,
    [InsertDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NULL,
    CONSTRAINT [PK_Tb_Addresses] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tb_Addresses_Tb_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Tb_Suppliers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Tb_E-mails] (
    [Id] uniqueidentifier NOT NULL,
    [SupplierId] uniqueidentifier NOT NULL,
    [EmailAddress] varchar(100) NOT NULL,
    [InsertDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NULL,
    CONSTRAINT [PK_Tb_E-mails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tb_E-mails_Tb_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Tb_Suppliers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Tb_Phones] (
    [Id] uniqueidentifier NOT NULL,
    [SupplierId] uniqueidentifier NOT NULL,
    [Ddd] varchar(2) NOT NULL,
    [Number] varchar(9) NOT NULL,
    [InsertDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NULL,
    CONSTRAINT [PK_Tb_Phones] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tb_Phones_Tb_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Tb_Suppliers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Tb_Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [SupplierId] uniqueidentifier NOT NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    [Name] varchar(200) NOT NULL,
    [BarCode] varchar(13) NOT NULL,
    [QuantityStock] varchar(200) NOT NULL,
    [Active] bit NOT NULL,
    [PriceSales] decimal(18,2) NOT NULL,
    [PricePurchase] decimal(18,2) NOT NULL,
    [ImagePath] varchar(200) NOT NULL,
    [InsertDate] datetime2 NOT NULL,
    [UpdateDate] datetime2 NULL,
    CONSTRAINT [PK_Tb_Produtos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tb_Produtos_Tb_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Tb_Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Tb_Produtos_Tb_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [Tb_Suppliers] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Tb_Addresses_SupplierId] ON [Tb_Addresses] ([SupplierId]);
GO

CREATE UNIQUE INDEX [IX_Tb_E-mails_SupplierId] ON [Tb_E-mails] ([SupplierId]);
GO

CREATE UNIQUE INDEX [IX_Tb_Phones_SupplierId] ON [Tb_Phones] ([SupplierId]);
GO

CREATE INDEX [IX_Tb_Produtos_CategoryId] ON [Tb_Produtos] ([CategoryId]);
GO

CREATE INDEX [IX_Tb_Produtos_SupplierId] ON [Tb_Produtos] ([SupplierId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220107165858_Initial', N'5.0.12');
GO

COMMIT;
GO

