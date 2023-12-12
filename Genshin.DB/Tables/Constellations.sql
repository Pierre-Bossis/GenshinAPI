CREATE TABLE [dbo].[Constellations]
(
	[Id] INT NOT NULL PRIMARY KEY,
  [Nom] VARCHAR(255) NOT NULL UNIQUE,
  [Description] VARCHAR(MAX) NOT NULL,
  [PathIcone] VARCHAR(100) NOT NULL,
  [Personnage_Id] INTEGER NOT NULL
  CONSTRAINT FK_PersoConstellation FOREIGN KEY (Personnage_Id) REFERENCES Personnages(Id)
)
