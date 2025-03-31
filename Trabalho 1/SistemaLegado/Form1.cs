using System.Diagnostics;

namespace SistemaLegado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("HH:mm:ss");

            string[] prefixos = { "aa", "ab", "ba", "bb" };
            Random rand = new Random();

            string prefixo = prefixos[rand.Next(prefixos.Length)];
            string sufixo = rand.Next(100000, 999999).ToString();
            string codigo = prefixo + sufixo;

            int tempo = rand.Next(30, 51); // Tempo entre 30 e 50 segundos
            string[] resultados = { "01", "02", "03", "04", "05", "06" };
            string resultado = resultados[rand.Next(resultados.Length)];

            // Caminho do ficheiro
            string caminhoFicheiro = @"C:\SikuliDados\dados_gerados.txt";

            // Escrever no ficheiro (modo overwrite!)
            using (StreamWriter writer = new StreamWriter(caminhoFicheiro, false)) // false = sobrescreve
            {
                writer.WriteLine("Data=" + data);
                writer.WriteLine("Hora=" + hora);
                writer.WriteLine("Codigo_Peca=" + codigo);
                writer.WriteLine("Tempo_Producao=" + tempo);
                writer.WriteLine("Codigo_Resultado=" + resultado);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string caminhoJava = @"C:\Programas\Java\jdk-23\bin\java.exe";
                string caminhoJar = @"C:\Sikuli\sikulixide-2.0.5-win.jar";
                string caminhoScript = @"C:\SikuliDados\simulador.sikuli";

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = caminhoJava,
                    Arguments = $"-jar \"{caminhoJar}\" -r \"{caminhoScript}\"",
                    UseShellExecute = false
                };

                Process.Start(psi);
                button2.Enabled = false;
                MessageBox.Show("Script Sikuli iniciado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar automação: " + ex.Message);
            }
        }
    }
}
