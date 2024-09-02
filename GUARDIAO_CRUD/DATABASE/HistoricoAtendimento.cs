using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class HistoricoAtendimento : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimento InsertHistoricoAtendimento(GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimento historico)
        {
            string sql = "";
            long historicoAtendimento_id = 0;
            try
            {
                sql = "INSERT INTO tblHistoricoAtendimento";
                sql += " (solicitacaoAtendimento_id";
                sql += " ,usuario_id";
                sql += " ,historicoAtendimento_message";
                sql += " ,historicoAtendimento_dataCadastro)";
                sql += " VALUES(?,?,?,?);";
                sql += " SELECT @@IDENTITY AS 'IDENTITY';";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"solicitacaoAtendimento_id", System.Data.OleDb.OleDbType.Numeric).Value = historico.solicitacaoAtendimento_id;
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = historico.usuario_id;
                CM.Parameters.Add(@"historicoAtendimento_message", System.Data.OleDb.OleDbType.LongVarChar).Value = historico.historicoAtendimento_message;
                CM.Parameters.Add(@"historicoAtendimento_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                historicoAtendimento_id = Convert.ToInt64(CM.ExecuteScalar());
                if (historicoAtendimento_id == 0)
                    throw new Exception("Ocorreu um problema ao inserir historico de atendimento na base de dados.");

                historico.historicoAtendimento_id = historicoAtendimento_id;
                if (historico.arquivoHistoricos != null)
                    SaveArquivoHistorioAtendimento(historico);

            }
            catch (Exception ex)
            {
                if (historico == null)
                    historico = new GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimento();
                historico.resultCode = -1;
                historico.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(HistoricoAtendimento).Namespace);
            }
            return historico;
        }

        public GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull GetHistoricoAtendimentoBySociliacaoAtendimentoID(long solicitacaoAtendimento_id)
        {
            GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull historico = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT historicoAtendimento_id";
                sql += " ,solicitacaoAtendimento_id";
                sql += " ,usuario_id";
                sql += " ,historicoAtendimento_message";
                sql += " ,historicoAtendimento_dataCadastro";
                sql += " FROM tblHistoricoAtendimento";
                sql += " WHERE solicitacaoAtendimento_id = " + solicitacaoAtendimento_id;
                sql += " ORDER BY historicoAtendimento_id ASC";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum historico de atendimento encontrado para o antendimento informado.");
                historico = new GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull();
                historico.historicos = new List<GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimento>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    historico.historicos.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimento>());
                    GUARDIAO_STRUCTS.DATABASE.ArquivoHistoricoAtendimentoFull afull = GetArquivosHistoricoAtendimentoByID(historico.historicos[historico.historicos.Count - 1].historicoAtendimento_id);
                    if (afull != null)
                        historico.historicos[historico.historicos.Count - 1].arquivoHistoricos = afull.arquivos;
                }

            }
            catch (Exception ex)
            {
                if (historico == null)
                    historico = new GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull();
                historico.resultCode = -1;
                historico.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(HistoricoAtendimento).Namespace);
            }
            return historico;
        }

        public GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull GetHistoricoAtendimentoByHistoricoID(long historicoAtendimento_id)
        {
            GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull historico = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT historicoAtendimento_id";
                sql += " ,solicitacaoAtendimento_id";
                sql += " ,usuario_id";
                sql += " ,historicoAtendimento_message";
                sql += " ,historicoAtendimento_dataCadastro";
                sql += " FROM tblHistoricoAtendimento";
                sql += " WHERE historicoAtendimento_id = " + historicoAtendimento_id;
                sql += " ORDER BY historicoAtendimento_id ASC";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum historico de atendimento encontrado para o antendimento informado.");
                historico = new GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull();
                historico.historicos = new List<GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimento>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    historico.historicos.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimento>());
                    GUARDIAO_STRUCTS.DATABASE.ArquivoHistoricoAtendimentoFull afull = GetArquivosHistoricoAtendimentoByID(historico.historicos[historico.historicos.Count - 1].historicoAtendimento_id);
                    if (afull != null)
                        historico.historicos[historico.historicos.Count - 1].arquivoHistoricos = afull.arquivos;
                }

            }
            catch (Exception ex)
            {
                if (historico == null)
                    historico = new GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimentoFull();
                historico.resultCode = -1;
                historico.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(HistoricoAtendimento).Namespace);
            }
            return historico;
        }

        public GUARDIAO_STRUCTS.DATABASE.ArquivoHistoricoAtendimentoFull GetArquivosHistoricoAtendimentoByID(long historicoAtendimento_id)
        {
            GUARDIAO_STRUCTS.DATABASE.ArquivoHistoricoAtendimentoFull arquivos = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT arquivoHistoricoAtendimento_id";
                sql += " ,historicoAtendimento_id";
                sql += " ,arquivoHistoricoAtendimento_ext";
                sql += " ,arquivoHistoricoAtendimento_file";
                sql += " FROM tblArquivoHistoricoAtendimento";
                sql += " WHERE historicoAtendimento_id = " + historicoAtendimento_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum arquivo encontrado para o historico informado.");

                arquivos = new GUARDIAO_STRUCTS.DATABASE.ArquivoHistoricoAtendimentoFull();
                arquivos.arquivos = new List<GUARDIAO_STRUCTS.DATABASE.ArquivoHistoricoAtendimento>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    arquivos.arquivos.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.ArquivoHistoricoAtendimento>());
                    arquivos.arquivos[arquivos.arquivos.Count - 1].arquivoHistoricoAtendimento_file = RemoveTypeHtml(arquivos.arquivos[arquivos.arquivos.Count - 1].arquivoHistoricoAtendimento_file);
                }
            }
            catch (Exception)
            {
                arquivos = null;
            }
            return arquivos;
        }

        private void SaveArquivoHistorioAtendimento(GUARDIAO_STRUCTS.DATABASE.HistoricoAtendimento historico)
        {
            try
            {
                OpenDataBase();
                for (int i = 0; i < historico.arquivoHistoricos.Count; i++)
                {
                    if (!InsertArquivoAtendimento(historico.historicoAtendimento_id, historico.arquivoHistoricos[i]))
                        throw new Exception("Ocorreu um problema ao inserir arquivo do historico de atendiemento.");
                }
            }
            catch (Exception ex)
            {
                historico.resultDescription = ex.Message;
            }
            finally
            {
                CloseDataBase();
            }
        }

        private bool InsertArquivoAtendimento(long historicoAtendimento_id, GUARDIAO_STRUCTS.DATABASE.ArquivoHistoricoAtendimento arquivo)
        {
            bool resul = true;
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblArquivoHistoricoAtendimento";
                sql += " (historicoAtendimento_id";
                sql += " ,arquivoHistoricoAtendimento_ext";
                sql += " ,arquivoHistoricoAtendimento_file)";
                sql += " VALUES(?,?,?)";

                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"historicoAtendimento_id", System.Data.OleDb.OleDbType.Numeric).Value = historicoAtendimento_id;
                CM.Parameters.Add(@"arquivoHistoricoAtendimento_ext", System.Data.OleDb.OleDbType.VarChar).Value = arquivo.arquivoHistoricoAtendimento_ext;
                CM.Parameters.Add(@"arquivoHistoricoAtendimento_file", System.Data.OleDb.OleDbType.LongVarChar).Value = arquivo.arquivoHistoricoAtendimento_file;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar arquivo do historico de atendimento.");

            }
            catch (Exception ex)
            {
                resul = false;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(HistoricoAtendimento).Namespace);
            }
            return resul;
        }

        private string RemoveTypeHtml(string val)
        {
            int positionStart = 0;
            int positionEnd = 0;
            try
            {
                positionStart = val.IndexOf(",");
                if (positionStart == -1)
                    return val;
                positionStart += 1;
                positionEnd = val.Length - positionStart;
                val = val.Substring(positionStart, positionEnd);
            }
            catch (Exception)
            {
                val = "";
            }
            return val;
        }
    }
}
