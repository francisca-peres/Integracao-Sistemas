using System;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace WinFormsProdutorRabbit
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer autoTimer = new System.Windows.Forms.Timer();
        private Random random = new Random();
        private int pecasGeradas = 0;
        private const int limitePecas = 3;
        private bool prontoParaEnviar = false;

        public Form1()
        {
            InitializeComponent();

            // Configura o timer
            autoTimer.Interval = 5000; // 5 segundos
            autoTimer.Tick += AutoTimer_Tick;

            // Liga o botão Preencher ao evento
            btnPreencher.Click += btnPreencher_Click;
        }

        private void btnPreencher_Click(object sender, EventArgs e)
        {
            pecasGeradas = 0;

            // Gerar a primeira peça
            PreencherCamposAutomaticamente();

            // Indicar que a próxima iteração será de envio, não de geração
            prontoParaEnviar = true;

            // Começar o ciclo
            autoTimer.Start();
        }

        private void AutoTimer_Tick(object sender, EventArgs e)
        {
            if (pecasGeradas >= limitePecas)
            {
                autoTimer.Stop();
                MessageBox.Show("Geração automática concluída.");
                return;
            }

            if (prontoParaEnviar)
            {
                btnEnviar_Click(null, null); // Envia os dados da peça
                pecasGeradas++;

                // Só limpa os campos se ainda houver mais peças a gerar
                if (pecasGeradas < limitePecas)
                {
                    LimparCampos();
                }
            }
            else
            {
                PreencherCamposAutomaticamente(); // Preenche nova peça visível
            }

            prontoParaEnviar = !prontoParaEnviar; // Alterna entre gerar e enviar
        }

        private void PreencherCamposAutomaticamente()
        {
            DateTime agora = DateTime.Now;

            txtData.Text = agora.ToString("yyyy-MM-dd");
            txtHora.Text = agora.ToString("HH:mm:ss");

            string[] tipos = { "aa", "ab", "ba", "bb" };
            string tipo = tipos[random.Next(tipos.Length)];
            string identificador = random.Next(100000, 999999).ToString();

            txtCodigoPeca.Text = tipo + identificador;
            txtTempo.Text = random.Next(10, 51).ToString();
            txtResultado.Text = random.Next(1, 7).ToString("D2");
        }

        private void LimparCampos()
        {
            txtData.Clear();
            txtHora.Clear();
            txtCodigoPeca.Clear();
            txtTempo.Clear();
            txtResultado.Clear();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DateTime.TryParse(txtData.Text, out DateTime data))
                {
                    MessageBox.Show("Data inválida.");
                    return;
                }

                if (!TimeSpan.TryParse(txtHora.Text, out TimeSpan hora))
                {
                    MessageBox.Show("Hora inválida.");
                    return;
                }

                if (!int.TryParse(txtTempo.Text, out int tempoProducao))
                {
                    MessageBox.Show("Tempo de produção inválido.");
                    return;
                }

                var dados = new
                {
                    Data_Producao = data.ToString("yyyy-MM-dd"),
                    Hora_Producao = hora.ToString(),
                    Codigo_Peca = txtCodigoPeca.Text,
                    Tempo_Producao = tempoProducao,
                    Codigo_Resultado = txtResultado.Text
                };

                var json = JsonConvert.SerializeObject(dados);

                var factory = new ConnectionFactory() { HostName = "localhost" };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "fila_pecas",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "fila_pecas",
                        basicProperties: null,
                        body: body
                    );
                }

                Console.WriteLine($"Mensagem enviada: {json}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}
