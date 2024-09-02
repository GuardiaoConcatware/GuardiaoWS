using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class Atendimentos : DataBase
    {

        public GUARDIAO_STRUCTS.DATABASE.Atendimentos InsertAtendimento(GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento)
        {
            string sql = "";
            long atendimento_id = 0;
            long atendimentoOld_id = 0;
            try
            {
                atendimentoOld_id = VerificaAtendimentoExiste(atendimento);
                if (atendimentoOld_id != 0)
                {
                    atendimento.atendimento_id = atendimentoOld_id;
                    return atendimento;
                }

                sql = "INSERT INTO tblAtendimentos";
                sql += " (solicitacaoAtendimento_id";
                sql += " ,atendimento_status";
                sql += " ,usuario_id";
                sql += " ,advogado_id";
                sql += " ,atendimento_dataInicio";
                sql += " ,atendimento_dataFim";
                sql += " ,atendimento_tempoOcioso)";
                sql += " VALUES(?,?,?,?,?,?,?);";
                sql += " SELECT @@IDENTITY AS 'IDENTITY';";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"solicitacaoAtendimento_id", System.Data.OleDb.OleDbType.Numeric).Value = atendimento.solicitacaoAtendimento_id;
                CM.Parameters.Add(@"atendimento_status", System.Data.OleDb.OleDbType.VarChar).Value = atendimento.atendimento_status;
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = atendimento.usuario_id;
                CM.Parameters.Add(@"advogado_id", System.Data.OleDb.OleDbType.Numeric).Value = atendimento.advogado_id;
                CM.Parameters.Add(@"atendimento_dataInicio", System.Data.OleDb.OleDbType.Date).Value = Convert.ToDateTime(atendimento.atendimento_dataInicio).ToString("yyyy-MM-dd HH:mm:ss");
                CM.Parameters.Add(@"atendimento_dataFim", System.Data.OleDb.OleDbType.Date).Value = atendimento.atendimento_dataFim == "" ? null : Convert.ToDateTime(atendimento.atendimento_dataFim).ToString("yyyy-MM-dd HH:mm:ss");
                CM.Parameters.Add(@"atendimento_tempoOcioso", System.Data.OleDb.OleDbType.Integer).Value = atendimento.atendimento_tempoOcioso;

                atendimento_id = Convert.ToInt64(CM.ExecuteScalar());
                if (atendimento_id == 0)
                    throw new Exception("Ocorreu um problema ao salvar informações do atendimento no servidor.");

                atendimento.atendimento_id = atendimento_id;
            }
            catch (Exception ex)
            {
                if (atendimento == null)
                    atendimento = new GUARDIAO_STRUCTS.DATABASE.Atendimentos();
                atendimento.resultCode = -1;
                atendimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return atendimento;
        }

        private long VerificaAtendimentoExiste(GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento)
        {
            long atendimento_id = 0;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT atendimento_id";
                sql += ",solicitacaoAtendimento_id";
                sql += ",atendimento_status";
                sql += ",usuario_id";
                sql += ",advogado_id";
                sql += ",atendimento_dataInicio";
                sql += ",atendimento_dataFim";
                sql += ",atendimento_tempoOcioso";
                sql += " FROM tblAtendimentos";
                sql += " WHERE solicitacaoAtendimento_id = " + atendimento.solicitacaoAtendimento_id;
                sql += " AND atendimento_status = 'EA'";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum registro encontrado para os parâmetros informados.");

                atendimento = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Atendimentos>();

                TimeSpan t = TimeSpan.FromSeconds((DateTime.Now - Convert.ToDateTime(atendimento.atendimento_dataInicio)).TotalSeconds);
                DateTime dtI = Convert.ToDateTime(atendimento.atendimento_dataInicio);
                dtI = dtI.AddSeconds(t.TotalSeconds);

                atendimento.atendimento_dataInicio = dtI.ToString("yyyy-MM-dd HH:mm:ss");

                UpdateDataInicialAtendimento(atendimento.atendimento_id, atendimento.atendimento_dataInicio);

                atendimento_id = atendimento.atendimento_id;
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
                atendimento_id = 0;
            }
            return atendimento_id;
        }

        private void UpdateDataInicialAtendimento(long atendimento_id, string atendimento_dataInicio)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblAtendimentos SET atendimento_dataInicio = '" + atendimento_dataInicio + "' WHERE atendimento_id = " + atendimento_id;
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                {
                    throw new Exception("Ocorreu um problema ao atualizar data inicio atendimento.");
                }
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
        }

        public GUARDIAO_STRUCTS.DATABASE.Atendimentos UpdateAtendimento(GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblAtendimentos SET";
                sql += " solicitacaoAtendimento_id = ?";
                sql += " ,atendimento_status = ?";
                sql += " ,usuario_id = ?";
                sql += " ,advogado_id = ?";
                //sql += " ,atendimento_dataInicio";
                sql += " ,atendimento_dataFim = ?";
                sql += " ,atendimento_tempoOcioso = ?";
                sql += " WHERE atendimento_id = " + atendimento.atendimento_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"solicitacaoAtendimento_id", System.Data.OleDb.OleDbType.Numeric).Value = atendimento.solicitacaoAtendimento_id;
                CM.Parameters.Add(@"atendimento_status", System.Data.OleDb.OleDbType.VarChar).Value = atendimento.atendimento_status;
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = atendimento.usuario_id;
                CM.Parameters.Add(@"advogado_id", System.Data.OleDb.OleDbType.Numeric).Value = atendimento.advogado_id;
                //CM.Parameters.Add(@"atendimento_dataInicio", System.Data.OleDb.OleDbType.Date).Value = Convert.ToDateTime(atendimento.atendimento_dataInicio).ToString("yyyy-MM-dd HH:mm:ss");
                CM.Parameters.Add(@"atendimento_dataFim", System.Data.OleDb.OleDbType.Date).Value = Convert.ToDateTime(atendimento.atendimento_dataFim).ToString("yyyy-MM-dd HH:mm:ss");
                CM.Parameters.Add(@"atendimento_tempoOcioso", System.Data.OleDb.OleDbType.Integer).Value = atendimento.atendimento_tempoOcioso;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao atualizar informações do atendimento no servidor.");

                if (atendimento.atendimento_status == "AF")
                    SetSolicitacaoFinalizada(atendimento);

            }
            catch (Exception ex)
            {
                if (atendimento == null)
                    atendimento = new GUARDIAO_STRUCTS.DATABASE.Atendimentos();
                atendimento.resultCode = -1;
                atendimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return atendimento;
        }

        public GUARDIAO_STRUCTS.DATABASE.Atendimentos GetAtendimentoByID(long atendimento_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento = null;
            try
            {
                sql = "SELECT atendimento_id";
                sql += " ,solicitacaoAtendimento_id";
                sql += " ,atendimento_status";
                sql += " ,usuario_id";
                sql += " ,advogado_id";
                sql += " ,atendimento_dataInicio";
                sql += " ,atendimento_dataFim";
                sql += " ,atendimento_tempoOcioso";
                sql += " FROM tblAtendimentos";
                sql += " WHERE atendimento_id = " + atendimento_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum atendimento encontrado para o parâmetro informado.");

                atendimento = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Atendimentos>();

            }
            catch (Exception ex)
            {
                if (atendimento == null)
                    atendimento = new GUARDIAO_STRUCTS.DATABASE.Atendimentos();
                atendimento.resultCode = -1;
                atendimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
            return atendimento;
        }

        public GUARDIAO_STRUCTS.DATABASE.Atendimentos GetAtendimentoBySolicitacaoAtendimentoID(long solicitacaoAtendimento_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento = null;
            try
            {
                sql = "SELECT atendimento_id";
                sql += " ,solicitacaoAtendimento_id";
                sql += " ,atendimento_status";
                sql += " ,usuario_id";
                sql += " ,advogado_id";
                sql += " ,atendimento_dataInicio";
                sql += " ,atendimento_dataFim";
                sql += " ,atendimento_tempoOcioso";
                sql += " FROM tblAtendimentos";
                sql += " WHERE solicitacaoAtendimento_id = " + solicitacaoAtendimento_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum atendimento encontrado para o parâmetro informado.");

                atendimento = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Atendimentos>();

            }
            catch (Exception ex)
            {
                if (atendimento == null)
                    atendimento = new GUARDIAO_STRUCTS.DATABASE.Atendimentos();
                atendimento.resultCode = -1;
                atendimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
            return atendimento;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentos> GetRelatorioAtendimentos(GUARDIAO_STRUCTS.DATABASE.FiltroRelatorioAtendimento filtro)
        {
            List<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentos> relatorios = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT tblSolicitacaoAtendimento.solicitacaoAtendimento_id";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_descricao";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_status";
                sql += " , tblAtendimentos.atendimento_dataInicio";
                sql += " , tblAtendimentos.atendimento_dataFim ";
                sql += " , tblAtendimentos.atendimento_tempoOcioso";
                sql += " , tblEspecialidade.especialidade_nome";
                sql += " , tblAtendimentos.atendimento_status";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_dataCadastro";
                sql += " FROM tblSolicitacaoAtendimento";
                sql += " LEFT JOIN tblAtendimentos ON tblAtendimentos.solicitacaoAtendimento_id = tblSolicitacaoAtendimento.solicitacaoAtendimento_id";
                sql += " INNER JOIN tblEspecialidade ON tblSolicitacaoAtendimento.especialidade_id = tblEspecialidade.especialidade_id";
                sql += " INNER JOIN tblUsuario ON tblSolicitacaoAtendimento.usuario_id = tblUsuario.usuario_id";
                sql += " WHERE CONVERT(CHAR(10), tblSolicitacaoAtendimento.solicitacaoAtendimento_dataCadastro, 121) BETWEEN '" + Convert.ToDateTime(filtro.solicitacaoAtendimento_dataInicial).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(filtro.solicitacaoAtendimento_dataFinal).ToString("yyyy-MM-dd") + "'";
                if (filtro.usuario_id != 0)
                    sql += " AND tblAtendimentos.usuario_id = " + filtro.usuario_id;
                if (filtro.advogado_id != 0)
                    sql += " AND tblAtendimentos.advogado_id = " + filtro.advogado_id;
                if (filtro.atendimento_status != "")
                    sql += " AND tblAtendimentos.atendimento_status = '" + filtro.atendimento_status + "'";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum registro encontrado para os parâmetros informados.");
                relatorios = new List<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentos>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    relatorios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentos>());
                }
            }
            catch (Exception ex)
            {
                relatorios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
            return relatorios;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativo> GetRelatorioAtendimentosAdnistrativo(GUARDIAO_STRUCTS.DATABASE.FiltroRelatorioAtendimento filtro)
        {
            List<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativo> relatorios = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT tblAtendimentos.atendimento_id";
                sql += " , tblAtendimentos.solicitacaoAtendimento_id";
                sql += " , (SELECT usuario_nome FROM tblUsuario WHERE usuario_id = tblSolicitacaoAtendimento.advogado_id) AS advogado_name";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblEspecialidade.especialidade_nome";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_descricao";
                sql += " , tblAtendimentos.atendimento_status";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_dataCadastro";
                sql += " , (DATEDIFF(SECOND, tblAtendimentos.atendimento_dataInicio, tblAtendimentos.atendimento_dataFim) - tblAtendimentos.atendimento_tempoOcioso) AS atendimento_duracao";
                sql += " FROM tblAtendimentos ";
                sql += " INNER JOIN tblSolicitacaoAtendimento ON tblAtendimentos.solicitacaoAtendimento_id = tblSolicitacaoAtendimento.solicitacaoAtendimento_id ";
                sql += " INNER JOIN tblUsuario ON tblSolicitacaoAtendimento.usuario_id = tblUsuario.usuario_id ";
                sql += " INNER JOIN tblEspecialidade ON tblSolicitacaoAtendimento.especialidade_id = tblEspecialidade.especialidade_id";
                sql += " WHERE CONVERT(CHAR(10), tblSolicitacaoAtendimento.solicitacaoAtendimento_dataCadastro, 121) BETWEEN '" + Convert.ToDateTime(filtro.solicitacaoAtendimento_dataInicial).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(filtro.solicitacaoAtendimento_dataFinal).ToString("yyyy-MM-dd") + "'";
                if (filtro.advogado_id != 0)
                    sql += " AND tblSolicitacaoAtendimento.advogado_id = " + filtro.advogado_id;
                if (filtro.especialidade_id != 0)
                    sql += " AND tblSolicitacaoAtendimento.especialidade_id = " + filtro.especialidade_id;
                if (filtro.usuario_id != 0)
                    sql += " AND tblSolicitacaoAtendimento.usuario_id = " + filtro.usuario_id;
                if (filtro.atendimento_status != "")
                    sql += " AND tblAtendimentos.atendimento_status = '" + filtro.atendimento_status + "'";
                sql += " ORDER BY tblSolicitacaoAtendimento.solicitacaoAtendimento_dataCadastro";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum registro encontrado para os parâmetros informados.");
                relatorios = new List<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativo>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    relatorios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativo>());
                }
            }
            catch (Exception ex)
            {
                relatorios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
            return relatorios;
        }

        public GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativoDart GetRelatorioAtendimentosAdnistrativoDart(GUARDIAO_STRUCTS.DATABASE.FiltroRelatorioAtendimento filtro)
        {
            GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativoDart relatorios = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT tblAtendimentos.atendimento_id";
                sql += " , tblAtendimentos.solicitacaoAtendimento_id";
                sql += " , tblSolicitacaoAtendimento.advogado_id";
                if (filtro.usuario_id != 0)
                {
                    sql += " , (SELECT usuario_nome FROM tblUsuario WHERE usuario_id = tblSolicitacaoAtendimento.advogado_id) AS advogado_name";
                    sql += " , (SELECT usuario_foto FROM tblUsuario WHERE usuario_id = tblSolicitacaoAtendimento.advogado_id) AS advogado_foto";
                    sql += " , (SELECT (CASE WHEN COUNT(usuarioOnline_id) = 0 THEN 0 ELSE 1 END) FROM tblUsuarioOnline WHERE usuario_id = tblSolicitacaoAtendimento.advogado_id) AS advogado_online";
                }
                else
                {
                    sql += " , (SELECT usuario_nome FROM tblUsuario WHERE usuario_id = tblSolicitacaoAtendimento.usuario_id) AS advogado_name";
                    sql += " , (SELECT usuario_foto FROM tblUsuario WHERE usuario_id = tblSolicitacaoAtendimento.usuario_id) AS advogado_foto";
                }
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblEspecialidade.especialidade_id";
                sql += " , tblEspecialidade.especialidade_nome";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_descricao";
                sql += " , tblAtendimentos.atendimento_status";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_dataCadastro";
                sql += " , (DATEDIFF(SECOND, tblAtendimentos.atendimento_dataInicio, tblAtendimentos.atendimento_dataFim) - tblAtendimentos.atendimento_tempoOcioso) AS atendimento_duracao";
                sql += " FROM tblAtendimentos ";
                sql += " INNER JOIN tblSolicitacaoAtendimento ON tblAtendimentos.solicitacaoAtendimento_id = tblSolicitacaoAtendimento.solicitacaoAtendimento_id ";
                sql += " INNER JOIN tblUsuario ON tblSolicitacaoAtendimento.usuario_id = tblUsuario.usuario_id ";
                sql += " INNER JOIN tblEspecialidade ON tblSolicitacaoAtendimento.especialidade_id = tblEspecialidade.especialidade_id";
                sql += " WHERE CONVERT(CHAR(10), tblSolicitacaoAtendimento.solicitacaoAtendimento_dataCadastro, 121) BETWEEN '" + Convert.ToDateTime(filtro.solicitacaoAtendimento_dataInicial).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(filtro.solicitacaoAtendimento_dataFinal).ToString("yyyy-MM-dd") + "'";
                if (filtro.advogado_id != 0)
                    sql += " AND tblSolicitacaoAtendimento.advogado_id = " + filtro.advogado_id;
                if (filtro.especialidade_id != 0)
                    sql += " AND tblSolicitacaoAtendimento.especialidade_id = " + filtro.especialidade_id;
                if (filtro.usuario_id != 0)
                    sql += " AND tblSolicitacaoAtendimento.usuario_id = " + filtro.usuario_id;
                if (filtro.atendimento_status != "")
                    sql += " AND tblAtendimentos.atendimento_status = '" + filtro.atendimento_status + "'";
                sql += " ORDER BY tblSolicitacaoAtendimento.solicitacaoAtendimento_dataCadastro DESC";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum registro encontrado para os parâmetros informados.");
                relatorios = new GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativoDart();
                relatorios.relatorioAtendimentoAdministrativos = new List<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativo>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    relatorios.relatorioAtendimentoAdministrativos.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativo>());
                }
            }
            catch (Exception ex)
            {
                if (relatorios == null)
                    relatorios = new GUARDIAO_STRUCTS.DATABASE.RelatorioAtendimentoAdministrativoDart();
                relatorios.resultCode = -1;
                relatorios.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
            return relatorios;
        }

        private void SetSolicitacaoFinalizada(GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento)
        {
            try
            {
                atendimento = GetAtendimentoByID(atendimento.atendimento_id);
                GUARDIAO_CRUD.DATABASE.SolicitacaoAtendimento objSolicitacaoAtendimento = new SolicitacaoAtendimento();

                if (!objSolicitacaoAtendimento.UpdateStatusSolicitacao(atendimento.solicitacaoAtendimento_id, "SF"))
                    throw new Exception("Ocorreu um problema ao atualizar status da solicitação.");

                GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento sol = objSolicitacaoAtendimento.GetSolicitacoesAtendimentoByID(atendimento.solicitacaoAtendimento_id);
                if (sol.resultCode != 0)
                    throw new Exception(sol.resultDescription);                
                GUARDIAO_STRUCTS.DATABASE.ParametrosSistema parametros = GetParametrosSistemas();
                if (sol.solicitacaoAtendimento_tipo != 2)
                {
                    InsertExtratoAtendimentoAdvogado(atendimento, parametros);
                    InsertExtratoAtendimentoCliente(atendimento, parametros);
                }
                else
                {
                    InsertExtratoAtendimentoAdvogadoUrgencia(atendimento, parametros);
                    InsertExtratoAtendimentoClienteUrgencia(atendimento, parametros);
                }





            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);

            }

        }

        private GUARDIAO_STRUCTS.DATABASE.ParametrosSistema GetParametrosSistemas()
        {
            GUARDIAO_STRUCTS.DATABASE.ParametrosSistema parametros = null;
            try
            {
                GUARDIAO_CRUD.DATABASE.ParametrosSistema obj = new ParametrosSistema();
                parametros = obj.GetParametrosSistema();
            }
            catch (Exception ex)
            {
                if (parametros == null)
                    parametros = new GUARDIAO_STRUCTS.DATABASE.ParametrosSistema();
                parametros.resultCode = -1;
                parametros.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }
            return parametros;
        }

        private void InsertExtratoAtendimentoAdvogado(GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento, GUARDIAO_STRUCTS.DATABASE.ParametrosSistema parametros)
        {
            GUARDIAO_STRUCTS.DATABASE.Extrato extrato = null;
            try
            {
                extrato = new GUARDIAO_STRUCTS.DATABASE.Extrato();

                DateTime di = Convert.ToDateTime(atendimento.atendimento_dataInicio);
                DateTime df = Convert.ToDateTime(atendimento.atendimento_dataFim);

                TimeSpan timeSpan = TimeSpan.FromSeconds((df - di).TotalSeconds);
                double totalMinutos = (df - di).TotalMinutes;
                double totalMinutosOcioso = (atendimento.atendimento_tempoOcioso * parametros.parametroSistema_tempoMaximoEspera);
                totalMinutos = totalMinutos - totalMinutosOcioso;

                TimeSpan tOcioso = TimeSpan.FromSeconds(totalMinutosOcioso * 60);

                decimal valorPorMinuto = parametros.parametroSistema_valorHora / 60;
                string tempo = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)timeSpan.TotalHours, (int)timeSpan.TotalMinutes, timeSpan.Seconds);
                string tempoOcioso = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)tOcioso.TotalHours, (int)tOcioso.TotalMinutes, tOcioso.Seconds);

                decimal percentualGuardiao = parametros.parametroSistema_percentualGuardiao;
                decimal valorGeral = (valorPorMinuto * Convert.ToDecimal(totalMinutos));

                percentualGuardiao = (valorGeral * percentualGuardiao) / 100;
                valorGeral = valorGeral - percentualGuardiao;

                extrato.extrato_valor = valorGeral;
                extrato.extrato_valorPercentual = percentualGuardiao;
                extrato.extrato_totalMinutosOcioso = tempoOcioso;
                extrato.extrato_id = 0;
                extrato.extrato_dataCadastro = DateTime.Now.ToString();
                extrato.usuario_id = atendimento.advogado_id;
                extrato.tipoExtrato_id = 4;
                extrato.atendimento_id = atendimento.atendimento_id;
                extrato.extrato_tempo = tempo;

                GUARDIAO_CRUD.DATABASE.ExtratoCrud objExtrato = new ExtratoCrud();
                extrato = objExtrato.InsertExtrato(extrato);

                if (extrato.resultCode == 0)
                {
                    GUARDIAO_STRUCTS.DATABASE.Saldo saldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                    saldo.usuario_id = atendimento.advogado_id;
                    saldo.saldo_valor = extrato.extrato_valor;
                    saldo.saldo_horas = extrato.extrato_tempo;
                    saldo.saldo_ultimaAtualizacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    GUARDIAO_CRUD.DATABASE.SaldoCrud objSaldo = new SaldoCrud();
                    saldo = objSaldo.SaveSaldoUsuario(saldo, 4);
                }

            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }

        }

        private void InsertExtratoAtendimentoCliente(GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento, GUARDIAO_STRUCTS.DATABASE.ParametrosSistema parametros)
        {
            GUARDIAO_STRUCTS.DATABASE.Extrato extrato = null;
            try
            {
                extrato = new GUARDIAO_STRUCTS.DATABASE.Extrato();

                DateTime di = Convert.ToDateTime(atendimento.atendimento_dataInicio);
                DateTime df = Convert.ToDateTime(atendimento.atendimento_dataFim);

                TimeSpan timeSpan = TimeSpan.FromSeconds((df - di).TotalSeconds);
                double totalMinutos = (df - di).TotalMinutes;
                decimal valorPorMinuto = parametros.parametroSistema_valorHora / 60;
                string tempo = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)timeSpan.TotalHours, (int)timeSpan.TotalMinutes, timeSpan.Seconds);


                extrato.extrato_valor = (valorPorMinuto * Convert.ToDecimal(totalMinutos));
                extrato.extrato_id = 0;
                extrato.extrato_dataCadastro = DateTime.Now.ToString();
                extrato.usuario_id = atendimento.usuario_id;
                extrato.tipoExtrato_id = 3;
                extrato.atendimento_id = atendimento.atendimento_id;
                extrato.extrato_tempo = tempo;

                GUARDIAO_CRUD.DATABASE.ExtratoCrud objExtrato = new ExtratoCrud();
                extrato = objExtrato.InsertExtrato(extrato);

                if (extrato.resultCode == 0)
                {
                    GUARDIAO_STRUCTS.DATABASE.Saldo saldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                    saldo.usuario_id = atendimento.usuario_id;
                    saldo.saldo_valor = extrato.extrato_valor;
                    saldo.saldo_horas = extrato.extrato_tempo;
                    saldo.saldo_ultimaAtualizacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    GUARDIAO_CRUD.DATABASE.SaldoCrud objSaldo = new SaldoCrud();
                    saldo = objSaldo.SaveSaldoUsuario(saldo, 3);
                }
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }

        }

        private void InsertExtratoAtendimentoAdvogadoUrgencia(GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento, GUARDIAO_STRUCTS.DATABASE.ParametrosSistema parametros)
        {
            GUARDIAO_STRUCTS.DATABASE.Extrato extrato = null;
            try
            {
                extrato = new GUARDIAO_STRUCTS.DATABASE.Extrato();

                DateTime di = Convert.ToDateTime(atendimento.atendimento_dataInicio);
                DateTime df = Convert.ToDateTime(atendimento.atendimento_dataFim);

                TimeSpan timeSpan = TimeSpan.FromSeconds((df - di).TotalSeconds);
                double totalMinutos = (df - di).TotalMinutes;
                double totalMinutosOcioso = (atendimento.atendimento_tempoOcioso * parametros.parametroSistema_tempoMaximoEspera);
                totalMinutos = totalMinutos - totalMinutosOcioso;

                TimeSpan tOcioso = TimeSpan.FromSeconds(totalMinutosOcioso * 60);

                decimal valorPorMinuto = parametros.parametroSistema_valorHora / 60;
                string tempo = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)timeSpan.TotalHours, (int)timeSpan.TotalMinutes, timeSpan.Seconds);
                string tempoOcioso = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)tOcioso.TotalHours, (int)tOcioso.TotalMinutes, tOcioso.Seconds);

                decimal percentualGuardiao = parametros.parametroSistema_percentualGuardiao;
                decimal valorGeral = parametros.parametroSistema_valorHoraPlantao;

                percentualGuardiao = (parametros.parametroSistema_valorHoraPlantao * percentualGuardiao) / 100;
                valorGeral = valorGeral - percentualGuardiao;

                extrato.extrato_valor = valorGeral;
                extrato.extrato_valorPercentual = percentualGuardiao;
                extrato.extrato_totalMinutosOcioso = tempoOcioso;
                extrato.extrato_id = 0;
                extrato.extrato_dataCadastro = DateTime.Now.ToString();
                extrato.usuario_id = atendimento.advogado_id;
                extrato.tipoExtrato_id = 4;
                extrato.atendimento_id = atendimento.atendimento_id;
                extrato.extrato_tempo = tempo;

                GUARDIAO_CRUD.DATABASE.ExtratoCrud objExtrato = new ExtratoCrud();
                extrato = objExtrato.InsertExtrato(extrato);

                if (extrato.resultCode == 0)
                {
                    GUARDIAO_STRUCTS.DATABASE.Saldo saldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                    saldo.usuario_id = atendimento.advogado_id;
                    saldo.saldo_valor = extrato.extrato_valor;
                    saldo.saldo_horas = extrato.extrato_tempo;
                    saldo.saldo_ultimaAtualizacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    GUARDIAO_CRUD.DATABASE.SaldoCrud objSaldo = new SaldoCrud();
                    saldo = objSaldo.SaveSaldoUsuario(saldo, 4);
                }

            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }

        }

        private void InsertExtratoAtendimentoClienteUrgencia(GUARDIAO_STRUCTS.DATABASE.Atendimentos atendimento, GUARDIAO_STRUCTS.DATABASE.ParametrosSistema parametros)
        {
            GUARDIAO_STRUCTS.DATABASE.Extrato extrato = null;
            try
            {
                extrato = new GUARDIAO_STRUCTS.DATABASE.Extrato();

                DateTime di = Convert.ToDateTime(atendimento.atendimento_dataInicio);
                DateTime df = Convert.ToDateTime(atendimento.atendimento_dataFim);

                TimeSpan timeSpan = TimeSpan.FromSeconds((df - di).TotalSeconds);
                double totalMinutos = (df - di).TotalMinutes;
                decimal valorPorMinuto = parametros.parametroSistema_valorHora / 60;
                string tempo = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)timeSpan.TotalHours, (int)timeSpan.TotalMinutes, timeSpan.Seconds);


                extrato.extrato_valor = parametros.parametroSistema_valorHoraPlantao;
                extrato.extrato_id = 0;
                extrato.extrato_dataCadastro = DateTime.Now.ToString();
                extrato.usuario_id = atendimento.usuario_id;
                extrato.tipoExtrato_id = 3;
                extrato.atendimento_id = atendimento.atendimento_id;
                extrato.extrato_tempo = tempo;

                GUARDIAO_CRUD.DATABASE.ExtratoCrud objExtrato = new ExtratoCrud();
                extrato = objExtrato.InsertExtrato(extrato);

                if (extrato.resultCode == 0)
                {
                    GUARDIAO_STRUCTS.DATABASE.Saldo saldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                    saldo.usuario_id = atendimento.usuario_id;
                    saldo.saldo_valor = extrato.extrato_valor;
                    saldo.saldo_horas = extrato.extrato_tempo;
                    saldo.saldo_ultimaAtualizacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    GUARDIAO_CRUD.DATABASE.SaldoCrud objSaldo = new SaldoCrud();
                    saldo = objSaldo.SaveSaldoUsuario(saldo, 3);
                }
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimentos).Namespace);
            }

        }
    }
}
