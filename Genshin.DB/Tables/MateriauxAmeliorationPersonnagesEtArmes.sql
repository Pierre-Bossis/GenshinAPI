CREATE TABLE [dbo].[MateriauxAmeliorationPersonnagesEtArmes]
(
	[Id] INT NOT NULL PRIMARY KEY,
  [Nom] VARCHAR(50) NOT NULL UNIQUE,
  [PathIcone] VARCHAR(50) NOT NULL,
  [Source] VARCHAR(50) NOT NULL,
  [Rarete] INTEGER NOT NULL
)
