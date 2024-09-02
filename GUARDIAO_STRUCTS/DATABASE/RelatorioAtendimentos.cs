using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class RelatorioAtendimentos : Result
    {

        public long solicitacaoAtendimento_id { get; set; }
        public string usuario_nome { get; set; }
        public string solicitacaoAtendimento_descricao { get; set; }
        public string solicitacaoAtendimento_status { get; set; }
        public string atendimento_dataInicio { get; set; }
        public string atendimento_dataFim { get; set; }
        public int atendimento_tempoOcioso { get; set; }
        public string especialidade_nome { get; set; }
        public string atendimento_status { get; set; }
        public string solicitacaoAtendimento_dataCadastro { get; set; }

    }
}
