CREATE PROCEDURE sp_UpdateProduto
    @ID_Produto INT,
    @Codigo_Peca CHAR(8),
    @Data_Producao DATE,
    @Hora_Producao TIME,
    @Tempo_Producao INT,
	@Codigo_Resultado CHAR(2)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Produto WHERE ID_Produto = @ID_Produto)
    BEGIN
        PRINT 'Erro: Produto não encontrado.';
        RETURN;
    END

    UPDATE Produto
    SET 
        Codigo_Peca = @Codigo_Peca,
        Data_Producao = @Data_Producao,
        Hora_Producao = @Hora_Producao,
        Tempo_Producao = @Tempo_Producao,
		Codigo_Resultado = @Codigo_Resultado
    WHERE ID_Produto = @ID_Produto;
END;
GO