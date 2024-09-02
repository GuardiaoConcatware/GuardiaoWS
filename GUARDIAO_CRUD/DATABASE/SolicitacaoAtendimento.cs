using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class SolicitacaoAtendimento : DataBase
    {

        public GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento InsertSolicitacao(GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento solicitacao)
        {
            string sql = "";
            long solicitacaoAtendimento_id = 0;
            try
            {
                sql = "INSERT INTO tblSolicitacaoAtendimento";
                sql += " (usuario_id";
                sql += " ,advogado_id";
                sql += " ,especialidade_id";
                sql += " ,solicitacaoAtendimento_tipo";
                sql += " ,solicitacaoAtendimento_identity";
                sql += " ,solicitacaoAtendimento_descricao";
                sql += " ,solicitacaoAtendimento_status";
                sql += " ,solicitacaoAtendimento_dataCadastro)";
                sql += " VALUES(?,?,?,?,?,?,?,?);";
                sql += " SELECT @@IDENTITY AS 'IDENTITY';";
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = solicitacao.usuario_id;
                CM.Parameters.Add(@"advogado_id", System.Data.OleDb.OleDbType.Numeric).Value = solicitacao.advogado_id;
                CM.Parameters.Add(@"especialidade_id", System.Data.OleDb.OleDbType.Numeric).Value = solicitacao.especialidade_id;
                CM.Parameters.Add(@"solicitacaoAtendimento_tipo", System.Data.OleDb.OleDbType.Numeric).Value = solicitacao.solicitacaoAtendimento_tipo;
                CM.Parameters.Add(@"solicitacaoAtendimento_identity", System.Data.OleDb.OleDbType.VarChar).Value = solicitacao.solicitacaoAtendimento_identity;
                CM.Parameters.Add(@"solicitacaoAtendimento_descricao", System.Data.OleDb.OleDbType.LongVarChar).Value = solicitacao.solicitacaoAtendimento_descricao;
                CM.Parameters.Add(@"solicitacaoAtendimento_status", System.Data.OleDb.OleDbType.VarChar).Value = "PA";
                CM.Parameters.Add(@"solicitacaoAtendimento_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                solicitacaoAtendimento_id = Convert.ToInt64(CM.ExecuteScalar());
                if (solicitacaoAtendimento_id == 0)
                    throw new Exception("Ocorreu um problema ao salvar solicitação no servidor.");
                solicitacao.solicitacaoAtendimento_id = solicitacaoAtendimento_id;

            }
            catch (Exception ex)
            {
                if (solicitacao == null)
                    solicitacao = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento();
                solicitacao.resultCode = -1;
                solicitacao.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return solicitacao;
        }

        public bool UpdateStatusSolicitacao(long solicitacaoAtendimento_id, string newStatus)
        {
            string sql = "";
            int reg = 0;
            bool resul = true;
            try
            {
                sql = "UPDATE tblSolicitacaoAtendimento SET";
                sql += " solicitacaoAtendimento_status = ?";
                sql += " WHERE solicitacaoAtendimento_id = " + solicitacaoAtendimento_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);

                CM.Parameters.Add(@"solicitacaoAtendimento_status", System.Data.OleDb.OleDbType.VarChar).Value = newStatus;


                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar solicitação no servidor.");

            }
            catch (Exception ex)
            {
                resul = false;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return resul;
        }
        public bool UpdateStatusSolicitacaoChat(long solicitacaoAtendimento_id, string solicitacaoAtendimento_identity)
        {
            string sql = "";
            int reg = 0;
            bool resul = true;
            try
            {
                sql = "UPDATE tblSolicitacaoAtendimento SET";
                sql += " solicitacaoAtendimento_identity = ?";
                sql += " WHERE solicitacaoAtendimento_id = " + solicitacaoAtendimento_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);

                CM.Parameters.Add(@"solicitacaoAtendimento_identity", System.Data.OleDb.OleDbType.VarChar).Value = solicitacaoAtendimento_identity;


                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar solicitação no servidor.");

            }
            catch (Exception ex)
            {
                resul = false;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return resul;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento> GetAllSolicitacoesAtendimento(long advogado_id, int solicitacaoAtendimento_tipo)
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento> solicitacaos = null;
            try
            {
                sql = "SELECT tblSolicitacaoAtendimento.solicitacaoAtendimento_id";
                sql += " , tblSolicitacaoAtendimento.usuario_id";
                sql += " , tblSolicitacaoAtendimento.advogado_id";
                sql += " , tblSolicitacaoAtendimento.especialidade_id";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_tipo";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_descricao";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_status";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_dataCadastro";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_identity";
                sql += " , tblEspecialidade.especialidade_nome";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblUsuario.usuario_foto";
                sql += " FROM tblSolicitacaoAtendimento ";
                sql += " INNER JOIN tblUsuario ON tblSolicitacaoAtendimento.usuario_id = tblUsuario.usuario_id ";
                sql += " INNER JOIN tblEspecialidade ON tblSolicitacaoAtendimento.especialidade_id = tblEspecialidade.especialidade_id";
                sql += " WHERE tblSolicitacaoAtendimento.advogado_id = " + advogado_id;
                sql += " AND tblSolicitacaoAtendimento.solicitacaoAtendimento_identity IS NOT NULL";
                sql += " AND tblSolicitacaoAtendimento.solicitacaoAtendimento_identity <>''";
                sql += " AND tblSolicitacaoAtendimento.solicitacaoAtendimento_status = 'PA'";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma solicitação encontrada no servidor.");

                solicitacaos = new List<GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    solicitacaos.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento>());
                }
            }
            catch (Exception ex)
            {
                solicitacaos = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return solicitacaos;
        }

        public GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimentoDart GetAllSolicitacoesAtendimentoDart(long advogado_id, int solicitacaoAtendimento_tipo)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimentoDart solicitacoes = null;
            try
            {
                sql = "SELECT tblSolicitacaoAtendimento.solicitacaoAtendimento_id";
                sql += " , tblSolicitacaoAtendimento.usuario_id";
                sql += " , tblSolicitacaoAtendimento.advogado_id";
                sql += " , tblSolicitacaoAtendimento.especialidade_id";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_tipo";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_descricao";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_status";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_dataCadastro";
                sql += " , tblSolicitacaoAtendimento.solicitacaoAtendimento_identity";
                sql += " , tblEspecialidade.especialidade_nome";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblUsuario.usuario_foto";
                sql += " FROM tblSolicitacaoAtendimento ";
                sql += " INNER JOIN tblUsuario ON tblSolicitacaoAtendimento.usuario_id = tblUsuario.usuario_id ";
                sql += " INNER JOIN tblEspecialidade ON tblSolicitacaoAtendimento.especialidade_id = tblEspecialidade.especialidade_id";
                sql += " WHERE tblSolicitacaoAtendimento.advogado_id = " + advogado_id;
                sql += " AND tblSolicitacaoAtendimento.solicitacaoAtendimento_identity IS NOT NULL";
                sql += " AND tblSolicitacaoAtendimento.solicitacaoAtendimento_identity <>''";
                sql += " AND tblSolicitacaoAtendimento.solicitacaoAtendimento_status = 'PA'";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma solicitação encontrada no servidor.");

                solicitacoes = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimentoDart();
                solicitacoes.solicitacaoAtendimentos = new List<GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    solicitacoes.solicitacaoAtendimentos.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento>());
                }
            }
            catch (Exception ex)
            {
                solicitacoes = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return solicitacoes;
        }

        public GUARDIAO_STRUCTS.DATABASE.DescarteSolicitacaoAtendimento DescartarSolicitacao(GUARDIAO_STRUCTS.DATABASE.DescarteSolicitacaoAtendimento descarte)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblDescarteSolicitacaoAtendimento";
                sql += " (solicitacaoAtendimento_id";
                sql += " ,descarteSolicitacaoAtendimento_motivo";
                sql += " ,descarteSolicitacaoAtendimento_dataCadastro)";
                sql += " VALUES(?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"solicitacaoAtendimento_id", System.Data.OleDb.OleDbType.Numeric).Value = descarte.solicitacaoAtendimento_id;
                CM.Parameters.Add(@"descarteSolicitacaoAtendimento_motivo", System.Data.OleDb.OleDbType.LongVarChar).Value = descarte.descarteSolcitacaoAtendimento_motivo;
                CM.Parameters.Add(@"descarteSolicitacaoAtendimento_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao descartar solicitação no servidor.");
                SetSolicitacaoDescartada(descarte.solicitacaoAtendimento_id);
            }
            catch (Exception ex)
            {
                if (descarte == null)
                    descarte = new GUARDIAO_STRUCTS.DATABASE.DescarteSolicitacaoAtendimento();
                descarte.resultCode = -1;
                descarte.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return descarte;
        }

        public GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento GetSolicitacoesAtendimentoByID(long solicitacaoAtendimento_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento solicitacao = null;
            try
            {
                sql = "SELECT solicitacaoAtendimento_id";
                sql += " ,usuario_id";
                sql += " ,advogado_id";
                sql += " ,especialidade_id";
                sql += " ,solicitacaoAtendimento_tipo";
                sql += " ,solicitacaoAtendimento_identity";
                sql += " ,solicitacaoAtendimento_descricao";
                sql += " ,solicitacaoAtendimento_status";
                sql += " ,solicitacaoAtendimento_dataCadastro";
                sql += " FROM tblSolicitacaoAtendimento";
                sql += " WHERE solicitacaoAtendimento_id = " + solicitacaoAtendimento_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma solicitação encontrada no servidor.");



                solicitacao = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento>();

            }
            catch (Exception ex)
            {
                if (solicitacao == null)
                    solicitacao = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoAtendimento();
                solicitacao.resultCode = -1;
                solicitacao.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            return solicitacao;
        }

        private void SetSolicitacaoDescartada(long solicitacaoAtendimento_id)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblSolicitacaoAtendimento SET solicitacaoAtendimento_status = 'DE' WHERE solicitacaoAtendimento_id = " + solicitacaoAtendimento_id;
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um erro ao atualziar status de descarte no servidor.");
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoAtendimento).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
        }

    }
}
