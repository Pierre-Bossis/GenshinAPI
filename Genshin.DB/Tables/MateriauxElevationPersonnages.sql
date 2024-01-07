CREATE TABLE [dbo].[MateriauxElevationPersonnages]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
  [Nom] VARCHAR(50) NOT NULL UNIQUE,
  [Icone] VARCHAR(max) NOT NULL,
  [Source] VARCHAR(100) NOT NULL,
  [Rarete] INTEGER NOT NULL
)
