using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Escritorio : Result
    {
        public long escritorio_id { get; set; }

        public long municipio_codigo { get; set; }

        public string municipio_uf { get; set; }
        public string municipio_nome { get; set; }

        public long escritorio_cnpj { get; set; }

        public string escritorio_razaoSocial { get; set; }

        public string escritorio_nomeFantasia { get; set; }

        public string escritorio_inscricaoMunicipal { get; set; }

        public string escritorio_inscricaoEstadual { get; set; }

        public string escritorio_cep { get; set; }

        public string escritorio_endereco { get; set; }

        public string escritorio_numero { get; set; }

        public string escritorio_complemento { get; set; }

        public string escritorio_bairro { get; set; }

        public string escritorio_telefone { get; set; }

        public string escritorio_logoMarca { get; set; }

        public bool escritorio_ativo { get; set; }

        public string escritorio_status { get; set; }

        public string escritorio_email { get; set; }

        public string escritorio_chavePix { get; set; }

        public string escritorio_latitude { get; set; }

        public string escritorio_longitude { get; set; }
        public string escritorio_dataCadastro { get; set; }
    }
}
