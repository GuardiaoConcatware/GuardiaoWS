using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class PercentualPreco : Result
    {
        public long percentualPreco_id { get; set; }

        public long usuario_id { get; set; }

        public long advogado_id { get; set; }

        public long tipoConsulta_id { get; set; }

        public decimal percentualPreco_valor { get; set; }

        public bool percentualPreco_ativo { get; set; }

        public string percentualPreco_dataCadastro { get; set; }
    }
}
