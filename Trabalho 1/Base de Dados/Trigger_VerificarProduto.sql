USE Contabilidade;
GO

CREATE TRIGGER trg_VerificarProduto
ON Custos_Peca
FOR INSERT
AS
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM Producao2.dbo.Produto p
        INNER JOIN inserted i ON p.ID_Produto = i.ID_Produto
    )
    BEGIN
        PRINT 'O Produto inserido na Contabilidade não existe na Produção.';
        ROLLBACK TRANSACTION;
    END
END;
GO