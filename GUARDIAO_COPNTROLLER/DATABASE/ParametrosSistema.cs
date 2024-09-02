using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class ParametrosSistema
    {
        private GUARDIAO_CRUD.DATABASE.ParametrosSistema objParametrosSistema = null;
        public string InsertParametrosSistema(string json)
        {
            string sql = "";
            int reg = 0;
            GUARDIAO_STRUCTS.DATABASE.ParametrosSistema parametros = null;
            try
            {
                parametros = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.ParametrosSistema>(json);
                objParametrosSistema = new GUARDIAO_CRUD.DATABASE.ParametrosSistema();
                parametros = objParametrosSistema.InsertParametrosSistema(parametros);
            }
            catch (Exception ex)
            {
                if (parametros == null)
                    parametros = new GUARDIAO_STRUCTS.DATABASE.ParametrosSistema();
                parametros.resultCode = -1;
                parametros.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ParametrosSistema).Namespace);
            }

            return JsonConvert.SerializeObject(parametros);
        }

        public string GetParametrosSistema()
        {

            GUARDIAO_STRUCTS.DATABASE.ParametrosSistema parametros = null;
            try
            {
                objParametrosSistema = new GUARDIAO_CRUD.DATABASE.ParametrosSistema();
                parametros = objParametrosSistema.GetParametrosSistema();

            }
            catch (Exception ex)
            {
                if (parametros == null)
                    parametros = new GUARDIAO_STRUCTS.DATABASE.ParametrosSistema();
                parametros.resultCode = -1;
                parametros.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ParametrosSistema).Namespace);
            }

            return JsonConvert.SerializeObject(parametros);
        }
    }
}
