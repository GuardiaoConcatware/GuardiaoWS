using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Atendimento:Result
    {
        public long atendimento_id { get; set; }
        public long solicitacaoAtendimento_id { get; set; }
        public long usuario_id { get; set; }
        public bool atendimento_status { get; set; }
        public long advogado_id { get; set; }
        public string dataInicio_atendimento { get; set; }
        public string dataFim_Atendimento { get; set; }
    }
}
