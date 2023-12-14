CREATE TABLE [dbo].[Aptitudes]
(
	[Id] INT NOT NULL PRIMARY KEY,
  [Nom] VARCHAR(255) NOT NULL UNIQUE,
  [Description] VARCHAR(MAX) NOT NULL,
  [IsAptitudeCombat] BIT NOT NULL,
  [PathIcone] VARBINARY(Max) NOT NULL,
  [Personnage_Id] INTEGER NOT NULL
  CONSTRAINT FK_PersoAptitude FOREIGN KEY (Personnage_Id) REFERENCES Personnages(Id)
)
