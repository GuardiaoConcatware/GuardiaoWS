using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class FiltroSolicitacaoSaque : Result
    {

        public long usuario_id { get; set; }
        public string solicitacaoRecebimento_status { get; set; }
        public string solicitacaoRecebimento_dataInicial {  get; set; }
        public string solicitacaoRecebimento_dataFinal { get; set; }
    }
}
