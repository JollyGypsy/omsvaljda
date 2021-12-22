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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211216133344_InitialMigration')
BEGIN
    CREATE TABLE [Contacts] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NULL,
        [Notes] nvarchar(max) NULL,
        [Dob] nvarchar(max) NULL,
        [Gender] nvarchar(max) NULL,
        CONSTRAINT [PK_Contacts] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211216133344_InitialMigration')
BEGIN
    CREATE TABLE [Groups] (
        [GroupID] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Groups] PRIMARY KEY ([GroupID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211216133344_InitialMigration')
BEGIN
    CREATE TABLE [Addresses] (
        [AddressID] int NOT NULL IDENTITY,
        [AddressValue] nvarchar(max) NOT NULL,
        [State] nvarchar(max) NULL,
        [ZipCode] int NOT NULL,
        [ContactID] int NOT NULL,
        CONSTRAINT [PK_Addresses] PRIMARY KEY ([AddressID]),
        CONSTRAINT [FK_Addresses_Contacts_ContactID] FOREIGN KEY ([ContactID]) REFERENCES [Contacts] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211216133344_InitialMigration')
BEGIN
    CREATE TABLE [Phones] (
        [PhoneID] int NOT NULL IDENTITY,
        [PhoneValue] nvarchar(max) NOT NULL,
        [CallCode] int NOT NULL,
        [ContactID] int NOT NULL,
        CONSTRAINT [PK_Phones] PRIMARY KEY ([PhoneID]),
        CONSTRAINT [FK_Phones_Contacts_ContactID] FOREIGN KEY ([ContactID]) REFERENCES [Contacts] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211216133344_InitialMigration')
BEGIN
    CREATE TABLE [GroupToPersons] (
        [Id] int NOT NULL IDENTITY,
        [ContactID] int NOT NULL,
        [GroupID] int NOT NULL,
        CONSTRAINT [PK_GroupToPersons] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_GroupToPersons_Contacts_ContactID] FOREIGN KEY ([ContactID]) REFERENCES [Contacts] ([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_GroupToPersons_Groups_GroupID] FOREIGN KEY ([GroupID]) REFERENCES [Groups] ([GroupID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211216133344_InitialMigration')
BEGIN
    CREATE INDEX [IX_Addresses_ContactID] ON [Addresses] ([ContactID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211216133344_InitialMigration')
BEGIN
    CREATE INDEX [IX_GroupToPersons_ContactID] ON [GroupToPersons] ([ContactID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211216133344_InitialMigration')
BEGIN
    CREATE INDEX [IX_GroupToPersons_GroupID] ON [GroupToPersons] ([GroupID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211216133344_InitialMigration')
BEGIN
    CREATE INDEX [IX_Phones_ContactID] ON [Phones] ([ContactID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211216133344_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211216133344_InitialMigration', N'5.0.0');
END;
GO

COMMIT;
GO

