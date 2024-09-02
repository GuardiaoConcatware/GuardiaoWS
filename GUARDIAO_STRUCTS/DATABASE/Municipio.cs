using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Municipio : Result
    {
        public long municipio_id { get; set; }

        public long municipio_codigo { get; set; }

        public long municipio_codigo2 { get; set; }

        public string municipio_nome { get; set; }

        public string municipio_uf { get; set; }
    }
}
