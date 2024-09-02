using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class ItemFuncionalidade : Result
    {
        public long itemFuncionalidade_id { get; set; }

        public long grupoFuncionalidade_id { get; set; }

        public string itemFuncionalidade_nome { get; set; }

    }
}
