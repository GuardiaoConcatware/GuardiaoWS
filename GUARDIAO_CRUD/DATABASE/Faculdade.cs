using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class Faculdade : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.Faculdade InsertNewFaculdade(GUARDIAO_STRUCTS.DATABASE.Faculdade faculdade)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblFaculdade";
                sql += " (municipio_codigo";
                sql += " ,faculdade_cnpj";
                sql += " ,faculdade_razaoSocial";
                sql += " ,faculdade_nomeFantasia";
                sql += " ,faculdade_inscricaoMunicipal";
                sql += " ,faculdade_inscricaoEstadual";
                sql += " ,faculdade_cep";
                sql += " ,faculdade_endereco";
                sql += " ,faculdade_numero";
                sql += " ,faculdade_complemento";
                sql += " ,faculdade_bairro";
                sql += " ,faculdade_telefone";
                sql += " ,faculdade_logoMarca";
                sql += " ,faculdade_ativo";
                sql += " ,faculdade_status";
                sql += " ,faculdade_email";
                sql += " ,faculdade_dataCadastro)";
                sql += " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"municipio_codigo", System.Data.OleDb.OleDbType.Numeric).Value = faculdade.municipio_codigo;
                CM.Parameters.Add(@"faculdade_cnpj", System.Data.OleDb.OleDbType.Numeric).Value = faculdade.faculdade_cnpj;
                CM.Parameters.Add(@"faculdade_razaoSocial", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_razaoSocial;
                CM.Parameters.Add(@"faculdade_nomeFantasia", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_nomeFantasia;
                CM.Parameters.Add(@"faculdade_inscricaoMunicipal", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_inscricaoMunicipal;
                CM.Parameters.Add(@"faculdade_inscricaoEstadual", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_inscricaoEstadual;
                CM.Parameters.Add(@"faculdade_cep", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_cep;
                CM.Parameters.Add(@"faculdade_endereco", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_endereco;
                CM.Parameters.Add(@"faculdade_numero", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_numero;
                CM.Parameters.Add(@"faculdade_complemento", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_complemento;
                CM.Parameters.Add(@"faculdade_bairro", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_bairro;
                CM.Parameters.Add(@"faculdade_telefone", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_telefone;
                CM.Parameters.Add(@"faculdade_logoMarca", System.Data.OleDb.OleDbType.LongVarChar).Value = faculdade.faculdade_logoMarca;
                CM.Parameters.Add(@"faculdade_ativo", System.Data.OleDb.OleDbType.Boolean).Value = faculdade.faculdade_ativo;
                CM.Parameters.Add(@"faculdade_status", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_status;
                CM.Parameters.Add(@"faculdade_email", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_email;
                CM.Parameters.Add(@"faculdade_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar faculdade no servidor.");

            }
            catch (Exception ex)
            {
                if (faculdade == null)
                    faculdade = new GUARDIAO_STRUCTS.DATABASE.Faculdade();
                faculdade.resultCode = -1;
                faculdade.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Faculdade).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return faculdade;
        }

        public GUARDIAO_STRUCTS.DATABASE.Faculdade UpdateFaculdade(GUARDIAO_STRUCTS.DATABASE.Faculdade faculdade)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblFaculdade SET";
                sql += " municipio_codigo = ?";
                sql += " ,faculdade_cnpj = ?";
                sql += " ,faculdade_razaoSocial = ?";
                sql += " ,faculdade_nomeFantasia = ?";
                sql += " ,faculdade_inscricaoMunicipal = ?";
                sql += " ,faculdade_inscricaoEstadual = ?";
                sql += " ,faculdade_cep = ?";
                sql += " ,faculdade_endereco = ?";
                sql += " ,faculdade_numero = ?";
                sql += " ,faculdade_complemento = ?";
                sql += " ,faculdade_bairro = ?";
                sql += " ,faculdade_telefone = ?";
                sql += " ,faculdade_logoMarca = ?";
                sql += " ,faculdade_ativo = ?";
                sql += " ,faculdade_status = ?";
                sql += " ,faculdade_email = ?";
                sql += " ,faculdade_dataCadastro = ?";
                sql += " WHERE faculdade_id = " + faculdade.faculdade_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"municipio_codigo", System.Data.OleDb.OleDbType.Numeric).Value = faculdade.municipio_codigo;
                CM.Parameters.Add(@"faculdade_cnpj", System.Data.OleDb.OleDbType.Numeric).Value = faculdade.faculdade_cnpj;
                CM.Parameters.Add(@"faculdade_razaoSocial", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_razaoSocial;
                CM.Parameters.Add(@"faculdade_nomeFantasia", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_nomeFantasia;
                CM.Parameters.Add(@"faculdade_inscricaoMunicipal", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_inscricaoMunicipal;
                CM.Parameters.Add(@"faculdade_inscricaoEstadual", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_inscricaoEstadual;
                CM.Parameters.Add(@"faculdade_cep", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_cep;
                CM.Parameters.Add(@"faculdade_endereco", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_endereco;
                CM.Parameters.Add(@"faculdade_numero", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_numero;
                CM.Parameters.Add(@"faculdade_complemento", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_complemento;
                CM.Parameters.Add(@"faculdade_bairro", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_bairro;
                CM.Parameters.Add(@"faculdade_telefone", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_telefone;
                CM.Parameters.Add(@"faculdade_logoMarca", System.Data.OleDb.OleDbType.LongVarChar).Value = faculdade.faculdade_logoMarca;
                CM.Parameters.Add(@"faculdade_ativo", System.Data.OleDb.OleDbType.Boolean).Value = faculdade.faculdade_ativo;
                CM.Parameters.Add(@"faculdade_status", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_status;
                CM.Parameters.Add(@"faculdade_email", System.Data.OleDb.OleDbType.VarChar).Value = faculdade.faculdade_email;
                CM.Parameters.Add(@"faculdade_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao atualizar faculdade no servidor.");

            }
            catch (Exception ex)
            {
                if (faculdade == null)
                    faculdade = new GUARDIAO_STRUCTS.DATABASE.Faculdade();
                faculdade.resultCode = -1;
                faculdade.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Faculdade).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return faculdade;
        }

        public GUARDIAO_STRUCTS.DATABASE.Faculdade GetFaculdadeByID(long faculdade_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Faculdade faculdade = null;
            try
            {
                sql = "SELECT faculdade_id";
                sql += " ,tblMunicipio.municipio_codigo";
                sql += " ,tblMunicipio.municipio_uf";
                sql += " ,tblMunicipio.municipio_nome";
                sql += " ,faculdade_cnpj";
                sql += " ,faculdade_razaoSocial";
                sql += " ,faculdade_nomeFantasia";
                sql += " ,faculdade_inscricaoMunicipal";
                sql += " ,faculdade_inscricaoEstadual";
                sql += " ,faculdade_cep";
                sql += " ,faculdade_endereco";
                sql += " ,faculdade_numero";
                sql += " ,faculdade_complemento";
                sql += " ,faculdade_bairro";
                sql += " ,faculdade_telefone";
                sql += " ,faculdade_logoMarca";
                sql += " ,faculdade_ativo";
                sql += " ,faculdade_status";
                sql += " ,faculdade_email";
                sql += " ,faculdade_dataCadastro";
                sql += " FROM tblFaculdade";
                sql += " INNER JOIN tblMunicipio ON tblMunicipio.municipio_codigo = tblFaculdade.municipio_codigo";
                sql += " WHERE faculdade_id = " + faculdade_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum faculdade encontrada para o parâmetro informado.");

                faculdade = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Faculdade>();

            }
            catch (Exception ex)
            {
                if (faculdade == null)
                    faculdade = new GUARDIAO_STRUCTS.DATABASE.Faculdade();
                faculdade.resultCode = -1;
                faculdade.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Faculdade).Namespace);
            }

            return faculdade;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.Faculdade> GetAllFaculdades()
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.Faculdade> faculdades = null;
            try
            {
                sql = "SELECT faculdade_id";
                sql += " ,municipio_codigo";
                sql += " ,faculdade_cnpj";
                sql += " ,faculdade_razaoSocial";
                sql += " ,faculdade_nomeFantasia";
                sql += " ,faculdade_inscricaoMunicipal";
                sql += " ,faculdade_inscricaoEstadual";
                sql += " ,faculdade_cep";
                sql += " ,faculdade_endereco";
                sql += " ,faculdade_numero";
                sql += " ,faculdade_complemento";
                sql += " ,faculdade_bairro";
                sql += " ,faculdade_telefone";
                sql += " ,faculdade_logoMarca";
                sql += " ,faculdade_ativo";
                sql += " ,faculdade_status";
                sql += " ,faculdade_email";
                sql += " ,faculdade_dataCadastro";
                sql += " FROM tblFaculdade";
                sql += " ORDER BY faculdade_razaoSocial";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum faculdade encontrada para o parâmetro informado.");

                faculdades = new List<GUARDIAO_STRUCTS.DATABASE.Faculdade>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    faculdades.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Faculdade>());
                }

            }
            catch (Exception ex)
            {
                faculdades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Faculdade).Namespace);
            }

            return faculdades;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.Faculdade> GetAllFaculdadesAtivas()
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.Faculdade> faculdades = null;
            try
            {
                sql = "SELECT faculdade_id";
                sql += " ,municipio_codigo";
                sql += " ,faculdade_cnpj";
                sql += " ,faculdade_razaoSocial";
                sql += " ,faculdade_nomeFantasia";
                sql += " ,faculdade_inscricaoMunicipal";
                sql += " ,faculdade_inscricaoEstadual";
                sql += " ,faculdade_cep";
                sql += " ,faculdade_endereco";
                sql += " ,faculdade_numero";
                sql += " ,faculdade_complemento";
                sql += " ,faculdade_bairro";
                sql += " ,faculdade_telefone";
                sql += " ,faculdade_logoMarca";
                sql += " ,faculdade_ativo";
                sql += " ,faculdade_status";
                sql += " ,faculdade_email";
                sql += " ,faculdade_dataCadastro";
                sql += " FROM tblFaculdade";
                sql += " WHERE faculdade_ativo = 1";
                sql += " ORDER BY faculdade_razaoSocial";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum faculdade encontrada para o parâmetro informado.");

                faculdades = new List<GUARDIAO_STRUCTS.DATABASE.Faculdade>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    faculdades.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Faculdade>());
                }

            }
            catch (Exception ex)
            {
                faculdades = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Faculdade).Namespace);
            }

            return faculdades;
        }
    }
}



