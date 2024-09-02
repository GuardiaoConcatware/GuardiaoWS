using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class UsuarioOnline : Result
    {
        public long usuarioOnline_id { get; set; }
        public long usuario_id { get; set; }
        public string usuarioOnline_dataCadastro { get; set; }
        public string usuarioOnline_identity { get; set; }
        public string usuarioOnline_latitude { get; set; }
        public string usuarioOnline_longitude { get; set; }
        public int usuarioOnline_tipo { get; set; }
    }
}
