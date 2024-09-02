using GUARDIAO_COMMOM;
using GUARDIAO_STRUCTS.DATABASE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class PercentualPreco : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.PercentualPreco InsertNewPercentualPreco(GUARDIAO_STRUCTS.DATABASE.PercentualPreco percentualPreco)
        {
            string sql = "";
            long percentualPreco_id = 0;
            try
            {
                sql = "INSERT INTO tblPercentualPreco";
                sql += " (usuario_id";
                sql += " ,advogado_id";
                sql += " ,tipoConsulta_id";
                sql += " ,percentualPreco_valor";
                sql += " ,percentualPreco_ativo";
                sql += " ,percentualPreco_dataCadastro)";
                sql += " VALUES(?,?,?,?,?,?);";
                sql += " SELECT @@IDENTITY AS 'IDENTITY';";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = percentualPreco.usuario_id;
                CM.Parameters.Add(@"advogado_id", System.Data.OleDb.OleDbType.Numeric).Value = percentualPreco.advogado_id;
                CM.Parameters.Add(@"tipoConsulta_id", System.Data.OleDb.OleDbType.Numeric).Value = percentualPreco.tipoConsulta_id;
                CM.Parameters.Add(@"percentualPreco_valor", System.Data.OleDb.OleDbType.Decimal).Value = percentualPreco.percentualPreco_valor;
                CM.Parameters.Add(@"percentualPreco_ativo", System.Data.OleDb.OleDbType.Boolean).Value = percentualPreco.percentualPreco_ativo;
                CM.Parameters.Add(@"percentualPreco_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                percentualPreco_id = Convert.ToInt64(CM.ExecuteScalar());
                if (percentualPreco_id == 0)
                    throw new Exception("Ocorreu um problema ao inserir percentual.");

                percentualPreco.percentualPreco_id = percentualPreco_id;
            }
            catch (Exception ex)
            {
                if (percentualPreco == null)
                    percentualPreco = new GUARDIAO_STRUCTS.DATABASE.PercentualPreco();
                percentualPreco.resultCode = -1;
                percentualPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(PercentualPreco).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return percentualPreco;
        }
        public GUARDIAO_STRUCTS.DATABASE.PercentualPreco UpdatePercentualPreco(GUARDIAO_STRUCTS.DATABASE.PercentualPreco percentualPreco)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblPercentualPreco SET";
                sql += " usuario_id = ?";
                sql += " ,advogado_id = ?";
                sql += " ,tipoConsulta_id = ?";
                sql += " ,percentualPreco_valor = ?";
                sql += " ,percentualPreco_ativo = ?";
                sql += " ,percentualPreco_dataCadastro = ?";
                sql += " WHERE percentualPreco_id = " + percentualPreco.percentualPreco_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = percentualPreco.usuario_id;
                CM.Parameters.Add(@"advogado_id", System.Data.OleDb.OleDbType.Numeric).Value = percentualPreco.advogado_id;
                CM.Parameters.Add(@"tipoConsulta_id", System.Data.OleDb.OleDbType.Numeric).Value = percentualPreco.tipoConsulta_id;
                CM.Parameters.Add(@"percentualPreco_valor", System.Data.OleDb.OleDbType.Decimal).Value = percentualPreco.percentualPreco_valor;
                CM.Parameters.Add(@"percentualPreco_ativo", System.Data.OleDb.OleDbType.Boolean).Value = percentualPreco.percentualPreco_ativo;
                CM.Parameters.Add(@"percentualPreco_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao atualizar percentual.");
            }
            catch (Exception ex)
            {
                if (percentualPreco == null)
                    percentualPreco = new GUARDIAO_STRUCTS.DATABASE.PercentualPreco();
                percentualPreco.resultCode = -1;
                percentualPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(PercentualPreco).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return percentualPreco;
        }
        public GUARDIAO_STRUCTS.DATABASE.PercentualPreco GetPercentualPrecoByID(long percentualPreco_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.PercentualPreco percentualPreco = null;
            try
            {
                sql = "SELECT percentualPreco_id";
                sql += " ,usuario_id";
                sql += " ,advogado_id";
                sql += " ,tipoConsulta_id";
                sql += " ,percentualPreco_valor";
                sql += " ,percentualPreco_ativo";
                sql += " ,percentualPreco_dataCadastro";
                sql += " FROM tblPercentualPreco";
                sql += " WHERE percentualPreco_id = " + percentualPreco_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum percentual encontrada para o parâmetro informado.");

                percentualPreco = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.PercentualPreco>();
            }
            catch (Exception ex)
            {
                if (percentualPreco == null)
                    percentualPreco = new GUARDIAO_STRUCTS.DATABASE.PercentualPreco();
                percentualPreco.resultCode = -1;
                percentualPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(PercentualPreco).Namespace);
            }

            return percentualPreco;
        }
        public List<GUARDIAO_STRUCTS.DATABASE.PercentualPreco> GetAllPercentualPrecoByAdvogadoByAtivo(long advogado_id, bool percentualPreco_ativo)
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.PercentualPreco> percentualPrecos = null;
            try
            {
                sql = "SELECT percentualPreco_id";
                sql += " ,usuario_id";
                sql += " ,advogado_id";
                sql += " ,tipoConsulta_id";
                sql += " ,percentualPreco_valor";
                sql += " ,percentualPreco_ativo";
                sql += " ,percentualPreco_dataCadastro";
                sql += " FROM tblPercentualPreco";
                sql += " WHERE percentualPreco_ativo = " + (percentualPreco_ativo ? 1 : 0);
                if (advogado_id > 0)
                    sql += " AND advogado_id = " + advogado_id;


                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum percentual encontrada para o parâmetro informado.");
                percentualPrecos = new List<GUARDIAO_STRUCTS.DATABASE.PercentualPreco>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    percentualPrecos.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.PercentualPreco>());
                }

            }
            catch (Exception ex)
            {
                percentualPrecos = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(PercentualPreco).Namespace);
            }

            return percentualPrecos;
        }
    }
}
