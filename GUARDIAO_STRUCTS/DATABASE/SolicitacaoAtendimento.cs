using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class SolicitacaoAtendimento : Result
    {
        public long solicitacaoAtendimento_id { get; set; }

        public long usuario_id { get; set; }

        public string usuario_nome { get; set; }

        public string usuario_foto { get; set; }

        public long advogado_id { get; set; }

        public long especialidade_id { get; set; }

        public string solicitacaoAtendimento_identity { get; set; }

        public string especialidade_nome { get; set; }

        public string solicitacaoAtendimento_descricao { get; set; }

        public string solicitacaoAtendimento_status { get; set; }

        public string solicitacaoAtendimento_dataCadastro { get; set; }

        public long solicitacaoAtendimento_tipo { get; set; }

    }
}
