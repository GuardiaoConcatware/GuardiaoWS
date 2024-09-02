using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class Escritorio
    {
        private GUARDIAO_CRUD.DATABASE.Escritorio objEscritorio = null;

        public string InsertNewEscritorio(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Escritorio escritorio = null;
            try
            {
                escritorio = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Escritorio>(json);
                objEscritorio = new GUARDIAO_CRUD.DATABASE.Escritorio();
                escritorio = objEscritorio.InsertNewEscritorio(escritorio);

            }
            catch (Exception ex)
            {
                if (escritorio == null)
                    escritorio = new GUARDIAO_STRUCTS.DATABASE.Escritorio();
                escritorio.resultCode = -1;
                escritorio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Escritorio).Namespace);
            }

            return JsonConvert.SerializeObject(escritorio);
        }

        public string UpdateEscritorio(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Escritorio escritorio = null;
            try
            {
                escritorio = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Escritorio>(json);
                objEscritorio = new GUARDIAO_CRUD.DATABASE.Escritorio();
                escritorio = objEscritorio.UpdateEscritorio(escritorio);

            }
            catch (Exception ex)
            {
                if (escritorio == null)
                    escritorio = new GUARDIAO_STRUCTS.DATABASE.Escritorio();
                escritorio.resultCode = -1;
                escritorio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Escritorio).Namespace);
            }

            return JsonConvert.SerializeObject(escritorio);
        }

        public string GetEscritorioByID(long escritorio_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Escritorio escritorio = null;
            try
            {
                objEscritorio = new GUARDIAO_CRUD.DATABASE.Escritorio();
                escritorio = objEscritorio.GetEscritorioByID(escritorio_id);
            }
            catch (Exception ex)
            {
                if (escritorio == null)
                    escritorio = new GUARDIAO_STRUCTS.DATABASE.Escritorio();
                escritorio.resultCode = -1;
                escritorio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Escritorio).Namespace);
            }

            return JsonConvert.SerializeObject(escritorio);
        }
        public string GetAllEscritorios()
        {
            List<GUARDIAO_STRUCTS.DATABASE.Escritorio> escritorios = null;
            try
            {
                objEscritorio = new GUARDIAO_CRUD.DATABASE.Escritorio();
                escritorios = objEscritorio.GetAllEscritorios();
            }
            catch (Exception ex)
            {
                escritorios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Escritorio).Namespace);
            }
            return JsonConvert.SerializeObject(escritorios);
        }
        public string GetAllEscritoriosAtivos()
        {
            List<GUARDIAO_STRUCTS.DATABASE.Escritorio> escritorios = null;
            try
            {
                objEscritorio = new GUARDIAO_CRUD.DATABASE.Escritorio();
                escritorios = objEscritorio.GetAllEscritoriosAtivos();
            }
            catch (Exception ex)
            {
                escritorios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Escritorio).Namespace);
            }
            return JsonConvert.SerializeObject(escritorios);
        }

    }
}
