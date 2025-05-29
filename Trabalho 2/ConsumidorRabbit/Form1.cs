using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsumidorRabbit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "fila_pecas",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var peca = JsonConvert.DeserializeObject<MensagemPeca>(message);

                    // Mostrar apenas se falhou
                    if (peca.Codigo_Resultado != "01")
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            listBox1.Items.Add($"Falha: {peca.Codigo_Peca} | Resultado: {peca.Codigo_Resultado}");
                        });
                    }

                    // Preparar o objeto para envio à API
                    var produto = new
                    {
                        Codigo_Peca = peca.Codigo_Peca,
                        Data_Producao = DateTime.Now.Date,
                        Hora_Producao = DateTime.Now.TimeOfDay,
                        Tempo_Producao = peca.Tempo_Producao,
                        Codigo_Resultado = peca.Codigo_Resultado
                    };

                    await EnviarParaAPI(produto);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro no consumidor: " + ex.Message);
                }
            };

            channel.BasicConsume(
                queue: "fila_pecas",
                autoAck: true,
                consumer: consumer
            );

            MessageBox.Show("Consumo iniciado com sucesso!");
        }

        private async Task EnviarParaAPI(object produto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5169/"); 
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(produto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("api/Produtos", content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Erro ao enviar para API: {response.StatusCode}");
                }
                else
                {
                    Console.WriteLine("Peça enviada com sucesso via API.");
                }
            }
        }
    }

}