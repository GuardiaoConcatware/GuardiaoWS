using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER
{
    public class ExtratoController
    {
        GUARDIAO_CRUD.DATABASE.ExtratoCrud objExtrato = null;

        public string InsertExtrato(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Extrato extrato = null;
            try
            {
                extrato = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Extrato>(json);
                objExtrato = new GUARDIAO_CRUD.DATABASE.ExtratoCrud();
                extrato = objExtrato.InsertExtrato(extrato);

            }
            catch (Exception ex)
            {
                if (extrato == null)
                    extrato = new GUARDIAO_STRUCTS.DATABASE.Extrato();
                extrato.resultCode = -1;
                extrato.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ExtratoController).Namespace);
            }

            return JsonConvert.SerializeObject(extrato);
        }

        public string GetAllExtratos(long usuario_id)
        {

            GUARDIAO_STRUCTS.DATABASE.ExtratosList extratos = null;
            try
            {
                objExtrato = new GUARDIAO_CRUD.DATABASE.ExtratoCrud();
                extratos = objExtrato.GetExtrato(usuario_id);
            }
            catch (Exception ex)
            {
                extratos = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ExtratoController).Namespace);
            }
            return JsonConvert.SerializeObject(extratos);
        }

        public string GetExtratoByFiltro(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.ExtratosList extrato = null;
            GUARDIAO_STRUCTS.DATABASE.FiltroExtrato filtro = null;

            try
            {
                filtro = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.FiltroExtrato>(json);
                objExtrato = new GUARDIAO_CRUD.DATABASE.ExtratoCrud();
                extrato = objExtrato.GetExtratoByFiltro(filtro);
            }
            catch (Exception ex)
            {
                if (extrato == null)
                    extrato = new GUARDIAO_STRUCTS.DATABASE.ExtratosList();

                extrato.resultCode = -1;
                extrato.resultDescription = ex.Message;
            }
            return JsonConvert.SerializeObject(extrato);
        }
    }
}