CREATE PROCEDURE sp_InserirCusto    
	@ID_Produto INT
AS
BEGIN
    DECLARE @Codigo_Peca CHAR(8), @Tempo_Producao INT, @Custo_Producao DECIMAL(10,2);

    -- Verifica se o Produto existe
    IF NOT EXISTS (SELECT 1 FROM Producao2.dbo.Produto WHERE ID_Produto = @ID_Produto)
    BEGIN
        PRINT 'Erro: Produto não encontrado na Produção.';
        RETURN;
    END

    -- Obtém os dados do Produto
    SELECT @Codigo_Peca = Codigo_Peca, @Tempo_Producao = Tempo_Producao
    FROM Producao_teste.dbo.Produto
    WHERE ID_Produto = @ID_Produto;

    -- Calcula o Custo de Produção
    SET @Custo_Producao = 
        CASE 
            WHEN @Codigo_Peca LIKE 'aa%' THEN @Tempo_Producao * 1.9
            WHEN @Codigo_Peca LIKE 'ab%' THEN @Tempo_Producao * 1.3
            WHEN @Codigo_Peca LIKE 'ba%' THEN @Tempo_Producao * 1.7
            WHEN @Codigo_Peca LIKE 'bb%' THEN @Tempo_Producao * 1.2
            ELSE 0
        END;

    -- Insere os custos na tabela Custos_Peca
    INSERT INTO Custos_Peca (ID_Produto, Codigo_Peca, Tempo_Producao, Custo_Producao, Lucro, Prejuizo)
    VALUES (@ID_Produto, @Codigo_Peca, @Tempo_Producao, @Custo_Producao, 0, 0);
END;
GO