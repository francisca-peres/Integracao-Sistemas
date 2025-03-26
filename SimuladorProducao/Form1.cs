namespace SimuladorProducao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            var rand = new Random();

            string[] tipos = { "aa", "ab", "ba", "bb" };
            string tipo = tipos[rand.Next(tipos.Length)];
            string identificador = rand.Next(100000, 999999).ToString(); //gera um número com 6 digitos
            string codigo = tipo + identificador; //junta o tipo e o identificar e gera um codigo de 8 digitos

            string data = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("HH:mm:ss");
            int tempo = rand.Next(10, 51);
            string[] resultados = { "01", "02", "03", "04", "05", "06" };
            string resultado = resultados[rand.Next(resultados.Length)];

            txtData.Text = data;
            txtHora.Text = hora;
            txtCodigo.Text = codigo;
            txtTempo.Text = tempo.ToString();
            txtResultado.Text = resultado;
        }

       
    }
}
