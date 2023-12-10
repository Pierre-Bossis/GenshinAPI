CREATE TABLE [dbo].[Personnages_MateriauxElevationPersonnages]
(
		[Personnage_Id] INT NOT NULL,
    [MateriauxElevationPersonnage_Id] INT NOT NULL,
    [Quantite] INT NOT NULL

    CONSTRAINT FK_PersonnageIntermediaire3 FOREIGN KEY (Personnage_Id) REFERENCES Personnages(Id),
    CONSTRAINT FK_MateriauxElevationPersonnage FOREIGN KEY (MateriauxElevationPersonnage_Id) REFERENCES MateriauxElevationPersonnages(Id),
    PRIMARY KEY (Personnage_Id, MateriauxElevationPersonnage_Id)
)
