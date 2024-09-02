using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Anuncio : Result
    {
        public long anuncio_id { get; set; }
        public string anuncio_link { get; set; }
        public string anuncio_dataCadastro { get; set; }
        public string anuncio_banner { get; set; }
        public string anuncio_descricao { get; set; }
        public string anuncio_titulo { get; set; }
    }
}
