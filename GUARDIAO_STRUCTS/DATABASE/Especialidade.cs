using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class Especialidade : Result
    {
        public long especialidade_id { get; set; }

        public string especialidade_nome { get; set; }

        public string especialidade_descricao { get; set; }

        public bool especialidade_ativa { get; set; }

        public string especialidade_dataCadastro { get; set; }
    }
}
