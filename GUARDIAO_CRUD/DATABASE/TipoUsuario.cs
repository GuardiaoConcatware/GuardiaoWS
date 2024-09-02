using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class TipoUsuario : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.TipoUsuario InsertNewTipoUsuario(GUARDIAO_STRUCTS.DATABASE.TipoUsuario tipoUsuario)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblTipoUsuario";
                sql += " (especieUsuario_id";
                sql += " ,tipoUsuario_descricao)";
                sql += " VALUES(?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"especieUsuario_id", System.Data.OleDb.OleDbType.Numeric).Value = tipoUsuario.especieUsuario_id;
                CM.Parameters.Add(@"tipoUsuario_descricao", System.Data.OleDb.OleDbType.VarChar).Value = tipoUsuario.tipoUsuario_descricao;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");

                // empresa.empresa_logoMarca = "";
            }
            catch (Exception ex)
            {
                if (tipoUsuario == null)
                    tipoUsuario = new GUARDIAO_STRUCTS.DATABASE.TipoUsuario();
                tipoUsuario.resultCode = -1;
                tipoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoUsuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tipoUsuario;
        }

        public GUARDIAO_STRUCTS.DATABASE.TipoUsuario UpdateTipoUsuario(GUARDIAO_STRUCTS.DATABASE.TipoUsuario tipoUsuario)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblTipoUsuario SET";
                sql += " especieUsuario_id = ?";
                sql += " tipoUsuario_descricao = ?";
                sql += " WHERE funcionalidadeSistema_id = " + tipoUsuario.tipoUsuario_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"especieUsuario_id", System.Data.OleDb.OleDbType.Numeric).Value = tipoUsuario.especieUsuario_id;
                CM.Parameters.Add(@"tipoUsuario_descricao", System.Data.OleDb.OleDbType.VarChar).Value = tipoUsuario.tipoUsuario_descricao;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");

                // empresa.empresa_logoMarca = "";
            }
            catch (Exception ex)
            {
                if (tipoUsuario == null)
                    tipoUsuario = new GUARDIAO_STRUCTS.DATABASE.TipoUsuario();
                tipoUsuario.resultCode = -1;
                tipoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoUsuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tipoUsuario;
        }

        public GUARDIAO_STRUCTS.DATABASE.TipoUsuario GetTipoUsuarioByID(long tipoUsuario_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.TipoUsuario tipoUsuario = null;
            try
            {
                sql = "SELECT tipoUsuario_id";
                sql += " ,tipoUsuario_id";
                sql += " ,tipoUsuario_descricao";
                sql += " FROM tblTipoUsuario";
                sql += " WHERE tipoUsuario_id = " + tipoUsuario_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum municipio encontrado para o parâmetro informado.");

                tipoUsuario = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.TipoUsuario>();
            }
            catch (Exception ex)
            {
                if (tipoUsuario == null)
                    tipoUsuario = new GUARDIAO_STRUCTS.DATABASE.TipoUsuario();
                tipoUsuario.resultCode = -1;
                tipoUsuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoUsuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tipoUsuario;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.TipoUsuario> GetAllTipoUsuario(long especieUsuario_id)
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.TipoUsuario> tipoUsuarios = null;
            try
            {
                sql = "SELECT tipoUsuario_id";
                sql += " ,especieUsuario_id";
                sql += " ,tipoUsuario_descricao";
                sql += " FROM tblTipoUsuario";
                sql += " WHERE especieUsuario_id = " + especieUsuario_id;
                sql += " ORDER BY tipoUsuario_descricao";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum tipo de usuário encontrado para o parâmetro informado.");

                tipoUsuarios = new List<GUARDIAO_STRUCTS.DATABASE.TipoUsuario>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    tipoUsuarios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.TipoUsuario>());
                }


            }
            catch (Exception ex)
            {
                tipoUsuarios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoUsuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tipoUsuarios;
        }
    }
}
