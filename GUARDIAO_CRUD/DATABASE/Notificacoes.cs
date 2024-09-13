using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class Notificacoes : DataBase
    {

        public GUARDIAO_STRUCTS.DATABASE.Notificacao InsertNotificacao(GUARDIAO_STRUCTS.DATABASE.Notificacao notificacao)
        {
            string sql = "";
            int reg = 0;
            try
            {
                // DeleteAllUsuarioOnlineById(online.usuario_id);
                /*
                 public long notificacao_id { get; set; }
        public long usuario_id { get; set; }
        public string notificacao_descricao { get; set; }
        public string notificacao_data { get; set; }
        public string notificacao_titulo { get; set; }
        public bool notificacao_status { get; set; }
                 */

                sql = " INSERT INTO tblNotificacoes (usuario_id";
                sql += " ,notificacao_descricao";
                sql += " , notificacao_titulo";
                sql += " , notificacao_status";
                sql += " , notificacao_data)";
                sql += " VALUES(?,?,?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = notificacao.usuario_id;
                CM.Parameters.Add(@"notificacao_descricao", System.Data.OleDb.OleDbType.VarChar).Value = notificacao.notificacao_descricao;
                CM.Parameters.Add(@"notificacao_titulo", System.Data.OleDb.OleDbType.VarChar).Value = notificacao.notificacao_titulo;
                CM.Parameters.Add(@"notificacao_status", System.Data.OleDb.OleDbType.Boolean).Value = notificacao.notificacao_status;
                CM.Parameters.Add(@"notificacao_data", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao inserir usuario online no servidor.");
            }
            catch (Exception ex)
            {
                if (notificacao == null)
                    notificacao = new GUARDIAO_STRUCTS.DATABASE.Notificacao();
                notificacao.resultCode = -1;
                notificacao.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Notificacoes).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return notificacao;
        }

        public GUARDIAO_STRUCTS.DATABASE.Notificacao DeleteAllNotificacoes(GUARDIAO_STRUCTS.DATABASE.Notificacao notificacao)
        {
            string sql = "";
            try
            {
                sql = "DELETE FROM tblNotificacoes WHERE usuario_id = " + notificacao.usuario_id;
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (notificacao == null)
                    notificacao = new GUARDIAO_STRUCTS.DATABASE.Notificacao();
                notificacao.resultCode = -1;
                notificacao.notificacao_descricao = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Notificacoes).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return notificacao;
        }

        public GUARDIAO_STRUCTS.DATABASE.Notificacoes GetAllSolicitacoesAtendimento(long usuario_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Notificacoes notificacao = null;
            try
            {
                sql = "SELECT notificacao_id";
                sql += " , usuario_id";
                sql += " , notificacao_descricao";
                sql += " , notificacao_titulo";
                sql += " , notificacao_data";
                sql += " , notificacao_status";
                sql += " FROM tblNotificacoes ";
                if (usuario_id != 0)
                {

                    sql += " WHERE usuario_id = " + usuario_id;
                }

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma notificação encontrada no servidor.");

                notificacao = new GUARDIAO_STRUCTS.DATABASE.Notificacoes();
                notificacao.notificacoes = new List<GUARDIAO_STRUCTS.DATABASE.Notificacao>();

                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    notificacao.notificacoes.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Notificacao>());
                }
            }
            catch (Exception ex)
            {
                notificacao = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Notificacoes).Namespace);
            }
            return notificacao;
        }

        public bool UpdateNotificacao(long notificacao_id)
        {
            string sql = "";
            int reg = 0;
            bool resul = true;
            try
            {
                sql = " UPDATE tblNotificacoes SET ";
                sql += " notificacao_status = ? ";
                sql += " WHERE notificacao_id = " + notificacao_id;
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"notificacao_status", System.Data.OleDb.OleDbType.Boolean).Value = true;
                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("UM ERRO INESPERADO ACONTECEU");

            }
            catch (Exception ex)
            {

                resul = false;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Notificacoes).Namespace);
            }
            return resul;
        }
    }
}
