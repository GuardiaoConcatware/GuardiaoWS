using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE.ASAAS
{
    public class CreditCard
    {
        public string holderName { get; set; }
        public string number { get; set; }
        public string expiryMonth { get; set; }
        public string expiryYear { get; set; }
        public string ccv { get; set; }
        public CreditCardHolderInfo creditCardHolderInfo { get; set; }
    }
}
