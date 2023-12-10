CREATE TABLE [dbo].[Personnages]
(
	[Id] INT NOT NULL PRIMARY KEY,
  [NOM] VARCHAR(50) UNIQUE NOT NULL,
  [OeilDivin] VARCHAR(50) NOT NULL,
  [TypeArme] VARCHAR(50) NOT NULL,
  [Lore] VARCHAR(MAX) NOT NULL,
  [Nationalite] VARCHAR(50) NOT NULL,
  [PathTrailer_YT] VARCHAR(MAX) NOT NULL,
  [PathSplashArt] VARCHAR(50) NOT NULL,
  [PathPortrait] VARCHAR(50) NOT NULL,
  [DateSortie] Datetime NOT NULL,
  [Arme_Id] INT,
  [MateriauxAmeliorationPersonnage_Id] INT NOT NULL,
  [Produit_Id] INT NOT NULL,
  [Rarete] INT NOT NULL

  CONSTRAINT FK_Arme FOREIGN KEY (Arme_Id) REFERENCES Armes(Id)
  CONSTRAINT FK_MaterieuxAmeliorationPersonnage FOREIGN KEY (MateriauxAmeliorationPersonnage_Id) REFERENCES MateriauxAmeliorationPersonnages(Id),
  CONSTRAINT FK_Produit FOREIGN KEY (Produit_Id) REFERENCES Produits(Id)
)
