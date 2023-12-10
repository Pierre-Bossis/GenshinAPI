CREATE TABLE [dbo].[Personnages_MateriauxAmeliorationPersonnagesEtArmes]
(
	[Personnage_Id] INT NOT NULL,
  [MateriauxAmeliorationPersonnagesEtArmes_Id] INT NOT NULL,
  [Quantite] INT NOT NULL

  CONSTRAINT FK_PersonnageIntermediaire FOREIGN KEY (Personnage_Id) REFERENCES Personnages(Id),
  CONSTRAINT FK_MatAmelioPersoEtArmes FOREIGN KEY (MateriauxAmeliorationPersonnagesEtArmes_Id) REFERENCES MateriauxAmeliorationPersonnagesEtArmes(Id),
  PRIMARY KEY (Personnage_Id,MateriauxAmeliorationPersonnagesEtArmes_Id)
)
