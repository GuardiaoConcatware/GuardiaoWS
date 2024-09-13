using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class Notificacoes
    {
        private GUARDIAO_CRUD.DATABASE.Notificacoes objNotificacoes = null;

        public string InsertNotificacao(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Notificacao notificacao = null;
            try
            {
                notificacao = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Notificacao>(json);
                objNotificacoes = new GUARDIAO_CRUD.DATABASE.Notificacoes();
                notificacao = objNotificacoes.InsertNotificacao(notificacao);

            }
            catch (Exception ex)
            {
                if (notificacao == null)
                    notificacao = new GUARDIAO_STRUCTS.DATABASE.Notificacao();
                notificacao.resultCode = -1;
                notificacao.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Notificacoes).Namespace);
            }

            return JsonConvert.SerializeObject(notificacao);
        }

        public string UpdateNotificacao(long json)
        {
            bool resul = true;
            try
            {
                //tipoUsuario = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Notificacao>(json);
                objNotificacoes = new GUARDIAO_CRUD.DATABASE.Notificacoes();
                resul = objNotificacoes.UpdateNotificacao(json);
                // tipoUsuario = objNotificacoes.UpdateNotificacao(tipoUsuario);
            }
            catch (Exception ex)
            {
                resul = false;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoUsuario).Namespace);
            }

            return JsonConvert.SerializeObject(resul);
        }

        public string GetAllNotificacoes(long usuario_id)
        {

            GUARDIAO_STRUCTS.DATABASE.Notificacoes notificacoes = null;
            try
            {
                objNotificacoes = new GUARDIAO_CRUD.DATABASE.Notificacoes();
                notificacoes = objNotificacoes.GetAllSolicitacoesAtendimento(usuario_id);
            }
            catch (Exception ex)
            {
                notificacoes = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Notificacoes).Namespace);
            }
            return JsonConvert.SerializeObject(notificacoes);
        }

        public string DeleteNotificacoes(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Notificacao notificacao = null;
            try
            {

                notificacao = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Notificacao>(json);
                objNotificacoes = new GUARDIAO_CRUD.DATABASE.Notificacoes();
                notificacao = objNotificacoes.DeleteAllNotificacoes(notificacao);

            }
            catch (Exception ex)
            {
                if (notificacao == null)
                    notificacao = new GUARDIAO_STRUCTS.DATABASE.Notificacao();
                notificacao.resultCode = -1;
                notificacao.resultDescription = ex.Message;

            }

            return JsonConvert.SerializeObject(notificacao);
        }
    }
}
