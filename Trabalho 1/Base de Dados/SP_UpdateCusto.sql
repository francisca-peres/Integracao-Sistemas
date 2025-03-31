CREATE PROCEDURE sp_UpdateCusto
    @ID_Custo INT,
    @Custo_Producao DECIMAL(10,2),
    @Lucro DECIMAL(10,2),
    @Prejuizo DECIMAL(10,2)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Custos_Peca WHERE ID_Custo = @ID_Custo)
    BEGIN
        PRINT 'Erro: Custo não encontrado.';
        RETURN;
    END

    UPDATE Custos_Peca
    SET 
        Custo_Producao = @Custo_Producao,
        Lucro = @Lucro,
        Prejuizo = @Prejuizo
    WHERE ID_Custo = @ID_Custo;
END;
GO