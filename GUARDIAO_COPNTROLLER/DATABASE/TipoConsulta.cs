using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class TipoConsulta
    {
        GUARDIAO_CRUD.DATABASE.TipoConsulta objTipoConsulta = null;

        public string InsertNewTipoConsulta(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.TipoConsulta tipoConsulta = null;
            try
            {
                tipoConsulta = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.TipoConsulta>(json);
                objTipoConsulta = new GUARDIAO_CRUD.DATABASE.TipoConsulta();
                tipoConsulta = objTipoConsulta.InsertNewTipoConsulta(tipoConsulta);
            }
            catch (Exception ex)
            {
                if (tipoConsulta == null)
                    tipoConsulta = new GUARDIAO_STRUCTS.DATABASE.TipoConsulta();
                tipoConsulta.resultCode = -1;
                tipoConsulta.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoConsulta).Namespace);
            }

            return JsonConvert.SerializeObject(tipoConsulta);
        }

        public string UpdateTipoConsulta(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.TipoConsulta tipoConsulta = null;
            try
            {
                tipoConsulta = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.TipoConsulta>(json);
                objTipoConsulta = new GUARDIAO_CRUD.DATABASE.TipoConsulta();
                tipoConsulta = objTipoConsulta.UpdateTipoConsulta(tipoConsulta);
            }
            catch (Exception ex)
            {
                if (tipoConsulta == null)
                    tipoConsulta = new GUARDIAO_STRUCTS.DATABASE.TipoConsulta();
                tipoConsulta.resultCode = -1;
                tipoConsulta.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoConsulta).Namespace);
            }

            return JsonConvert.SerializeObject(tipoConsulta);
        }

        public string GetTipoConsultaByID(long tipoConsulta_id)
        {
            GUARDIAO_STRUCTS.DATABASE.TipoConsulta tipoConsulta = null;
            try
            {
                objTipoConsulta = new GUARDIAO_CRUD.DATABASE.TipoConsulta();
                tipoConsulta = objTipoConsulta.GetTipoConsultaByID(tipoConsulta_id);
            }
            catch (Exception ex)
            {
                if (tipoConsulta == null)
                    tipoConsulta = new GUARDIAO_STRUCTS.DATABASE.TipoConsulta();
                tipoConsulta.resultCode = -1;
                tipoConsulta.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoConsulta).Namespace);
            }

            return JsonConvert.SerializeObject(tipoConsulta);
        }

        public string GetAllTipoConsulta()
        {
            List<GUARDIAO_STRUCTS.DATABASE.TipoConsulta> tipoConsultas = null;
            try
            {
                objTipoConsulta = new GUARDIAO_CRUD.DATABASE.TipoConsulta();
                tipoConsultas = objTipoConsulta.GetAllTipoConsulta();
            }
            catch (Exception ex)
            {
                tipoConsultas = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoConsulta).Namespace);
            }

            return JsonConvert.SerializeObject(tipoConsultas);
        }
    }
}
