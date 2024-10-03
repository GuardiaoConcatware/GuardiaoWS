using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
  public class UsuarioQuantidade
  {
        public string  DataCriacao{ get; set; }
        public int  TotalAdvogados{ get; set; }
        public int  ContadorAdvogados{ get; set; }
    } 
  
  public class UsuarioQuantidadeAdvogado
  {
        public string DataAtendimento{ get; set; }
        public int  TotalAtendimentos{ get; set; }
        public int  ContadorAdvogados{ get; set; }
  }
}
