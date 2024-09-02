using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class TipoUsuario
    {
        GUARDIAO_CRUD.DATABASE.TipoUsuario objtipoUsuario = null;

        public string InsertNewTipoUsuario(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.TipoUsuario tipoUsuario = null;
            try
            {
                tipoUsuario = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.TipoUsuario>(json);
                objtipoUsuario = new GUARDIAO_CRUD.DATABASE.TipoUsuario();
                tipoUsuario = objtipoUsuario.InsertNewTipoUsuario(tipoUsuario);
            }
            catch (Exception ex)
            {
                if (tipoUsuario == null)
                    tipoUsuario = new GUARDIAO_STRUCTS.DATABASE.TipoUsuario();
                tipoUsuario.resultCode = -1;
                tipoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoUsuario).Namespace);
            }

            return JsonConvert.SerializeObject(tipoUsuario);
        }

        public string UpdateTipoUsuario(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.TipoUsuario tipoUsuario = null;
            try
            {
                tipoUsuario = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.TipoUsuario>(json);
                objtipoUsuario = new GUARDIAO_CRUD.DATABASE.TipoUsuario();
                tipoUsuario = objtipoUsuario.UpdateTipoUsuario(tipoUsuario);
            }
            catch (Exception ex)
            {
                if (tipoUsuario == null)
                    tipoUsuario = new GUARDIAO_STRUCTS.DATABASE.TipoUsuario();
                tipoUsuario.resultCode = -1;
                tipoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoUsuario).Namespace);
            }

            return JsonConvert.SerializeObject(tipoUsuario);
        }

        public string GetTipUsuarioByID(long tipoUsuario_id)
        {
            GUARDIAO_STRUCTS.DATABASE.TipoUsuario tipoUsuario = null;
            try
            {
                objtipoUsuario = new GUARDIAO_CRUD.DATABASE.TipoUsuario();
                tipoUsuario = objtipoUsuario.GetTipoUsuarioByID(tipoUsuario_id);
            }
            catch (Exception ex)
            {
                if (tipoUsuario == null)
                    tipoUsuario = new GUARDIAO_STRUCTS.DATABASE.TipoUsuario();
                tipoUsuario.resultCode = -1;
                tipoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoConsulta).Namespace);
            }

            return JsonConvert.SerializeObject(tipoUsuario);
        }

        public string GetAllTipoUsuario(long especieUsuario_id)
        {
            List<GUARDIAO_STRUCTS.DATABASE.TipoUsuario> tipoUsuarios = null;
            try
            {
                objtipoUsuario = new GUARDIAO_CRUD.DATABASE.TipoUsuario();
                tipoUsuarios = objtipoUsuario.GetAllTipoUsuario(especieUsuario_id);
            }
            catch (Exception ex)
            {
                tipoUsuarios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoUsuario).Namespace);
            }

            return JsonConvert.SerializeObject(tipoUsuarios);
        }
    }
}
