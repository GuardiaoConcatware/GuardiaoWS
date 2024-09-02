using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_STRUCTS.DATABASE
{
    public class ParametrosSistema : Result
    {
        public long parametroSistema_id { get; set; }

        public long parametroSistema_tempoMaximoEspera { get; set; }

        public long parametroSistema_raioAtendimento { get; set; }

        public long parametroSistema_atendimentosSimultaneos { get; set; }

        public long parametroSistema_percentualGuardiao { get; set; }

        public decimal parametroSistema_valorHora { get; set; }

        public decimal parametroSistema_valorHoraPlantao { get; set; }

        public decimal parametroSistema_cargaRecarga { get; set; }

        public decimal parametroSistema_valorMinimoSaque { get; set; }

        public decimal parametroSistema_valorMaximoSaque { get; set; }

        public decimal parametroSistema_saldoMinimoAtendimento { get; set; }
    }
}
