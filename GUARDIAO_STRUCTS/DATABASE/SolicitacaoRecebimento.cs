using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class SolicitacaoRecebimento : Result
    {
        public long solicitacaoRecebimento_id { get; set; }
        public long usuario_id { get; set; }
        public string usuario_nome { get; set; }
        public string solicitacaoRecebimento_status { get; set; }
        public string solicitacaoRecebimento_motivoRecusa { get; set; }
        public string solicitacaoRecebimento_dataCadastro { get; set; }
        public double solicitacaoRecebimento_valorDisponivel { get; set; }
        public double solicitacaoRecebimento_valorSolicitado { get; set; }
    }
}
