using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class TipoUsuario : Result
    {
        public long tipoUsuario_id { get; set; }

        public long especieUsuario_id { get; set; }

        public string tipoUsuario_descricao { get; set; }
    }
}
