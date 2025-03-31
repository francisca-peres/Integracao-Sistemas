CREATE PROCEDURE SP_CustoByID
  @id_custo int
  AS
  BEGIN  
SELECT ID_Produto,Codigo_Peca,Tempo_Producao,Custo_Producao,Lucro,Prejuizo FROM Custos_Peca WHERE ID_Custo=@id_custo
  END 