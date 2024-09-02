using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class FiltroUsuarioOnline : Result
    {
        public long usuarioOnline_tipo { get; set; }
        public long municipio_codigo { get; set; }
        public long especialidade_id { get; set; }
    }
}
