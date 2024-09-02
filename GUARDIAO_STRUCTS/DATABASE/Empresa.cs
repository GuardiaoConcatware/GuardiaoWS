using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Empresa : Result
    {
        public long empresa_id { get; set; }

        public long municipio_codigo { get; set; }

        public string municipio_nome { get; set; }

        public string municipio_uf { get; set; }

        public long empresa_cnpj { get; set; }

        public string empresa_razaoSocial { get; set; }

        public string empresa_nomeFantasia { get; set; }

        public string empresa_inscricaoMunicipal { get; set; }

        public string empresa_inscricaoEstadual { get; set; }

        public string empresa_cep { get; set; }

        public string empresa_endereco { get; set; }

        public string empresa_numero { get; set; }

        public string empresa_complemento { get; set; }

        public string empresa_bairro { get; set; }

        public string empresa_telefone { get; set; }

        public string empresa_logoMarca { get; set; }

        public bool empresa_ativo { get; set; }

        public string empresa_status { get; set; }

        public string empresa_email { get; set; }

        public string empresa_dataCadastro { get; set; }
    }
}
