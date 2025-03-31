CREATE PROCEDURE sp_InserirProduto
    @Codigo_Peca CHAR(8),
    @Data_Producao DATE,
    @Hora_Producao TIME,
    @Tempo_Producao INT, 
	@Codigo_Resultado Char(2)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Produto WHERE Codigo_Peca = @Codigo_Peca)
    BEGIN
        PRINT 'Erro: Já existe uma peça com esse código.';
        RETURN;
    END

	DECLARE @CodigoResultadoFinal CHAR(2);

    -- Se o código não for informado, usa '06 - Desconhecido'
    IF @Codigo_Resultado IS NULL OR @Codigo_Resultado NOT IN ('01', '02', '03', '04', '05', '06')
        SET @CodigoResultadoFinal = '06';
    ELSE
        SET @CodigoResultadoFinal = @Codigo_Resultado;


    INSERT INTO Produto (Codigo_Peca, Data_Producao, Hora_Producao, Tempo_Producao, Codigo_Resultado)
    VALUES (@Codigo_Peca, @Data_Producao, @Hora_Producao, @Tempo_Producao, @Codigo_Resultado);
END;