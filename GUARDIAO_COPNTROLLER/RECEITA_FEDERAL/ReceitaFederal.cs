using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.RECEITA_FEDERAL
{
    public class ReceitaFederal
    {
        public string GetDadosCNPJ(string cnpj)
        {
            JObject obj;
            GUARDIAO_STRUCTS.DATABASE.Empresa empresa = null;
            try
            {
                var requisicaoWeb = WebRequest.CreateHttp("https://www.receitaws.com.br/v1/cnpj/" + cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Trim());
                requisicaoWeb.Method = "GET";
                requisicaoWeb.UserAgent = "RequisicaoWebDemo";

                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    obj = JObject.Parse(objResponse.ToString());
                    streamDados.Close();
                    resposta.Close();
                }

                if (obj == null)
                    throw new Exception("OPS! NENHUM DADO ENCONTRADO PARA O CNPJ INFORMADO.");
                if (obj.ContainsKey("status"))
                    if (obj["status"].ToString().ToUpper() == "ERROR")
                        throw new Exception("OPS! " + obj["message"].ToString().ToUpper());

                empresa = new GUARDIAO_STRUCTS.DATABASE.Empresa();
                empresa.empresa_razaoSocial = obj["nome"].ToString().ToUpper();
                empresa.empresa_nomeFantasia = obj["fantasia"].ToString().ToUpper();
                empresa.empresa_cep = obj["cep"].ToString().Replace(".", "").Replace("-", "");
                empresa.empresa_endereco = obj["logradouro"].ToString().ToUpper();
                empresa.empresa_numero = obj["numero"].ToString();
                if (obj.ContainsKey("complemento"))
                    empresa.empresa_complemento = obj["complemento"].ToString().ToUpper();
                empresa.empresa_bairro = obj["bairro"].ToString().ToUpper();

                GUARDIAO_CRUD.DATABASE.Municipio dbMunicipio = new GUARDIAO_CRUD.DATABASE.Municipio();
                GUARDIAO_STRUCTS.DATABASE.Municipio mm = dbMunicipio.GetMunicipioByName(obj["municipio"].ToString().Trim());
                if (mm.resultCode == 0)
                {
                    empresa.municipio_codigo = mm.municipio_codigo;
                    empresa.municipio_uf = mm.municipio_uf;
                    empresa.municipio_nome = mm.municipio_nome.ToUpper();
                }


            }
            catch (Exception ex)
            {
                if (empresa == null)
                    empresa = new GUARDIAO_STRUCTS.DATABASE.Empresa();
                empresa.resultCode = -1;
                empresa.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ReceitaFederal).Namespace);
            }

            return JsonConvert.SerializeObject(empresa);
        }
    }
}
