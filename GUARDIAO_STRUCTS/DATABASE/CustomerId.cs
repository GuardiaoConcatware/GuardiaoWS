using GUARDIAO_STRUCTS.DATABASE.ASAAS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class CustomerId : Errors
    {
        public string customer_id { get; set; }
        public long usuario_id { get; set; }
    }
}
