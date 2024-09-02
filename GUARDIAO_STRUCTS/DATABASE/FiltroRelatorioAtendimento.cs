using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class FiltroRelatorioAtendimento : Result
    {
        public string solicitacaoAtendimento_dataInicial { get; set; }
        public string solicitacaoAtendimento_dataFinal { get; set; }
        public long usuario_id { get; set; }
        public long advogado_id { get; set; }
        public long especialidade_id { get; set; }
        public string atendimento_status { get; set; }
    }
}
