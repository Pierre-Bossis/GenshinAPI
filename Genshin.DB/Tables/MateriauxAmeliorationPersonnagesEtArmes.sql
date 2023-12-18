CREATE TABLE [dbo].[MateriauxAmeliorationPersonnagesEtArmes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
  [Nom] VARCHAR(50) NOT NULL UNIQUE,
  [Icone] VARBINARY(Max) NOT NULL,
  [Source] VARCHAR(100) NOT NULL,
  [Rarete] INTEGER NOT NULL
)
