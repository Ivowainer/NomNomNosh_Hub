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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231222153831_Initial Migration, Relationship Member has Recipes'
)
BEGIN
    CREATE TABLE [Members] (
        [Member_Id] uniqueidentifier NOT NULL,
        [Username] nvarchar(max) NOT NULL,
        [First_Name] nvarchar(max) NOT NULL,
        [Last_Name] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [Profile_Image] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Members] PRIMARY KEY ([Member_Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231222153831_Initial Migration, Relationship Member has Recipes'
)
BEGIN
    CREATE TABLE [Recipes] (
        [Recipe_Id] uniqueidentifier NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Published_Date] datetime2 NOT NULL,
        [Main_Image] nvarchar(max) NOT NULL,
        [Average_Rating] decimal(18,2) NOT NULL,
        [Member_Id] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Recipes] PRIMARY KEY ([Recipe_Id]),
        CONSTRAINT [FK_Recipes_Members_Member_Id] FOREIGN KEY ([Member_Id]) REFERENCES [Members] ([Member_Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231222153831_Initial Migration, Relationship Member has Recipes'
)
BEGIN
    CREATE INDEX [IX_Recipes_Member_Id] ON [Recipes] ([Member_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231222153831_Initial Migration, Relationship Member has Recipes'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231222153831_Initial Migration, Relationship Member has Recipes', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE TABLE [RecipeComments] (
        [RecipeComment_Id] uniqueidentifier NOT NULL,
        [Recipe_Id] uniqueidentifier NOT NULL,
        [Member_Id] uniqueidentifier NOT NULL,
        [RecipeComment_Content] nvarchar(max) NOT NULL,
        [RecipeComment_Date] datetime2 NOT NULL,
        CONSTRAINT [PK_RecipeComments] PRIMARY KEY ([RecipeComment_Id]),
        CONSTRAINT [FK_RecipeComments_Members_Member_Id] FOREIGN KEY ([Member_Id]) REFERENCES [Members] ([Member_Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_RecipeComments_Recipes_Recipe_Id] FOREIGN KEY ([Recipe_Id]) REFERENCES [Recipes] ([Recipe_Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE TABLE [RecipeImages] (
        [RecipeImage_Id] uniqueidentifier NOT NULL,
        [Recipe_Id] uniqueidentifier NOT NULL,
        [Url] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_RecipeImages] PRIMARY KEY ([RecipeImage_Id]),
        CONSTRAINT [FK_RecipeImages_Recipes_Recipe_Id] FOREIGN KEY ([Recipe_Id]) REFERENCES [Recipes] ([Recipe_Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE TABLE [RecipeRates] (
        [RecipeRate_Id] uniqueidentifier NOT NULL,
        [Recipe_Id] uniqueidentifier NOT NULL,
        [Member_Id] uniqueidentifier NOT NULL,
        [Rating_Value] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_RecipeRates] PRIMARY KEY ([RecipeRate_Id]),
        CONSTRAINT [FK_RecipeRates_Members_Member_Id] FOREIGN KEY ([Member_Id]) REFERENCES [Members] ([Member_Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_RecipeRates_Recipes_Recipe_Id] FOREIGN KEY ([Recipe_Id]) REFERENCES [Recipes] ([Recipe_Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE TABLE [RecipeSaved] (
        [RecipeSaved_Id] uniqueidentifier NOT NULL,
        [Recipe_Id] uniqueidentifier NOT NULL,
        [Member_Id] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_RecipeSaved] PRIMARY KEY ([RecipeSaved_Id]),
        CONSTRAINT [FK_RecipeSaved_Members_Member_Id] FOREIGN KEY ([Member_Id]) REFERENCES [Members] ([Member_Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_RecipeSaved_Recipes_Recipe_Id] FOREIGN KEY ([Recipe_Id]) REFERENCES [Recipes] ([Recipe_Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE TABLE [RecipeSteps] (
        [RecipeStep_Id] uniqueidentifier NOT NULL,
        [Recipe_Id] uniqueidentifier NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [RecipeStep_Content] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_RecipeSteps] PRIMARY KEY ([RecipeStep_Id]),
        CONSTRAINT [FK_RecipeSteps_Recipes_Recipe_Id] FOREIGN KEY ([Recipe_Id]) REFERENCES [Recipes] ([Recipe_Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE INDEX [IX_RecipeComments_Member_Id] ON [RecipeComments] ([Member_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE INDEX [IX_RecipeComments_Recipe_Id] ON [RecipeComments] ([Recipe_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE INDEX [IX_RecipeImages_Recipe_Id] ON [RecipeImages] ([Recipe_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE INDEX [IX_RecipeRates_Member_Id] ON [RecipeRates] ([Member_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE INDEX [IX_RecipeRates_Recipe_Id] ON [RecipeRates] ([Recipe_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE INDEX [IX_RecipeSaved_Member_Id] ON [RecipeSaved] ([Member_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE INDEX [IX_RecipeSaved_Recipe_Id] ON [RecipeSaved] ([Recipe_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    CREATE INDEX [IX_RecipeSteps_Recipe_Id] ON [RecipeSteps] ([Recipe_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20231227001556_Relationships'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231227001556_Relationships', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240110144635_OnDelete Behavior Cascade'
)
BEGIN
    ALTER TABLE [RecipeSteps] DROP CONSTRAINT [FK_RecipeSteps_Recipes_Recipe_Id];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240110144635_OnDelete Behavior Cascade'
)
BEGIN
    ALTER TABLE [RecipeSteps] ADD CONSTRAINT [FK_RecipeSteps_Recipes_Recipe_Id] FOREIGN KEY ([Recipe_Id]) REFERENCES [Recipes] ([Recipe_Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240110144635_OnDelete Behavior Cascade'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240110144635_OnDelete Behavior Cascade', N'8.0.0');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240111121850_On Cascade RecipeComment'
)
BEGIN
    ALTER TABLE [RecipeComments] DROP CONSTRAINT [FK_RecipeComments_Members_Member_Id];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240111121850_On Cascade RecipeComment'
)
BEGIN
    ALTER TABLE [RecipeComments] DROP CONSTRAINT [FK_RecipeComments_Recipes_Recipe_Id];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240111121850_On Cascade RecipeComment'
)
BEGIN
    ALTER TABLE [RecipeSteps] DROP CONSTRAINT [FK_RecipeSteps_Recipes_Recipe_Id];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240111121850_On Cascade RecipeComment'
)
BEGIN
    ALTER TABLE [RecipeComments] ADD CONSTRAINT [FK_RecipeComments_Members_Member_Id] FOREIGN KEY ([Member_Id]) REFERENCES [Members] ([Member_Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240111121850_On Cascade RecipeComment'
)
BEGIN
    ALTER TABLE [RecipeComments] ADD CONSTRAINT [FK_RecipeComments_Recipes_Recipe_Id] FOREIGN KEY ([Recipe_Id]) REFERENCES [Recipes] ([Recipe_Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240111121850_On Cascade RecipeComment'
)
BEGIN
    ALTER TABLE [RecipeSteps] ADD CONSTRAINT [FK_RecipeSteps_Recipes_Recipe_Id] FOREIGN KEY ([Recipe_Id]) REFERENCES [Recipes] ([Recipe_Id]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240111121850_On Cascade RecipeComment'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240111121850_On Cascade RecipeComment', N'8.0.0');
END;
GO

COMMIT;
GO

