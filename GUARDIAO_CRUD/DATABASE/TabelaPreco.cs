using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class TabelaPreco : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.TabelaPreco InsertNewTabelaPreco(GUARDIAO_STRUCTS.DATABASE.TabelaPreco tabelaPreco)
        {
            string sql = "";
            long tabelaPreco_id = 0;
            try
            {
                sql = "INSERT INTO tblTabelaPreco";
                sql += " (usuario_id";
                sql += " ,advogado_id";
                sql += " ,tipoConsulta_id";
                sql += " ,tabelaPreco_valor";
                sql += " ,tabelaPreco_ativo";
                sql += " ,tabelaPreco_dataCadastro)";
                sql += " VALUES(?,?,?,?,?,?);";
                sql += " SELECT @@IDENTITY AS 'IDENTITY';";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = tabelaPreco.usuario_id;
                CM.Parameters.Add(@"advogado_id", System.Data.OleDb.OleDbType.Numeric).Value = tabelaPreco.advogado_id;
                CM.Parameters.Add(@"tipoConsulta_id", System.Data.OleDb.OleDbType.Numeric).Value = tabelaPreco.tipoConsulta_id;
                CM.Parameters.Add(@"tabelaPreco_valor", System.Data.OleDb.OleDbType.Decimal).Value = tabelaPreco.tabelaPreco_valor;
                CM.Parameters.Add(@"tabelaPreco_ativo", System.Data.OleDb.OleDbType.Boolean).Value = tabelaPreco.tabelaPreco_ativo;
                CM.Parameters.Add(@"tabelaPreco_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                tabelaPreco_id = Convert.ToInt64(CM.ExecuteScalar());
                if (tabelaPreco_id == 0)
                    throw new Exception("Ocorreu um problema ao salvar tabela de preço no servidor.");

                tabelaPreco.tabelaPreco_id = tabelaPreco_id;


            }
            catch (Exception ex)
            {
                if (tabelaPreco == null)
                    tabelaPreco = new GUARDIAO_STRUCTS.DATABASE.TabelaPreco();
                tabelaPreco.resultCode = -1;
                tabelaPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TabelaPreco).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tabelaPreco;
        }

        public GUARDIAO_STRUCTS.DATABASE.TabelaPreco UpdateTabelaPreco(GUARDIAO_STRUCTS.DATABASE.TabelaPreco tabelaPreco)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblTabelaPreco SET";
                sql += " usuario_id = ?";
                sql += " ,advogado_id = ?";
                sql += " ,tipoConsulta_id = ?";
                sql += " ,tabelaPreco_valor = ?";
                sql += " ,tabelaPreco_ativo = ?";
                sql += " ,tabelaPreco_dataCadastro = ?";
                sql += " WHERE tabelaPreco_id = " + tabelaPreco.tabelaPreco_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"advogado_id", System.Data.OleDb.OleDbType.Numeric).Value = tabelaPreco.advogado_id;
                CM.Parameters.Add(@"tipoConsulta_id", System.Data.OleDb.OleDbType.Numeric).Value = tabelaPreco.tipoConsulta_id;
                CM.Parameters.Add(@"tabelaPreco_valor", System.Data.OleDb.OleDbType.Decimal).Value = tabelaPreco.tabelaPreco_valor;
                CM.Parameters.Add(@"tabelaPreco_ativo", System.Data.OleDb.OleDbType.Boolean).Value = tabelaPreco.tabelaPreco_ativo;
                CM.Parameters.Add(@"tabelaPreco_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");

                // empresa.empresa_logoMarca = "";
            }
            catch (Exception ex)
            {
                if (tabelaPreco == null)
                    tabelaPreco = new GUARDIAO_STRUCTS.DATABASE.TabelaPreco();
                tabelaPreco.resultCode = -1;
                tabelaPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TabelaPreco).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tabelaPreco;
        }

        public GUARDIAO_STRUCTS.DATABASE.TabelaPreco GetTabelaPrecoByID(long tabelaPreco_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.TabelaPreco tabelaPreco = null;
            try
            {
                sql = "SELECT tabelaPreco_id";
                sql += " ,usuario_id";
                sql += " ,advogado_id";
                sql += " ,tipoConsulta_id";
                sql += " ,tabelaPreco_valor";
                sql += " ,tabelaPreco_ativo";
                sql += " ,tabelaPreco_dataCadastro";
                sql += " FROM tblTabelaPreco";
                sql += " WHERE tabelaPreco_id = " + tabelaPreco_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum municipio encontrado para o parâmetro informado.");

                tabelaPreco = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.TabelaPreco>();
            }
            catch (Exception ex)
            {
                if (tabelaPreco == null)
                    tabelaPreco = new GUARDIAO_STRUCTS.DATABASE.TabelaPreco();
                tabelaPreco.resultCode = -1;
                tabelaPreco.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TabelaPreco).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tabelaPreco;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.TabelaPreco> GetAllTabelaPreco()
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.TabelaPreco> tabelaPrecos = null;
            try
            {
                sql = "SELECT tabelaPreco_id";
                sql += " ,usuario_id";
                sql += " ,advogado_id";
                sql += " ,tipoConsulta_id";
                sql += " ,tabelaPreco_valor";
                sql += " ,tabelaPreco_ativo";
                sql += " ,tabelaPreco_dataCadastro";
                sql += " FROM tblTabelaPreco";
                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                tabelaPrecos = new List<GUARDIAO_STRUCTS.DATABASE.TabelaPreco>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    tabelaPrecos.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.TabelaPreco>());
                }


            }
            catch (Exception ex)
            {
                tabelaPrecos = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(TabelaPreco).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return tabelaPrecos;
        }
    }
}
