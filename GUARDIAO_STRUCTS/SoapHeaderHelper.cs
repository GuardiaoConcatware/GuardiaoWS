using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

namespace GUARDIAO_STRUCTS
{
    public class SoapHeaderHelper : SoapHeader
    {
        public string guardiaoClient_user { get; set; }
        public string guardiaoClient_passwords { get; set; }
    }
}
