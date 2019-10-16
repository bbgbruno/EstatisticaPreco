CREATE TABLE [dbo].[Produto]
(
	[Id] CHAR(50) NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(200) NULL, 
    [Preco] FLOAT NULL, 
    [Categoria] INT NULL, 
    [Codigo] VARCHAR(50) NULL, 
    [EAN13] VARCHAR(50) NULL, 
    [Origem] VARCHAR(50) NULL
)
