USE Producao2
go
CREATE TRIGGER trg_InserirCustoPeca
ON Produto
AFTER INSERT
AS
BEGIN
    INSERT INTO Contabilidade.dbo.Custos_Peca (ID_Produto, Codigo_Peca, Tempo_Producao, Custo_Producao, Lucro, Prejuizo)
    SELECT 
        i.ID_Produto, 
        i.Codigo_Peca, 
        i.Tempo_Producao,
        -- Cálculo do Custo de Produção
        CASE 
            WHEN i.Codigo_Peca LIKE 'aa%' THEN i.Tempo_Producao * 1.9
            WHEN i.Codigo_Peca LIKE 'ab%' THEN i.Tempo_Producao * 1.3
            WHEN i.Codigo_Peca LIKE 'ba%' THEN i.Tempo_Producao * 1.7
            WHEN i.Codigo_Peca LIKE 'bb%' THEN i.Tempo_Producao * 1.2
        END AS Custo_Producao,
        0 AS Lucro,   -- Lucro será calculado depois
        0 AS Prejuizo -- Prejuízo será calculado depois
    FROM inserted i;

	UPDATE c  
    SET Prejuizo =  
        CASE  
            WHEN c.Codigo_Peca LIKE 'aa%' THEN c.Tempo_Producao * 0.9 + t.Custo_Falha  
            WHEN c.Codigo_Peca LIKE 'ab%' THEN c.Tempo_Producao * 1.1 + t.Custo_Falha  
            WHEN c.Codigo_Peca LIKE 'ba%' THEN c.Tempo_Producao * 1.2 + t.Custo_Falha  
            WHEN c.Codigo_Peca LIKE 'bb%' THEN c.Tempo_Producao * 1.3 + t.Custo_Falha  
        END  
    FROM Contabilidade.dbo.Custos_Peca c  
    JOIN inserted i ON c.ID_Produto = i.ID_Produto  
    JOIN (  
        SELECT '01' AS Codigo_Resultado, 0 AS Custo_Falha UNION  
        SELECT '02', 3 UNION  
        SELECT '03', 2 UNION  
        SELECT '04', 2.4 UNION  
        SELECT '05', 1.7 UNION  
        SELECT '06', 4.5  
    ) AS t ON i.Codigo_Resultado = t.Codigo_Resultado;  

    UPDATE c  
    SET Lucro =  
        CASE  
            WHEN c.Codigo_Peca LIKE 'aa%' THEN 120 - (c.Custo_Producao + c.Prejuizo)  
            WHEN c.Codigo_Peca LIKE 'ab%' THEN 100 - (c.Custo_Producao + c.Prejuizo)  
            WHEN c.Codigo_Peca LIKE 'ba%' THEN 110 - (c.Custo_Producao + c.Prejuizo)  
            WHEN c.Codigo_Peca LIKE 'bb%' THEN 90 - (c.Custo_Producao + c.Prejuizo)  
        END  
    FROM Contabilidade.dbo.Custos_Peca c  
    JOIN inserted i ON c.ID_Produto = i.ID_Produto;
END;
GO