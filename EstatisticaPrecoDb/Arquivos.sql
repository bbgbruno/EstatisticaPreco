CREATE TABLE [dbo].[Arquivos]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(100) NULL, 
    [Caminho] VARCHAR(300) NULL, 
    [Origem] VARCHAR(100) NULL
)
