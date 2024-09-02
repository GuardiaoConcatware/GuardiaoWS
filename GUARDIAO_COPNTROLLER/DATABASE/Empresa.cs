using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class Empresa
    {
        GUARDIAO_CRUD.DATABASE.Empresa objEmpresa = null;

        public string InsertNewEmpresa(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Empresa empresa = null;
            try
            {
                empresa = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Empresa>(json);
                objEmpresa = new GUARDIAO_CRUD.DATABASE.Empresa();
                empresa = objEmpresa.InsertNewEmpresa(empresa);
            }
            catch (Exception ex)
            {
                if (empresa == null)
                    empresa = new GUARDIAO_STRUCTS.DATABASE.Empresa();
                empresa.resultCode = -1;
                empresa.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Empresa).Namespace);
            }

            return JsonConvert.SerializeObject(empresa);
        }

        public string UpdateEmpresa(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Empresa empresa = null;
            try
            {
                empresa = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Empresa>(json);
                objEmpresa = new GUARDIAO_CRUD.DATABASE.Empresa();
                empresa = objEmpresa.UpdateEmpresa(empresa);
            }
            catch (Exception ex)
            {
                if (empresa == null)
                    empresa = new GUARDIAO_STRUCTS.DATABASE.Empresa();
                empresa.resultCode = -1;
                empresa.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Empresa).Namespace);
            }

            return JsonConvert.SerializeObject(empresa);
        }

        public string GetEmpresaByID(long empresa_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Empresa empresa = null;
            try
            {
                objEmpresa = new GUARDIAO_CRUD.DATABASE.Empresa();
                empresa = objEmpresa.GetEmpresaByID(empresa_id);
            }
            catch (Exception ex)
            {
                if (empresa == null)
                    empresa = new GUARDIAO_STRUCTS.DATABASE.Empresa();
                empresa.resultCode = -1;
                empresa.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Empresa).Namespace);
            }

            return JsonConvert.SerializeObject(empresa);
        }

        public string GetAllEmpresa()
        {
            List<GUARDIAO_STRUCTS.DATABASE.Empresa> empresas = null;
            try
            {
                objEmpresa = new GUARDIAO_CRUD.DATABASE.Empresa();
                empresas = objEmpresa.GetAllEmpresa();
            }
            catch (Exception ex)
            {
                empresas = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Empresa).Namespace);
            }

            return JsonConvert.SerializeObject(empresas);
        }
    }
}
