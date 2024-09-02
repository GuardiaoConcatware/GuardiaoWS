using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Atendimentos : Result
    {
        public long atendimento_id { get; set; }

        public long solicitacaoAtendimento_id { get; set; }

        public string atendimento_status { get; set; }

        public long usuario_id { get; set; }

        public long advogado_id { get; set; }

        public string atendimento_dataInicio { get; set; }

        public string atendimento_dataFim { get; set; }

        public int atendimento_tempoOcioso { get; set; }
    }
}
