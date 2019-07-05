using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfomedBenner.Models
{
    public class Medicamento
    {
        public int Id { get; set; }
        public int Sequencial { get; set; }
        public string Periodo { get; set; }
        public string Unimed { get; set; }
        public int CodItem { get; set; }
        public string MedicamentoDesc { get; set; }
        public decimal Valor { get; set; }
    }
}
