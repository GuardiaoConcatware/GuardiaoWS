// crud crudUsuarios
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class CrudUsuarios : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.Pix InsertChavePix(GUARDIAO_STRUCTS.DATABASE.Pix pix)
        {
            string sql = "";
            long reg = 0;
            try
            {
                sql = "UPDATE tblUsuario SET";
                sql += " usuario_chavePIX = ?";
                sql += " WHERE usuario_id = " + pix.usuario_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_chavePIX", System.Data.OleDb.OleDbType.VarChar, 250).Value = pix.usuario_chavePIX;

                reg = Convert.ToInt64(CM.ExecuteNonQuery());
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO ATUALIZAR DADOS DO USUÁRIO NO SERVIDOR.");


            }
            catch (Exception ex)
            {
                if (pix == null)
                    pix = new GUARDIAO_STRUCTS.DATABASE.Pix();
                pix.resultCode = -1;
                pix.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return pix;
        }

        public GUARDIAO_STRUCTS.DATABASE.AlterarSenha AleterarSenha(GUARDIAO_STRUCTS.DATABASE.AlterarSenha senha)
        {
            string sql = "";
            long reg = 0;
            try
            {
                sql = "UPDATE tblUsuario SET";
                sql += " usuario_senha = ?";
                sql += " WHERE usuario_id = " + senha.usuario_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_senha", System.Data.OleDb.OleDbType.VarChar, 250).Value = senha.usuario_senha;

                reg = Convert.ToInt64(CM.ExecuteNonQuery());
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO ATUALIZAR DADOS DO USUÁRIO NO SERVIDOR.");


            }
            catch (Exception ex)
            {
                if (senha == null)
                    senha = new GUARDIAO_STRUCTS.DATABASE.AlterarSenha();
                senha.resultCode = -1;
                senha.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return senha;
        }

        public GUARDIAO_STRUCTS.DATABASE.AdvogadoCliente InsertAdvogadoCliente(GUARDIAO_STRUCTS.DATABASE.AdvogadoCliente advogadoCliente)
        {
            string sql = "";
            long reg = 0;
            try
            {
                sql = "UPDATE tblUsuario SET";
                sql += " especieUsuario_id = ?";
                sql += " , usuario_nome = ?";
                sql += " , usuario_cpf = ?";
                sql += " , usuario_endereco = ?";
                sql += " , usuario_oab = ?";
                sql += " , usuario_bairro = ?";
                sql += " , usuario_cep = ?";
                sql += " , municipio_nome = ?";
                sql += " , usuario_email = ?";
                sql += " , usuario_foto = ?";
                sql += " , usuario_ativo = ?";
                sql += " , usuario_dataCadastro = ?";
                sql += " , customer_id = ?";
                sql += " WHERE usuario_id = " + advogadoCliente.usuario_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"especieUsuario_id", System.Data.OleDb.OleDbType.Numeric, 18).Value = advogadoCliente.especieUsuario_id;
                CM.Parameters.Add(@"usuario_nome", System.Data.OleDb.OleDbType.VarChar, 250).Value = advogadoCliente.usuario_nome;
                CM.Parameters.Add(@"usuario_cpf", System.Data.OleDb.OleDbType.Numeric, 18).Value = advogadoCliente.usuario_cpf;
                CM.Parameters.Add(@"usuario_endereco", System.Data.OleDb.OleDbType.VarChar, 250).Value = advogadoCliente.usuario_endereco;
                CM.Parameters.Add(@"usuario_oab", System.Data.OleDb.OleDbType.VarChar, 250).Value = advogadoCliente.usuario_oab;
                CM.Parameters.Add(@"usuario_bairro", System.Data.OleDb.OleDbType.VarChar, 50).Value = advogadoCliente.usuario_bairro;
                CM.Parameters.Add(@"usuario_cep", System.Data.OleDb.OleDbType.VarChar, 50).Value = advogadoCliente.usuario_cep;
                CM.Parameters.Add(@"municipio_nome", System.Data.OleDb.OleDbType.VarChar, 50).Value = advogadoCliente.municipio_nome;
                CM.Parameters.Add(@"usuario_email", System.Data.OleDb.OleDbType.VarChar, 250).Value = advogadoCliente.usuario_email;
                CM.Parameters.Add(@"usuario_foto", System.Data.OleDb.OleDbType.LongVarChar).Value = advogadoCliente.usuario_foto;
                CM.Parameters.Add(@"usuario_ativo", System.Data.OleDb.OleDbType.Boolean).Value = advogadoCliente.usuario_ativo;
                CM.Parameters.Add(@"usuario_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                CM.Parameters.Add(@"customer_id", System.Data.OleDb.OleDbType.LongVarChar).Value = advogadoCliente.customer_id;


                reg = Convert.ToInt64(CM.ExecuteNonQuery());
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO ATUALIZAR DADOS DO USUÁRIO NO SERVIDOR.");


            }
            catch (Exception ex)
            {
                if (advogadoCliente == null)
                    advogadoCliente = new GUARDIAO_STRUCTS.DATABASE.AdvogadoCliente();
                advogadoCliente.resultCode = -1;
                advogadoCliente.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return advogadoCliente;
        }

        public GUARDIAO_STRUCTS.DATABASE.CustomerId InsertCustomerId(GUARDIAO_STRUCTS.DATABASE.CustomerId customer_id)
        {
            string sql = "";
            long reg = 0;
            try
            {
                sql = "UPDATE tblUsuario SET";
                sql += " customer_id = ?";
                sql += " WHERE usuario_id = " + customer_id.usuario_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"customer_id", System.Data.OleDb.OleDbType.LongVarChar).Value = customer_id.customer_id;


                reg = Convert.ToInt64(CM.ExecuteNonQuery());
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO ATUALIZAR DADOS DO USUÁRIO NO SERVIDOR.");


            }
            catch (Exception ex)
            {
                if (customer_id == null)
                    customer_id = new GUARDIAO_STRUCTS.DATABASE.CustomerId();
                //customer_id.resultCode = -1;
                customer_id.code = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return customer_id;
        }
    }
}
