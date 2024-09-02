using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.ASAAS
{
    public class QrCodeEstaticoController
    {
        private GUARDIAO_CRUD.ASAAS.QrCodeCrud objQrCodeEstatico = null;
        public string GetQrCode()
        {
            GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida qrCodeEstatico = null;
            try
            {
                objQrCodeEstatico = new GUARDIAO_CRUD.ASAAS.QrCodeCrud();
                qrCodeEstatico = objQrCodeEstatico.GetQrCode();
            }
            catch (Exception ex)
            {
                if(qrCodeEstatico == null)
                {
                    qrCodeEstatico = new GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida();
                    
                }
                //qrCodeEstatico.resultCode = -1;
                //qrCodeEstatico.resultDescription = ex.Message;
            }
            return JsonConvert.SerializeObject(qrCodeEstatico);
        }

        public string InsertQrcode(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstatico qrCodeEstatico = null;
            GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida qrCodeEstaticoSaida = null;
            try
            {
                qrCodeEstatico = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstatico>(json);
                objQrCodeEstatico = new GUARDIAO_CRUD.ASAAS.QrCodeCrud();
                qrCodeEstaticoSaida = objQrCodeEstatico.InsertQrCode(qrCodeEstatico);
            }
            catch (Exception ex)
            {
                if(qrCodeEstatico == null)
                {
                    qrCodeEstatico = new GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstatico();
                    //qrCodeEstatico.resultCode = -1;
                    qrCodeEstatico.description = ex.Message;
                }
            }
            return JsonConvert.SerializeObject(qrCodeEstatico);
        }
    }
}
