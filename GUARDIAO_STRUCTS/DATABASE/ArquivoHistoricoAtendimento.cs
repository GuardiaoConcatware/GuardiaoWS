using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class ArquivoHistoricoAtendimento : Result
    {
        public long arquivoHistoricoAtendimento_id { get; set; }

        public long historicoAtendimento_id { get; set; }

        public string arquivoHistoricoAtendimento_ext { get; set; }

        public string arquivoHistoricoAtendimento_file { get; set; }
    }
}
