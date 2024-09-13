using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
  public class UsuarioAdvogadoAtivo
  {
    public string usuario_nome { get; set; }
    public int usuario_id { get; set; }
    public bool usuario_ativo { get; set; }
    public string usuario_email { get; set; }
    public string usuario_oab { get; set; }
    public string usuario_telefone { get; set; }
    public DateTime usuario_dataCadastro { get; set; }
  }


  public class UsuarioAdvogadoAtendimentoAtivo
  {
    public string solicitacaoAtendimento_status { get; set; }
    public long solicitacaoAtendimento_id { get; set; }
    public string solicitacaoAtendimento_identity { get; set; }
    public DateTime solicitacaoAtendimento_dataCadastro { get; set; }
    public string usuario_nome { get; set; }
  }
}
