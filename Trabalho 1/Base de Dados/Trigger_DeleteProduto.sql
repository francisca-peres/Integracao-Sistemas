USE Producao2;
GO

CREATE TRIGGER trg_DeleteProduto
ON Produto
AFTER DELETE
AS
BEGIN
    -- Remover os custos do produto na Contabilidade_teste
    DELETE FROM Contabilidade.dbo.Custos_Peca 
    WHERE ID_Produto IN (SELECT ID_Produto FROM deleted);

END;
GO