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
    public class Escritorio : DataBase
    {

        public GUARDIAO_STRUCTS.DATABASE.Escritorio InsertNewEscritorio(GUARDIAO_STRUCTS.DATABASE.Escritorio escritorio)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblEscritorio";
                sql += " (municipio_codigo";
                sql += " ,escritorio_cnpj";
                sql += " ,escritorio_razaoSocial";
                sql += " ,escritorio_nomeFantasia";
                sql += " ,escritorio_inscricaoMunicipal";
                sql += " ,escritorio_inscricaoEstadual";
                sql += " ,escritorio_cep";
                sql += " ,escritorio_endereco";
                sql += " ,escritorio_numero";
                sql += " ,escritorio_complemento";
                sql += " ,escritorio_bairro";
                sql += " ,escritorio_telefone";
                sql += " ,escritorio_logoMarca";
                sql += " ,escritorio_ativo";
                sql += " ,escritorio_status";
                sql += " ,escritorio_email";
                sql += " ,escritorio_chavePix";
                sql += " ,escritorio_latitude";
                sql += " ,escritorio_longitude";
                sql += " ,escritorio_dataCadastro)";
                sql += " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);

                CM.Parameters.Add(@"municipio_codigo", System.Data.OleDb.OleDbType.Numeric).Value = escritorio.municipio_codigo;
                CM.Parameters.Add(@"escritorio_cnpj", System.Data.OleDb.OleDbType.Numeric).Value = escritorio.escritorio_cnpj;
                CM.Parameters.Add(@"escritorio_razaoSocial", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_razaoSocial;
                CM.Parameters.Add(@"escritorio_nomeFantasia", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_nomeFantasia;
                CM.Parameters.Add(@"escritorio_inscricaoMunicipal", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_inscricaoMunicipal;
                CM.Parameters.Add(@"escritorio_inscricaoEstadual", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_inscricaoEstadual;
                CM.Parameters.Add(@"escritorio_cep", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_cep;
                CM.Parameters.Add(@"escritorio_endereco", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_endereco;
                CM.Parameters.Add(@"escritorio_numero", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_numero;
                CM.Parameters.Add(@"escritorio_complemento", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_complemento;
                CM.Parameters.Add(@"escritorio_bairro", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_bairro;
                CM.Parameters.Add(@"escritorio_telefone", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_telefone;
                CM.Parameters.Add(@"escritorio_logoMarca", System.Data.OleDb.OleDbType.LongVarChar).Value = escritorio.escritorio_logoMarca;
                CM.Parameters.Add(@"escritorio_ativo", System.Data.OleDb.OleDbType.Boolean).Value = escritorio.escritorio_ativo;
                CM.Parameters.Add(@"escritorio_status", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_status;
                CM.Parameters.Add(@"escritorio_email", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_email;
                CM.Parameters.Add(@"escritorio_chavePix", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_chavePix;
                CM.Parameters.Add(@"escritorio_latitude", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_latitude;
                CM.Parameters.Add(@"escritorio_longitude", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_longitude;
                CM.Parameters.Add(@"escritorio_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados do escritório no servidor.");

                escritorio.escritorio_logoMarca = null;

            }
            catch (Exception ex)
            {
                if (escritorio == null)
                    escritorio = new GUARDIAO_STRUCTS.DATABASE.Escritorio();
                escritorio.resultCode = -1;
                escritorio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Escritorio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return escritorio;
        }

        public GUARDIAO_STRUCTS.DATABASE.Escritorio UpdateEscritorio(GUARDIAO_STRUCTS.DATABASE.Escritorio escritorio)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblEscritorio SET";
                sql += " municipio_codigo = ?";
                sql += " ,escritorio_cnpj = ?";
                sql += " ,escritorio_razaoSocial = ?";
                sql += " ,escritorio_nomeFantasia = ?";
                sql += " ,escritorio_inscricaoMunicipal = ?";
                sql += " ,escritorio_inscricaoEstadual = ?";
                sql += " ,escritorio_cep = ?";
                sql += " ,escritorio_endereco = ?";
                sql += " ,escritorio_numero = ?";
                sql += " ,escritorio_complemento = ?";
                sql += " ,escritorio_bairro = ?";
                sql += " ,escritorio_telefone = ?";
                sql += " ,escritorio_logoMarca = ?";
                sql += " ,escritorio_ativo = ?";
                sql += " ,escritorio_status = ?";
                sql += " ,escritorio_email = ?";
                sql += " ,escritorio_chavePix = ?";
                sql += " ,escritorio_latitude = ?";
                sql += " ,escritorio_longitude = ?";
                sql += " ,escritorio_dataCadastro = ?";
                sql += " WHERE escritorio_id = " + escritorio.escritorio_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);

                CM.Parameters.Add(@"municipio_codigo", System.Data.OleDb.OleDbType.Numeric).Value = escritorio.municipio_codigo;
                CM.Parameters.Add(@"escritorio_cnpj", System.Data.OleDb.OleDbType.Numeric).Value = escritorio.escritorio_cnpj;
                CM.Parameters.Add(@"escritorio_razaoSocial", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_razaoSocial;
                CM.Parameters.Add(@"escritorio_nomeFantasia", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_nomeFantasia;
                CM.Parameters.Add(@"escritorio_inscricaoMunicipal", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_inscricaoMunicipal;
                CM.Parameters.Add(@"escritorio_inscricaoEstadual", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_inscricaoEstadual;
                CM.Parameters.Add(@"escritorio_cep", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_cep;
                CM.Parameters.Add(@"escritorio_endereco", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_endereco;
                CM.Parameters.Add(@"escritorio_numero", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_numero;
                CM.Parameters.Add(@"escritorio_complemento", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_complemento;
                CM.Parameters.Add(@"escritorio_bairro", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_bairro;
                CM.Parameters.Add(@"escritorio_telefone", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_telefone;
                CM.Parameters.Add(@"escritorio_logoMarca", System.Data.OleDb.OleDbType.LongVarChar).Value = escritorio.escritorio_logoMarca;
                CM.Parameters.Add(@"escritorio_ativo", System.Data.OleDb.OleDbType.Boolean).Value = escritorio.escritorio_ativo;
                CM.Parameters.Add(@"escritorio_status", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_status;
                CM.Parameters.Add(@"escritorio_email", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_email;
                CM.Parameters.Add(@"escritorio_chavePix", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_chavePix;
                CM.Parameters.Add(@"escritorio_latitude", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_latitude;
                CM.Parameters.Add(@"escritorio_longitude", System.Data.OleDb.OleDbType.VarChar).Value = escritorio.escritorio_longitude;
                CM.Parameters.Add(@"escritorio_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao atualizar dados do escritório no servidor.");

                escritorio.escritorio_logoMarca = null;

            }
            catch (Exception ex)
            {
                if (escritorio == null)
                    escritorio = new GUARDIAO_STRUCTS.DATABASE.Escritorio();
                escritorio.resultCode = -1;
                escritorio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Escritorio).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return escritorio;
        }

        public GUARDIAO_STRUCTS.DATABASE.Escritorio GetEscritorioByID(long escritorio_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Escritorio escritorio = null;
            try
            {
                sql = "SELECT escritorio_id";
                sql += " ,tblMunicipio.municipio_codigo";
                sql += " ,tblMunicipio.municipio_uf";
                sql += " ,tblMunicipio.municipio_nome";
                sql += " ,escritorio_cnpj";
                sql += " ,escritorio_razaoSocial";
                sql += " ,escritorio_nomeFantasia";
                sql += " ,escritorio_inscricaoMunicipal";
                sql += " ,escritorio_inscricaoEstadual";
                sql += " ,escritorio_cep";
                sql += " ,escritorio_endereco";
                sql += " ,escritorio_numero";
                sql += " ,escritorio_complemento";
                sql += " ,escritorio_bairro";
                sql += " ,escritorio_telefone";
                sql += " ,escritorio_logoMarca";
                sql += " ,escritorio_ativo";
                sql += " ,escritorio_status";
                sql += " ,escritorio_chavePix";
                sql += " ,escritorio_latitude";
                sql += " ,escritorio_longitude";
                sql += " ,escritorio_email";
                sql += " ,escritorio_dataCadastro";
                sql += " FROM tblEscritorio";
                sql += " INNER JOIN tblMunicipio ON tblMunicipio.municipio_codigo = tblEscritorio.municipio_codigo";
                sql += " WHERE escritorio_id = " + escritorio_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum escritório encontrado para o parâmetro informado.");

                escritorio = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Escritorio>();

            }
            catch (Exception ex)
            {
                if (escritorio == null)
                    escritorio = new GUARDIAO_STRUCTS.DATABASE.Escritorio();
                escritorio.resultCode = -1;
                escritorio.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Escritorio).Namespace);
            }
            return escritorio;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.Escritorio> GetAllEscritorios()
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.Escritorio> escritorios = null;
            try
            {
                sql = "SELECT escritorio_id";
                sql += " ,tblMunicipio.municipio_codigo";
                sql += " ,tblMunicipio.municipio_uf";
                sql += " ,tblMunicipio.municipio_nome";
                sql += " ,escritorio_cnpj";
                sql += " ,escritorio_razaoSocial";
                sql += " ,escritorio_nomeFantasia";
                sql += " ,escritorio_inscricaoMunicipal";
                sql += " ,escritorio_inscricaoEstadual";
                sql += " ,escritorio_cep";
                sql += " ,escritorio_endereco";
                sql += " ,escritorio_numero";
                sql += " ,escritorio_complemento";
                sql += " ,escritorio_bairro";
                sql += " ,escritorio_telefone";
                sql += " ,escritorio_logoMarca";
                sql += " ,escritorio_ativo";
                sql += " ,escritorio_status";
                sql += " ,escritorio_email";
                sql += " ,escritorio_chavePix";
                sql += " ,escritorio_latitude";
                sql += " ,escritorio_longitude";
                sql += " ,escritorio_dataCadastro";
                sql += " FROM tblEscritorio";
                sql += " INNER JOIN tblMunicipio ON tblMunicipio.municipio_codigo = tblEscritorio.municipio_codigo";
                sql += " ORDER BY escritorio_razaoSocial";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum escritório encontrado para o parâmetro informado.");

                escritorios = new List<GUARDIAO_STRUCTS.DATABASE.Escritorio>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    escritorios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Escritorio>());
                }


            }
            catch (Exception ex)
            {
                escritorios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Escritorio).Namespace);
            }
            return escritorios;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.Escritorio> GetAllEscritoriosAtivos()
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.Escritorio> escritorios = null;
            try
            {
                sql = "SELECT escritorio_id";
                sql += " ,municipio_codigo";
                sql += " ,escritorio_cnpj";
                sql += " ,escritorio_razaoSocial";
                sql += " ,escritorio_nomeFantasia";
                sql += " ,escritorio_inscricaoMunicipal";
                sql += " ,escritorio_inscricaoEstadual";
                sql += " ,escritorio_cep";
                sql += " ,escritorio_endereco";
                sql += " ,escritorio_numero";
                sql += " ,escritorio_complemento";
                sql += " ,escritorio_bairro";
                sql += " ,escritorio_telefone";
                sql += " ,escritorio_logoMarca";
                sql += " ,escritorio_ativo";
                sql += " ,escritorio_status";
                sql += " ,escritorio_email";
                sql += " ,escritorio_chavePix";
                sql += " ,escritorio_latitude";
                sql += " ,escritorio_longitude";
                sql += " ,escritorio_dataCadastro";
                sql += " FROM tblEscritorio";
                sql += " WHERE escritorio_ativo = 1";
                sql += " ORDER BY escritorio_razaoSocial";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum escritório encontrado para o parâmetro informado.");

                escritorios = new List<GUARDIAO_STRUCTS.DATABASE.Escritorio>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    escritorios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Escritorio>());
                }


            }
            catch (Exception ex)
            {
                escritorios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Escritorio).Namespace);
            }
            return escritorios;
        }
    }
}
