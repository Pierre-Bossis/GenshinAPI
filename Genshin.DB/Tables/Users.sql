CREATE TABLE [dbo].[Users]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
  [Username] VARCHAR(50) NOT NULL UNIQUE,
  [Email] VARCHAR(70) NOT NULL UNIQUE,
  [MotDePasse] VARCHAR(MAX) NOT NULL,
  [IsAdmin] BIT NOT NULL,
  [Avatar_Id] INTEGER DEFAULT 1

  CONSTRAINT FK_Avatar FOREIGN KEY (Avatar_Id) REFERENCES Avatars(Id)
)
