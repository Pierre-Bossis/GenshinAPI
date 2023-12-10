CREATE TABLE [dbo].[Personnages_LivresAptitude]
(
		[Personnage_Id] INT NOT NULL,
    [LivreAptitude_Id] INT NOT NULL,
    [Quantite] INT NOT NULL

    CONSTRAINT FK_PersonnageIntermediaire2 FOREIGN KEY (Personnage_Id) REFERENCES Personnages(Id),
    CONSTRAINT FK_LivreAptitude FOREIGN KEY (LivreAptitude_Id) REFERENCES LivresAptitude(Id),
    PRIMARY KEY (Personnage_Id, LivreAptitude_Id)
)
