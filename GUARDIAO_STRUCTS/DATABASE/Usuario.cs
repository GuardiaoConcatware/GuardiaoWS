using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Usuario : Result
    {
        public long usuario_id { get; set; }
        public long empresa_id { get; set; }
        public long especieUsuario_id { get; set; }
        public long grupoUsuario_id { get; set; }
        public long tipoUsuario_id { get; set; }
        public long municipio_codigo { get; set; }
        public string municipio_uf { get; set; }
        public string municipio_nome { get; set; }
        public long usuario_cpf { get; set; }
        public string usuario_nome { get; set; }
        public string usuario_email { get; set; }
        public string usuario_senha { get; set; }
        public string usuario_oab { get; set; }
        public string usuario_telefone { get; set; }
        public string usuario_endereco { get; set; }
        public string usuario_numero { get; set; }
        public string usuario_bairro { get; set; }
        public string usuario_cep { get; set; }
        public string usuario_rg { get; set; }
        public string usuario_foto { get; set; }
        public decimal usuario_valorHora { get; set; }
        public string usuario_dataAdmissao { get; set; }
        public string usuario_dataDesligamento { get; set; }
        public bool usuario_ativo { get; set; }
        public string usuario_dataCadastro { get; set; }
        public string usuario_chavePIX { get; set; }
        public string usuario_latitude { get; set; }
        public string usuario_longitude { get; set; }

        public int usuarioOnline_tipo { get; set; }
        public List<EspecialidadeUsuario> especialidadeUsuarios { get; set; }
    }
}
