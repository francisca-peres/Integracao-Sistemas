// ProdutosController.cs
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;


[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly string sqlConnectionStringProducao = "Data Source=LAPTOP-BMHBCFRV;Initial Catalog=Producao2;Integrated Security=True;Encrypt=False";
    private readonly string sqlConnectionStringContabilidade = "Data Source=LAPTOP-BMHBCFRV;Initial Catalog=Contabilidade2;Integrated Security=True;Encrypt=False";

    [HttpGet]
    public ActionResult<List<Produto>> Get()
    {
        var produtos = new List<Produto>();
        using (SqlConnection con = new SqlConnection(sqlConnectionStringProducao))
        using (SqlCommand cmd = new SqlCommand("sp_GetProdutos", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    produtos.Add(new Produto
                    {
                        ID_Produto = Convert.ToInt32(reader["ID_Produto"]),
                        Codigo_Peca = reader["Codigo_Peca"].ToString(),
                        Data_Producao = Convert.ToDateTime(reader["Data_Producao"]),
                        Hora_Producao = TimeSpan.Parse(reader["Hora_Producao"].ToString()),
                        Tempo_Producao = Convert.ToInt32(reader["Tempo_Producao"]),
                        Codigo_Resultado = reader["Codigo_Resultado"].ToString()
                    });
                }
            }
        }
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> GetById(int id)
    {
        Produto produto = null;
        using (SqlConnection con = new SqlConnection(sqlConnectionStringProducao))
        using (SqlCommand cmd = new SqlCommand("SP_GetProdutoByID", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_produto", id);
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    produto = new Produto
                    {
                        Codigo_Peca = reader["Codigo_Peca"].ToString(),
                        Data_Producao = Convert.ToDateTime(reader["Data_Producao"]),
                        Hora_Producao = TimeSpan.Parse(reader["Hora_Producao"].ToString()),
                        Tempo_Producao = Convert.ToInt32(reader["Tempo_Producao"]),
                        Codigo_Resultado = reader["Codigo_Resultado"].ToString()
                    };
                }
            }
        }
        return produto != null ? Ok(produto) : NotFound();
    }

    [HttpPost]
    public ActionResult Post([FromBody] Produto p)
    {
        using (SqlConnection con = new SqlConnection(sqlConnectionStringProducao))
        using (SqlCommand cmd = new SqlCommand("sp_InserirProduto", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Codigo_Peca", p.Codigo_Peca);
            cmd.Parameters.AddWithValue("@Data_Producao", p.Data_Producao);
            cmd.Parameters.AddWithValue("@Hora_Producao", p.Hora_Producao);
            cmd.Parameters.AddWithValue("@Tempo_Producao", p.Tempo_Producao);
            cmd.Parameters.AddWithValue("@Codigo_Resultado", p.Codigo_Resultado);
            con.Open();
            
            cmd.ExecuteNonQuery();
        }
        return Ok("Produto inserido com sucesso!");
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Produto p)
    {
        using (SqlConnection con = new SqlConnection(sqlConnectionStringProducao))
        using (SqlCommand cmd = new SqlCommand("sp_UpdateProduto", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_Produto", id);
            cmd.Parameters.AddWithValue("@Codigo_Peca", p.Codigo_Peca);
            cmd.Parameters.AddWithValue("@Data_Producao", p.Data_Producao);
            cmd.Parameters.AddWithValue("@Hora_Producao", p.Hora_Producao);
            cmd.Parameters.AddWithValue("@Tempo_Producao", p.Tempo_Producao);
            cmd.Parameters.AddWithValue("@Codigo_Resultado", p.Codigo_Resultado);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        return Ok("Produto atualizado com sucesso!");
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        using (SqlConnection con = new SqlConnection(sqlConnectionStringProducao))
        using (SqlCommand cmd = new SqlCommand("sp_DeleteByID", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_Produto", id);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        return Ok("Produto eliminado com sucesso!");
    }

    [HttpGet("{id}/custos")]
    public ActionResult<CustoPeca> GetCustosDoProduto(int id)
    {
        CustoPeca custo = null;
        using (SqlConnection con = new SqlConnection(sqlConnectionStringContabilidade))
        using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Custos_Peca WHERE ID_Produto = @ID", con))
        {
            cmd.Parameters.AddWithValue("@ID", id);
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    custo = new CustoPeca
                    {
                        ID_Custo = Convert.ToInt32(reader["ID_Custo"]),
                        ID_Produto = Convert.ToInt32(reader["ID_Produto"]),
                        Codigo_Peca = reader["Codigo_Peca"].ToString(),
                        Tempo_Producao = Convert.ToInt32(reader["Tempo_Producao"]),
                        Custo_Producao = Convert.ToDecimal(reader["Custo_Producao"]),
                        Lucro = Convert.ToDecimal(reader["Lucro"]),
                        Prejuizo = Convert.ToDecimal(reader["Prejuizo"])
                    };
                }
            }
        }
        return custo != null ? Ok(custo) : NotFound();
    }
}

// Models
public class Produto
{
    public int ID_Produto { get; set; }
    public string Codigo_Peca { get; set; }
    public DateTime Data_Producao { get; set; }
    public TimeSpan Hora_Producao { get; set; }
    public int Tempo_Producao { get; set; }
    public string Codigo_Resultado { get; set; }
}

public class CustoPeca
{
    public int ID_Custo { get; set; }
    public int ID_Produto { get; set; }
    public string Codigo_Peca { get; set; }
    public int Tempo_Producao { get; set; }
    public decimal Custo_Producao { get; set; }
    public decimal Lucro { get; set; }
    public decimal Prejuizo { get; set; }
}
