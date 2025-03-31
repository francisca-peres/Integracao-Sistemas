CREATE PROCEDURE sp_GetProdutos
 AS
 BEGIN
 select ID_Produto,Codigo_Peca,Data_Producao,Hora_Producao,Tempo_Producao, Codigo_Resultado from Produto;
 END