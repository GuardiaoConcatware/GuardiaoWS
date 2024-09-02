using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_COMMOM
{
    public class SendMail
    {
        private string CRENDENCIAL_EMAIL = "joao@concatware.com.br";
        private string CRENDENCIAL_PWD = "Concatware@2024";
        private string REMETENTE = "joao@concatware.com.br";
        private string SMTP_SERVER = "smtp.hostinger.com";
        private int PORTA_SERVER = 587;

        public bool SendEmailNewUser(GUARDIAO_STRUCTS.DATABASE.Usuario usuario)
        {
            bool resul = true;
            MailMessage message = new MailMessage();
            string subject = "Esqueci minha senha";
            try
            {
                message.From = new MailAddress(REMETENTE);
                MailAddressCollection mailAddresses = new MailAddressCollection();
                mailAddresses.Add(usuario.usuario_email);
                message.To.Add(mailAddresses[0]);
                message.Subject = subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Body = CreateBodyEmail(usuario);
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                message.BodyEncoding = System.Text.Encoding.UTF8;

                SmtpClient client = new SmtpClient(SMTP_SERVER, PORTA_SERVER);
                client.EnableSsl = false;
                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(CRENDENCIAL_EMAIL, CRENDENCIAL_PWD);
                client.Credentials = networkCredential;
                client.Send(message);
            }
            catch (Exception ex)
            {
                Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SendMail).Namespace);
                resul = false;
            }
            return resul;
        }

        private string CreateBodyEmail(GUARDIAO_STRUCTS.DATABASE.Usuario usuario)
        {
            string html = "";
            try
            {
                html += "<html><head>";
                html += "<meta charset='utf-8'>";
                html += "<title></title>";
                html += "</head>";
                html += "<body>";
                html += "<div style='display: flex;justify-items: center;flex-direction: column;'>";
                html += "<div>Clique no link abaixo para redefinir sua senha</div>";
                html += "<div><a href='http://177.39.20.17/hom/guardiao/site/forgot.aspx?identity=" + GUARDIAO_COMMOM.Crypto.EncryptSentence(usuario.usuario_id.ToString()) + "'>guardiao.com.br/forgot.aspx</a></div>";
                html += "</div>";
                html += "</body>";
                html += "</html>";
            }
            catch (Exception ex)
            {
                Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SendMail).Namespace);
                html = "";
            }
            return html;
        }
    }
}
