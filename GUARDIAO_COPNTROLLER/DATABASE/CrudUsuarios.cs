// controller CrudUsuarios
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class CrudUsuarios
    {
        GUARDIAO_CRUD.DATABASE.CrudUsuarios objUsuario = null;
        public string ValidarLoginUsuarioApp(long usuario_cpf, string usuario_senha)//, bool isPersonLogin)
        {

            GUARDIAO_STRUCTS.DATABASE.Usuario usuario = null;
            try
            {
                GUARDIAO_CRUD.DATABASE.Usuario objUsuario = new GUARDIAO_CRUD.DATABASE.Usuario();
                //if (!isPersonLogin)
                usuario = objUsuario.ValidarLoginUsuario(usuario_cpf, usuario_senha, 0); // GUARDIAO_COMMOM.Crypto.DecryptSentence(usuario_senha)
                /* else
                     usuario = objUsuario.ValidarLoginEmpresa(usuario_cpf, usuario_senha);*/
            }
            catch (Exception ex)
            {
                if (usuario == null)
                    usuario = new GUARDIAO_STRUCTS.DATABASE.Usuario();
                usuario.resultCode = -1;
                usuario.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;

            return JsonConvert.SerializeObject(usuario, serializerSettings);
        }


        public string InsertAdvogadoCliente(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.AdvogadoCliente advogadoCliente = null;
            try
            {
                advogadoCliente = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.AdvogadoCliente>(json);
                objUsuario = new GUARDIAO_CRUD.DATABASE.CrudUsuarios();
                advogadoCliente = objUsuario.InsertAdvogadoCliente(advogadoCliente);
            }
            catch (Exception ex)
            {
                if (advogadoCliente == null)
                    advogadoCliente = new GUARDIAO_STRUCTS.DATABASE.AdvogadoCliente();
                advogadoCliente.resultCode = -1;
                advogadoCliente.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(advogadoCliente);
        }

        public string InsertCustomerId(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.CustomerId customerId = null;
            try
            {
                customerId = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.CustomerId>(json);
                objUsuario = new GUARDIAO_CRUD.DATABASE.CrudUsuarios();
                customerId = objUsuario.InsertCustomerId(customerId);
            }
            catch (Exception ex)
            {
                if (customerId == null)
                    customerId = new GUARDIAO_STRUCTS.DATABASE.CustomerId();
                //customerId.resultCode = -1;
                customerId.code = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(customerId);
        }

        //AleterarSenha
        public string AleterarSenha(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.AlterarSenha senha = null;
            try
            {
                senha = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.AlterarSenha>(json);
                GUARDIAO_CRUD.DATABASE.CrudUsuarios objUsuario = new GUARDIAO_CRUD.DATABASE.CrudUsuarios();
                senha = objUsuario.AleterarSenha(senha);
            }
            catch (Exception ex)
            {
                if (senha == null)
                    senha = new GUARDIAO_STRUCTS.DATABASE.AlterarSenha();
                senha.resultCode = -1;
                senha.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(senha);
        }

        public string InsertChavePix(string json)
        {
            GUARDIAO_STRUCTS.DATABASE.Pix pix = null;
            try
            {
                pix = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Pix>(json);
                GUARDIAO_CRUD.DATABASE.CrudUsuarios objUsuario = new GUARDIAO_CRUD.DATABASE.CrudUsuarios();
                pix = objUsuario.InsertChavePix(pix);
            }
            catch (Exception ex)
            {
                if (pix == null)
                    pix = new GUARDIAO_STRUCTS.DATABASE.Pix();
                pix.resultCode = -1;
                pix.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Usuario).Namespace);
            }

            return JsonConvert.SerializeObject(pix);
        }
    }
}
