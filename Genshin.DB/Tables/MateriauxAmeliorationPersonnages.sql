CREATE TABLE [dbo].[MateriauxAmeliorationPersonnages]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
  [Nom] VARCHAR(50) NOT NULL UNIQUE,
  [PathIcone] VARCHAR(100) NOT NULL,
  [Source] VARCHAR(100) NOT NULL,
  [Rarete] INTEGER NOT NULL
)
