using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE.ASAAS
{
    public class QrCodeEstaticoSaida
    {
        public string id { get; set; }
        public string encodedImage { get; set; }
        public string payload { get; set; }
        public bool allowsMultiplePayments { get; set; }
        public string expirationDate { get; set; }
        public string externalReference { get; set; }

    }
}
