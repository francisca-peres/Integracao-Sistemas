CREATE PROCEDURE sp_DeleteByID
  @id_Produto int
  AS
  BEGIN 
DELETE FROM Produto WHERE ID_Produto=@id_Produto
  END