using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class GrupoFuncionalidade : Result
    {
        public long grupoFuncionalidade_id { get; set; }

        public string grupoFuncionalidade_nome { get; set; }

        public List<ItemFuncionalidade> itemFuncionalidades { get; set; }
    }
}
