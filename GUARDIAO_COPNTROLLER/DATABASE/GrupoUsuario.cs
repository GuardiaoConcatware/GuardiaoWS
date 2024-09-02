using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class GrupoUsuario
    {
        GUARDIAO_CRUD.DATABASE.GrupoUsuario objGrupoUsuario = null;


        public string InsertNewGrupoUsuario(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.GrupoUsuario grupoUsuario = null;
            try
            {
                grupoUsuario = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.GrupoUsuario>(json);
                objGrupoUsuario = new GUARDIAO_CRUD.DATABASE.GrupoUsuario();
                grupoUsuario = objGrupoUsuario.InsertNewGrupoUsuario(grupoUsuario);
            }
            catch (Exception ex)
            {
                if (grupoUsuario == null)
                    grupoUsuario = new GUARDIAO_STRUCTS.DATABASE.GrupoUsuario();
                grupoUsuario.resultCode = -1;
                grupoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuario).Namespace);
            }

            return JsonConvert.SerializeObject(grupoUsuario);
        }

        public string UpdateGrupoUsuario(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.GrupoUsuario grupoUsuario = null;
            try
            {
                grupoUsuario = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.GrupoUsuario>(json);
                objGrupoUsuario = new GUARDIAO_CRUD.DATABASE.GrupoUsuario();
                grupoUsuario = objGrupoUsuario.UpdateGrupoUsuario(grupoUsuario);
            }
            catch (Exception ex)
            {
                if (grupoUsuario == null)
                    grupoUsuario = new GUARDIAO_STRUCTS.DATABASE.GrupoUsuario();
                grupoUsuario.resultCode = -1;
                grupoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuario).Namespace);
            }

            return JsonConvert.SerializeObject(grupoUsuario);
        }

        public string GetGrupoUsuarioByID(long grupoUsuario_id)
        {
            GUARDIAO_STRUCTS.DATABASE.GrupoUsuario grupoUsuario = null;
            try
            {
                objGrupoUsuario = new GUARDIAO_CRUD.DATABASE.GrupoUsuario();
                grupoUsuario = objGrupoUsuario.GetGrupoUsuarioByID(grupoUsuario_id);
            }
            catch (Exception ex)
            {
                if (grupoUsuario == null)
                    grupoUsuario = new GUARDIAO_STRUCTS.DATABASE.GrupoUsuario();
                grupoUsuario.resultCode = -1;
                grupoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuario).Namespace);
            }

            return JsonConvert.SerializeObject(grupoUsuario);
        }

        public string GetAllGrupoUsuario()
        {
            List<GUARDIAO_STRUCTS.DATABASE.GrupoUsuario> grupoUsuarios = null;
            try
            {
                objGrupoUsuario = new GUARDIAO_CRUD.DATABASE.GrupoUsuario();
                grupoUsuarios = objGrupoUsuario.GetAllGrupoUsuario();
            }
            catch (Exception ex)
            {
                grupoUsuarios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuario).Namespace);
            }

            return JsonConvert.SerializeObject(grupoUsuarios);
        }

        public string GetGrupoFuncionalidadeDisponivel(long grupoUsuario_id)
        {
            List<GUARDIAO_STRUCTS.DATABASE.GrupoFuncionalidade> grupoFuncionalidades = null;
            try
            {
                objGrupoUsuario = new GUARDIAO_CRUD.DATABASE.GrupoUsuario();
                grupoFuncionalidades = objGrupoUsuario.GetGrupoFuncionalidadeDisponivel(grupoUsuario_id);
            }
            catch (Exception ex)
            {
                grupoFuncionalidades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuario).Namespace);
            }
            return JsonConvert.SerializeObject(grupoFuncionalidades);
        }

        public string GetItemFuncionalidadeByGrupoUsuarioByGrupoFuncionadade(long grupoUsuario_id, long grupoFuncionalidade_id)
        {
            List<GUARDIAO_STRUCTS.DATABASE.ItemFuncionalidade> itemFuncionalidades = null;
            try
            {
                objGrupoUsuario = new GUARDIAO_CRUD.DATABASE.GrupoUsuario();
                itemFuncionalidades = objGrupoUsuario.GetItemFuncionalidadeByGrupoUsuarioByGrupoFuncionadade(grupoUsuario_id, grupoFuncionalidade_id);
            }
            catch (Exception ex)
            {
                itemFuncionalidades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuario).Namespace);
            }
            return JsonConvert.SerializeObject(itemFuncionalidades);
        }

        public string SaveFuncionalidadesGrupoUsuario(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.GrupoUsuario grupoUsuario = null;
            try
            {
                grupoUsuario = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.GrupoUsuario>(json);
                objGrupoUsuario = new GUARDIAO_CRUD.DATABASE.GrupoUsuario();
                grupoUsuario = objGrupoUsuario.SaveFuncionalidadesGrupoUsuario(grupoUsuario);

            }
            catch (Exception ex)
            {
                if (grupoUsuario == null)
                    grupoUsuario = new GUARDIAO_STRUCTS.DATABASE.GrupoUsuario();
                grupoUsuario.resultCode = -1;
                grupoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuario).Namespace);
            }
            return JsonConvert.SerializeObject(grupoUsuario);
        }
    }
}