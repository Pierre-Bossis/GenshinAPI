CREATE TABLE [dbo].[Aptitudes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
  [Nom] VARCHAR(255) NOT NULL UNIQUE,
  [Description] VARCHAR(MAX) NOT NULL,
  [IsAptitudeCombat] BIT NOT NULL,
  [Icone] VARCHAR(Max) NOT NULL,
  [Personnage_Id] INTEGER NOT NULL
  CONSTRAINT FK_PersoAptitude FOREIGN KEY (Personnage_Id) REFERENCES Personnages(Id)
)
