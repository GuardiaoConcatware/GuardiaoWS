using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class Municipio
    {
        GUARDIAO_CRUD.DATABASE.Municipio objMunicipio = null;

        public string InsertNewMunicipio(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Municipio municipio = null;
            try
            {
                municipio = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Municipio>(json);
                objMunicipio = new GUARDIAO_CRUD.DATABASE.Municipio();
                municipio = objMunicipio.InsertNewMunicipio(municipio);
            }
            catch (Exception ex)
            {
                if (municipio == null)
                    municipio = new GUARDIAO_STRUCTS.DATABASE.Municipio();
                municipio.resultCode = -1;
                municipio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }

            return JsonConvert.SerializeObject(municipio);
        }

        public string UpdateMunicipio(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Municipio municipio = null;
            try
            {
                municipio = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Municipio>(json);
                objMunicipio = new GUARDIAO_CRUD.DATABASE.Municipio();
                municipio = objMunicipio.UpdateMunicipio(municipio);
            }
            catch (Exception ex)
            {
                if (municipio == null)
                    municipio = new GUARDIAO_STRUCTS.DATABASE.Municipio();
                municipio.resultCode = -1;
                municipio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }

            return JsonConvert.SerializeObject(municipio);
        }

        public string GetMunicipioByID(long municipio_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Municipio municipio = null;
            try
            {
                objMunicipio = new GUARDIAO_CRUD.DATABASE.Municipio();
                municipio = objMunicipio.GetEmpresaByID(municipio_id);
            }
            catch (Exception ex)
            {
                if (municipio == null)
                    municipio = new GUARDIAO_STRUCTS.DATABASE.Municipio();
                municipio.resultCode = -1;
                municipio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }

            return JsonConvert.SerializeObject(municipio);
        }

        public string GetAllUF()
        {
            List<string> municipios = null;
            try
            {
                objMunicipio = new GUARDIAO_CRUD.DATABASE.Municipio();
                municipios = objMunicipio.GetAllUF();
            }
            catch (Exception ex)
            {
                municipios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }

            return JsonConvert.SerializeObject(municipios);
        }

        public string GetAllMunicipioByUF(string UF)
        {
            List<GUARDIAO_STRUCTS.DATABASE.Municipio> municipios = null;
            try
            {
                objMunicipio = new GUARDIAO_CRUD.DATABASE.Municipio();
                municipios = objMunicipio.GetAllMunicipioByUF(UF);
            }
            catch (Exception ex)
            {
                municipios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }

            return JsonConvert.SerializeObject(municipios);
        }
        public string GetAllMunicipioByUFDart(string UF)
        {
            GUARDIAO_STRUCTS.DATABASE.MunicipioDart municipio = null;
            try
            {
                objMunicipio = new GUARDIAO_CRUD.DATABASE.Municipio();
                municipio = objMunicipio.GetAllMunicipioByUFDart(UF);
            }
            catch (Exception ex)
            {
                if (municipio == null)
                    municipio = new GUARDIAO_STRUCTS.DATABASE.MunicipioDart();
                municipio.resultCode = -1;
                municipio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }

            return JsonConvert.SerializeObject(municipio);
        }

        
    }
}
