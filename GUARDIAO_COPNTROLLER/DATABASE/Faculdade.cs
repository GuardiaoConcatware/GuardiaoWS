using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class Faculdade
    {
        private GUARDIAO_CRUD.DATABASE.Faculdade objFaculdade = null;
        public string InsertNewFaculdade(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Faculdade faculdade = null;
            try
            {
                faculdade = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Faculdade>(json);
                objFaculdade = new GUARDIAO_CRUD.DATABASE.Faculdade();
                faculdade = objFaculdade.InsertNewFaculdade(faculdade);
                faculdade.faculdade_logoMarca = null;
            }
            catch (Exception ex)
            {
                if (faculdade == null)
                    faculdade = new GUARDIAO_STRUCTS.DATABASE.Faculdade();
                faculdade.resultCode = -1;
                faculdade.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Faculdade).Namespace);
            }

            return JsonConvert.SerializeObject(faculdade);
        }

        public string UpdateFaculdade(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Faculdade faculdade = null;
            try
            {
                faculdade = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Faculdade>(json);
                objFaculdade = new GUARDIAO_CRUD.DATABASE.Faculdade();
                faculdade = objFaculdade.UpdateFaculdade(faculdade);
                faculdade.faculdade_logoMarca = null;
            }
            catch (Exception ex)
            {
                if (faculdade == null)
                    faculdade = new GUARDIAO_STRUCTS.DATABASE.Faculdade();
                faculdade.resultCode = -1;
                faculdade.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Faculdade).Namespace);
            }

            return JsonConvert.SerializeObject(faculdade);
        }

        public string GetFaculdadeByID(long faculdade_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Faculdade faculdade = null;
            try
            {
                objFaculdade = new GUARDIAO_CRUD.DATABASE.Faculdade();
                faculdade = objFaculdade.GetFaculdadeByID(faculdade_id);
            }
            catch (Exception ex)
            {
                if (faculdade == null)
                    faculdade = new GUARDIAO_STRUCTS.DATABASE.Faculdade();
                faculdade.resultCode = -1;
                faculdade.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Faculdade).Namespace);
            }

            return JsonConvert.SerializeObject(faculdade);
        }

        public string GetAllFaculdades()
        {
            List<GUARDIAO_STRUCTS.DATABASE.Faculdade> faculdades = null;
            try
            {
                objFaculdade = new GUARDIAO_CRUD.DATABASE.Faculdade();
                faculdades = objFaculdade.GetAllFaculdades();
            }
            catch (Exception ex)
            {
                faculdades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Faculdade).Namespace);
            }

            return JsonConvert.SerializeObject(faculdades);
        }

        public string GetAllFaculdadesAtivas()
        {
            List<GUARDIAO_STRUCTS.DATABASE.Faculdade> faculdades = null;
            try
            {
                objFaculdade = new GUARDIAO_CRUD.DATABASE.Faculdade();
                faculdades = objFaculdade.GetAllFaculdadesAtivas();
            }
            catch (Exception ex)
            {
                faculdades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Faculdade).Namespace);
            }

            return JsonConvert.SerializeObject(faculdades);
        }
    }
}
