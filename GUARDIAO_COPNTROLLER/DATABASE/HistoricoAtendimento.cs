using GUARDIAO_COMMOM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class HistoricoAtendimento
    {

        private GUARDIAO_CRUD.DATABASE.HistoricoAtendimento objHistoricoAtendimento = null;

        public string InsertHistoricoAtendimento(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimento historico = null;
            try
            {
                historico = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimento>(json);
                objHistoricoAtendimento = new GUARDIAO_CRUD.DATABASE.HistoricoAtendimento();
                historico = objHistoricoAtendimento.InsertHistoricoAtendimento(historico);

            }
            catch (Exception ex)
            {
                if (historico == null)
                    historico = new GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimento();
                historico.resultCode = -1;
                historico.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(HistoricoAtendimento).Namespace);
            }
            return JsonConvert.SerializeObject(historico);
        }
        public string GetHistoricoAtendimentoBySociliacaoAtendimentoID(long solicitacaoAtendimento_id)
        {
            GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull historico = null;
            try
            {
                objHistoricoAtendimento = new GUARDIAO_CRUD.DATABASE.HistoricoAtendimento();
                historico = objHistoricoAtendimento.GetHistoricoAtendimentoBySociliacaoAtendimentoID(solicitacaoAtendimento_id);

            }
            catch (Exception ex)
            {
                if (historico == null)
                    historico = new GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull();
                historico.resultCode = -1;
                historico.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(HistoricoAtendimento).Namespace);
            }
            return JsonConvert.SerializeObject(historico);
        }
        public string GetHistoricoAtendimentoByHistoricoID(long historicoAtendimento_id)
        {
            GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull historico = null;
            try
            {
                objHistoricoAtendimento = new GUARDIAO_CRUD.DATABASE.HistoricoAtendimento();
                historico = objHistoricoAtendimento.GetHistoricoAtendimentoByHistoricoID(historicoAtendimento_id);

            }
            catch (Exception ex)
            {
                if (historico == null)
                    historico = new GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull();
                historico.resultCode = -1;
                historico.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(HistoricoAtendimento).Namespace);
            }
            return JsonConvert.SerializeObject(historico);
        }
        public string GetArquivosHistoricoAtendimentoByID(long historicoAtendimento_id)
        {
            GUARDIAO_STRUCTS.DATABASE.ArquivoHistoricoAtendimentoFull arquivos = null;
            try
            {
                objHistoricoAtendimento = new GUARDIAO_CRUD.DATABASE.HistoricoAtendimento();
                arquivos = objHistoricoAtendimento.GetArquivosHistoricoAtendimentoByID(historicoAtendimento_id);
            }
            catch (Exception)
            {
                arquivos = null;
            }
            return JsonConvert.SerializeObject(arquivos);
        }
    }
}
