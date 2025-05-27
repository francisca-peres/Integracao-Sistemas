using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ConsumidorRabbit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
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

            consumer.Received += (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var peca = JsonConvert.DeserializeObject<MensagemPeca>(message);

                    // Apenas mostrar se resultado for diferente de "01"
                    if (peca.Codigo_Resultado != "01")
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            listBox1.Items.Add($"Falha: {peca.Codigo_Peca} | Resultado: {peca.Codigo_Resultado}");
                        });
                    }

                    // Inserir na base de dados "Producao2", tabela Produto
                    using (SqlConnection conn = new SqlConnection("Server=localhost;Database=Producao2;Trusted_Connection=True;TrustServerCertificate=True;"))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Produto (Codigo_Peca, Data_Producao, Hora_Producao, Tempo_Producao, Codigo_Resultado) " +
                            "VALUES (@Codigo, @Data, @Hora, @Tempo, @Resultado)", conn);

                        cmd.Parameters.AddWithValue("@Codigo", peca.Codigo_Peca);
                        cmd.Parameters.AddWithValue("@Data", DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@Hora", DateTime.Now.TimeOfDay);
                        cmd.Parameters.AddWithValue("@Tempo", peca.Tempo_Producao);
                        cmd.Parameters.AddWithValue("@Resultado", peca.Codigo_Resultado);

                        cmd.ExecuteNonQuery();
                    }
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
    }
}