CREATE PROCEDURE SP_GetProdutoByID
  @id_produto int
  AS
  BEGIN 
SELECT Codigo_Peca, Data_Producao,Hora_Producao,Tempo_Producao,Codigo_Resultado FROM Produto WHERE ID_Produto=@id_produto
  END 