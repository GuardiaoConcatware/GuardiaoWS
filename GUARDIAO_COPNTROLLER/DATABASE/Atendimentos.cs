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
    public class Atendimentos
    {
        private GUARDIAO_CRUD.DATABASE.Atendimentos objAtendimentos = null;
        public string InsertAtendimento(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento = null;
            try
            {
                atendimento = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Atendimentos>(json);
                objAtendimentos = new GUARDIAO_CRUD.DATABASE.Atendimentos();
                atendimento = objAtendimentos.InsertAtendimento(atendimento);
            }
            catch (Exception ex)
            {
                if (atendimento == null)
                    atendimento = new GUARDIAO_STRUCTS.DATABASE.Atendimentos();
                atendimento.resultCode = -1;
                atendimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }

            return JsonConvert.SerializeObject(atendimento);
        }

        public string UpdateAtendimento(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento = null;
            try
            {
                atendimento = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Atendimentos>(json);
                objAtendimentos = new GUARDIAO_CRUD.DATABASE.Atendimentos();
                atendimento = objAtendimentos.UpdateAtendimento(atendimento);
            }
            catch (Exception ex)
            {
                if (atendimento == null)
                    atendimento = new GUARDIAO_STRUCTS.DATABASE.Atendimentos();
                atendimento.resultCode = -1;
                atendimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }

            return JsonConvert.SerializeObject(atendimento);
        }

        public string GetAtendimentoByID(long atendimento_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento = null;
            try
            {
                objAtendimentos = new GUARDIAO_CRUD.DATABASE.Atendimentos();
                atendimento = objAtendimentos.GetAtendimentoByID(atendimento_id);
            }
            catch (Exception ex)
            {
                if (atendimento == null)
                    atendimento = new GUARDIAO_STRUCTS.DATABASE.Atendimentos();
                atendimento.resultCode = -1;
                atendimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }

            return JsonConvert.SerializeObject(atendimento);
        }

        public string GetAtendimentoBySolicitacaoAtendimentoID(long solicitacaoAtendimento_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento = null;
            try
            {
                objAtendimentos = new GUARDIAO_CRUD.DATABASE.Atendimentos();
                atendimento = objAtendimentos.GetAtendimentoBySolicitacaoAtendimentoID(solicitacaoAtendimento_id);
            }
            catch (Exception ex)
            {
                if (atendimento == null)
                    atendimento = new GUARDIAO_STRUCTS.DATABASE.Atendimentos();
                atendimento.resultCode = -1;
                atendimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }

            return JsonConvert.SerializeObject(atendimento);
        }

        public string GetRelatorioAtendimentos(string json)
        {
            List<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentos> relatorios = null;
            GUARDIAO_STRUCTS.DATABASE.FiltroRelatorioAtendimento filtro = null;
            try
            {
                filtro = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.FiltroRelatorioAtendimento>(json);
                objAtendimentos = new GUARDIAO_CRUD.DATABASE.Atendimentos();
                relatorios = objAtendimentos.GetRelatorioAtendimentos(filtro);
            }
            catch (Exception ex)
            {
                relatorios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
            return JsonConvert.SerializeObject(relatorios);
        }

        public string GetRelatorioAtendimentosAdnistrativo(string json)
        {
            List<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativo> relatorios = null;
            GUARDIAO_STRUCTS.DATABASE.FiltroRelatorioAtendimento filtro = null;
            try
            {
                filtro = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.FiltroRelatorioAtendimento>(json);
                objAtendimentos = new GUARDIAO_CRUD.DATABASE.Atendimentos();
                relatorios = objAtendimentos.GetRelatorioAtendimentosAdnistrativo(filtro);
            }
            catch (Exception ex)
            {
                relatorios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
            return JsonConvert.SerializeObject(relatorios);
        }

        public string GetRelatorioAtendimentosAdnistrativoDart(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativoDart relatorios = null;
            GUARDIAO_STRUCTS.DATABASE.FiltroRelatorioAtendimento filtro = null;
            try
            {
                filtro = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.FiltroRelatorioAtendimento>(json);
                objAtendimentos = new GUARDIAO_CRUD.DATABASE.Atendimentos();
                relatorios = objAtendimentos.GetRelatorioAtendimentosAdnistrativoDart(filtro);
            }
            catch (Exception ex)
            {
                relatorios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
            return JsonConvert.SerializeObject(relatorios);
        }
    }
}
