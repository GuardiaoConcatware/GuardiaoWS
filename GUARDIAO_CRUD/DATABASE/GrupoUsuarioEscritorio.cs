using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUARDIAO_COMMOM;

namespace GUARDIAO_CRUD.DATABASE
{
    public class GrupoUsuarioEscritorio:DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.GrupoUsuario InsertNewGrupoUsuario(GUARDIAO_STRUCTS.DATABASE.GrupoUsuario grupoUsuario)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblGrupoUsuarioEscritorio";
                sql += " (grupoUsuario_descricao)";
                sql += " VALUES(?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"grupoUsuario_descricao", System.Data.OleDb.OleDbType.VarChar).Value = grupoUsuario.grupoUsuario_descricao;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");

                // empresa.empresa_logoMarca = "";
            }
            catch (Exception ex)
            {
                if (grupoUsuario == null)
                    grupoUsuario = new GUARDIAO_STRUCTS.DATABASE.GrupoUsuario();
                grupoUsuario.resultCode = -1;
                grupoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuarioEscritorio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return grupoUsuario;
        }

        public GUARDIAO_STRUCTS.DATABASE.GrupoUsuario UpdateGrupoUsuario(GUARDIAO_STRUCTS.DATABASE.GrupoUsuario grupoUsuario)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblGrupoUsuarioEscritorioEscritorio SET";
                sql += " grupoUsuario_descricao = ?";
                sql += " WHERE grupoUsuario_id = " + grupoUsuario.grupoUsuario_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"grupoUsuario_descricao", System.Data.OleDb.OleDbType.VarChar).Value = grupoUsuario.grupoUsuario_descricao;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");

                //empresa.empresa_logoMarca = "";
            }
            catch (Exception ex)
            {
                if (grupoUsuario == null)
                    grupoUsuario = new GUARDIAO_STRUCTS.DATABASE.GrupoUsuario();
                grupoUsuario.resultCode = -1;
                grupoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuarioEscritorio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return grupoUsuario;
        }

        public GUARDIAO_STRUCTS.DATABASE.GrupoUsuario GetGrupoUsuarioByID(long grupoUsuario_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.GrupoUsuario grupoUsuario = null;
            try
            {
                sql = "SELECT grupoUsuario_id";
                sql += " ,grupoUsuario_descricao";
                sql += " FROM tblGrupoUsuarioEscritorio";
                sql += " WHERE grupoUsuario_id = " + grupoUsuario_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                grupoUsuario = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.GrupoUsuario>();
                grupoUsuario.grupoFuncionalidades = GetFuncionalidadesByGrupoUsuarioID(grupoUsuario.grupoUsuario_id);
            }
            catch (Exception ex)
            {
                if (grupoUsuario == null)
                    grupoUsuario = new GUARDIAO_STRUCTS.DATABASE.GrupoUsuario();
                grupoUsuario.resultCode = -1;
                grupoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuarioEscritorio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return grupoUsuario;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.GrupoUsuario> GetAllGrupoUsuario()
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.GrupoUsuario> grupoUsuarios = null;
            try
            {
                sql = "SELECT grupoUsuario_id";
                sql += " ,grupoUsuario_descricao";
                sql += " FROM tblGrupoUsuarioEscritorio";
                sql += " ORDER BY grupoUsuario_id";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                grupoUsuarios = new List<GUARDIAO_STRUCTS.DATABASE.GrupoUsuario>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    grupoUsuarios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.GrupoUsuario>());
                }


            }
            catch (Exception ex)
            {
                grupoUsuarios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuarioEscritorio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return grupoUsuarios;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.GrupoFuncionalidade> GetGrupoFuncionalidadeDisponivel(long grupoUsuario_id)
        {
            List<GUARDIAO_STRUCTS.DATABASE.GrupoFuncionalidade> grupoFuncionalidades = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT tblGrupoFuncionalidadeEscritorio.grupoFuncionalidade_id";
                sql += " , tblGrupoFuncionalidadeEscritorio.grupoFuncionalidade_nome";
                sql += " , tblItemFuncionalidadeEscritorio.itemFuncionalidade_id";
                sql += " , tblItemFuncionalidadeEscritorio.itemFuncionalidade_nome";
                sql += " FROM tblGrupoFuncionalidadeEscritorio";
                sql += " INNER JOIN tblItemFuncionalidadeEscritorio ON tblGrupoFuncionalidadeEscritorio.grupoFuncionalidade_id = tblItemFuncionalidadeEscritorio.grupoFuncionalidade_id";
                sql += " WHERE itemFuncionalidade_id NOT IN(";
                sql += " SELECT itemFuncionalidade_id";
                sql += " FROM tblGrupoUsuarioEscritorioItem";
                sql += " WHERE grupoUsuario_id = " + grupoUsuario_id + ")";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("NENHUM GRUPO DE FUNCIONALIDADE ENCONTRADO PARA O PARÂMETRO INFORMADO.");

                DataTable tblIDGrupoFuncionalidade = GUARDIAO_COMMOM.Util.SelectDistinct(ds.Tables["T"], "grupoFuncionalidade_id");
                if (tblIDGrupoFuncionalidade.Rows.Count != 0)
                {
                    grupoFuncionalidades = new List<GUARDIAO_STRUCTS.DATABASE.GrupoFuncionalidade>();
                    for (int i = 0; i < tblIDGrupoFuncionalidade.Rows.Count; i++)
                    {


                        var strExpr = "grupoFuncionalidade_id = " + tblIDGrupoFuncionalidade.Rows[i][0].ToString();
                        var strSort = "grupoFuncionalidade_nome ASC";
                        List<DataRow> tblGrupoFuncionalidade = ds.Tables["T"].Select(strExpr, strSort).ToList();

                        GUARDIAO_STRUCTS.DATABASE.GrupoFuncionalidade gf = new GUARDIAO_STRUCTS.DATABASE.GrupoFuncionalidade();
                        gf.grupoFuncionalidade_id = Convert.ToInt64(tblIDGrupoFuncionalidade.Rows[i][0]);
                        gf.grupoFuncionalidade_nome = tblGrupoFuncionalidade[0]["grupoFuncionalidade_nome"].ToString();
                        if (tblGrupoFuncionalidade.Count > 0)
                        {
                            gf.itemFuncionalidades = new List<GUARDIAO_STRUCTS.DATABASE.ItemFuncionalidade>();
                            for (int j = 0; j < tblGrupoFuncionalidade.Count; j++)
                            {
                                GUARDIAO_STRUCTS.DATABASE.ItemFuncionalidade iF = new GUARDIAO_STRUCTS.DATABASE.ItemFuncionalidade();
                                iF.grupoFuncionalidade_id = gf.grupoFuncionalidade_id;
                                iF.itemFuncionalidade_id = Convert.ToInt64(tblGrupoFuncionalidade[j]["itemFuncionalidade_id"]);
                                iF.itemFuncionalidade_nome = tblGrupoFuncionalidade[j]["itemFuncionalidade_nome"].ToString();
                                gf.itemFuncionalidades.Add(iF);
                            }
                        }
                        grupoFuncionalidades.Add(gf);
                    }


                }
            }
            catch (Exception ex)
            {
                grupoFuncionalidades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuarioEscritorio).Namespace);
            }
            return grupoFuncionalidades;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.ItemFuncionalidade> GetItemFuncionalidadeByGrupoUsuarioByGrupoFuncionadade(long grupoUsuario_id, long grupoFuncionalidade_id)
        {
            List<GUARDIAO_STRUCTS.DATABASE.ItemFuncionalidade> itemFuncionalidades = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT tblItemFuncionalidadeEscritorio.itemFuncionalidade_id";
                sql += " , tblItemFuncionalidadeEscritorio.grupoFuncionalidade_id";
                sql += " , tblItemFuncionalidadeEscritorio.itemFuncionalidade_nome COLLATE SQL_Latin1_General_Cp1251_CS_AS AS itemFuncionalidade_nome";
                sql += " FROM tblGrupoUsuarioEscritorioItem";
                sql += " INNER JOIN tblItemFuncionalidadeEscritorio ON tblGrupoUsuarioEscritorioItem.itemFuncionalidade_id = tblItemFuncionalidadeEscritorio.itemFuncionalidade_id";
                sql += " WHERE tblGrupoUsuarioEscritorioItem.grupoUsuario_id = " + grupoUsuario_id;
                sql += " AND tblItemFuncionalidadeEscritorio.grupoFuncionalidade_id = " + grupoFuncionalidade_id;

                ds = ExecuteSelect(sql);

                if (ds == null)
                    throw new Exception("NENHUM ITEM DE FUNCIONALIDADE ENCONTRADO PARA O GRUPO E FUNCIONALIDADE INFORMADOS.");
                itemFuncionalidades = new List<GUARDIAO_STRUCTS.DATABASE.ItemFuncionalidade>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    itemFuncionalidades.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.ItemFuncionalidade>());
                }
            }
            catch (Exception ex)
            {
                itemFuncionalidades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuarioEscritorio).Namespace);
            }
            return itemFuncionalidades;
        }

        public GUARDIAO_STRUCTS.DATABASE.GrupoUsuario SaveFuncionalidadesGrupoUsuario(GUARDIAO_STRUCTS.DATABASE.GrupoUsuario grupoUsuario)
        {
            try
            {
                DeleteAllFuncionadadesByGrupoUsuarioID(grupoUsuario.grupoUsuario_id);

                for (int i = 0; i < grupoUsuario.grupoFuncionalidades.Count; i++)
                {
                    for (int j = 0; j < grupoUsuario.grupoFuncionalidades[i].itemFuncionalidades.Count; j++)
                    {
                        if (!InsertItemGrupoFuncionalidadeGrupoUsuario(grupoUsuario.grupoUsuario_id
                            , grupoUsuario.grupoFuncionalidades[i].grupoFuncionalidade_id
                            , grupoUsuario.grupoFuncionalidades[i].itemFuncionalidades[j].itemFuncionalidade_id))
                        {
                            DeleteAllFuncionadadesByGrupoUsuarioID(grupoUsuario.grupoUsuario_id);
                            throw new Exception("OCORREU UM PROBLEMA AO SALVAR ITENS DO GRUPO DE PERMISSÂO DE USUÁRIO.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (grupoUsuario == null)
                    grupoUsuario = new GUARDIAO_STRUCTS.DATABASE.GrupoUsuario();
                grupoUsuario.resultCode = -1;
                grupoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuarioEscritorio).Namespace);
            }
            return grupoUsuario;
        }

        private List<GUARDIAO_STRUCTS.DATABASE.GrupoFuncionalidade> GetFuncionalidadesByGrupoUsuarioID(long grupoUsuario_id)
        {
            List<GUARDIAO_STRUCTS.DATABASE.GrupoFuncionalidade> grupoFuncionalidades = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT DISTINCT tblGrupoFuncionalidade.grupoFuncionalidade_id";
                sql += " , tblGrupoFuncionalidade.grupoFuncionalidade_nome COLLATE SQL_Latin1_General_Cp1251_CS_AS AS grupoFuncionalidade_nome";
                sql += " FROM tblGrupoUsuarioEscritorioItem";
                sql += " INNER JOIN tblGrupoFuncionalidade ON tblGrupoUsuarioEscritorioItem.grupoFuncionalidade_id = tblGrupoFuncionalidade.grupoFuncionalidade_id";
                sql += " WHERE tblGrupoUsuarioEscritorioItem.grupoUsuario_id = " + grupoUsuario_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("NENHUM GRUPO DE FUNCIONADADE ENCONTRADO PARA O GRUPO DE USUÁRIO INFORMADO.");

                grupoFuncionalidades = new List<GUARDIAO_STRUCTS.DATABASE.GrupoFuncionalidade>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    GUARDIAO_STRUCTS.DATABASE.GrupoFuncionalidade gf = ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.GrupoFuncionalidade>();
                    gf.itemFuncionalidades = GetItemFuncionalidadeByGrupoUsuarioByGrupoFuncionadade(grupoUsuario_id, gf.grupoFuncionalidade_id);
                    grupoFuncionalidades.Add(gf);

                }
            }
            catch (Exception ex)
            {
                grupoFuncionalidades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuarioEscritorio).Namespace);
            }
            return grupoFuncionalidades;

        }

        private bool InsertItemGrupoFuncionalidadeGrupoUsuario(long grupoUsuario_id, long grupoFuncionalidade_id, long itemFuncionalidade_id)
        {
            bool resul = true;
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblGrupoUsuarioEscritorioItem";
                sql += " (grupoUsuario_id";
                sql += " , grupoFuncionalidade_id";
                sql += " , itemFuncionalidade_id)";
                sql += " VALUES(?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"grupoUsuario_id", System.Data.OleDb.OleDbType.Numeric, 18).Value = grupoUsuario_id;
                CM.Parameters.Add(@"grupoFuncionalidade_id", System.Data.OleDb.OleDbType.Numeric, 18).Value = grupoFuncionalidade_id;
                CM.Parameters.Add(@"itemFuncionalidade_id", System.Data.OleDb.OleDbType.Numeric, 18).Value = itemFuncionalidade_id;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("OCORREU UM ERRO AO INSERIR FUNCIONALIDADE NO GRUPO DO USUÁRIO.");
            }
            catch (Exception ex)
            {
                resul = false;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuarioEscritorio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return resul;
        }

        private void DeleteAllFuncionadadesByGrupoUsuarioID(long grupoUsuario_id)
        {
            string sql = "";
            try
            {
                sql = "DELETE FROM tblGrupoUsuarioEscritorioItem WHERE grupoUsuario_id = " + grupoUsuario_id;
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(GrupoUsuarioEscritorio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
        }
    }
}
