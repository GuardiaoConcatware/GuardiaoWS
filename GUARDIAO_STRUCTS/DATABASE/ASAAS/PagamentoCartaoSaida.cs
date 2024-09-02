using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE.ASAAS
{
    public class PagamentoCartaoSaida
    {
        public string @object { get; set; }
        public string id { get; set; }
        public string dateCreated { get; set; }
        public string customer { get; set; }
        public string paymentLink { get; set; }
        public float value { get; set; }
        public float netValue { get; set; }

        public string originalValue { get; set; }
        public string interestValue { get; set; }
        public string description { get; set; }
        public string billingType { get; set; }
        public string confirmedDate { get; set; }
        public CreditCard creditCard { get; set; }
        public string pixTransaction { get; set; }
        public string status { get; set; }
        public string dueDate { get; set; }
        public string originalDueDate { get; set; }
        public string paymentDate { get; set; }
        public string clientPaymentDate { get; set; }
    
    }
}

