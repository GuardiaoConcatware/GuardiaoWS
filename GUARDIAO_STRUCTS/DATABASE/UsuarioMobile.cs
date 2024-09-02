using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class UsuarioMobile : Result
    {
        public List<UsuarioEmpresaCadastrados> usuarios { get; set; }
    }
}
