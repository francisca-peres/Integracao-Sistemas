using System;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace WinFormsProdutorRabbit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                var dados = new
                {
                    Codigo_Peca = txtCodigoPeca.Text,
                    Tempo_Producao = txtTempo.Text,
                    Codigo_Resultado = txtResultado.Text,
                    Tipo = txtTipo.Text
                };

                var json = JsonConvert.SerializeObject(dados);
                MessageBox.Show("JSON gerado: " + json); // DEBUG

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

                MessageBox.Show("Mensagem enviada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}