using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class Atendimento
    {
        GUARDIAO_CRUD.DATABASE.Atendimento objAtendimento = null;
        public string GetAllAtendimentosByStatus(bool atendimentoStatus)
        {

            List<GUARDIAO_STRUCTS.DATABASE.Atendimento> atendimentos = null;
            try
            {
                objAtendimento = new GUARDIAO_CRUD.DATABASE.Atendimento();
                atendimentos = objAtendimento.GetAllAtendimentosByStatus(atendimentoStatus);
            }
            catch (Exception ex)
            {
                atendimentos = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimento).Namespace);
            }

            return JsonConvert.SerializeObject(atendimentos);
        }
    }
}
