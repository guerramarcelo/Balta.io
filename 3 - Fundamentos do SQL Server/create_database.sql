CREATE TABLE [Aluno](
 [Id] int not null, 
 [Nome] NVARCHAR(80) not null,
 [Email] NVARCHAR(180) not NULL,
 [Nascimento] DATETIME NULL,
 [Active] BIT NOT NULL DEFAULT(0),

 CONSTRAINT [PK_Aluno] PRIMARY KEY ([Id]),
 CONSTRAINT [UQ_Aluno_Email] UNIQUE ([Email])
)
go

CREATE INDEX [IX_Aluno_Email] ON [Aluno] ([Email])

DROP TABLE Aluno

ALTER TABLE [Aluno] alter COLUMN [Active] BIT not NULL

ALTER TABLE [Aluno] DROP CONSTRAINT [PK_Aluno]


CREATE TABLE [Curso](
    [Id]   INT NOT NULL IDENTITY (1,1),
    [Nome] NVARCHAR(80) not null,
    [CategoriaId] INTEGER NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY (CategoriaId) REFERENCES [Categoria] ([Id])

)

drop TABLE Curso

CREATE TABLE [ProgressoCurso](
    [AlunoId] INTEGER NOT NULL,
    [CursoId] INTEGER NOT NULL,
    [Progresso] INTEGER NOT NULL,
    [UltimaAtualizacao] DATETIME NOT NULL DEFAULT(GETDATE())   
    
    CONSTRAINT PK_ProgressoCurso PRIMARY KEY ([AlunoId], [CursoId])   
)

DROP TABLE ProgressoCurso

CREATE TABLE [Categoria](
    [Id] INTEGER not null,
    [Nome] NVARCHAR(80) not null,

    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id])

)

USE [master];
DECLARE  @kill VARCHAR(8000) ='';
SELECT @kill = @kill + 'kill' + CONVERT (VARCHAR(5), session_id) + ';'
FROM sys.dm_exec_sessions
WHERE database_id = db_id('Curso')

EXEC (@kill);

DROP DATABASE [Cursos]


CREATE TABLE [Curso](
    [Id]  INT NOT NULL IDENTITY (1,1),
    [Nome] NVARCHAR(80) not null,
    [CategoriaId] INTEGER NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY (CategoriaId) REFERENCES [Categoria] ([Id])
)

CREATE TABLE [Categoria](
    [Id]  INT NOT NULL IDENTITY (1,1),
    [Nome] NVARCHAR(80) not null,

    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id])

)

CREATE DATABASE [Cursos]

GO

CREATE TABLE [Categoria](
    [Id]   INT NOT NULL IDENTITY (1,1),
    [Nome] NVARCHAR(80) not null,

    CONSTRAINT [PK_Categoria] PRIMARY KEY ([Id])

)

CREATE TABLE [Curso](
    [Id]   INT NOT NULL IDENTITY (1,1),
    [Nome] NVARCHAR(80) not null,
    [CategoriaId] INTEGER NOT NULL,

    CONSTRAINT [PK_Curso] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY (CategoriaId) REFERENCES [Categoria] ([Id])
)

