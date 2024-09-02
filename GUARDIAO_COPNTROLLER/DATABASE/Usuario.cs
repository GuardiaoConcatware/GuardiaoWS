using GUARDIAO_COMMOM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class Usuario
    {
        GUARDIAO_CRUD.DATABASE.Usuario objUsuario = null;
        public string InsertUsuario(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                usuario = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Usuario>(json);
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.InsertUsuario(usuario);
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(usuario);
        }

        public string UpdateUsuario(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                usuario = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Usuario>(json);
                GUARDIAO_CRUD.DATABASE.Usuario objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.UpdateUsuario(usuario);
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(usuario);
        }

        public string GetAllUsuariosByEspecie(long empresa_id, long especieUsuario_id)
        {

            List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados> usuario = null;
            try
            {
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.GetAllUsuariosByEspecie(empresa_id, especieUsuario_id);
            }
            catch (Exception ex)
            {
                usuario = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(usuario);
        }

        public string GetAllUsuariosByEspecieOnline(long empresa_id, long especieUsuario_id)
        {

            List<GUARDIAO_STRUCTS.DATABASE.UsuarioEmpresaCadastrados> usuario = null;
            try
            {
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.GetAllUsuariosByEspecieOnline(empresa_id, especieUsuario_id);
            }
            catch (Exception ex)
            {
                usuario = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(usuario);
        }

        public string GetAllUsuariosByEspecieMobile(long empresa_id, long especieUsuario_id)
        {

            GUARDIAO_STRUCTS.DATABASE.UsuarioMobile usuario = null;
            try
            {
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.GetAllUsuariosByEspecieMobile(empresa_id, especieUsuario_id);
            }
            catch (Exception ex)
            {
                usuario = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(usuario);
        }

        public string GetAllUsuariosByEspecieOnlineMobile(string latitude, string longitude)
        {

            GUARDIAO_STRUCTS.DATABASE.UsuarioMobile usuario = null;
            try
            {
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.GetAllUsuariosByEspecieOnlineMobile(latitude, longitude);
            }
            catch (Exception ex)
            {
                usuario = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(usuario);
        }

        public string GetUsuarioById(long usuario_id)
        {

            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                GUARDIAO_CRUD.DATABASE.Usuario objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.GetUsuarioById(usuario_id);
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(usuario);
        }

        public string ValidarLoginUsuario(long usuario_cpf, string usuario_senha)
        {

            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                GUARDIAO_CRUD.DATABASE.Usuario objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.ValidarLoginUsuario(usuario_cpf, GUARDIAO_COMMOM.Crypto.DecryptSentence(usuario_senha));
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }



            return JsonConvert.SerializeObject(usuario);
        }

        public string InsertUsuarioOnline(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.UsuarioOnline online = null;
            try
            {
                online = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.UsuarioOnline>(json);
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                online = objUsuario.InsertUsuarioOnline(online);

            }
            catch (Exception ex)
            {
                if (online == null)
                    online = new GUARDIAO_STRUCTS.DATABASE.UsuarioOnline();
                online.resultCode = -1;
                online.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(online);
        }

        public string InsertUsuarioOffline(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.UsuarioOnline online = null;
            try
            {
                online = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.UsuarioOnline>(json);
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                online = objUsuario.InsertUsuarioOffline(online);

            }
            catch (Exception ex)
            {
                if (online == null)
                    online = new GUARDIAO_STRUCTS.DATABASE.UsuarioOnline();
                online.resultCode = -1;
                online.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(online);
        }

        public string GetAllUsuarioByAdvogadoID(long advogado_id)
        {

            List<GUARDIAO_STRUCTS.DATABASE.Usuario> usuarios = null;
            try
            {
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuarios = objUsuario.GetAllUsuarioByAdvogadoID(advogado_id);
            }
            catch (Exception)
            {
                usuarios = null;
            }
            return JsonConvert.SerializeObject(usuarios);
        }

        public string GetAllUsuarioByAdvogadoIDEspecianlidade(long advogado_id, long especialidade_id)
        {

            List<GUARDIAO_STRUCTS.DATABASE.Usuario> usuarios = null;
            try
            {
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuarios = objUsuario.GetAllUsuarioByAdvogadoIDEspecianlidade(advogado_id, especialidade_id);
            }
            catch (Exception)
            {
                usuarios = null;
            }
            return JsonConvert.SerializeObject(usuarios);
        }

        public string VerificaEmailCadastrado(string usuario_email)
        {

            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.VerificaEmailCadastrado(usuario_email);
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;

            }
            return JsonConvert.SerializeObject(usuario);
        }

        public string EsqueciMinhaSenha(string usuario_email)
        {

            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.EsqueciMinhaSenha(usuario_email);

            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;

            }
            return JsonConvert.SerializeObject(usuario);
        }

        public string GetUsuarioBySolicitacaoID(long solicitacaoAtendimento_id)
        {

            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {

                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.GetUsuarioBySolicitacaoID(solicitacaoAtendimento_id);

            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(usuario);
        }

        public string GetAllUsuarioOnlineByFiltro(string json)
        {

            GUARDIAO_STRUCTS.DATABASE.UsuarioListaMobile usuario = null;
            GUARDIAO_STRUCTS.DATABASE.FiltroUsuarioOnline filtro = null;
            try
            {
                filtro = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.FiltroUsuarioOnline>(json);
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.GetAllUsuarioOnlineByFiltro(filtro);
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.UsuarioListaMobile();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
            }
            return JsonConvert.SerializeObject(usuario);
        }

        public string VerificaUsuarioOnline(long usuario_id)
        {
            GUARDIAO_STRUCTS.DATABASE.UsuarioOnline usuario = null;
            try
            {
                objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                usuario = objUsuario.VerificaUsuarioOnline(usuario_id);
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.UsuarioOnline();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
            }
            return JsonConvert.SerializeObject(usuario);
        }
    }
}
