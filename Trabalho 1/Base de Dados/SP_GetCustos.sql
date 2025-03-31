CREATE PROCEDURE sp_GetCustos
 AS
 BEGIN
 select ID_Custo, ID_Produto,Codigo_Peca,Tempo_Producao,Custo_Producao,Lucro,Prejuizo from Custos_Peca;
 END