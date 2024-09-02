using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.SOAPHEADER
{
    public class ValidateSoapHeader
    {
        public bool Valdate(GUARDIAO_STRUCTS.SoapHeaderHelper soapHeader)
        {
            bool resul = true;
            string user = "";
            string pwd = "";
            try
            {

                user = GUARDIAO_COMMOM.Crypto.DecryptSentence(soapHeader.guardiaoClient_user).Trim();
                pwd = GUARDIAO_COMMOM.Crypto.DecryptSentence(soapHeader.guardiaoClient_passwords).Trim();

                if (user != "guarda_client" || pwd != "guarda_#2024/2024+ecv*newSystem")
                    resul = false;


            }
            catch (Exception ex)
            {
                resul = false;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ValidateSoapHeader).Namespace);
            }
            return resul;
        }
    }
}
