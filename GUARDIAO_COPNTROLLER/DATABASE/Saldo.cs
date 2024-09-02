using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CONTROLLER.DATABASE
{
    public class Saldo
    {
        private GUARDIAO_CRUD.DATABASE.SaldoCrud objSaldo = null;
        public string SaveSaldoUsuario(string json, int tipoExtrato_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Saldo saldo = null;

            try
            {
                saldo = JsonConvert.DeserializeObject<GUARDIAO_STRUCTS.DATABASE.Saldo>(json);
                objSaldo = new GUARDIAO_CRUD.DATABASE.SaldoCrud();
                saldo = objSaldo.SaveSaldoUsuario(saldo, tipoExtrato_id);
            }
            catch (Exception ex)
            {
                if (saldo == null)
                    saldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                saldo.resultCode = -1;
                saldo.resultDescription = ex.Message;
            }
            return JsonConvert.SerializeObject(saldo);
        }
    }
}
