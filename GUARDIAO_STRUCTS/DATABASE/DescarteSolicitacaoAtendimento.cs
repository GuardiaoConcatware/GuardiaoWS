using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class DescarteSolicitacaoAtendimento : Result
    {
        public long descarteSolcitacaoAtendimento_id { get; set; }
        public long solicitacaoAtendimento_id { get; set; }
        public string descarteSolcitacaoAtendimento_motivo { get; set; }
        public string descarteSolcitacaoAtendimento_dataCadastro { get; set; }

    }
}
