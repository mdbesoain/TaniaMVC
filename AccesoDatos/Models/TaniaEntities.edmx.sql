
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/08/2015 21:53:49
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

IF OBJECT_ID(N'[dbo].[FK_EventoDisciplina]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Eventos] DROP CONSTRAINT [FK_EventoDisciplina];
GO
IF OBJECT_ID(N'[dbo].[FK_EventoEstadistica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Estadisticas] DROP CONSTRAINT [FK_EventoEstadistica];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoriaFoto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fotos] DROP CONSTRAINT [FK_CategoriaFoto];
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
IF OBJECT_ID(N'[dbo].[Reportes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reportes];
GO
IF OBJECT_ID(N'[dbo].[Estadisticas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estadisticas];
GO
IF OBJECT_ID(N'[dbo].[Habilidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Habilidades];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Fotos'
CREATE TABLE [dbo].[Fotos] (
    [id_foto] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [url] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [id_categoria] int  NOT NULL
);
GO

-- Creating table 'Eventos'
CREATE TABLE [dbo].[Eventos] (
    [id_evento] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [direccion] nvarchar(max)  NOT NULL,
    [fecha] nvarchar(max)  NOT NULL,
    [url_flayer] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [id_disciplina] int  NOT NULL
);
GO

-- Creating table 'Auspiciadores'
CREATE TABLE [dbo].[Auspiciadores] (
    [id_auspiciador] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [url_logo] nvarchar(max)  NOT NULL,
    [website] nvarchar(max)  NOT NULL
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
    [fecha] datetime  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [id_categoria] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Reportes'
CREATE TABLE [dbo].[Reportes] (
    [reporte_id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL,
    [url] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Estadisticas'
CREATE TABLE [dbo].[Estadisticas] (
    [id_estadistica] int IDENTITY(1,1) NOT NULL,
    [pos_manga1] nvarchar(max)  NOT NULL,
    [pos_manga2] nvarchar(max)  NOT NULL,
    [pos_final] nvarchar(max)  NOT NULL,
    [Evento_id_evento] int  NOT NULL
);
GO

-- Creating table 'Habilidades'
CREATE TABLE [dbo].[Habilidades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Abouts'
CREATE TABLE [dbo].[Abouts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
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

-- Creating primary key on [reporte_id] in table 'Reportes'
ALTER TABLE [dbo].[Reportes]
ADD CONSTRAINT [PK_Reportes]
    PRIMARY KEY CLUSTERED ([reporte_id] ASC);
GO

-- Creating primary key on [id_estadistica] in table 'Estadisticas'
ALTER TABLE [dbo].[Estadisticas]
ADD CONSTRAINT [PK_Estadisticas]
    PRIMARY KEY CLUSTERED ([id_estadistica] ASC);
GO

-- Creating primary key on [Id] in table 'Habilidades'
ALTER TABLE [dbo].[Habilidades]
ADD CONSTRAINT [PK_Habilidades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Abouts'
ALTER TABLE [dbo].[Abouts]
ADD CONSTRAINT [PK_Abouts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_disciplina] in table 'Eventos'
ALTER TABLE [dbo].[Eventos]
ADD CONSTRAINT [FK_EventoDisciplina]
    FOREIGN KEY ([id_disciplina])
    REFERENCES [dbo].[Disciplinas]
        ([id_disciplina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventoDisciplina'
CREATE INDEX [IX_FK_EventoDisciplina]
ON [dbo].[Eventos]
    ([id_disciplina]);
GO

-- Creating foreign key on [Evento_id_evento] in table 'Estadisticas'
ALTER TABLE [dbo].[Estadisticas]
ADD CONSTRAINT [FK_EventoEstadistica]
    FOREIGN KEY ([Evento_id_evento])
    REFERENCES [dbo].[Eventos]
        ([id_evento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventoEstadistica'
CREATE INDEX [IX_FK_EventoEstadistica]
ON [dbo].[Estadisticas]
    ([Evento_id_evento]);
GO

-- Creating foreign key on [id_categoria] in table 'Fotos'
ALTER TABLE [dbo].[Fotos]
ADD CONSTRAINT [FK_CategoriaFoto]
    FOREIGN KEY ([id_categoria])
    REFERENCES [dbo].[Categorias]
        ([id_categoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaFoto'
CREATE INDEX [IX_FK_CategoriaFoto]
ON [dbo].[Fotos]
    ([id_categoria]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------