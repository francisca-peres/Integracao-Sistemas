using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumidorRabbit
{
    public class MensagemPeca
    {
        public string Codigo_Peca { get; set; }
        public string Tempo_Producao { get; set; }
        public string Codigo_Resultado { get; set; }
        public string Tipo { get; set; }  // se já não estiver a ser usado, podes remover

        public DateTime DataHora_Producao { get; set; } // usado para preencher data e hora
    }

}
