using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class TipoConsulta : Result
    {
        public long tipoConsulta_id { get; set; }

        public string tipoConsulta_descricao { get; set; }
    }
}
