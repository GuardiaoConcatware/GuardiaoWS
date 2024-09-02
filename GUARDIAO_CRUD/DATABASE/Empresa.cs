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
    public class Empresa : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.Empresa InsertNewEmpresa(GUARDIAO_STRUCTS.DATABASE.Empresa empresa)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblEmpresa";
                sql += " (municipio_codigo";
                sql += " ,empresa_cnpj";
                sql += " ,empresa_razaoSocial";
                sql += " ,empresa_nomeFantasia";
                sql += " ,empresa_inscricaoMunicipal";
                sql += " ,empresa_inscricaoEstadual";
                sql += " ,empresa_cep";
                sql += " ,empresa_endereco";
                sql += " ,empresa_numero";
                sql += " ,empresa_complemento";
                sql += " ,empresa_bairro";
                sql += " ,empresa_telefone";
                sql += " ,empresa_logoMarca";
                sql += " ,empresa_ativo";
                sql += " ,empresa_status";
                sql += " ,empresa_email";
                sql += " ,empresa_dataCadastro)";
                sql += " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"municipio_codigo", System.Data.OleDb.OleDbType.Numeric).Value = empresa.municipio_codigo;
                CM.Parameters.Add(@"empresa_cnpj", System.Data.OleDb.OleDbType.Numeric).Value = empresa.empresa_cnpj;
                CM.Parameters.Add(@"empresa_razaoSocial", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_razaoSocial;
                CM.Parameters.Add(@"empresa_nomeFantasia", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_nomeFantasia;
                CM.Parameters.Add(@"empresa_inscricaoMunicipal", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_inscricaoMunicipal;
                CM.Parameters.Add(@"empresa_inscricaoEstadual", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_inscricaoEstadual;
                CM.Parameters.Add(@"empresa_cep", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_cep;
                CM.Parameters.Add(@"empresa_endereco", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_endereco;
                CM.Parameters.Add(@"empresa_numero", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_numero;
                CM.Parameters.Add(@"empresa_complemento", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_complemento;
                CM.Parameters.Add(@"empresa_bairro", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_bairro;
                CM.Parameters.Add(@"empresa_telefone", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_telefone;
                CM.Parameters.Add(@"empresa_logoMarca", System.Data.OleDb.OleDbType.LongVarChar).Value = empresa.empresa_logoMarca;
                CM.Parameters.Add(@"empresa_ativo", System.Data.OleDb.OleDbType.Boolean).Value = empresa.empresa_ativo;
                CM.Parameters.Add(@"empresa_status", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_status;
                CM.Parameters.Add(@"empresa_email", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_email;
                CM.Parameters.Add(@"empresa_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");

                empresa.empresa_logoMarca = "";
            }
            catch (Exception ex)
            {
                if (empresa == null)
                    empresa = new GUARDIAO_STRUCTS.DATABASE.Empresa();
                empresa.resultCode = -1;
                empresa.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Empresa).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return empresa;
        }

        public GUARDIAO_STRUCTS.DATABASE.Empresa UpdateEmpresa(GUARDIAO_STRUCTS.DATABASE.Empresa empresa)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "UPDATE tblEmpresa SET";
                sql += " municipio_codigo = ?";
                sql += " ,empresa_cnpj = ?";
                sql += " ,empresa_razaoSocial = ?";
                sql += " ,empresa_nomeFantasia = ?";
                sql += " ,empresa_inscricaoMunicipal = ?";
                sql += " ,empresa_inscricaoEstadual = ?";
                sql += " ,empresa_cep = ?";
                sql += " ,empresa_endereco = ?";
                sql += " ,empresa_numero = ?";
                sql += " ,empresa_complemento = ?";
                sql += " ,empresa_bairro = ?";
                sql += " ,empresa_telefone = ?";
                sql += " ,empresa_logoMarca = ?";
                sql += " ,empresa_ativo = ?";
                sql += " ,empresa_status = ?";
                sql += " ,empresa_email = ?";
                sql += " ,empresa_dataCadastro = ?";
                sql += " WHERE empresa_id = " + empresa.empresa_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"municipio_codigo", System.Data.OleDb.OleDbType.Numeric).Value = empresa.municipio_codigo;
                CM.Parameters.Add(@"empresa_cnpj", System.Data.OleDb.OleDbType.Numeric).Value = empresa.empresa_cnpj;
                CM.Parameters.Add(@"empresa_razaoSocial", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_razaoSocial;
                CM.Parameters.Add(@"empresa_nomeFantasia", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_nomeFantasia;
                CM.Parameters.Add(@"empresa_inscricaoMunicipal", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_inscricaoMunicipal;
                CM.Parameters.Add(@"empresa_inscricaoEstadual", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_inscricaoEstadual;
                CM.Parameters.Add(@"empresa_cep", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_cep;
                CM.Parameters.Add(@"empresa_endereco", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_endereco;
                CM.Parameters.Add(@"empresa_numero", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_numero;
                CM.Parameters.Add(@"empresa_complemento", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_complemento;
                CM.Parameters.Add(@"empresa_bairro", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_bairro;
                CM.Parameters.Add(@"empresa_telefone", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_telefone;
                CM.Parameters.Add(@"empresa_logoMarca", System.Data.OleDb.OleDbType.LongVarChar).Value = empresa.empresa_logoMarca;
                CM.Parameters.Add(@"empresa_ativo", System.Data.OleDb.OleDbType.Boolean).Value = empresa.empresa_ativo;
                CM.Parameters.Add(@"empresa_status", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_status;
                CM.Parameters.Add(@"empresa_email", System.Data.OleDb.OleDbType.VarChar).Value = empresa.empresa_email;
                CM.Parameters.Add(@"empresa_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar dados da empresa no servidor.");

                empresa.empresa_logoMarca = "";
            }
            catch (Exception ex)
            {
                if (empresa == null)
                    empresa = new GUARDIAO_STRUCTS.DATABASE.Empresa();
                empresa.resultCode = -1;
                empresa.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Empresa).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return empresa;
        }

        public GUARDIAO_STRUCTS.DATABASE.Empresa GetEmpresaByID(long empresa_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Empresa empresa = null;
            try
            {
                sql = "SELECT empresa_id";
                sql += " ,tblMunicipio.municipio_codigo";
                sql += " ,tblMunicipio.municipio_uf";
                sql += " ,tblMunicipio.municipio_nome";
                sql += " ,empresa_cnpj";
                sql += " ,empresa_razaoSocial";
                sql += " ,empresa_nomeFantasia";
                sql += " ,empresa_inscricaoMunicipal";
                sql += " ,empresa_inscricaoEstadual";
                sql += " ,empresa_cep";
                sql += " ,empresa_endereco";
                sql += " ,empresa_numero";
                sql += " ,empresa_complemento";
                sql += " ,empresa_bairro";
                sql += " ,empresa_telefone";
                sql += " ,empresa_logoMarca";
                sql += " ,empresa_ativo";
                sql += " ,empresa_status";
                sql += " ,empresa_email";
                sql += " ,empresa_dataCadastro";
                sql += " FROM tblEmpresa";
                sql += " INNER JOIN tblMunicipio ON tblMunicipio.municipio_codigo = tblEmpresa.municipio_codigo";
                sql += " WHERE empresa_id = " + empresa_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                empresa = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Empresa>();
            }
            catch (Exception ex)
            {
                if (empresa == null)
                    empresa = new GUARDIAO_STRUCTS.DATABASE.Empresa();
                empresa.resultCode = -1;
                empresa.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Empresa).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return empresa;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.Empresa> GetAllEmpresa()
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.Empresa> empresas = null;
            try
            {
                sql = "SELECT empresa_id";
                sql += " ,municipio_codigo";
                sql += " ,empresa_cnpj";
                sql += " ,empresa_razaoSocial";
                sql += " ,empresa_nomeFantasia";
                sql += " ,empresa_inscricaoMunicipal";
                sql += " ,empresa_inscricaoEstadual";
                sql += " ,empresa_cep";
                sql += " ,empresa_endereco";
                sql += " ,empresa_numero";
                sql += " ,empresa_complemento";
                sql += " ,empresa_bairro";
                sql += " ,empresa_telefone";
                sql += " ,empresa_logoMarca";
                sql += " ,empresa_ativo";
                sql += " ,empresa_status";
                sql += " ,empresa_email";
                sql += " ,empresa_dataCadastro";
                sql += " FROM tblEmpresa";
                sql += " ORDER BY empresa_razaoSocial";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                empresas = new List<GUARDIAO_STRUCTS.DATABASE.Empresa>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    empresas.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Empresa>());
                }


            }
            catch (Exception ex)
            {
                empresas = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Empresa).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return empresas;
        }

    }
}