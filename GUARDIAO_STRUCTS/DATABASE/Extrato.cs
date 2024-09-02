using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Extrato : Result
    {
        public long extrato_id { get; set; }

        public long usuario_id { get; set; }

        public string usuario_nome { get; set; }

        public long tipoExtrato_id { get; set; }

        public long atendimento_id { get; set; }

        public decimal extrato_valor { get; set; }

        public decimal extrato_valorPercentual { get; set; }

        public string extrato_tempo { get; set; }

        public string extrato_totalMinutosOcioso { get; set; }

        public string extrato_dataCadastro { get; set; }

    }
}