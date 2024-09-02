using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class Municipio : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.Municipio InsertNewMunicipio(GUARDIAO_STRUCTS.DATABASE.Municipio municipio)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblMunicipio";
                sql += " (municipio_codigo";
                sql += " ,municipio_codigo2";
                sql += " ,municipio_nome";
                sql += " ,municipio_uf)";
                sql += " VALUES(?,?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"municipio_codigo", System.Data.OleDb.OleDbType.Numeric).Value = municipio.municipio_codigo;
                CM.Parameters.Add(@"municipio_codigo2", System.Data.OleDb.OleDbType.Numeric).Value = municipio.municipio_codigo2;
                CM.Parameters.Add(@"municipio_nome", System.Data.OleDb.OleDbType.VarChar).Value = municipio.municipio_nome;
                CM.Parameters.Add(@"municipio_uf", System.Data.OleDb.OleDbType.VarChar).Value = municipio.municipio_uf;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");

                // empresa.empresa_logoMarca = "";
            }
            catch (Exception ex)
            {
                if (municipio == null)
                    municipio = new GUARDIAO_STRUCTS.DATABASE.Municipio();
                municipio.resultCode = -1;
                municipio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return municipio;
        }

        public GUARDIAO_STRUCTS.DATABASE.Municipio UpdateMunicipio(GUARDIAO_STRUCTS.DATABASE.Municipio municipio)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblMunicipio SET";
                sql += " municipio_codigo = ?";
                sql += " ,municipio_codigo2 = ?";
                sql += " ,municipio_nome = ?";
                sql += " ,municipio_uf = ?";
                sql += " WHERE municipio_id = " + municipio.municipio_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"municipio_codigo", System.Data.OleDb.OleDbType.Numeric).Value = municipio.municipio_codigo;
                CM.Parameters.Add(@"municipio_codigo2", System.Data.OleDb.OleDbType.Numeric).Value = municipio.municipio_codigo2;
                CM.Parameters.Add(@"municipio_nome", System.Data.OleDb.OleDbType.VarChar).Value = municipio.municipio_nome;
                CM.Parameters.Add(@"municipio_uf", System.Data.OleDb.OleDbType.VarChar).Value = municipio.municipio_uf;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");

                // empresa.empresa_logoMarca = "";
            }
            catch (Exception ex)
            {
                if (municipio == null)
                    municipio = new GUARDIAO_STRUCTS.DATABASE.Municipio();
                municipio.resultCode = -1;
                municipio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return municipio;
        }

        public GUARDIAO_STRUCTS.DATABASE.Municipio GetEmpresaByID(long municipio_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Municipio municipio = null;
            try
            {
                sql = "SELECT municipio_id";
                sql += " ,municipio_codigo";
                sql += " ,municipio_codigo2";
                sql += " ,municipio_nome";
                sql += " ,municipio_uf";
                sql += " FROM tblMunicipio";
                sql += " WHERE municipio_id = " + municipio_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum municipio encontrado para o parâmetro informado.");

                municipio = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Municipio>();
            }
            catch (Exception ex)
            {
                if (municipio == null)
                    municipio = new GUARDIAO_STRUCTS.DATABASE.Municipio();
                municipio.resultCode = -1;
                municipio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return municipio;
        }

        public GUARDIAO_STRUCTS.DATABASE.Municipio GetMunicipioByCodigo(long municipio_codigo)
        {

            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Municipio municipio = null;
            try
            {
                sql = "SELECT municipio_id";
                sql += " ,municipio_codigo";
                sql += " ,municipio_codigo2";
                sql += " ,municipio_nome";
                sql += " ,municipio_uf";
                sql += " FROM tblMunicipio";
                sql += " WHERE municipio_codigo = " + municipio_codigo;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum municipio encontrado para o parâmetro informado.");

                municipio = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Municipio>();
            }
            catch (Exception ex)
            {
                if (municipio == null)
                    municipio = new GUARDIAO_STRUCTS.DATABASE.Municipio();
                municipio.resultCode = -1;
                municipio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return municipio;
        }

        public GUARDIAO_STRUCTS.DATABASE.Municipio GetMunicipioByName(string municipio_nome)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Municipio municipio = null;
            try
            {
                sql = "SELECT municipio_id";
                sql += " ,municipio_codigo";
                sql += " ,municipio_codigo2";
                sql += " ,municipio_nome";
                sql += " ,municipio_uf";
                sql += " FROM tblMunicipio";
                sql += " WHERE municipio_nome = '" + municipio_nome + "'";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum municipio encontrado para o parâmetro informado.");

                municipio = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Municipio>();
            }
            catch (Exception ex)
            {
                if (municipio == null)
                    municipio = new GUARDIAO_STRUCTS.DATABASE.Municipio();
                municipio.resultCode = -1;
                municipio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }
            return municipio;
        }

        public List<string> GetAllUF()
        {
            string sql = "";
            DataSet ds = null;
            List<string> municipios = null;
            try
            {
                sql = "SELECT DISTINCT municipio_uf";
                sql += " FROM tblMunicipio";
                sql += " ORDER BY municipio_uf";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                municipios = new List<string>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    municipios.Add(ds.Tables["T"].Rows[i]["municipio_uf"].ToString());
                }


            }
            catch (Exception ex)
            {
                municipios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return municipios;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.Municipio> GetAllMunicipioByUF(string UF)
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.Municipio> municipios = null;
            try
            {
                sql = "SELECT municipio_id";
                sql += " ,municipio_codigo";
                sql += " ,municipio_codigo2";
                sql += " ,municipio_nome";
                sql += " ,municipio_uf";
                sql += " FROM tblMunicipio";
                sql += " WHERE municipio_uf = '" + UF + "'";
                sql += " ORDER BY municipio_nome";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                municipios = new List<GUARDIAO_STRUCTS.DATABASE.Municipio>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    municipios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Municipio>());
                }


            }
            catch (Exception ex)
            {
                municipios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return municipios;
        }

        public GUARDIAO_STRUCTS.DATABASE.MunicipioDart GetAllMunicipioByUFDart(string UF)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.MunicipioDart municipio = null;
            try
            {
                sql = "SELECT municipio_id";
                sql += " ,municipio_codigo";
                sql += " ,municipio_codigo2";
                sql += " ,municipio_nome";
                sql += " ,municipio_uf";
                sql += " FROM tblMunicipio";
                sql += " WHERE municipio_uf = '" + UF + "'";
                sql += " ORDER BY municipio_nome";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                municipio = new GUARDIAO_STRUCTS.DATABASE.MunicipioDart();
                municipio.municipios = new List<GUARDIAO_STRUCTS.DATABASE.Municipio>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    municipio.municipios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Municipio>());
                }


            }
            catch (Exception ex)
            {
                if (municipio == null)
                    municipio = new GUARDIAO_STRUCTS.DATABASE.MunicipioDart();
                municipio.resultCode = -1;
                municipio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Municipio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return municipio;
        }
    }
}
