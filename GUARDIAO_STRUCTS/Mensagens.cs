using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Mensagens:Result
    {
        public long mensagem_id { get; set; }
        public long usuario_id { get; set; }
        public long atendimento_id { get; set; }
        public string mensagem_texto { get; set; }
        public string mensagem_dataEnvio { get; set; }
    }
}
