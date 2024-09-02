using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Saldo : Result
    {
        public long saldo_id { get; set; }

        public long usuario_id { get; set; }

        public decimal saldo_valor { get; set; }

        public string saldo_horas { get; set; }

        public string saldo_ultimaAtualizacao { get; set; }
    }
}