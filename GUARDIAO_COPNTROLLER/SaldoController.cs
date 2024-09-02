using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER
{
    public class SaldoController
    {
        GUARDIAO_CRUD.DATABASE.SaldoCrud objectSaldo = null;
        public string GetSaldo(long usuario_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Saldo saldo = null;
            try
            {
                objectSaldo = new GUARDIAO_CRUD.DATABASE.SaldoCrud();
                saldo = objectSaldo.GetSaldoByUsuarioId(usuario_id);
            }
            catch (Exception)
            {

                throw;
            }
            return JsonConvert.SerializeObject(saldo);
        }
    }
}
