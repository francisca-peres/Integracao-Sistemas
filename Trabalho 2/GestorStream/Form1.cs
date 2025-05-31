using RabbitMQ.Stream.Client;
using RabbitMQ.Stream.Client.Reliable;
using System.Buffers;
using System.Text;
using System.Text.Json;

namespace GestorStream
{
    public partial class Form1 : Form
    {
        private int totalPecas = 0;
        private int pecasOK = 0;
        private int pecasComFalha = 0;
        private int somaTempoProducao = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private async Task InicializarConsumer()
        {
            var config = new StreamSystemConfig
            {
                UserName = "guest",
                Password = "guest",
                Endpoints = new[] { new System.Net.IPEndPoint(System.Net.IPAddress.Parse("127.0.0.1"), 5552) }
            };

            var system = await StreamSystem.Create(config);

            var consumer = await Consumer.Create(
         new ConsumerConfig(system, "pecas_stream")
         {
             MessageHandler = async (stream, consumer, ctx, message) =>
             {
                 var json = Encoding.UTF8.GetString(message.Data.Contents.ToArray());
                 var peca = JsonSerializer.Deserialize<Producao>(json);

                 totalPecas++;
                 somaTempoProducao += peca.Tempo_Producao;

                 if (peca.Codigo_Resultado == "01")
                     pecasOK++;
                 else
                     pecasComFalha++;

                 AtualizarMetricas();
                 await Task.CompletedTask; // necessário para satisfazer async
             }
         });

        }

        private void AtualizarMetricas()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(AtualizarMetricas));
                return;
            }

            txtTotalPecas.Text = totalPecas.ToString();
            txtTotalOK.Text = pecasOK.ToString();
            txtTotalFalhas.Text = pecasComFalha.ToString();
            txtTempoMedio.Text = totalPecas > 0
                ? (somaTempoProducao / (double)totalPecas).ToString("F2") + " s"
                : "0 s";
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            await InicializarConsumer();

        }
    }

    public class Producao
    {
        public string Codigo_Peca { get; set; }
        public string Codigo_Resultado { get; set; }
        public int Tempo_Producao { get; set; }
        public DateTime DataHora { get; set; }
    }
}

