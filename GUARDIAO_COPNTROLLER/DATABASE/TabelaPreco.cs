using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class TabelaPreco
    {
        GUARDIAO_CRUD.DATABASE.TabelaPreco objTabelaPreco = null;

        public string InsertNewTabelaPreco(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.TabelaPreco tabelaPreco = null;
            try
            {
                tabelaPreco = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.TabelaPreco>(json);
                objTabelaPreco = new GUARDIAO_CRUD.DATABASE.TabelaPreco();
                tabelaPreco = objTabelaPreco.InsertNewTabelaPreco(tabelaPreco);
            }
            catch (Exception ex)
            {
                if (tabelaPreco == null)
                    tabelaPreco = new GUARDIAO_STRUCTS.DATABASE.TabelaPreco();
                tabelaPreco.resultCode = -1;
                tabelaPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TabelaPreco).Namespace);
            }

            return JsonConvert.SerializeObject(tabelaPreco);
        }

        public string UpdateTabelaPreco(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.TabelaPreco tabelaPreco = null;
            try
            {
                tabelaPreco = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.TabelaPreco>(json);
                objTabelaPreco = new GUARDIAO_CRUD.DATABASE.TabelaPreco();
                tabelaPreco = objTabelaPreco.UpdateTabelaPreco(tabelaPreco);
            }
            catch (Exception ex)
            {
                if (tabelaPreco == null)
                    tabelaPreco = new GUARDIAO_STRUCTS.DATABASE.TabelaPreco();
                tabelaPreco.resultCode = -1;
                tabelaPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TabelaPreco).Namespace);
            }

            return JsonConvert.SerializeObject(tabelaPreco);
        }

        public string GetTabelaPrecoByID(long tabelaPreco_id)
        {
            GUARDIAO_STRUCTS.DATABASE.TabelaPreco tabelaPreco = null;
            try
            {
                objTabelaPreco = new GUARDIAO_CRUD.DATABASE.TabelaPreco();
                tabelaPreco = objTabelaPreco.GetTabelaPrecoByID(tabelaPreco_id);
            }
            catch (Exception ex)
            {
                if (tabelaPreco == null)
                    tabelaPreco = new GUARDIAO_STRUCTS.DATABASE.TabelaPreco();
                tabelaPreco.resultCode = -1;
                tabelaPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TabelaPreco).Namespace);
            }

            return JsonConvert.SerializeObject(tabelaPreco);
        }

        public string GetAllTabelaPreco()
        {
            List<GUARDIAO_STRUCTS.DATABASE.TabelaPreco> tabelaPrecos = null;
            try
            {
                objTabelaPreco = new GUARDIAO_CRUD.DATABASE.TabelaPreco();
                tabelaPrecos = objTabelaPreco.GetAllTabelaPreco();
            }
            catch (Exception ex)
            {
                tabelaPrecos = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TabelaPreco).Namespace);
            }

            return JsonConvert.SerializeObject(tabelaPrecos);
        }
    }
}
