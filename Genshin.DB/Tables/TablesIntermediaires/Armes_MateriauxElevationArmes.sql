CREATE TABLE [dbo].[Armes_MateriauxElevationArmes]
(
	  [Arme_Id] INT NOT NULL,
    [MateriauxElevationArme_Id] INT NOT NULL,
    [Quantite] INT NOT NULL

    CONSTRAINT FK_ArmeIntermediaire FOREIGN KEY (Arme_Id) REFERENCES Armes(Id),
    CONSTRAINT FK_MaterielIntermediaire FOREIGN KEY (MateriauxElevationArme_Id) REFERENCES MateriauxElevationArmes(Id),
    PRIMARY KEY (Arme_Id, MateriauxElevationArme_Id)
)
