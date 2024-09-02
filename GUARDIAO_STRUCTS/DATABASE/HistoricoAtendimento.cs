using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class HistoricoAtendimento : Result
    {
        public long historicoAtendimento_id { get; set; }

        public long solicitacaoAtendimento_id { get; set; }

        public long usuario_id { get; set; }

        public string historicoAtendimento_message { get; set; }

        public string historicoAtendimento_dataCadastro { get; set; }

        public List<ArquivoHistoricoAtendimento> arquivoHistoricos { get; set; }
    }
}
