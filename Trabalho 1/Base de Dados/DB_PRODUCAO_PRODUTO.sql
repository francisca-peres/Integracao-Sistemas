CREATE DATABASE Producao2;
GO
USE Producao2;
GO

CREATE TABLE Produto (
    ID_Produto INT IDENTITY(1,1) PRIMARY KEY,
    Codigo_Peca CHAR(8) NOT NULL CHECK (
        Codigo_Peca LIKE 'aa______' OR
        Codigo_Peca LIKE 'ab______' OR
        Codigo_Peca LIKE 'ba______' OR
        Codigo_Peca LIKE 'bb______'
    ) UNIQUE,
    Data_Producao DATE NOT NULL,
    Hora_Producao TIME NOT NULL,
    Tempo_Producao INT CHECK (Tempo_Producao BETWEEN 10 AND 50) NOT NULL,
    Codigo_Resultado CHAR(2) CHECK (Codigo_Resultado IN ('01', '02', '03', '04', '05', '06')) NOT NULL DEFAULT '06'
);
GO