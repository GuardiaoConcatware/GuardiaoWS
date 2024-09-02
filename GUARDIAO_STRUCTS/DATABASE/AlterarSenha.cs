using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class AlterarSenha:Result
    {
        public long usuario_id { get; set; }
        public string usuario_senha { get; set; }
    }
}
