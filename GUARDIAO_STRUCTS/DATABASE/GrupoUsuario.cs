using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class GrupoUsuario : Result
    {
        public long grupoUsuario_id { get; set; }

        public string grupoUsuario_descricao { get; set; }

        public List<GrupoFuncionalidade> grupoFuncionalidades { get; set; }
    }
}
