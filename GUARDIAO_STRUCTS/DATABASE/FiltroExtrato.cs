using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class FiltroExtrato : Result
    {
        public long usuario_id { get; set; }
        public long tipoExtrato_id { get; set; }
        public string extrato_dataInicial { get; set; }
        public string extrato_dataFinal { get; set; }
    }
}
