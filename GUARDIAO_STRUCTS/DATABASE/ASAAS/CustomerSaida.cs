using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE.ASAAS
{
    /*
            public string name { get; set; }
        public string email { get; set; }
        public string cpfCnpj { get; set; }
        public string postalCode { get; set; }
        public string addressNumber { get; set; }
        public string phone { get; set; }
        public bool notificationDisabled { get; set; }
     */
    public class CustomerSaida
    {
        public string @object { get; set; }
        public string id { get; set; }
        public string name { get; set; }

        public string email { get; set; }

        public string phone { get; set; }
        public string addressNumber { get; set; }
        public string postalCode { get; set; }
        public string cpfCnpj { get; set; }
        public string personType { get; set; }
        public bool deleted { get; set; }
        public bool notificationDisabled { get; set; }
        public bool canDelete { get; set; }
        public bool cannotBeDeletedReason { get; set; }
        public bool canEdit { get; set; }
        public bool cannotEditReason { get; set; }
    }
}
