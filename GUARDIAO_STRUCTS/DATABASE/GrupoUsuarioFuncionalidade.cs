using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class GrupoUsuarioFuncionalidade : Result
    {
        public long grupoUsuarioFuncionalidade_id { get; set; }

        public long grupoUsuario_id { get; set; }

        public long grupoFuncionalidade_id { get; set; }

        public long funcionalidadeSistema_id { get; set; }
    }
}
