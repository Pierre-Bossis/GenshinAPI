CREATE TABLE [dbo].[Armes_MateriauxAmeliorationPersonnagesEtArmes]
(
	[Arme_Id] INT NOT NULL,
  [MateriauxAmeliorationPersonnagesEtArmes_Id] INT NOT NULL,
  [Quantite] INT NOT NULL

  CONSTRAINT FK_ArmeIntermediaire2 FOREIGN KEY (Arme_Id) REFERENCES Armes(Id),
  CONSTRAINT FK_MatAmelioPersoEtArmes2 FOREIGN KEY (MateriauxAmeliorationPersonnagesEtArmes_Id) REFERENCES MateriauxAmeliorationPersonnagesEtArmes(Id),
  PRIMARY KEY (Arme_Id,MateriauxAmeliorationPersonnagesEtArmes_Id)
)
