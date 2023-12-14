CREATE TABLE [dbo].[Armes]
(
	[Id] INT NOT NULL PRIMARY KEY,
  [NOM] VARCHAR(50) NOT NULL UNIQUE,
  [TypeArme] VARCHAR(50) NOT NULL,
  [Description] VARCHAR(MAX) NOT NULL,
  [Icone] VARBINARY(Max) NOT NULL,
  [SplashArt] VARBINARY(Max) NOT NULL,
  [NomStatPrincipale] VARCHAR(50) NOT NULL,
  [ValeurStatPrincipale] DECIMAL NOT NULL,
  [EffetPassif] VARCHAR(MAX) NOT NULL,
  [ATQBase] INT NOT NULL,
  [Rarete] INT NOT NULL
)
