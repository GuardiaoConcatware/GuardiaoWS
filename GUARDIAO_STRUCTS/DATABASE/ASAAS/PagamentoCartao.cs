using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE.ASAAS
{
    public class PagamentoCartao
    {
        public string billingType { get; set; }
        public CreditCard creditCard { get; set; }
        public CreditCardHolderInfo creditCardHolderInfo { get; set; }
        public string customer { get; set; }

        public float value { get; set; }
        public string dueDate { get; set; }
        public bool authorizeOnly { get; set; }
        public string remoteIp { get; set; }
    }
}
