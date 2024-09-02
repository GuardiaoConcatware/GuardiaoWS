using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUARDIAO_CRUD.DATABASE
{
    public class SolicitacaoRecebimento : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList GetAllSolicitacoesRecebimento()
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList solicitacaoRecebimentoList = null;
            try
            {
                sql = "SELECT * FROM tblSolicitacaoRecebimento";
                ds = ExecuteSelect(sql);
                if (ds == null)
                {
                    throw new Exception("NENHUM EXTRATO ENCONTRADO");

                }
                solicitacaoRecebimentoList = new GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList();
                solicitacaoRecebimentoList.solicitacaoRecebimentosList = new List<GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento>();

                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    solicitacaoRecebimentoList.solicitacaoRecebimentosList.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento>());
                }
            }
            catch (Exception ex)
            {
                if (solicitacaoRecebimentoList == null)
                {
                    solicitacaoRecebimentoList = new GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList();
                    solicitacaoRecebimentoList.resultCode = -1;
                    solicitacaoRecebimentoList.resultDescription = ex.Message;
                }

            }
            return solicitacaoRecebimentoList;
        }

        public GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList GetAllSolicitacoesRecebimentoByUsuarioId(long usuario_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList solicitacaoRecebimentoList = null;
            try
            {
                sql = "SELECT * FROM tblSolicitacaoRecebimento";
                sql += " WHERE usuario_id = " + usuario_id;
                ds = ExecuteSelect(sql);
                if (ds == null)
                {
                    throw new Exception("NENHUMA SOLICITACAO ENCONTRADA");

                }
                solicitacaoRecebimentoList = new GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList();
                solicitacaoRecebimentoList.solicitacaoRecebimentosList = new List<GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento>();

                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    solicitacaoRecebimentoList.solicitacaoRecebimentosList.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento>());
                }
            }
            catch (Exception ex)
            {
                if (solicitacaoRecebimentoList == null)
                {
                    solicitacaoRecebimentoList = new GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList();
                    solicitacaoRecebimentoList.resultCode = -1;
                    solicitacaoRecebimentoList.resultDescription = ex.Message;
                }

            }
            return solicitacaoRecebimentoList;
        }

        public GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento InsertSolicitacaoRecebimento(GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento solicitacaoRecebimento)
        {
            string sql = "";
            long usuario_id = 0;
            try
            {
                if (!VerificaSolicitacaoRecebimentoEmAberto(solicitacaoRecebimento))
                    throw new Exception("Já existe uma solicitação pendente de análise.");


                sql = "INSERT INTO tblSolicitacaoRecebimento";
                sql += " (usuario_id";
                sql += " ,solicitacaoRecebimento_status";
                sql += " ,solicitacaoRecebimento_motivoRecusa";
                sql += " ,solicitacaoRecebimento_dataCadastro";
                sql += " ,solicitacaoRecebimento_valorSolicitado";
                sql += " ,solicitacaoRecebimento_valorDisponivel)";
                sql += " VALUES(?,?,?,?,?,?);";
                sql += " SELECT @@IDENTITY AS 'IDENTITY';";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = solicitacaoRecebimento.usuario_id;
                CM.Parameters.Add(@"solicitacaoRecebimento_status", System.Data.OleDb.OleDbType.VarChar).Value = solicitacaoRecebimento.solicitacaoRecebimento_status;
                CM.Parameters.Add(@"solicitacaoRecebimento_motivoRecusa", System.Data.OleDb.OleDbType.VarChar).Value = solicitacaoRecebimento.solicitacaoRecebimento_motivoRecusa;
                CM.Parameters.Add(@"solicitacaoRecebimento_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                CM.Parameters.Add(@"solicitacaoRecebimento_valorSolicitado", System.Data.OleDb.OleDbType.Double).Value = solicitacaoRecebimento.solicitacaoRecebimento_valorSolicitado;
                CM.Parameters.Add(@"solicitacaoRecebimento_valorDisponivel", System.Data.OleDb.OleDbType.Double).Value = solicitacaoRecebimento.solicitacaoRecebimento_valorDisponivel;

                usuario_id = Convert.ToInt64(CM.ExecuteScalar());
                if (usuario_id == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO SALVAR A SOLICITAÇÃO NO SERVIDOR.");

                GUARDIAO_STRUCTS.DATABASE.Extrato ext = new GUARDIAO_STRUCTS.DATABASE.Extrato();
                ext.extrato_valor = decimal.Parse(solicitacaoRecebimento.solicitacaoRecebimento_valorSolicitado.ToString());
                ext.extrato_valorPercentual = 0;
                ext.extrato_id = 0;
                ext.extrato_tempo = "00:00";
                ext.extrato_dataCadastro = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ext.atendimento_id = 0;
                ext.tipoExtrato_id = 8;
                ext.usuario_id = solicitacaoRecebimento.usuario_id;
                ext.usuario_nome = solicitacaoRecebimento.usuario_nome;
                ext.extrato_totalMinutosOcioso = "00:00";


                DATABASE.ExtratoCrud objExtrato = new ExtratoCrud();
                ext = objExtrato.InsertExtrato(ext);

                /* usuario.usuario_id = usuario_id;'
                 if (usuario.especieUsuario_id == 2 || usuario.especieUsuario_id == 4)
                     SalvarEspecialidadesUsuario(usuario.usuario_id, usuario.especialidadeUsuarios);*/
            }
            catch (Exception ex)
            {
                if (solicitacaoRecebimento == null)
                    solicitacaoRecebimento = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento();
                solicitacaoRecebimento.resultCode = -1;
                solicitacaoRecebimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoRecebimento).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return solicitacaoRecebimento;
        }

        public GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento UpdateSolicitacaoRecebimentoStatus(long solicitacaoRecebimento_id, string status)
        {
            GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento solicitacaoRecebimento = null;
            string sql = "";
            long reg = 0;
            try
            {
                sql = "UPDATE tblSolicitacaoRecebimento SET";
                //sql += " usuario_id = ?";
                sql += " ,solicitacaoRecebimento_status = ?";
                sql += " WHERE solicitacaoRecebimento_id = " + solicitacaoRecebimento_id;


                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                //CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = solicitacaoRecebimento.usuario_id;
                CM.Parameters.Add(@"solicitacaoRecebimento_status", System.Data.OleDb.OleDbType.VarChar).Value = status;


                reg = Convert.ToInt64(CM.ExecuteNonQuery());
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO ATUALIZAR DADOS DO USUÁRIO NO SERVIDOR.");
                /*
                if (usuario.especieUsuario_id == 2 || usuario.especieUsuario_id == 4)
                    SalvarEspecialidadesUsuario(usuario.usuario_id, usuario.especialidadeUsuarios);*/
            }
            catch (Exception ex)
            {
                if (solicitacaoRecebimento == null)
                    solicitacaoRecebimento = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento();
                solicitacaoRecebimento.resultCode = -1;
                solicitacaoRecebimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoRecebimento).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return solicitacaoRecebimento;
        }

        public GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList GetAllSolicitacoesSaquesByFiltro(GUARDIAO_STRUCTS.DATABASE.FiltroSolicitacaoSaque filtro)
        {
            GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList solicitacoes = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT solicitacaoRecebimento_id";
                sql += " ,tblUsuario.usuario_id";
                sql += " ,tblUsuario.usuario_nome";
                sql += " ,solicitacaoRecebimento_status";
                sql += " ,solicitacaoRecebimento_motivoRecusa";
                sql += " ,solicitacaoRecebimento_dataCadastro";
                sql += " ,solicitacaoRecebimento_valorDisponivel";
                sql += " ,solicitacaoRecebimento_valorSolicitado";
                sql += " FROM tblSolicitacaoRecebimento";
                sql += " INNER JOIN tblUsuario ON tblUsuario.usuario_id = tblSolicitacaoRecebimento.usuario_id";
                sql += " WHERE CONVERT(CHAR(10), solicitacaoRecebimento_dataCadastro, 121) BETWEEN '" + Convert.ToDateTime(filtro.solicitacaoRecebimento_dataInicial).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(filtro.solicitacaoRecebimento_dataFinal).ToString("yyyy-MM-dd") + "'";

                if (filtro.usuario_id != 0)
                    sql += " AND tblUsuario.usuario_id = " + filtro.usuario_id;
                if (filtro.solicitacaoRecebimento_status != "")
                    sql += " AND solicitacaoRecebimento_status = '" + filtro.solicitacaoRecebimento_status + "'";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum registro encontrado para os parâmetros informados.");



                solicitacoes = new GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList();
                solicitacoes.solicitacaoRecebimentosList = new List<GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    solicitacoes.solicitacaoRecebimentosList.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento>());
                }

            }
            catch (Exception ex)
            {
                if (solicitacoes == null)
                    solicitacoes = new GUARDIAO_STRUCTS.DATABASE.SolicitacoesRecebimentosList();
                solicitacoes.resultCode = -1;
                solicitacoes.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoRecebimento).Namespace);
            }
            return solicitacoes;
        }

        public GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento GetAllSolicitacoesRecebimentoByID(long solicitacaoRecebimento_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento solicitacaoRecebimento = null;
            try
            {
                sql = "SELECT solicitacaoRecebimento_id";
                sql += " ,usuario_id";
                sql += " ,solicitacaoRecebimento_status";
                sql += " ,solicitacaoRecebimento_motivoRecusa";
                sql += " ,solicitacaoRecebimento_dataCadastro";
                sql += " ,solicitacaoRecebimento_valorDisponivel";
                sql += " ,solicitacaoRecebimento_valorSolicitado";
                sql += " FROM tblSolicitacaoRecebimento";
                sql += " WHERE solicitacaoRecebimento_id = " + solicitacaoRecebimento_id;
                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum registro encontrado para o parâmetro informado.");


                solicitacaoRecebimento = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento>();


            }
            catch (Exception ex)
            {
                if (solicitacaoRecebimento == null)
                    solicitacaoRecebimento = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento();
                solicitacaoRecebimento.resultCode = -1;
                solicitacaoRecebimento.resultDescription = ex.Message;

            }
            return solicitacaoRecebimento;
        }

        public GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento UpdateSolicitacaoRecebimentoStatus(GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento solicitacaoRecebimento)
        {

            string sql = "";
            long reg = 0;
            try
            {
                sql = "UPDATE tblSolicitacaoRecebimento";
                sql += " SET usuario_id = ?";
                sql += " ,solicitacaoRecebimento_status = ?";
                sql += " ,solicitacaoRecebimento_motivoRecusa = ?";
                sql += " ,solicitacaoRecebimento_valorDisponivel = ?";
                sql += " ,solicitacaoRecebimento_valorSolicitado = ?";
                sql += " WHERE solicitacaoRecebimento_id = " + solicitacaoRecebimento.solicitacaoRecebimento_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = solicitacaoRecebimento.usuario_id;
                CM.Parameters.Add(@"solicitacaoRecebimento_status", System.Data.OleDb.OleDbType.VarChar).Value = solicitacaoRecebimento.solicitacaoRecebimento_status;
                CM.Parameters.Add(@"solicitacaoRecebimento_motivoRecusa", System.Data.OleDb.OleDbType.VarChar).Value = solicitacaoRecebimento.solicitacaoRecebimento_motivoRecusa;
                CM.Parameters.Add(@"solicitacaoRecebimento_valorDisponivel", System.Data.OleDb.OleDbType.Decimal).Value = solicitacaoRecebimento.solicitacaoRecebimento_valorDisponivel;
                CM.Parameters.Add(@"solicitacaoRecebimento_valorSolicitado", System.Data.OleDb.OleDbType.Decimal).Value = solicitacaoRecebimento.solicitacaoRecebimento_valorSolicitado;


                reg = Convert.ToInt64(CM.ExecuteNonQuery());
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO ATUALIZAR DADOS DO USUÁRIO NO SERVIDOR.");

                if (solicitacaoRecebimento.solicitacaoRecebimento_status == "SA")
                {
                    InsertExtratoAtendimentoAdvogado(solicitacaoRecebimento.usuario_id, solicitacaoRecebimento.solicitacaoRecebimento_id, Convert.ToDecimal(solicitacaoRecebimento.solicitacaoRecebimento_valorSolicitado.ToString().Replace(".", ",")));
                }
            }
            catch (Exception ex)
            {
                if (solicitacaoRecebimento == null)
                    solicitacaoRecebimento = new GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento();
                solicitacaoRecebimento.resultCode = -1;
                solicitacaoRecebimento.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SolicitacaoRecebimento).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return solicitacaoRecebimento;
        }

        private void InsertExtratoAtendimentoAdvogado(long usuario_id, long solicitacaoRecebimento_id, decimal valor_solicitado)
        {
            GUARDIAO_STRUCTS.DATABASE.Extrato extrato = null;
            try
            {
                extrato = new GUARDIAO_STRUCTS.DATABASE.Extrato();


                extrato.extrato_valor = valor_solicitado;
                extrato.extrato_id = 0;
                extrato.extrato_dataCadastro = DateTime.Now.ToString();
                extrato.usuario_id = usuario_id;
                extrato.tipoExtrato_id = 5;
                extrato.atendimento_id = solicitacaoRecebimento_id;
                extrato.extrato_tempo = "00:00:00";

                GUARDIAO_CRUD.DATABASE.ExtratoCrud objExtrato = new ExtratoCrud();
                extrato = objExtrato.InsertExtrato(extrato);

                if (extrato.resultCode == 0)
                {
                    GUARDIAO_STRUCTS.DATABASE.Saldo saldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                    saldo.usuario_id = usuario_id;
                    saldo.saldo_valor = extrato.extrato_valor;
                    saldo.saldo_horas = extrato.extrato_tempo;
                    saldo.saldo_ultimaAtualizacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    GUARDIAO_CRUD.DATABASE.SaldoCrud objSaldo = new SaldoCrud();
                    saldo = objSaldo.SaveSaldoUsuario(saldo, 5);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool VerificaSolicitacaoRecebimentoEmAberto(GUARDIAO_STRUCTS.DATABASE.SolicitacaoRecebimento solicitacaoRecebimento)
        {
            bool resul = true;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT COUNT(solicitacaoRecebimento_id) AS Total";
                sql += " FROM tblSolicitacaoRecebimento";
                sql += " WHERE usuario_id = " + solicitacaoRecebimento.usuario_id;
                sql += " AND solicitacaoRecebimento_status = 'PA'";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Ocorreu um problema ao verificar solicitaão de recebimento.");
                if (Convert.ToInt32(ds.Tables["T"].Rows[0]["Total"]) > 0)
                    throw new Exception("Já existem solicitação de recebimento em andamento");
            }
            catch (Exception ex)
            {
                resul = false;
            }
            return resul;
        }
    }
}
