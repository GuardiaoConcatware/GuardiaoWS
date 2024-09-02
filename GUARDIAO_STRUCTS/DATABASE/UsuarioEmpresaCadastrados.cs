using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class UsuarioEmpresaCadastrados : Result
    {
        public long usuario_id { get; set; }
        public string empresa_razaoSocial { get; set; }
        public string tipoUsuario_descricao { get; set; }
        public long usuario_cpf { get; set; }
        public string usuario_nome { get; set; }
        public string usuario_telefone { get; set; }
        public string usuario_email { get; set; }
        public string usuario_foto { get; set; }
        public string usuario_oab { get; set; }
        public bool usuario_ativo { get; set; }
        public string usuario_dataCadastro { get; set; }
        public string municipio_uf { get; set; }
        public string municipio_nome { get; set; }
        public string usuarioOnline_latitude { get; set; }
        public string usuarioOnline_longitude { get; set; }
        public string especialidade_nome { get; set; }
        public string tipo_usuario { get; set; }
        public string especieUsuario_descricao { get; set; }
        public int usuarioOnline_tipo { get; set; }
    }
}
