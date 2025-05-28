using System;
using System.Text;
using System.Windows.Forms;
using FinanceiroServiceReference; // Refer�ncia ao servi�o SOAP

namespace ClienteSoap
{
    public partial class Form1 : Form
    {
        private FinanceiroServiceClient client;

        public Form1()
        {
            InitializeComponent();
            client = new FinanceiroServiceClient();
        }

        private void btnLucro_Click(object sender, EventArgs e)
        {
            try
            {
                var inicio = dtInicio.Value;
                var fim = dtFim.Value;

                var lucro = client.ObterLucroTotalAsync(inicio, fim).Result;
                txtResultado.Text = $"Lucro total: {lucro:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter lucro: {ex.Message}");
            }
        }

        private void btnPrejuizo_Click(object sender, EventArgs e)
        {
            try
            {
                var inicio = dtInicio.Value;
                var fim = dtFim.Value;

                var prejuizos = client.ObterPrejuizoTotalPorPecaAsync(inicio, fim).Result;
                StringBuilder sb = new StringBuilder();

                foreach (var item in prejuizos)
                {
                    sb.AppendLine($"Pe�a: {item.Key} -> Preju�zo: {item.Value:C}");
                }

                txtResultado.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter preju�zos: {ex.Message}");
            }
        }

        private void btnMaiorPrejuizo_Click(object sender, EventArgs e)
        {
            try
            {
                var codigo = client.PecaComMaiorPrejuizoAsync().Result;
                txtResultado.Text = $"Pe�a com maior preju�zo: {codigo}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter pe�a com maior preju�zo: {ex.Message}");
            }
        }

        private void btnCustos_Click(object sender, EventArgs e)
        {
            try
            {
                var inicio = dtInicio.Value;
                var fim = dtFim.Value;

                var custo = client.ObterCustosTotaisProducaoAsync(inicio, fim).Result;
                txtResultado.Text = $"Custos totais: {custo:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter custos: {ex.Message}");
            }
        }

        private void btnDetalhesPeca_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigoPeca.Text;
                var dados = client.ObterDadosFinanceirosPorPecaAsync(codigo).Result;

                txtResultado.Text = $"Pe�a: {dados.Codigo_Peca}\n" +
                                    $"Tempo: {dados.Tempo_Producao}\n" +
                                    $"Custo: {dados.Custo_Producao:C}\n" +
                                    $"Preju�zo: {dados.Prejuizo:C}\n" +
                                    $"Lucro: {dados.Lucro:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter dados da pe�a: {ex.Message}");
            }
        }
    }
}
