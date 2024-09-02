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
    public class SolicitacaoRecebimento
    {
        GUARDIAO_CRUD.DATABASE.SolicitacaoRecebimento objSolicitacaoRecebimento = null;
        public string GetAllSolicitacoesRecebimento()
        {
            GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList solicitacoesRecebimentosList = null;
            try
            {
                objSolicitacaoRecebimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoRecebimento();
                solicitacoesRecebimentosList = objSolicitacaoRecebimento.GetAllSolicitacoesRecebimento();
            }
            catch (Exception ex)
            {
                solicitacoesRecebimentosList = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoRecebimento).Namespace);
            }
            return JsonConvert.SerializeObject(solicitacoesRecebimentosList); ;
        }

        public string GetAllSolicitacoesRecebimentoByUsuarioId(long usuario_id)
        {
            GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList solicitacoesRecebimentosList = null;
            try
            {
                objSolicitacaoRecebimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoRecebimento();
                solicitacoesRecebimentosList = objSolicitacaoRecebimento.GetAllSolicitacoesRecebimentoByUsuarioId(usuario_id);
            }
            catch (Exception ex)
            {
                solicitacoesRecebimentosList = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoRecebimento).Namespace);
            }
            return JsonConvert.SerializeObject(solicitacoesRecebimentosList); ;
        }

        public string InsertSolicitacaoRecebimento(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento solicitacaoRecebimento = null;
            try
            {
                solicitacaoRecebimento = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento>(json);
                objSolicitacaoRecebimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoRecebimento();
                solicitacaoRecebimento = objSolicitacaoRecebimento.InsertSolicitacaoRecebimento(solicitacaoRecebimento);

            }
            catch (Exception ex)
            {
                if (solicitacaoRecebimento == null)
                    solicitacaoRecebimento = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento();
                solicitacaoRecebimento.resultCode = -1;
                solicitacaoRecebimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoRecebimento).Namespace);
            }

            return JsonConvert.SerializeObject(solicitacaoRecebimento);
        }

        public string UpdateSolicitacaoRecebimentoStatus(long solicitacaoRecebimento_id, string status)
        {
            GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento solicitacoesRecebimentosList = null;
            try
            {
                objSolicitacaoRecebimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoRecebimento();
                solicitacoesRecebimentosList = objSolicitacaoRecebimento.UpdateSolicitacaoRecebimentoStatus(solicitacaoRecebimento_id, status);
            }
            catch (Exception ex)
            {
                solicitacoesRecebimentosList = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoRecebimento).Namespace);
            }
            return JsonConvert.SerializeObject(solicitacoesRecebimentosList); ;
        }

        public string GetAllSolicitacoesSaquesByFiltro(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList solicitacoes = null;
            GUARDIAO_STRUCTS.DATABASE.FiltroSolicitacaoSaque filtro = null;
            try
            {
                filtro = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.FiltroSolicitacaoSaque>(json);
                objSolicitacaoRecebimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoRecebimento();
                solicitacoes = objSolicitacaoRecebimento.GetAllSolicitacoesSaquesByFiltro(filtro);

            }
            catch (Exception ex)
            {
                if (solicitacoes == null)
                    solicitacoes = new GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList();
                solicitacoes.resultCode = -1;
                solicitacoes.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoRecebimento).Namespace);
            }
            return JsonConvert.SerializeObject(solicitacoes);
        }

        public string GetAllSolicitacoesRecebimentoByID(long solicitacaoRecebimento_id)
        {

            GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento solicitacaoRecebimento = null;
            try
            {

                objSolicitacaoRecebimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoRecebimento();
                solicitacaoRecebimento = objSolicitacaoRecebimento.GetAllSolicitacoesRecebimentoByID(solicitacaoRecebimento_id);

            }
            catch (Exception ex)
            {
                if (solicitacaoRecebimento == null)
                    solicitacaoRecebimento = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento();
                solicitacaoRecebimento.resultCode = -1;
                solicitacaoRecebimento.resultDescription = ex.Message;

            }
            return JsonConvert.SerializeObject(solicitacaoRecebimento);
        }

        public string UpdateSolicitacaoRecebimentoStatus(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento solicitacaoRecebimento = null;
            try
            {
                solicitacaoRecebimento = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento>(json);
                objSolicitacaoRecebimento = new GUARDIAO_CRUD.DATABASE.SolicitacaoRecebimento();
                solicitacaoRecebimento = objSolicitacaoRecebimento.UpdateSolicitacaoRecebimentoStatus(solicitacaoRecebimento);
            }
            catch (Exception ex)
            {
                if (solicitacaoRecebimento == null)
                    solicitacaoRecebimento = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento();
                solicitacaoRecebimento.resultCode = -1;
                solicitacaoRecebimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoRecebimento).Namespace);
            }

            return JsonConvert.SerializeObject(solicitacaoRecebimento);
        }
    }
}
