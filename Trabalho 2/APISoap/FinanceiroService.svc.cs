using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

public class FinanceiroService : IFinanceiroService
{
    private string connectionString = ConfigurationManager.ConnectionStrings["ContabilidadeConnection"].ConnectionString;

    public string PecaComMaiorPrejuizo()
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT TOP 1 Codigo_Peca FROM Custos_Peca ORDER BY Prejuizo DESC", conn);
            return cmd.ExecuteScalar()?.ToString();
        }
    }

    public decimal ObterCustosTotaisProducao(DateTime dataInicio, DateTime dataFim)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand(@"
                SELECT SUM(c.Custo_Producao)
                FROM Custos_Peca c
                JOIN Producao2.dbo.Produto p ON p.ID_Produto = c.ID_Produto
                WHERE p.Data_Producao BETWEEN @inicio AND @fim", conn);

            cmd.Parameters.AddWithValue("@inicio", dataInicio);
            cmd.Parameters.AddWithValue("@fim", dataFim);
            return (decimal)(cmd.ExecuteScalar() ?? 0);
        }
    }

    public decimal ObterLucroTotal(DateTime dataInicio, DateTime dataFim)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand(@"
                SELECT SUM(c.Lucro)
                FROM Custos_Peca c
                JOIN Producao2.dbo.Produto p ON p.ID_Produto = c.ID_Produto
                WHERE p.Data_Producao BETWEEN @inicio AND @fim", conn);

            cmd.Parameters.AddWithValue("@inicio", dataInicio);
            cmd.Parameters.AddWithValue("@fim", dataFim);
            return (decimal)(cmd.ExecuteScalar() ?? 0);
        }
    }

    public List<PrejuizoPorPeca> ObterPrejuizoTotalPorPeca(DateTime dataInicio, DateTime dataFim)
    {
        var resultado = new List<PrejuizoPorPeca>();

        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand(@"
                SELECT c.Codigo_Peca, SUM(c.Prejuizo) AS TotalPrejuizo
                FROM Custos_Peca c
                JOIN Producao2.dbo.Produto p ON p.ID_Produto = c.ID_Produto
                WHERE p.Data_Producao BETWEEN @inicio AND @fim
                GROUP BY c.Codigo_Peca", conn);

            cmd.Parameters.AddWithValue("@inicio", dataInicio);
            cmd.Parameters.AddWithValue("@fim", dataFim);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                resultado.Add(new PrejuizoPorPeca
                {
                    Codigo = reader["Codigo_Peca"].ToString(),
                    Prejuizo = (decimal)reader["TotalPrejuizo"]
                });
            }
        }

        return resultado;
    }

    public DadosFinanceiros ObterDadosFinanceirosPorPeca(string codigoPeca)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT TOP 1 * FROM Custos_Peca WHERE Codigo_Peca = @codigo", conn);
            cmd.Parameters.AddWithValue("@codigo", codigoPeca);

            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new DadosFinanceiros
                {
                    Codigo_Peca = reader["Codigo_Peca"].ToString(),
                    Tempo_Producao = Convert.ToDecimal(reader["Tempo_Producao"]),
                    Custo_Producao = Convert.ToDecimal(reader["Custo_Producao"]),
                    Prejuizo = Convert.ToDecimal(reader["Prejuizo"]),
                    Lucro = Convert.ToDecimal(reader["Lucro"])
                };
            }
        }

        return null;
    }
}
