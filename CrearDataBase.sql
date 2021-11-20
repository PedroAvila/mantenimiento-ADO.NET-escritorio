

CREATE DATABASE Market
GO
Use Market
GO
CREATE TABLE Categorias
(
	Id int NOT NULL PRIMARY KEY identity(1,1),
	Nombre VARCHAR(255),
	Descripcion VARCHAR(255)
)


select * from Categorias
