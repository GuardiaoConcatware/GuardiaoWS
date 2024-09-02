using GUARDIAO_COMMOM;

using System;
using System.Collections.Generic;
using System.Data;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{

    /*
     1 - EMPRESA
    2 - ESCRITORIO
    3 -FACULDADE
    4 - ADVOGADO
    5 - CLIENTE
     */
    public class Usuario : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.Usuario InsertUsuario(GUARDIAO_STRUCTS.DATABASE.Usuario usuario)
        {
            string sql = "";
            long usuario_id = 0;
            try
            {
                if (VerificaEmailInUse(usuario.usuario_email))
                    throw new Exception("O Email informada ja encontra-se cadastrado.");


                sql = "INSERT INTO tblUsuario";
                sql += " (empresa_id";
                sql += " ,grupoUsuario_id";
                sql += " ,tipoUsuario_id";
                sql += " ,especieUsuario_id";
                sql += " ,municipio_codigo";
                sql += " ,usuario_cpf";
                sql += " ,usuario_nome";
                sql += " ,usuario_email";
                sql += " ,usuario_oab";
                sql += " ,usuario_telefone";
                sql += " ,usuario_endereco";
                sql += " ,usuario_numero";
                sql += " ,usuario_bairro";
                sql += " ,usuario_cep";
                sql += " ,usuario_rg";
                sql += " ,usuario_foto";
                sql += " ,usuario_senha";
                sql += " ,usuario_valorHora";
                sql += " ,usuario_dataAdmissao";
                sql += " ,usuario_dataDesligamento";
                sql += " ,usuario_ativo";
                sql += " ,usuario_chavePIX";
                sql += " ,usuario_latitude";
                sql += " ,usuario_longitude";
                sql += " ,usuario_dataCadastro)";
                sql += " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?);";
                sql += " SELECT @@IDENTITY AS 'IDENTITY';";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"empresa_id", System.Data.OleDb.OleDbType.Numeric).Value = usuario.empresa_id;
                CM.Parameters.Add(@"grupoUsuario_id", System.Data.OleDb.OleDbType.Numeric).Value = usuario.grupoUsuario_id;
                CM.Parameters.Add(@"tipoUsuario_id", System.Data.OleDb.OleDbType.Numeric).Value = usuario.tipoUsuario_id;
                CM.Parameters.Add(@"especieUsuario_id", System.Data.OleDb.OleDbType.Numeric).Value = usuario.especieUsuario_id;
                CM.Parameters.Add(@"municipio_codigo", System.Data.OleDb.OleDbType.VarChar).Value = usuario.municipio_codigo;
                CM.Parameters.Add(@"usuario_cpf", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_cpf;
                CM.Parameters.Add(@"usuario_nome", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_nome;
                CM.Parameters.Add(@"usuario_email", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_email;
                CM.Parameters.Add(@"usuario_oab", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_oab;
                CM.Parameters.Add(@"usuario_telefone", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_telefone;
                CM.Parameters.Add(@"usuario_endereco", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_endereco;
                CM.Parameters.Add(@"usuario_numero", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_numero;
                CM.Parameters.Add(@"usuario_bairro", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_bairro;
                CM.Parameters.Add(@"usuario_cep", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_cep;
                CM.Parameters.Add(@"usuario_rg", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_rg;
                CM.Parameters.Add(@"usuario_foto", System.Data.OleDb.OleDbType.LongVarChar).Value = usuario.usuario_foto;
                CM.Parameters.Add(@"usuario_senha", System.Data.OleDb.OleDbType.LongVarChar).Value = usuario.usuario_senha;
                CM.Parameters.Add(@"usuario_valorHora", System.Data.OleDb.OleDbType.Decimal).Value = usuario.usuario_valorHora;
                CM.Parameters.Add(@"usuario_dataAdmissao", System.Data.OleDb.OleDbType.Date).Value = usuario.usuario_dataAdmissao == "" ? null : Convert.ToDateTime(usuario.usuario_dataAdmissao).ToString("yyyy-MM-dd");
                CM.Parameters.Add(@"usuario_dataDesligamento", System.Data.OleDb.OleDbType.Date).Value = usuario.usuario_dataDesligamento == "" ? null : Convert.ToDateTime(usuario.usuario_dataDesligamento).ToString("yyyy-MM-dd");
                CM.Parameters.Add(@"usuario_ativo", System.Data.OleDb.OleDbType.Boolean).Value = usuario.usuario_ativo;
                CM.Parameters.Add(@"usuario_chavePIX", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_chavePIX;
                CM.Parameters.Add(@"usuario_latitude", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_latitude;
                CM.Parameters.Add(@"usuario_longitude", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_longitude;
                CM.Parameters.Add(@"usuario_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                usuario_id = Convert.ToInt64(CM.ExecuteScalar());
                if (usuario_id == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO SALVAR DADOS DO USUÁRIO NO SERVIDOR.");

                usuario.usuario_id = usuario_id;
                if (usuario.especieUsuario_id == 2 || usuario.especieUsuario_id == 4)
                    SalvarEspecialidadesUsuario(usuario.usuario_id, usuario.especialidadeUsuarios);
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return usuario;
        }

        public GUARDIAO_STRUCTS.DATABASE.Usuario UpdateUsuario(GUARDIAO_STRUCTS.DATABASE.Usuario usuario)
        {
            string sql = "";
            long reg = 0;
            try
            {
                sql = "UPDATE tblUsuario SET";
                sql += " empresa_id = ?";
                sql += " ,grupoUsuario_id = ?";
                sql += " ,tipoUsuario_id = ?";
                sql += " ,especieUsuario_id = ?";
                sql += " ,municipio_codigo = ?";
                sql += " ,usuario_cpf = ?";
                sql += " ,usuario_nome = ?";
                sql += " ,usuario_email = ?";
                sql += " ,usuario_oab = ?";
                sql += " ,usuario_telefone = ?";
                sql += " ,usuario_endereco = ?";
                sql += " ,usuario_numero = ?";
                sql += " ,usuario_bairro = ?";
                sql += " ,usuario_cep = ?";
                sql += " ,usuario_rg = ?";
                sql += " ,usuario_foto = ?";
                sql += " ,usuario_valorHora = ?";
                sql += " ,usuario_senha = ?";
                sql += " ,usuario_dataAdmissao = ?";
                sql += " ,usuario_dataDesligamento = ?";
                sql += " ,usuario_ativo = ?";
                sql += " ,usuario_chavePIX = ?";
                sql += " ,usuario_latitude = ?";
                sql += " ,usuario_longitude = ?";
                sql += " ,usuario_dataCadastro = ?";
                sql += " WHERE usuario_id = " + usuario.usuario_id;


                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"empresa_id", System.Data.OleDb.OleDbType.Numeric).Value = usuario.empresa_id;
                CM.Parameters.Add(@"grupoUsuario_id", System.Data.OleDb.OleDbType.Numeric).Value = usuario.grupoUsuario_id;
                CM.Parameters.Add(@"tipoUsuario_id", System.Data.OleDb.OleDbType.Numeric).Value = usuario.tipoUsuario_id;
                CM.Parameters.Add(@"especieUsuario_id", System.Data.OleDb.OleDbType.Numeric).Value = usuario.especieUsuario_id;
                CM.Parameters.Add(@"municipio_codigo", System.Data.OleDb.OleDbType.VarChar).Value = usuario.municipio_codigo;
                CM.Parameters.Add(@"usuario_cpf", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_cpf;
                CM.Parameters.Add(@"usuario_nome", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_nome;
                CM.Parameters.Add(@"usuario_email", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_email;
                CM.Parameters.Add(@"usuario_oab", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_oab;
                CM.Parameters.Add(@"usuario_telefone", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_telefone;
                CM.Parameters.Add(@"usuario_endereco", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_endereco;
                CM.Parameters.Add(@"usuario_numero", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_numero;
                CM.Parameters.Add(@"usuario_bairro", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_bairro;
                CM.Parameters.Add(@"usuario_cep", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_cep;
                CM.Parameters.Add(@"usuario_rg", System.Data.OleDb.OleDbType.LongVarChar).Value = usuario.usuario_rg;
                CM.Parameters.Add(@"usuario_foto", System.Data.OleDb.OleDbType.LongVarChar).Value = usuario.usuario_foto;
                CM.Parameters.Add(@"usuario_valorHora", System.Data.OleDb.OleDbType.Decimal).Value = usuario.usuario_valorHora;
                CM.Parameters.Add(@"usuario_senha", System.Data.OleDb.OleDbType.LongVarChar).Value = usuario.usuario_senha;
                CM.Parameters.Add(@"usuario_dataAdmissao", System.Data.OleDb.OleDbType.Date).Value = usuario.usuario_dataAdmissao == "" ? null : Convert.ToDateTime(usuario.usuario_dataAdmissao).ToString("yyyy-MM-dd");
                CM.Parameters.Add(@"usuario_dataDesligamento", System.Data.OleDb.OleDbType.Date).Value = usuario.usuario_dataDesligamento == "" ? null : Convert.ToDateTime(usuario.usuario_dataDesligamento).ToString("yyyy-MM-dd");
                CM.Parameters.Add(@"usuario_ativo", System.Data.OleDb.OleDbType.Boolean).Value = usuario.usuario_ativo;
                CM.Parameters.Add(@"usuario_chavePIX", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_chavePIX;
                CM.Parameters.Add(@"usuario_latitude", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_latitude;
                CM.Parameters.Add(@"usuario_longitude", System.Data.OleDb.OleDbType.VarChar).Value = usuario.usuario_longitude;
                CM.Parameters.Add(@"usuario_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = Convert.ToInt64(CM.ExecuteNonQuery());
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO ATUALIZAR DADOS DO USUÁRIO NO SERVIDOR.");

                if (usuario.especieUsuario_id == 2 || usuario.especieUsuario_id == 4)
                    SalvarEspecialidadesUsuario(usuario.usuario_id, usuario.especialidadeUsuarios);
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return usuario;
        }

        public GUARDIAO_STRUCTS.DATABASE.Usuario GetUsuarioById(long usuario_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                sql = "SELECT usuario_id";
                sql += " , empresa_id";
                sql += " , grupoUsuario_id";
                sql += " , tipoUsuario_id";
                sql += " , especieUsuario_id";
                sql += " , tblUsuario.municipio_codigo";
                sql += " , tblMunicipio.municipio_uf";
                sql += " , tblMunicipio.municipio_nome";
                sql += " , usuario_cpf";
                sql += " , usuario_nome";
                sql += " , usuario_email";
                sql += " , usuario_oab";
                sql += " , usuario_telefone";
                sql += " , usuario_endereco";
                sql += " , usuario_numero";
                sql += " , usuario_bairro";
                sql += " , usuario_cep";
                sql += " , usuario_rg";
                sql += " , usuario_foto";
                sql += " , usuario_valorHora";
                sql += " , usuario_senha";
                sql += " , CONVERT(CHAR(10),usuario_dataAdmissao,103) AS usuario_dataAdmissao";
                sql += " , CONVERT(CHAR(10),usuario_dataDesligamento,103) AS usuario_dataDesligamento";
                sql += " , usuario_ativo";
                sql += " , CONVERT(CHAR(10),usuario_dataCadastro,103) AS usuario_dataCadastro";
                sql += " , usuario_chavePIX";
                sql += " , usuario_latitude";
                sql += " , usuario_longitude";
                sql += " FROM tblUsuario";
                sql += " LEFT JOIN tblMunicipio ON tblMunicipio.municipio_codigo = tblUsuario.municipio_codigo";
                sql += " WHERE usuario_id = " + usuario_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("NENHUM USUÁRIO ENCONTRADO PARA OS PARÂMETROS INFORMADOS.");

                usuario = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Usuario>();
                if (usuario.especieUsuario_id == 2 || usuario.especieUsuario_id == 4)
                    usuario.especialidadeUsuarios = GetEspecialidadesByUsuarioID(usuario.usuario_id);


            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return usuario;
        }

        public GUARDIAO_STRUCTS.DATABASE.Usuario ValidarLoginUsuario(long usuario_cpf, string usuario_senha)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                sql = "SELECT tblUsuario.usuario_id";
                sql += " , tblUsuario.empresa_id";
                sql += " , tblUsuario.grupoUsuario_id";
                sql += " , tblUsuario.tipoUsuario_id";
                sql += " , tblUsuario.especieUsuario_id";
                sql += " , tblUsuario.municipio_codigo";
                sql += " , tblUsuario.municipio_nome";
                sql += " , tblUsuario.usuario_cpf";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblUsuario.usuario_email";
                sql += " , tblUsuario.usuario_oab";
                sql += " , tblUsuario.usuario_telefone";
                sql += " , tblUsuario.usuario_endereco";
                sql += " , tblUsuario.usuario_numero";
                sql += " , tblUsuario.usuario_bairro";
                sql += " , tblUsuario.usuario_cep";
                sql += " , tblUsuario.usuario_rg";
                sql += " , tblUsuario.usuario_foto";
                sql += " , tblUsuario.usuario_senha";
                sql += " , tblUsuario.usuario_valorHora";
                sql += " , tblUsuario.usuario_dataAdmissao";
                sql += " , tblUsuario.usuario_dataDesligamento";
                sql += " , tblUsuario.usuario_ativo";
                sql += " , tblUsuario.usuario_chavePIX";
                sql += " , tblUsuario.usuario_latitude";
                sql += " , tblUsuario.usuario_longitude";
                sql += " , tblUsuario.usuario_dataCadastro";
                sql += " , tblUsuario.customer_id";
                sql += " FROM tblUsuario";
                sql += " LEFT JOIN tblEmpresa ON tblEmpresa.empresa_id = tblUsuario.empresa_id";
                sql += " WHERE usuario_cpf = " + usuario_cpf;
                sql += " AND usuario_senha = '" + usuario_senha + "'";


                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("NENHUM USUÁRIO ENCONTRADO PARA OS PARÂMETROS INFORMADOS.");

                usuario = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Usuario>();
                if (!usuario.usuario_ativo)
                {
                    switch (usuario.especieUsuario_id)
                    {
                        case 1:
                        case 2:
                            throw new Exception("Usuário encontrado, mas encontra-se desativado.");
                        case 3:
                            throw new Exception("Usuário encontrado, mas encontra-se desativado.");
                        case 4:
                            throw new Exception("Usuário encontrado, mas encontra-se desativado ou em análise.");
                        case 5:
                            throw new Exception("Usuário encontrado, mas encontra-se desativado.");
                    }

                }

                GUARDIAO_CRUD.DATABASE.Municipio objMunicipio = new Municipio();
                GUARDIAO_STRUCTS.DATABASE.Municipio mun = objMunicipio.GetMunicipioByCodigo(usuario.municipio_codigo);
                if (mun != null)
                {
                    if (mun.resultCode == 0)
                    {
                        usuario.municipio_uf = mun.municipio_uf;
                        usuario.municipio_nome = mun.municipio_nome;
                    }
                }
                if (usuario.especieUsuario_id == 2 || usuario.especieUsuario_id == 4)
                    usuario.especialidadeUsuarios = GetEspecialidadesByUsuarioID(usuario.usuario_id);

                usuario.usuario_foto = Base64TOFile(usuario.usuario_foto);

            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return usuario;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados> GetAllUsuariosByEspecie(long empresa_id, long especieUsuario_id)
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados> usuarios = null;
            try
            {
                sql += "SELECT tblUsuario.usuario_id";
                switch (especieUsuario_id)
                {
                    case 1:
                        sql += " , tblEmpresa.empresa_razaoSocial";
                        sql += " , tblTipoUsuario.tipoUsuario_descricao";
                        break;
                    case 2:
                        sql += " , tblEmpresa.escritorio_razaoSocial AS empresa_razaoSocial";
                        sql += " , tblTipoUsuario.tipoUsuario_descricao";
                        break;
                    case 3:
                        sql += " , tblEmpresa.faculdade_razaoSocial AS empresa_razaoSocial";
                        sql += " , tblTipoUsuario.tipoUsuario_descricao";
                        break;
                    case 4:
                        sql += " , tblMunicipio.municipio_uf";
                        sql += " , tblMunicipio.municipio_nome";
                        break;
                }


                sql += " , tblUsuario.usuario_cpf";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblUsuario.usuario_telefone";
                sql += " , tblUsuario.usuario_email";
                sql += " , tblUsuario.usuario_oab";
                sql += " , tblUsuario.usuario_ativo";
                sql += " , tblUsuario.usuario_dataCadastro";
                sql += " , tblUsuario.usuario_chavePIX";
                sql += " , tblUsuario.usuario_latitude";
                sql += " , tblUsuario.usuario_longitude";
                sql += " , tblUsuario.usuario_valorHora";
                sql += " FROM tblUsuario ";

                switch (especieUsuario_id)
                {
                    case 1:
                        sql += " INNER JOIN tblEmpresa ON tblUsuario.empresa_id = tblEmpresa.empresa_id";
                        sql += " INNER JOIN tblTipoUsuario ON tblUsuario.tipoUsuario_id = tblTipoUsuario.tipoUsuario_id";
                        break;
                    case 2:
                        sql += " INNER JOIN tblEscritorio AS tblEmpresa ON tblUsuario.empresa_id = tblEmpresa.escritorio_id";
                        sql += " INNER JOIN tblTipoUsuario ON tblUsuario.tipoUsuario_id = tblTipoUsuario.tipoUsuario_id";
                        break;
                    case 3:
                        sql += " INNER JOIN tblFaculdade AS tblEmpresa ON tblUsuario.empresa_id = tblEmpresa.faculdade_id";
                        sql += " INNER JOIN tblTipoUsuario ON tblUsuario.tipoUsuario_id = tblTipoUsuario.tipoUsuario_id";
                        break;
                    case 4:
                        sql += " INNER JOIN tblMunicipio ON tblMunicipio.municipio_codigo = tblUsuario.municipio_codigo";
                        break;
                }


                sql += " WHERE tblUsuario.especieUsuario_id = " + especieUsuario_id;
                if (empresa_id != 0)

                    sql += " AND tblUsuario.empresa_id = " + empresa_id;
                sql += " ORDER BY tblUsuario.usuario_nome";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                usuarios = new List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    usuarios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados>());
                }


            }
            catch (Exception ex)
            {
                usuarios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return usuarios;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados> GetAllUsuariosByEspecieOnline(long empresa_id, long especieUsuario_id)
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados> usuarios = null;
            try
            {
                sql += "SELECT tblUsuario.usuario_id";
                switch (especieUsuario_id)
                {
                    case 1:
                        sql += " , tblEmpresa.empresa_razaoSocial";
                        sql += " , tblTipoUsuario.tipoUsuario_descricao";
                        break;
                    case 2:
                        sql += " , tblEmpresa.escritorio_razaoSocial AS empresa_razaoSocial";
                        sql += " , tblTipoUsuario.tipoUsuario_descricao";
                        break;
                    case 3:
                        sql += " , tblEmpresa.faculdade_razaoSocial AS empresa_razaoSocial";
                        sql += " , tblTipoUsuario.tipoUsuario_descricao";
                        break;
                    case 4:
                        sql += " , tblMunicipio.municipio_uf";
                        sql += " , tblMunicipio.municipio_nome";
                        break;
                }


                sql += " , tblUsuario.usuario_cpf";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblUsuario.usuario_telefone";
                sql += " , tblUsuario.usuario_email";
                sql += " , tblUsuario.usuario_oab";
                sql += " , tblUsuario.usuario_ativo";
                sql += " , tblUsuario.usuario_dataCadastro";
                sql += " , tblUsuario.usuario_chavePIX";
                sql += " , tblUsuario.usuario_latitude";
                sql += " , tblUsuario.usuario_longitude";
                sql += " , tblUsuario.usuario_valorHora";
                sql += " , tblUsuarioOnline.usuarioOnline_tipo";
                sql += " FROM tblUsuario ";

                switch (especieUsuario_id)
                {
                    case 1:
                        sql += " INNER JOIN tblEmpresa ON tblUsuario.empresa_id = tblEmpresa.empresa_id";
                        sql += " INNER JOIN tblTipoUsuario ON tblUsuario.tipoUsuario_id = tblTipoUsuario.tipoUsuario_id";
                        break;
                    case 2:
                        sql += " INNER JOIN tblEscritorio AS tblEmpresa ON tblUsuario.empresa_id = tblEmpresa.escritorio_id";
                        sql += " INNER JOIN tblTipoUsuario ON tblUsuario.tipoUsuario_id = tblTipoUsuario.tipoUsuario_id";
                        break;
                    case 3:
                        sql += " INNER JOIN tblFaculdade AS tblEmpresa ON tblUsuario.empresa_id = tblEmpresa.faculdade_id";
                        sql += " INNER JOIN tblTipoUsuario ON tblUsuario.tipoUsuario_id = tblTipoUsuario.tipoUsuario_id";
                        break;
                    case 4:
                        sql += " INNER JOIN tblMunicipio ON tblMunicipio.municipio_codigo = tblUsuario.municipio_codigo";
                        break;
                }
                sql += " INNER JOIN tblUsuarioOnline ON tblUsuarioOnline.usuario_id = tblUsuario.usuario_id";

                sql += " WHERE tblUsuario.especieUsuario_id = " + especieUsuario_id;
                if (empresa_id != 0)

                    sql += " AND tblUsuario.empresa_id = " + empresa_id;
                sql += " ORDER BY tblUsuario.usuario_nome";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                usuarios = new List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    usuarios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados>());
                }


            }
            catch (Exception ex)
            {
                usuarios = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return usuarios;
        }

        public GUARDIAO_STRUCTS.DATABASE.UsuarioMobile GetAllUsuariosByEspecieMobile(long empresa_id, long especieUsuario_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.UsuarioMobile usuarioMobile = null;

            try
            {
                sql += "SELECT tblUsuario.usuario_id";
                switch (especieUsuario_id)
                {
                    case 1:
                        sql += " , tblEmpresa.empresa_razaoSocial";
                        sql += " , tblTipoUsuario.tipoUsuario_descricao";
                        break;
                    case 2:
                        sql += " , tblEmpresa.escritorio_razaoSocial AS empresa_razaoSocial";
                        sql += " , tblTipoUsuario.tipoUsuario_descricao";
                        break;
                    case 3:
                        sql += " , tblEmpresa.faculdade_razaoSocial AS empresa_razaoSocial";
                        sql += " , tblTipoUsuario.tipoUsuario_descricao";
                        break;
                    case 4:
                        sql += " , tblMunicipio.municipio_uf";
                        sql += " , tblMunicipio.municipio_nome";
                        break;
                }


                sql += " , tblUsuario.usuario_cpf";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblUsuario.usuario_telefone";
                sql += " , tblUsuario.usuario_email";
                sql += " , tblUsuario.usuario_oab";
                sql += " , tblUsuario.usuario_ativo";
                sql += " , tblUsuario.usuario_dataCadastro";
                sql += " , tblUsuario.usuario_chavePIX";
                sql += " , tblUsuario.usuario_latitude";
                sql += " , tblUsuario.usuario_longitude";
                sql += " , tblUsuario.usuario_valorHora";
                sql += " FROM tblUsuario ";

                switch (especieUsuario_id)
                {
                    case 1:
                        sql += " INNER JOIN tblEmpresa ON tblUsuario.empresa_id = tblEmpresa.empresa_id";
                        sql += " INNER JOIN tblTipoUsuario ON tblUsuario.tipoUsuario_id = tblTipoUsuario.tipoUsuario_id";
                        break;
                    case 2:
                        sql += " INNER JOIN tblEscritorio AS tblEmpresa ON tblUsuario.empresa_id = tblEmpresa.escritorio_id";
                        sql += " INNER JOIN tblTipoUsuario ON tblUsuario.tipoUsuario_id = tblTipoUsuario.tipoUsuario_id";
                        break;
                    case 3:
                        sql += " INNER JOIN tblFaculdade AS tblEmpresa ON tblUsuario.empresa_id = tblEmpresa.faculdade_id";
                        sql += " INNER JOIN tblTipoUsuario ON tblUsuario.tipoUsuario_id = tblTipoUsuario.tipoUsuario_id";
                        break;
                    case 4:
                        sql += " INNER JOIN tblMunicipio ON tblMunicipio.municipio_codigo = tblUsuario.municipio_codigo";
                        break;
                }


                sql += " WHERE tblUsuario.especieUsuario_id = " + especieUsuario_id;
                if (empresa_id != 0)

                    sql += " AND tblUsuario.empresa_id = " + empresa_id;
                sql += " ORDER BY tblUsuario.usuario_nome";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                usuarioMobile = new GUARDIAO_STRUCTS.DATABASE.UsuarioMobile();
                usuarioMobile.usuarios = new List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    usuarioMobile.usuarios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados>());
                }


            }
            catch (Exception ex)
            {
                if (usuarioMobile == null)
                    usuarioMobile = new GUARDIAO_STRUCTS.DATABASE.UsuarioMobile();
                usuarioMobile.resultCode = -1;
                usuarioMobile.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return usuarioMobile;
        }

        public GUARDIAO_STRUCTS.DATABASE.UsuarioMobile GetAllUsuariosByEspecieOnlineMobile(string latitude, string longitude)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.UsuarioMobile usuarioMobile = null;
            try
            {
                sql = "SELECT tblUsuario.usuario_id ";
                sql += " , tblUsuario.usuario_cpf ";
                sql += " , tblUsuario.usuario_nome ";
                sql += " , tblUsuario.usuario_telefone ";
                sql += " , tblUsuario.usuario_email ";
                sql += " , tblUsuario.usuario_oab ";
                sql += " , tblUsuario.usuario_ativo ";
                sql += " , tblUsuario.usuario_dataCadastro ";
                sql += " , tblUsuario.usuario_chavePIX ";
                sql += " , tblUsuarioOnline.usuarioOnline_latitude ";
                sql += " , tblUsuarioOnline.usuarioOnline_longitude ";
                sql += " , tblUsuarioOnline.usuarioOnline_tipo";
                sql += " , tblUsuario.usuario_valorHora ";
                sql += " , tblUsuario.usuario_foto  ";
                sql += " , tblMunicipio.municipio_nome";
                sql += " , tblMunicipio.municipio_codigo";
                sql += " , tblEspecieUsuario.especieUsuario_descricao";
                sql += " , (CASE WHEN tblEspecieUsuario.especieUsuario_id = 2 THEN 'ESCRITÓRIO'";
                sql += "   WHEN tblEspecieUsuario.especieUsuario_id = 3 THEN 'FACULDADE'";
                sql += "   WHEN tblEspecieUsuario.especieUsuario_id = 4 THEN 'AVULSO' END) AS tipo_usuario";
                sql += "   ,(SELECT STRING_AGG(tblEspecialidade.especialidade_nome,' | ')";
                sql += " FROM tblEspecialidadeUsuario ";
                sql += " INNER JOIN tblEspecialidade ON tblEspecialidadeUsuario.especialidade_id = tblEspecialidade.especialidade_id";
                sql += " WHERE tblEspecialidadeUsuario.usuario_id = tblUsuario.usuario_id) AS especialidade_nome";
                sql += " FROM tblUsuario  ";
                sql += " INNER JOIN tblUsuarioOnline ON tblUsuarioOnline.usuario_id = tblUsuario.usuario_id ";
                sql += " INNER JOIN tblMunicipio ON tblMunicipio.municipio_codigo = tblUsuario.municipio_codigo";
                sql += " INNER JOIN tblEspecieUsuario ON tblEspecieUsuario.especieUsuario_id = tblUsuario.especieUsuario_id";
                sql += " WHERE tblUsuario.especieUsuario_id IN(2,3,4) ";
                sql += " ORDER BY tblUsuario.usuario_nome";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                usuarioMobile = new GUARDIAO_STRUCTS.DATABASE.UsuarioMobile();
                usuarioMobile.usuarios = new List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    usuarioMobile.usuarios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados>());
                    usuarioMobile.usuarios[usuarioMobile.usuarios.Count - 1].usuario_foto = Base64TOFile(usuarioMobile.usuarios[usuarioMobile.usuarios.Count - 1].usuario_foto);
                }

                usuarioMobile.usuarios = GetAdvogadosByRaio(usuarioMobile.usuarios, latitude, longitude);


            }
            catch (Exception ex)
            {
                if (usuarioMobile == null)
                    usuarioMobile = new GUARDIAO_STRUCTS.DATABASE.UsuarioMobile();
                usuarioMobile.resultCode = -1;
                usuarioMobile.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return usuarioMobile;
        }

        public void SalvarEspecialidadesUsuario(long usuario_id, List<GUARDIAO_STRUCTS.DATABASE.EspecialidadeUsuario> especialidades)
        {
            string sql = "";
            int reg = 0;
            Especialidade objEspecialidade = null;
            try
            {
                objEspecialidade = new Especialidade();
                objEspecialidade.DeleteAllEspecialidadesUsuarioByID(usuario_id);
                objEspecialidade.InserEspecialidadesUsuario(usuario_id, especialidades);
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
        }

        public GUARDIAO_STRUCTS.DATABASE.UsuarioOnline InsertUsuarioOnline(GUARDIAO_STRUCTS.DATABASE.UsuarioOnline online)
        {
            string sql = "";
            int reg = 0;
            try
            {
                DeleteAllUsuarioOnlineById(online.usuario_id);

                sql = "INSERT INTO tblUsuarioOnline(usuario_id";
                sql += " ,usuarioOnline_dataCadastro";
                sql += " ,usuarioOnline_identity";
                sql += " ,usuarioOnline_latitude";
                sql += " ,usuarioOnline_longitude";
                sql += " ,usuarioOnline_tipo)";
                sql += " VALUES(?,?,?,?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = online.usuario_id;
                CM.Parameters.Add(@"usuarioOnline_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                CM.Parameters.Add(@"usuarioOnline_identity", System.Data.OleDb.OleDbType.VarChar).Value = online.usuarioOnline_identity;
                CM.Parameters.Add(@"usuarioOnline_latitude", System.Data.OleDb.OleDbType.VarChar).Value = online.usuarioOnline_latitude;
                CM.Parameters.Add(@"usuarioOnline_longitude", System.Data.OleDb.OleDbType.VarChar).Value = online.usuarioOnline_longitude;
                CM.Parameters.Add(@"usuarioOnline_longitude", System.Data.OleDb.OleDbType.VarChar).Value = online.usuarioOnline_tipo;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao inserir usuario online no servidor.");
            }
            catch (Exception ex)
            {
                if (online == null)
                    online = new GUARDIAO_STRUCTS.DATABASE.UsuarioOnline();
                online.resultCode = -1;
                online.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return online;
        }

        public GUARDIAO_STRUCTS.DATABASE.UsuarioOnline InsertUsuarioOffline(GUARDIAO_STRUCTS.DATABASE.UsuarioOnline online)
        {
            try
            {
                DeleteAllUsuarioOnlineById(online.usuario_id);
            }
            catch (Exception ex)
            {
                if (online == null)
                    online = new GUARDIAO_STRUCTS.DATABASE.UsuarioOnline();
                online.resultCode = -1;
                online.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return online;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.Usuario> GetAllUsuarioByAdvogadoID(long advogado_id)
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.Usuario> usuarios = null;
            try
            {
                sql = "SELECT DISTINCT tblUsuario.usuario_id";
                sql += " , tblUsuario.empresa_id";
                sql += " , tblUsuario.grupoUsuario_id";
                sql += " , tblUsuario.tipoUsuario_id";
                sql += " , tblUsuario.especieUsuario_id";
                sql += " , tblUsuario.municipio_codigo";
                sql += " , tblUsuario.municipio_nome";
                sql += " , tblUsuario.usuario_cpf";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblUsuario.usuario_email";
                sql += " , tblUsuario.usuario_oab";
                sql += " , tblUsuario.usuario_telefone";
                sql += " , tblUsuario.usuario_endereco";
                sql += " , tblUsuario.usuario_numero";
                sql += " , tblUsuario.usuario_bairro";
                sql += " , tblUsuario.usuario_cep";
                sql += " , tblUsuario.usuario_rg";
                sql += " , tblUsuario.usuario_foto";
                sql += " , tblUsuario.usuario_senha";
                sql += " , tblUsuario.usuario_valorHora";
                sql += " , tblUsuario.usuario_dataAdmissao";
                sql += " , tblUsuario.usuario_dataDesligamento";
                sql += " , tblUsuario.usuario_ativo";
                sql += " , tblUsuario.usuario_chavePIX";
                sql += " , tblUsuario.usuario_latitude";
                sql += " , tblUsuario.usuario_longitude";
                sql += " , tblUsuario.usuario_dataCadastro";
                sql += " , tblUsuario.customer_id";
                sql += " FROM tblAtendimentos ";
                sql += " INNER JOIN tblUsuario ON tblAtendimentos.usuario_id = tblUsuario.usuario_id";
                sql += " WHERE tblAtendimentos.advogado_id = " + advogado_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum registro encontrado para os parâmetros informados.");
                usuarios = new List<GUARDIAO_STRUCTS.DATABASE.Usuario>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    usuarios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Usuario>());
                }
            }
            catch (Exception)
            {
                usuarios = null;
            }
            return usuarios;
        }

        public List<GUARDIAO_STRUCTS.DATABASE.Usuario> GetAllUsuarioByAdvogadoIDEspecianlidade(long advogado_id, long especialidade_id)
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.Usuario> usuarios = null;
            try
            {
                sql = "SELECT DISTINCT tblUsuario.usuario_id";
                sql += " , tblUsuario.empresa_id";
                sql += " , tblUsuario.grupoUsuario_id";
                sql += " , tblUsuario.tipoUsuario_id";
                sql += " , tblUsuario.especieUsuario_id";
                sql += " , tblUsuario.municipio_codigo";
                sql += " , tblUsuario.municipio_nome";
                sql += " , tblUsuario.usuario_cpf";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblUsuario.usuario_email";
                sql += " , tblUsuario.usuario_oab";
                sql += " , tblUsuario.usuario_telefone";
                sql += " , tblUsuario.usuario_endereco";
                sql += " , tblUsuario.usuario_numero";
                sql += " , tblUsuario.usuario_bairro";
                sql += " , tblUsuario.usuario_cep";
                sql += " , tblUsuario.usuario_rg";
                sql += " , tblUsuario.usuario_foto";
                sql += " , tblUsuario.usuario_senha";
                sql += " , tblUsuario.usuario_valorHora";
                sql += " , tblUsuario.usuario_dataAdmissao";
                sql += " , tblUsuario.usuario_dataDesligamento";
                sql += " , tblUsuario.usuario_ativo";
                sql += " , tblUsuario.usuario_chavePIX";
                sql += " , tblUsuario.usuario_latitude";
                sql += " , tblUsuario.usuario_longitude";
                sql += " , tblUsuario.usuario_dataCadastro";
                sql += " , tblUsuario.customer_id";
                sql += " FROM tblAtendimentos ";
                sql += " INNER JOIN tblUsuario ON tblAtendimentos.usuario_id = tblUsuario.usuario_id";
                sql += " INNER JOIN tblSolicitacaoAtendimento ON tblSolicitacaoAtendimento.solicitacaoAtendimento_id = tblAtendimentos.solicitacaoAtendimento_id";
                sql += " WHERE tblAtendimentos.advogado_id = " + advogado_id;
                sql += " AND tblSolicitacaoAtendimento.especialidade_id = " + especialidade_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum registro encontrado para os parâmetros informados.");
                usuarios = new List<GUARDIAO_STRUCTS.DATABASE.Usuario>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    usuarios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Usuario>());
                }
            }
            catch (Exception)
            {
                usuarios = null;
            }
            return usuarios;
        }

        public GUARDIAO_STRUCTS.DATABASE.Usuario VerificaEmailCadastrado(string usuario_email)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                sql = "SELECT COUNT(usuario_id) AS TOTAL FROM tblUsuario WHERE usuario_email = '" + usuario_email + "'";
                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Ocorreu um problema ao verificar email do usuário");
                if (Convert.ToInt32(ds.Tables["T"].Rows[0]["TOTAL"].ToString()) > 0)
                    throw new Exception("O Email informado já encontra-se cadastrado no servidor.");

                usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;

            }
            return usuario;
        }
        public bool VerificaEmailInUse(string usuario_email)
        {
            string sql = "";
            DataSet ds = null;
            bool resul = false;
            try
            {
                sql = "SELECT COUNT(usuario_id) AS TOTAL FROM tblUsuario WHERE usuario_email = '" + usuario_email + "'";
                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Ocorreu um problema ao verificar email do usuário");
                if (Convert.ToInt32(ds.Tables["T"].Rows[0]["TOTAL"].ToString()) > 0)
                    throw new Exception("O Email informado já encontra-se cadastrado no servidor.");

            }
            catch (Exception)
            {
                resul = true;

            }
            return resul;
        }
        public GUARDIAO_STRUCTS.DATABASE.Usuario EsqueciMinhaSenha(string usuario_email)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                sql = "SELECT TOP 1 usuario_id";
                sql += " ,empresa_id";
                sql += " ,grupoUsuario_id";
                sql += " ,tipoUsuario_id";
                sql += " ,especieUsuario_id";
                sql += " ,municipio_codigo";
                sql += " ,municipio_nome";
                sql += " ,usuario_cpf";
                sql += " ,usuario_nome";
                sql += " ,usuario_email";
                sql += " ,usuario_oab";
                sql += " ,usuario_telefone";
                sql += " ,usuario_endereco";
                sql += " ,usuario_numero";
                sql += " ,usuario_bairro";
                sql += " ,usuario_cep";
                sql += " ,usuario_rg";
                sql += " ,usuario_foto";
                sql += " ,usuario_senha";
                sql += " ,usuario_valorHora";
                sql += " ,usuario_dataAdmissao";
                sql += " ,usuario_dataDesligamento";
                sql += " ,usuario_ativo";
                sql += " ,usuario_chavePIX";
                sql += " ,usuario_latitude";
                sql += " ,usuario_longitude";
                sql += " ,usuario_dataCadastro";
                sql += " ,customer_id";
                sql += " FROM tblUsuario";
                sql += " WHERE usuario_email = '" + usuario_email + "'";
                sql += " ORDER BY usuario_id DESC";
                ds = ExecuteSelect(sql);

                if (ds == null)
                    throw new Exception("Ocorreu um problema ao verificar email do usuário");

                usuario = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Usuario>();

                GUARDIAO_COMMOM.SendMail sendMail = new SendMail();
                if (!sendMail.SendEmailNewUser(usuario))
                    throw new Exception("Usuário encontrado porém ocorreu um problema ao enviar email.");

            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;

            }
            return usuario;
        }

        public GUARDIAO_STRUCTS.DATABASE.Usuario GetUsuarioBySolicitacaoID(long solicitacaoAtendimento_id)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                sql = "SELECT tblUsuario.usuario_id";
                sql += " , tblUsuario.empresa_id";
                sql += " , tblUsuario.grupoUsuario_id";
                sql += " , tblUsuario.tipoUsuario_id";
                sql += " , tblUsuario.especieUsuario_id";
                sql += " , tblUsuario.municipio_codigo";
                sql += " , tblUsuario.municipio_nome";
                sql += " , tblUsuario.usuario_cpf";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblUsuario.usuario_email";
                sql += " , tblUsuario.usuario_oab";
                sql += " , tblUsuario.usuario_telefone";
                sql += " , tblUsuario.usuario_endereco";
                sql += " , tblUsuario.usuario_numero";
                sql += " , tblUsuario.usuario_bairro";
                sql += " , tblUsuario.usuario_cep";
                sql += " , tblUsuario.usuario_rg";
                sql += " , tblUsuario.usuario_foto";
                sql += " , tblUsuario.usuario_senha";
                sql += " , tblUsuario.usuario_valorHora";
                sql += " , tblUsuario.usuario_dataAdmissao";
                sql += " , tblUsuario.usuario_dataDesligamento";
                sql += " , tblUsuario.usuario_ativo";
                sql += " , tblUsuario.usuario_chavePIX";
                sql += " , tblUsuario.usuario_latitude";
                sql += " , tblUsuario.usuario_longitude";
                sql += " , tblUsuario.usuario_dataCadastro";
                sql += " , tblUsuario.customer_id";
                sql += " FROM tblUsuario ";
                sql += " INNER JOIN tblSolicitacaoAtendimento ON tblUsuario.usuario_id = tblSolicitacaoAtendimento.usuario_id";
                sql += " WHERE tblSolicitacaoAtendimento.solicitacaoAtendimento_id = " + solicitacaoAtendimento_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("NENHUM USUÁRIO ENCONTRADO PARA OS PARÂMETROS INFORMADOS.");

                usuario = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Usuario>();
                if (usuario.especieUsuario_id == 2 || usuario.especieUsuario_id == 4)
                    usuario.especialidadeUsuarios = GetEspecialidadesByUsuarioID(usuario.usuario_id);


            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return usuario;
        }

        public GUARDIAO_STRUCTS.DATABASE.UsuarioListaMobile GetAllUsuarioOnlineByFiltro(GUARDIAO_STRUCTS.DATABASE.FiltroUsuarioOnline filtro)
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.UsuarioListaMobile usuario = null;
            try
            {
                sql = "SELECT tblUsuario.usuario_id";
                sql += " , tblUsuario.empresa_id";
                sql += " , tblUsuario.grupoUsuario_id";
                sql += " , tblUsuario.tipoUsuario_id";
                sql += " , tblUsuario.especieUsuario_id";
                sql += " , tblUsuario.municipio_codigo";
                sql += " , tblUsuario.municipio_nome";
                sql += " , tblUsuario.usuario_cpf";
                sql += " , tblUsuario.usuario_nome";
                sql += " , tblUsuario.usuario_email";
                sql += " , tblUsuario.usuario_oab";
                sql += " , tblUsuario.usuario_telefone";
                sql += " , tblUsuario.usuario_endereco";
                sql += " , tblUsuario.usuario_numero";
                sql += " , tblUsuario.usuario_bairro";
                sql += " , tblUsuario.usuario_cep";
                sql += " , tblUsuario.usuario_rg";
                sql += " , tblUsuario.usuario_foto";
                sql += " , tblUsuario.usuario_senha";
                sql += " , tblUsuario.usuario_valorHora";
                sql += " , tblUsuario.usuario_dataAdmissao";
                sql += " , tblUsuario.usuario_dataDesligamento";
                sql += " , tblUsuario.usuario_ativo";
                sql += " , tblUsuario.usuario_chavePIX";
                sql += " , tblUsuario.usuario_latitude";
                sql += " , tblUsuario.usuario_longitude";
                sql += " , tblUsuario.usuario_dataCadastro";
                sql += " , tblUsuario.customer_id";
                sql += " , tblUsuarioOnline.usuarioOnline_tipo";
                sql += " FROM tblUsuarioOnline ";
                sql += " INNER JOIN tblUsuario ON tblUsuarioOnline.usuario_id = tblUsuario.usuario_id ";
                sql += " INNER JOIN tblEspecialidadeUsuario ON tblUsuario.usuario_id = tblEspecialidadeUsuario.usuario_id";
                switch (filtro.usuarioOnline_tipo)
                {
                    case 1:
                        sql += " WHERE tblUsuarioOnline.usuarioOnline_tipo IN(1,3)";
                        break;
                    case 2:
                        sql += " WHERE tblUsuarioOnline.usuarioOnline_tipo IN(2,3)";
                        break;
                }

                sql += " AND tblEspecialidadeUsuario.especialidade_id =  " + filtro.especialidade_id;
                if (filtro.municipio_codigo != 0)
                    sql += " AND tblUsuario.municipio_codigo = " + filtro.municipio_codigo;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum registro encontrado para os parâmetros informados.");
                usuario = new GUARDIAO_STRUCTS.DATABASE.UsuarioListaMobile();
                usuario.usuarios = new List<GUARDIAO_STRUCTS.DATABASE.Usuario>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    usuario.usuarios.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Usuario>());
                    usuario.usuarios[usuario.usuarios.Count - 1].especialidadeUsuarios = GetEspecialidadesByUsuarioID(usuario.usuarios[usuario.usuarios.Count - 1].usuario_id);
                    usuario.usuarios[usuario.usuarios.Count - 1].usuario_foto = Base64TOFile(usuario.usuarios[usuario.usuarios.Count - 1].usuario_foto);
                }
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.UsuarioListaMobile();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
            }
            return usuario;
        }

        public GUARDIAO_STRUCTS.DATABASE.UsuarioOnline VerificaUsuarioOnline(long usuario_id)
        {
            GUARDIAO_STRUCTS.DATABASE.UsuarioOnline usuario = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT usuarioOnline_id";
                sql += " ,usuario_id";
                sql += " ,usuarioOnline_tipo";
                sql += " ,usuarioOnline_identity";
                sql += " ,usuarioOnline_latitude";
                sql += " ,usuarioOnline_longitude";
                sql += " ,usuarioOnline_dataCadastro";
                sql += " FROM tblUsuarioOnline";
                sql += " WHERE usuario_id = " + usuario_id;

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum usuario encontrado para o parametro informado.");

                usuario = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.UsuarioOnline>();
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.UsuarioOnline();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
            }
            return usuario;
        }

        private void DeleteAllUsuarioOnlineById(long usuario_id)
        {
            string sql = "";
            try
            {
                sql = "DELETE FROM tblUsuarioOnline WHERE usuario_id = " + usuario_id;
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
        }

        private List<GUARDIAO_STRUCTS.DATABASE.EspecialidadeUsuario> GetEspecialidadesByUsuarioID(long usuario_id)
        {
            List<GUARDIAO_STRUCTS.DATABASE.EspecialidadeUsuario> especialidades = null;
            try
            {
                Especialidade objEspecialidades = new Especialidade();
                especialidades = objEspecialidades.GetEspecialidadesByUsuarioID(usuario_id);
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            return especialidades;
        }

        private string Base64TOFile(string base64)
        {
            string pathFile = "";
            string destineFile = "";
            string nameFile = Guid.NewGuid().ToString().ToString() + ".jpg";
            try
            {
                destineFile = GUARDIAO_COMMOM.Directory.IMAGE_PATH + nameFile;
                System.IO.File.WriteAllBytes(destineFile, Convert.FromBase64String(base64));
                pathFile = nameFile;
            }
            catch (Exception ex)
            {
                pathFile = "";
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }
            return pathFile;
        }

        private List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados> GetAdvogadosByRaio(List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados> usuarios, string latitude, string longitude)
        {
            List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados> usuariosRaio = new List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados>();
            GeoCoordinate sCoord = null;
            double distance = 0;
            GUARDIAO_STRUCTS.DATABASE.ParametrosSistema parametros = null;
            try
            {
                GUARDIAO_CRUD.DATABASE.ParametrosSistema objParametros = new ParametrosSistema();
                parametros = objParametros.GetParametrosSistema();

                sCoord = new GeoCoordinate(Convert.ToDouble(latitude.Replace(".", ",")), Convert.ToDouble(longitude.Replace(".", ",")));
                for (int i = 0; i < usuarios.Count; i++)
                {
                    GeoCoordinate eCoord = new GeoCoordinate(Convert.ToDouble(usuarios[i].usuarioOnline_latitude.Replace(".", ",")), Convert.ToDouble(usuarios[i].usuarioOnline_longitude.Replace(".", ",")));
                    distance = (sCoord.GetDistanceTo(eCoord) / 1000);
                    if (distance <= parametros.parametroSistema_raioAtendimento)
                    {
                        usuariosRaio.Add(usuarios[i]);
                    }
                }
            }
            catch (Exception)
            {
                usuariosRaio = null;
            }

            return usuariosRaio;

        }


    }
}
