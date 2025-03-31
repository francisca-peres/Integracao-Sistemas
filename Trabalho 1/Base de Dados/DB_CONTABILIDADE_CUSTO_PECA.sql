CREATE DATABASE Contabilidade;
GO
USE Contabilidade;
GO

CREATE TABLE Custos_Peca (
    ID_Custo INT IDENTITY(1,1) PRIMARY KEY,
    ID_Produto INT NOT NULL,
    Codigo_Peca CHAR(8) NOT NULL,
    Tempo_Producao INT NOT NULL CHECK (Tempo_Producao BETWEEN 10 AND 50),
    Custo_Producao DECIMAL(10,2) NOT NULL,
    Lucro DECIMAL(10,2) NOT NULL,
	Prejuizo DECIMAL(10,2) NOT NULL
);
GO