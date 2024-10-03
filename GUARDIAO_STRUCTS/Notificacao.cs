using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Notificacao : Result
    {
        public long notificacao_id { get; set; }
        public long usuario_id { get; set; }
        public string notificacao_descricao { get; set; }
        public string notificacao_data { get; set; }
        public string notificacao_titulo { get; set; }
        public bool notificacao_status { get; set; }
    }
}
