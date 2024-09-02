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
    public class SolicitacaoAtendimento
    {
        private GUARDIAO_CRUD.DATABASE.SolicitacaoAtendimento objSolicitacaoAtendimento = null;
        public string InsertSolicitacao(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento solicitacao = null;
            try
            {
                solicitacao = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento>(json);
                objSolicitacaoAtendimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoAtendimento();
                solicitacao = objSolicitacaoAtendimento.InsertSolicitacao(solicitacao);

            }
            catch (Exception ex)
            {
                if (solicitacao == null)
                    solicitacao = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento();
                solicitacao.resultCode = -1;
                solicitacao.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return JsonConvert.SerializeObject(solicitacao);
        }
        public string UpdateStatusSolicitacao(long solicitacaoAtendimento_id, string newStatus)
        {

            bool resul = true;
            try
            {
                objSolicitacaoAtendimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoAtendimento();
                resul = objSolicitacaoAtendimento.UpdateStatusSolicitacao(solicitacaoAtendimento_id, newStatus);

            }
            catch (Exception ex)
            {
                resul = false;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return JsonConvert.SerializeObject(resul);
        }
        public string UpdateStatusSolicitacaoChat(long solicitacaoAtendimento_id, string solicitacaoAtendimento_identity)
        {

            bool resul = true;
            try
            {
                objSolicitacaoAtendimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoAtendimento();
                resul = objSolicitacaoAtendimento.UpdateStatusSolicitacaoChat(solicitacaoAtendimento_id, solicitacaoAtendimento_identity);

            }
            catch (Exception ex)
            {
                resul = false;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return JsonConvert.SerializeObject(resul);
        }
        public string GetAllSolicitacoesAtendimento(long advogado_id, int solicitacaoAtendimento_tipo)
        {

            List<GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento> solicitacaos = null;
            try
            {
                objSolicitacaoAtendimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoAtendimento();
                solicitacaos = objSolicitacaoAtendimento.GetAllSolicitacoesAtendimento(advogado_id, solicitacaoAtendimento_tipo);
            }
            catch (Exception ex)
            {
                solicitacaos = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return JsonConvert.SerializeObject(solicitacaos);
        }

        public string GetAllSolicitacoesAtendimentoDart(long advogado_id, int solicitacaoAtendimento_tipo)
        {

            GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimentoDart solicitacaos = null;
            try
            {
                objSolicitacaoAtendimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoAtendimento();
                solicitacaos = objSolicitacaoAtendimento.GetAllSolicitacoesAtendimentoDart(advogado_id, solicitacaoAtendimento_tipo);
            }
            catch (Exception ex)
            {
                solicitacaos = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return JsonConvert.SerializeObject(solicitacaos);
        }
        public string DescartarSolicitacao(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.DescarteSolicitacaoAtendimento descarte = null;
            try
            {

                descarte = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.DescarteSolicitacaoAtendimento>(json);
                objSolicitacaoAtendimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoAtendimento();
                descarte = objSolicitacaoAtendimento.DescartarSolicitacao(descarte);
            }
            catch (Exception ex)
            {
                if (descarte == null)
                    descarte = new GUARDIAO_STRUCTS.DATABASE.DescarteSolicitacaoAtendimento();
                descarte.resultCode = -1;
                descarte.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }

            return JsonConvert.SerializeObject(descarte);
        }
        public string GetSolicitacoesAtendimentoByID(long solicitacaoAtendimento_id)
        {

            GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento solicitacao = null;
            try
            {
                objSolicitacaoAtendimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoAtendimento();
                solicitacao = objSolicitacaoAtendimento.GetSolicitacoesAtendimentoByID(solicitacaoAtendimento_id);

            }
            catch (Exception ex)
            {
                if (solicitacao == null)
                    solicitacao = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento();
                solicitacao.resultCode = -1;
                solicitacao.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return JsonConvert.SerializeObject(solicitacao);
        }
    }

}
