using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.ASAAS
{
    public class PagamentoCartaoController
    {
        private GUARDIAO_HELPER_ASAAS.REST.ApiHelper objPagamentoCartao = null;
        public string InsertPagamentoCartao(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.ASAAS.PagamentoCartao pagamentoCartao = null;
            GUARDIAO_STRUCTS.DATABASE.ASAAS.PagamentoCartaoSaida pagamentoCartaoSaida = null;
            try
            {
                pagamentoCartao = Newtonsoft.Json.JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.ASAAS.PagamentoCartao>(json);
                objPagamentoCartao = new GUARDIAO_HELPER_ASAAS.REST.ApiHelper();
                pagamentoCartaoSaida = objPagamentoCartao.PagamentoCartao(pagamentoCartao);        
                
            }
            catch (Exception ex)
            {
                if (pagamentoCartaoSaida == null)
                {
                    pagamentoCartaoSaida = new GUARDIAO_STRUCTS.DATABASE.ASAAS.PagamentoCartaoSaida();
                    GUARDIAO_STRUCTS.DATABASE.ASAAS.Errors errors = new GUARDIAO_STRUCTS.DATABASE.ASAAS.Errors();
                    errors.description = ex.Message;
                }
            }
            return JsonConvert.SerializeObject(pagamentoCartaoSaida);
            // return JsonConvert.SerializeObject(pagamentoCartao);
        }
        
    }
}
