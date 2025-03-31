CREATE PROCEDURE sp_DeleteCustoByID
  @id_custo int
  AS
  BEGIN 
DELETE FROM Custos_Peca WHERE ID_Custo=@id_custo
  END