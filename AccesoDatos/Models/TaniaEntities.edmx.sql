
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2015 13:58:18
-- Generated from EDMX file: C:\Users\juancarlosgonzalezca\documents\visual studio 2013\Projects\TaniaMVC\AccesoDatos\Models\TaniaEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_9CA6D2_Tania];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FotoCategoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fotos] DROP CONSTRAINT [FK_FotoCategoria];
GO
IF OBJECT_ID(N'[dbo].[FK_EventoDisciplina]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Eventos] DROP CONSTRAINT [FK_EventoDisciplina];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Fotos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fotos];
GO
IF OBJECT_ID(N'[dbo].[Eventos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Eventos];
GO
IF OBJECT_ID(N'[dbo].[Auspiciadores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Auspiciadores];
GO
IF OBJECT_ID(N'[dbo].[Disciplinas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Disciplinas];
GO
IF OBJECT_ID(N'[dbo].[Logros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logros];
GO
IF OBJECT_ID(N'[dbo].[Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorias];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Fotos'
CREATE TABLE [dbo].[Fotos] (
    [id_foto] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [url] nvarchar(max)  NOT NULL,
    [Categoria_id_categoria] int  NOT NULL
);
GO

-- Creating table 'Eventos'
CREATE TABLE [dbo].[Eventos] (
    [id_evento] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [direccion] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [url_flayer] nvarchar(max)  NOT NULL,
    [Disciplina_id_disciplina] int  NOT NULL
);
GO

-- Creating table 'Auspiciadores'
CREATE TABLE [dbo].[Auspiciadores] (
    [id_auspiciador] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [url_logo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Disciplinas'
CREATE TABLE [dbo].[Disciplinas] (
    [id_disciplina] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Logros'
CREATE TABLE [dbo].[Logros] (
    [id_logro] int IDENTITY(1,1) NOT NULL,
    [titulo] nvarchar(max)  NOT NULL,
    [fecha] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [id_categoria] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id_foto] in table 'Fotos'
ALTER TABLE [dbo].[Fotos]
ADD CONSTRAINT [PK_Fotos]
    PRIMARY KEY CLUSTERED ([id_foto] ASC);
GO

-- Creating primary key on [id_evento] in table 'Eventos'
ALTER TABLE [dbo].[Eventos]
ADD CONSTRAINT [PK_Eventos]
    PRIMARY KEY CLUSTERED ([id_evento] ASC);
GO

-- Creating primary key on [id_auspiciador] in table 'Auspiciadores'
ALTER TABLE [dbo].[Auspiciadores]
ADD CONSTRAINT [PK_Auspiciadores]
    PRIMARY KEY CLUSTERED ([id_auspiciador] ASC);
GO

-- Creating primary key on [id_disciplina] in table 'Disciplinas'
ALTER TABLE [dbo].[Disciplinas]
ADD CONSTRAINT [PK_Disciplinas]
    PRIMARY KEY CLUSTERED ([id_disciplina] ASC);
GO

-- Creating primary key on [id_logro] in table 'Logros'
ALTER TABLE [dbo].[Logros]
ADD CONSTRAINT [PK_Logros]
    PRIMARY KEY CLUSTERED ([id_logro] ASC);
GO

-- Creating primary key on [id_categoria] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([id_categoria] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Categoria_id_categoria] in table 'Fotos'
ALTER TABLE [dbo].[Fotos]
ADD CONSTRAINT [FK_FotoCategoria]
    FOREIGN KEY ([Categoria_id_categoria])
    REFERENCES [dbo].[Categorias]
        ([id_categoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FotoCategoria'
CREATE INDEX [IX_FK_FotoCategoria]
ON [dbo].[Fotos]
    ([Categoria_id_categoria]);
GO

-- Creating foreign key on [Disciplina_id_disciplina] in table 'Eventos'
ALTER TABLE [dbo].[Eventos]
ADD CONSTRAINT [FK_EventoDisciplina]
    FOREIGN KEY ([Disciplina_id_disciplina])
    REFERENCES [dbo].[Disciplinas]
        ([id_disciplina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventoDisciplina'
CREATE INDEX [IX_FK_EventoDisciplina]
ON [dbo].[Eventos]
    ([Disciplina_id_disciplina]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------