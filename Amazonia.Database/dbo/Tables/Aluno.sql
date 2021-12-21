CREATE TABLE [dbo].[Aluno] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [Matricula]      CHAR (7)      NOT NULL,
    [Nome]           VARCHAR (100) NOT NULL,
    [DataNascimento] DATE          NOT NULL,
    [Sexo]           CHAR (1)      NULL,
    CONSTRAINT [PK_Aluno] PRIMARY KEY CLUSTERED ([Id] ASC)
);

