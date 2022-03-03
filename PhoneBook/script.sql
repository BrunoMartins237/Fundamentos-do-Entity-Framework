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

CREATE TABLE [Contact] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PhoneNumber] (
    [Id] int NOT NULL IDENTITY,
    [Number] NVARCHAR(60) NOT NULL,
    [ContactsId] int NULL,
    CONSTRAINT [PK_PhoneNumber] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PhoneNumber_Contact] FOREIGN KEY ([ContactsId]) REFERENCES [Contact] ([Id]) ON DELETE SET NULL
);
GO

CREATE UNIQUE INDEX [IX_Contact_Name] ON [Contact] ([Name]);
GO

CREATE INDEX [IX_PhoneNumber_ContactsId] ON [PhoneNumber] ([ContactsId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220227205044_InitialCreation', N'5.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Contact] ADD [Email] NVARCHAR(80) NOT NULL DEFAULT N'';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220227210203_AdicionandoNovaColuna', N'5.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ContactCategory] (
    [FK_ContactCategory_CategoryId] int NOT NULL,
    [FK_ContactCategory_ContactId] int NOT NULL,
    CONSTRAINT [PK_ContactCategory] PRIMARY KEY ([FK_ContactCategory_CategoryId], [FK_ContactCategory_ContactId]),
    CONSTRAINT [CategoryId] FOREIGN KEY ([FK_ContactCategory_CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [ContactId] FOREIGN KEY ([FK_ContactCategory_ContactId]) REFERENCES [Contact] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Category_Name] ON [Category] ([Name]);
GO

CREATE INDEX [IX_ContactCategory_FK_ContactCategory_ContactId] ON [ContactCategory] ([FK_ContactCategory_ContactId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220303211759_AdicionandoClasseCategory', N'5.0.9');
GO

COMMIT;
GO

