using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class Especialidade : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.Especialidade InsertNewEspecialidade(GUARDIAO_STRUCTS.DATABASE.Especialidade especialidade)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblEspecialidade";
                sql += " (especialidade_nome";
                sql += " , especialidade_descricao";
                sql += " , especialidade_ativa";
                sql += " , especialidade_dataCadastro)";
                sql += " VALUES(?,?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"especialidade_nome", System.Data.OleDb.OleDbType.VarChar).Value = especialidade.especialidade_nome;
                CM.Parameters.Add(@"especialidade_descricao", System.Data.OleDb.OleDbType.VarChar).Value = especialidade.especialidade_descricao;
                CM.Parameters.Add(@"especialidade_ativa", System.Data.OleDb.OleDbType.Boolean).Value = especialidade.especialidade_ativa;
                CM.Parameters.Add(@"especialidade_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");


            }
            catch (Exception ex)
            {
                if (especialidade == null)
                    especialidade = new GUARDIAO_STRUCTS.DATABASE.Especialidade();
                especialidade.resultCode = -1;
                especialidade.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return especialidade;
        }

        public GUARDIAO_STRUCTS.DATABASE.Especialidade UpdateEspecialidade(GUARDIAO_STRUCTS.DATABASE.Especialidade especialidade)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblEspecialidade SET";
                sql += " especialidade_nome = ?";
                sql += " , especialidade_descricao = ?";
                sql += " , especialidade_ativa = ?";
                sql += " WHERE especialidade_id = " + especialidade.especialidade_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"especialidade_nome", System.Data.OleDb.OleDbType.VarChar).Value = especialidade.especialidade_nome;
                CM.Parameters.Add(@"especialidade_descricao", System.Data.OleDb.OleDbType.VarChar).Value = especialidade.especialidade_descricao;
                CM.Parameters.Add(@"especialidade_ativa", System.Data.OleDb.OleDbType.Boolean).Value = especialidade.especialidade_ativa;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");


            }
            catch (Exception ex)
            {
                if (especialidade == null)
                    especialidade = new GUARDIAO_STRUCTS.DATABASE.Especialidade();
                especialidade.resultCode = -1;
                especialidade.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return especialidade;
        }

        public GUARDIAO_STRUCTS.DATABASE.Especialidade GetEspecialidadeByID(long especialidade_id)
        {
            string sql = "";
            GUARDIAO_STRUCTS.DATABASE.Especialidade especialidade = null;
            DataSet ds = null;
            try
            {
                sql = "SELECT especialidade_id";
                sql += " , especialidade_nome";
                sql += " , especialidade_descricao";
                sql += " , especialidade_ativa";
                sql += " , especialidade_dataCadastro";
                sql += " FROM tblEspecialidade";
                sql += " WHERE especialidade_id = " + especialidade_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma especialidade encontrada.");

                especialidade = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Especialidade>();

            }
            catch (Exception ex)
            {
                if (especialidade == null)
                    especialidade = new GUARDIAO_STRUCTS.DATABASE.Especialidade();
                especialidade.resultCode = -1;
                especialidade.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
            }
            return especialidade;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.Especialidade> GetAllEspecialidade()
        {
            string sql = "";
            List<GUARDIAO_STRUCTS.DATABASE.Especialidade> especialidades = null;
            DataSet ds = null;
            try
            {
                sql = "SELECT especialidade_id";
                sql += " , especialidade_nome";
                sql += " , especialidade_descricao";
                sql += " , especialidade_ativa";
                sql += " , especialidade_dataCadastro";
                sql += " FROM tblEspecialidade";
                sql += " ORDER BY especialidade_nome";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma especialidade encontrada.");

                especialidades = new List<GUARDIAO_STRUCTS.DATABASE.Especialidade>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    especialidades.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Especialidade>());
                }


            }
            catch (Exception ex)
            {
                especialidades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
            }
            return especialidades;
        }

        public GUARDIAO_STRUCTS.DATABASE.EspecialidadeMobile GetAllEspecialidadeMobile()
        {
            string sql = "";
            GUARDIAO_STRUCTS.DATABASE.EspecialidadeMobile especialidade = null;
            DataSet ds = null;
            try
            {
                sql = "SELECT especialidade_id";
                sql += " , especialidade_nome";
                sql += " , especialidade_descricao";
                sql += " , especialidade_ativa";
                sql += " , especialidade_dataCadastro";
                sql += " FROM tblEspecialidade";
                sql += " WHERE especialidade_ativa = 1";
                sql += " ORDER BY especialidade_nome";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma especialidade encontrada.");
                especialidade = new GUARDIAO_STRUCTS.DATABASE.EspecialidadeMobile();
                especialidade.especialidades = new List<GUARDIAO_STRUCTS.DATABASE.Especialidade>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    especialidade.especialidades.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Especialidade>());
                }


            }
            catch (Exception ex)
            {
                if (especialidade == null)
                    especialidade = new GUARDIAO_STRUCTS.DATABASE.EspecialidadeMobile();
                especialidade.resultCode = -1;
                especialidade.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
            }
            return especialidade;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.Especialidade> GetAllEspecialidadeByUsuarioID(long usuario_id)
        {
            string sql = "";
            List<GUARDIAO_STRUCTS.DATABASE.Especialidade> especialidades = null;
            DataSet ds = null;
            try
            {
                sql = "SELECT tblEspecialidade.especialidade_id";
                sql += " , tblEspecialidade.especialidade_nome";
                sql += " , tblEspecialidade.especialidade_descricao";
                sql += " , tblEspecialidade.especialidade_ativa";
                sql += " , tblEspecialidade.especialidade_dataCadastro";
                sql += " FROM tblEspecialidadeUsuario";
                sql += " INNER JOIN tblEspecialidade ON tblEspecialidadeUsuario.especialidade_id = tblEspecialidade.especialidade_id";
                sql += " WHERE tblEspecialidadeUsuario.usuario_id = " + usuario_id;
                sql += " ORDER BY tblEspecialidade.especialidade_descricao";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma especialidade encontrada.");

                especialidades = new List<GUARDIAO_STRUCTS.DATABASE.Especialidade>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    especialidades.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Especialidade>());
                }


            }
            catch (Exception ex)
            {
                especialidades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
            }
            return especialidades;
        }

        public void DeleteAllEspecialidadesUsuarioByID(long usuario_id)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "DELETE FROM tblEspecialidadeUsuario WHERE usuario_id = " + usuario_id;
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                reg = CM.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
        }

        public void InserEspecialidadesUsuario(long usuario_id, List<GUARDIAO_STRUCTS.DATABASE.EspecialidadeUsuario> especialidades)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblEspecialidadeUsuario";
                sql += " (usuario_id";
                sql += " ,especialidade_id)";
                sql += " VALUES(?,?)";

                OpenDataBase();
                for (int i = 0; i < especialidades.Count; i++)
                {
                    CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                    CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = usuario_id;
                    CM.Parameters.Add(@"especialidade_id", System.Data.OleDb.OleDbType.Numeric).Value = especialidades[i].especialidade_id;

                    reg = CM.ExecuteNonQuery();
                    if (reg == 0)
                        throw new Exception("Ocorreu um problema ao salvar especialidade no usuário no servidor.");

                    CM.Dispose();
                    CM = null;
                }
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
        }

        public List<GUARDIAO_STRUCTS.DATABASE.EspecialidadeUsuario> GetEspecialidadesByUsuarioID(long usuario_id)
        {
            List<GUARDIAO_STRUCTS.DATABASE.EspecialidadeUsuario> especialidades = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT tblEspecialidadeUsuario.usuario_id";
                sql += " , tblEspecialidade.especialidade_id";
                sql += " , tblEspecialidade.especialidade_nome";
                sql += " , tblEspecialidade.especialidade_descricao";
                sql += " , tblEspecialidade.especialidade_ativa";
                sql += " , tblEspecialidade.especialidade_dataCadastro";
                sql += " FROM tblEspecialidadeUsuario ";
                sql += " INNER JOIN tblEspecialidade ON tblEspecialidadeUsuario.especialidade_id = tblEspecialidade.especialidade_id";
                sql += " WHERE tblEspecialidadeUsuario.usuario_id = " + usuario_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma especialidade encontrada para o usuário informado.");

                especialidades = new List<GUARDIAO_STRUCTS.DATABASE.EspecialidadeUsuario>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    especialidades.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.EspecialidadeUsuario>());
                }
            }
            catch (Exception ex)
            {
                especialidades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Especialidade).Namespace);
            }
            return especialidades;
        }
    }
}
