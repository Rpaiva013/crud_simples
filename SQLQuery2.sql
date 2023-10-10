USE Registros
CREATE TABLE Usuarios (
     id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(50),
    email VARCHAR(50),
    senha VARCHAR (50),
	dataCadastro DATE
);

DELETE FROM Usuarios

SELECT * FROM Usuarios

DROP TABLE Usuarios