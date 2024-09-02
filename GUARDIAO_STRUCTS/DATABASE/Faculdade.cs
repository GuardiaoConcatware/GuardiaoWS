using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Faculdade : Result
    {
        public long faculdade_id { get; set; }

        public long municipio_codigo { get; set; }

        public string municipio_nome { get; set; }

        public string municipio_uf { get; set; }

        public long faculdade_cnpj { get; set; }

        public string faculdade_razaoSocial { get; set; }

        public string faculdade_nomeFantasia { get; set; }

        public string faculdade_inscricaoMunicipal { get; set; }

        public string faculdade_inscricaoEstadual { get; set; }

        public string faculdade_cep { get; set; }

        public string faculdade_endereco { get; set; }

        public string faculdade_numero { get; set; }

        public string faculdade_complemento { get; set; }

        public string faculdade_bairro { get; set; }

        public string faculdade_telefone { get; set; }

        public string faculdade_logoMarca { get; set; }

        public bool faculdade_ativo { get; set; }

        public string faculdade_status { get; set; }

        public string faculdade_email { get; set; }

        public string faculdade_dataCadastro { get; set; }
    }
}
