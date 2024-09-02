using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class PercentualPreco
    {
        private GUARDIAO_CRUD.DATABASE.PercentualPreco objPercentualPreco = null;
        public string InsertNewPercentualPreco(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.PercentualPreco percentualPreco = null;
            try
            {
                percentualPreco = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.PercentualPreco>(json);
                objPercentualPreco = new GUARDIAO_CRUD.DATABASE.PercentualPreco();
                percentualPreco = objPercentualPreco.InsertNewPercentualPreco(percentualPreco);
            }
            catch (Exception ex)
            {
                if (percentualPreco == null)
                    percentualPreco = new GUARDIAO_STRUCTS.DATABASE.PercentualPreco();
                percentualPreco.resultCode = -1;
                percentualPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(PercentualPreco).Namespace);
            }

            return JsonConvert.SerializeObject(percentualPreco);
        }
        public string UpdatePercentualPreco(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.PercentualPreco percentualPreco = null;
            try
            {
                percentualPreco = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.PercentualPreco>(json);
                objPercentualPreco = new GUARDIAO_CRUD.DATABASE.PercentualPreco();
                percentualPreco = objPercentualPreco.UpdatePercentualPreco(percentualPreco);
            }
            catch (Exception ex)
            {
                if (percentualPreco == null)
                    percentualPreco = new GUARDIAO_STRUCTS.DATABASE.PercentualPreco();
                percentualPreco.resultCode = -1;
                percentualPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(PercentualPreco).Namespace);
            }

            return JsonConvert.SerializeObject(percentualPreco);
        }
        public string GetPercentualPrecoByID(long percentualPreco_id)
        {
            GUARDIAO_STRUCTS.DATABASE.PercentualPreco percentualPreco = null;
            try
            {
                objPercentualPreco = new GUARDIAO_CRUD.DATABASE.PercentualPreco();
                percentualPreco = objPercentualPreco.GetPercentualPrecoByID(percentualPreco_id);
            }
            catch (Exception ex)
            {
                if (percentualPreco == null)
                    percentualPreco = new GUARDIAO_STRUCTS.DATABASE.PercentualPreco();
                percentualPreco.resultCode = -1;
                percentualPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(PercentualPreco).Namespace);
            }

            return JsonConvert.SerializeObject(percentualPreco);
        }
        public string GetAllPercentualPrecoByAdvogadoByAtivo(long advogado_id, bool percentualPreco_ativo)
        {
            List<GUARDIAO_STRUCTS.DATABASE.PercentualPreco> percentualPrecos = null;
            try
            {
                objPercentualPreco = new GUARDIAO_CRUD.DATABASE.PercentualPreco();
                percentualPrecos = objPercentualPreco.GetAllPercentualPrecoByAdvogadoByAtivo(advogado_id, percentualPreco_ativo);
            }
            catch (Exception ex)
            {
                percentualPrecos = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(PercentualPreco).Namespace);
            }

            return JsonConvert.SerializeObject(percentualPrecos);
        }
    }
}
