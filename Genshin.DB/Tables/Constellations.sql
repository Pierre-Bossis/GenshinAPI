CREATE TABLE [dbo].[Constellations]
(
  [Id] INT NOT NULL PRIMARY KEY IDENTITY,
  [Nom] VARCHAR(255) NOT NULL UNIQUE,
  [Description] VARCHAR(MAX) NOT NULL,
  [Icone] VARCHAR(Max) NOT NULL,
  [Personnage_Id] INTEGER NOT NULL
  CONSTRAINT FK_PersoConstellation FOREIGN KEY (Personnage_Id) REFERENCES Personnages(Id)
)
