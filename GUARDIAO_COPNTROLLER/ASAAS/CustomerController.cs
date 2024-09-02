using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.ASAAS
{
    public class CustomerController
    {
        GUARDIAO_CRUD.ASAAS.CustomerCrud objCustomerController = null;
        public string InsertCustomerController(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.ASAAS.CustomerSaida customerSaida = null;
            GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer customerEntrada = new GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer();
            try
            {
                customerEntrada = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer>(json);
                objCustomerController = new GUARDIAO_CRUD.ASAAS.CustomerCrud();
                customerSaida = objCustomerController.InsertCustomerCrud(customerEntrada);

            }
            catch (Exception ex)
            {
                /*if (extrato == null)
                    extrato = new GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer();
                extrato.resultCode = -1;
                extrato.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ExtratoController).Namespace);
            */
                }

            return JsonConvert.SerializeObject(customerSaida);
        }
    }
}
