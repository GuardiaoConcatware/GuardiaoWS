using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class RelatorioAtendimentoAdministrativo : Result
    {
        public long atendimento_id { get; set; }
        public long solicitacaoAtendimento_id { get; set; }
        public long advogado_id { get; set; }
        public string advogado_name { get; set; }
        public string advogado_foto { get; set; }
        public bool advogado_online { get; set; }
        public string usuario_nome { get; set; }
        public long especialidade_id { get; set; }
        public string especialidade_nome { get; set; }
        public string solicitacaoAtendimento_descricao { get; set; }
        public string atendimento_status { get; set; }
        public string solicitacaoAtendimento_dataCadastro { get; set; }
        public string atendimento_duracao { get; set; }
    }
}
