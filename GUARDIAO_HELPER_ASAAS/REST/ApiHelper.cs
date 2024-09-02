using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace GUARDIAO_HELPER_ASAAS.REST
{
    public class ApiHelper
    {
        //pay_oc6wh9l7libncewp
        private string URL_SANDBOX = "https://sandbox.asaas.com/api/v3/";
        private string URL_PRODUCAO = "https://api.asaas.com/";
        private string API_KEY_SANDBOX = "$aact_YTU5YTE0M2M2N2I4MTliNzk0YTI5N2U5MzdjNWZmNDQ6OjAwMDAwMDAwMDAwMDAwODA3OTI6OiRhYWNoXzUwNjg2NWRjLWQ2ZDYtNDljNy1iZDYxLTlhZjUwM2I2ZmViNw==";
        private string API_KEY_PRODUCAO = "";

        #region CLIENTE

        public GUARDIAO_STRUCTS.DATABASE.ASAAS.CustomerSaida InsertCustomer(GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer customer)
        {
            GUARDIAO_STRUCTS.DATABASE.ASAAS.CustomerSaida insertCustomer = null;

            try
            {
                var options = new RestClientOptions("https://sandbox.asaas.com/api/v3/customers");
                var client = new RestClient(options);
                var request = new RestRequest(new Uri("https://sandbox.asaas.com/api/v3/customers"),Method.Post);
                request.AddHeader("accept", "application/json");
                request.AddHeader("access_token", API_KEY_SANDBOX);
                request.AddJsonBody(JsonConvert.SerializeObject(customer), false);
                var response = client.Post(request);
                var result = response.Content;
                insertCustomer = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.ASAAS.CustomerSaida>(response.Content);

            }
            catch (Exception ex)
            {
                /*
                if (insertCustomer == null)
                {
                    insertCustomer = new GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer();
                    //insertCustomer.resultCode = -1;
                    insertCustomer.description = ex.Message;
                }
                */
            }
            return insertCustomer;
        }
        #endregion

        #region CARTÃO
        public GUARDIAO_STRUCTS.DATABASE.ASAAS.PagamentoCartaoSaida PagamentoCartao(GUARDIAO_STRUCTS.DATABASE.ASAAS.PagamentoCartao cartaoBody)
        {
            GUARDIAO_STRUCTS.DATABASE.ASAAS.PagamentoCartaoSaida pagamentoCartao = null;
            GUARDIAO_STRUCTS.DATABASE.ASAAS.Errors erros = null;


            try
            {
                var options = new RestClientOptions("https://sandbox.asaas.com/api/v3/payments/");
                var client = new RestClient(options);
                var request = new RestRequest(new Uri("https://sandbox.asaas.com/api/v3/payments/"), Method.Post);
                request.AddHeader("accept", "application/json");
                request.AddHeader("access_token", API_KEY_SANDBOX);
                request.AddJsonBody(JsonConvert.SerializeObject(cartaoBody), false);
                var response = client.Post(request);
                var result = response.Content;
                pagamentoCartao = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.ASAAS.PagamentoCartaoSaida>(response.Content);

            }
            catch (Exception ex)
            {
                erros.description = ex.Message;


            }
            return pagamentoCartao;
        }
        #endregion

        #region PIX

        public GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePixSaida CriarChavePix(GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePix createPixBody)
        {
            GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePixSaida chavePix = null;
            try
            {

                var options = new RestClientOptions($"{URL_SANDBOX}addressKeys");
                var client = new RestClient(options);
                var request = new RestRequest(new Uri("https://sandbox.asaas.com/api/v3/addressKeys"), Method.Post);
                request.AddHeader("accept", "application/json");
                request.AddHeader("access_token", API_KEY_SANDBOX);
                request.AddJsonBody(JsonConvert.SerializeObject(createPixBody), false);
                var response = client.Post(request);
                var result = response.Content;
                chavePix = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePixSaida>(response.Content);
            }
            catch (Exception error)
            {
                /*
                if (chavePix == null)
                {
                    chavePix = new GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePix();
                    chavePix.code = error.Message;
                    chavePix.description = error.Message;
                }*/
            }
            return chavePix;

        }
        public GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida QrcodeEstatico(GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstatico qrCodeEstatico)
        {
            GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida qrCode = null;
            try
            {
                var options = new RestClientOptions("https://sandbox.asaas.com/api/v3/pix/qrCodes/static");
                var client = new RestClient(options);
                var request = new RestRequest(new Uri("https://sandbox.asaas.com/api/v3/pix/qrCodes/static"), Method.Post);
                request.AddHeader("accept", "application/json");
                request.AddHeader("access_token", "$aact_YTU5YTE0M2M2N2I4MTliNzk0YTI5N2U5MzdjNWZmNDQ6OjAwMDAwMDAwMDAwMDAwODA3OTI6OiRhYWNoXzUwNjg2NWRjLWQ2ZDYtNDljNy1iZDYxLTlhZjUwM2I2ZmViNw==");
                request.AddJsonBody(JsonConvert.SerializeObject(qrCodeEstatico), false);
                var response = client.Post(request);
                var result = response.Content;
                qrCode = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida>(response.Content);

            }
            catch (Exception error)
            {
                /*
                if (qrCode == null)
                {
                    qrCode = new GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstatico();
                    //qrCode.resultCode = -1;
                    qrCode.description = error.Message;
                }
                */
            }
            return qrCode;
        }
        #endregion
    }
}
