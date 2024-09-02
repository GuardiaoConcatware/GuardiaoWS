using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class TabelaPreco : Result
    {
        public long tabelaPreco_id { get; set; }

        public long usuario_id { get; set; }

        public long advogado_id { get; set; }

        public long tipoConsulta_id { get; set; }

        public decimal tabelaPreco_valor { get; set; }

        public bool tabelaPreco_ativo { get; set; }

        public string tabelaPreco_dataCadastro { get; set; }
    }
}
