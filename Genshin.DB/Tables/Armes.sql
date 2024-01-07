CREATE TABLE [dbo].[Armes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
  [Nom] VARCHAR(50) NOT NULL UNIQUE,
  [TypeArme] VARCHAR(50) NOT NULL,
  [Description] VARCHAR(MAX) NOT NULL,
  [Icone] VARCHAR(Max) NOT NULL,
  [Image] VARCHAR(Max) NOT NULL,
  [NomStatPrincipale] VARCHAR(50) NOT NULL,
  [ValeurStatPrincipale] DECIMAL(18,2) NOT NULL,
  [EffetPassif] VARCHAR(MAX) NOT NULL,
  [ATQBase] INT NOT NULL,
  [Rarete] INT NOT NULL
)
