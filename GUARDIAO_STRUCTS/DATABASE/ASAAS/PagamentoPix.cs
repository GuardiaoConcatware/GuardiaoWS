using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE.ASAAS
{
    public class PagamentoPix : Errors
    {
        public bool success { get; set; }
        public string encodedImage { get; set; }
        public string payload { get; set; }
        public string expirationDate { get; set; }
    }
}
