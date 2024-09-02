using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class TipoConsulta : DataBase
    {

        public GUARDIAO_STRUCTS.DATABASE.TipoConsulta InsertNewTipoConsulta(GUARDIAO_STRUCTS.DATABASE.TipoConsulta tipoConsulta)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblTipoConsulta";
                sql += " (tipoConsulta_descricao)";
                sql += " VALUES(?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"tipoConsulta_descricao", System.Data.OleDb.OleDbType.VarChar).Value = tipoConsulta.tipoConsulta_descricao;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");

                // empresa.empresa_logoMarca = "";
            }
            catch (Exception ex)
            {
                if (tipoConsulta == null)
                    tipoConsulta = new GUARDIAO_STRUCTS.DATABASE.TipoConsulta();
                tipoConsulta.resultCode = -1;
                tipoConsulta.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoConsulta).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tipoConsulta;
        }

        public GUARDIAO_STRUCTS.DATABASE.TipoConsulta UpdateTipoConsulta(GUARDIAO_STRUCTS.DATABASE.TipoConsulta tipoConsulta)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblTipoConsulta SET";
                sql += " tipoConsulta_descricao = ?";
                sql += " WHERE tipoConsulta_id = " + tipoConsulta.tipoConsulta_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"municipio_codigo", System.Data.OleDb.OleDbType.VarChar).Value = tipoConsulta.tipoConsulta_descricao;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");

                // empresa.empresa_logoMarca = "";
            }
            catch (Exception ex)
            {
                if (tipoConsulta == null)
                    tipoConsulta = new GUARDIAO_STRUCTS.DATABASE.TipoConsulta();
                tipoConsulta.resultCode = -1;
                tipoConsulta.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoConsulta).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tipoConsulta;
        }

        public GUARDIAO_STRUCTS.DATABASE.TipoConsulta GetTipoConsultaByID(long tipoConculta_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.TipoConsulta tipoConsulta = null;
            try
            {
                sql = "SELECT tipoConculta_id";
                sql += " ,tipoConculta_descricao";
                sql += " FROM tblTipoConsulta";
                sql += " WHERE tipoConculta_id = " + tipoConculta_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum municipio encontrado para o parâmetro informado.");

                tipoConsulta = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.TipoConsulta>();
            }
            catch (Exception ex)
            {
                if (tipoConsulta == null)
                    tipoConsulta = new GUARDIAO_STRUCTS.DATABASE.TipoConsulta();
                tipoConsulta.resultCode = -1;
                tipoConsulta.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoConsulta).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tipoConsulta;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.TipoConsulta> GetAllTipoConsulta()
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.TipoConsulta> tipoConsultas = null;
            try
            {
                sql = "SELECT tipoConsulta_id";
                sql += " ,tipoConsulta_descricao";
                sql += " FROM tblTipoConsulta";
                sql += " ORDER BY tipoConsulta_id";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                tipoConsultas = new List<GUARDIAO_STRUCTS.DATABASE.TipoConsulta>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    tipoConsultas.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.TipoConsulta>());
                }


            }
            catch (Exception ex)
            {
                tipoConsultas = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TipoConsulta).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tipoConsultas;
        }
    }
}
