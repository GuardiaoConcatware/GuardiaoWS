using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE.ASAAS
{
    public class CreatePixSaida
    {
        public string id { get; set; }
        public string key { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string dateCreated { get; set; }
        public bool canBeDeleted { get; set; }
        public bool cannotBeDeletedReason { get; set; }
        public QrCode qrCode { get; set; }
    }
}
