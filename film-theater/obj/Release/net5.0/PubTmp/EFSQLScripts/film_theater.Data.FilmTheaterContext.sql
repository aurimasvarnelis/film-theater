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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211003160600_init')
BEGIN
    CREATE TABLE [Theaters] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Location] nvarchar(max) NULL,
        [CreationTimeUtc] datetime2 NOT NULL,
        CONSTRAINT [PK_Theaters] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211003160600_init')
BEGIN
    CREATE TABLE [Rooms] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Capacity] int NOT NULL,
        [RoomType] nvarchar(max) NULL,
        [CreationTimeUtc] datetime2 NOT NULL,
        [TheaterId] int NOT NULL,
        CONSTRAINT [PK_Rooms] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Rooms_Theaters_TheaterId] FOREIGN KEY ([TheaterId]) REFERENCES [Theaters] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211003160600_init')
BEGIN
    CREATE TABLE [Sessions] (
        [Id] int NOT NULL IDENTITY,
        [FilmName] nvarchar(max) NULL,
        [StartTime] nvarchar(max) NULL,
        [CreationTimeUtc] datetime2 NOT NULL,
        [RoomId] int NOT NULL,
        CONSTRAINT [PK_Sessions] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Sessions_Rooms_RoomId] FOREIGN KEY ([RoomId]) REFERENCES [Rooms] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211003160600_init')
BEGIN
    CREATE INDEX [IX_Rooms_TheaterId] ON [Rooms] ([TheaterId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211003160600_init')
BEGIN
    CREATE INDEX [IX_Sessions_RoomId] ON [Sessions] ([RoomId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211003160600_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211003160600_init', N'5.0.10');
END;
GO

COMMIT;
GO

