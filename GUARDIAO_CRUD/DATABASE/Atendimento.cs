using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
   public  class Atendimento: DataBase
    {
        public List<GUARDIAO_STRUCTS.DATABASE.Atendimento> GetAllAtendimentosByStatus(bool status)
        {
            string sql = "";
            DataSet ds = null;
            List<GUARDIAO_STRUCTS.DATABASE.Atendimento> atendimentos = null;
            try
            {
                sql += " atendimento_id";
                sql += " , solicitacaoAtendimento_id";
                sql += " , atendimento_status";
                sql += " , usuario_id";
                sql += " , advogado_id";
                sql += " , dataInicio_atendimentof";
                sql += " , dataFim_atendimento";
                sql += " FROM tblAtendimento";
                sql += " WHERE atendimento_status = " + status;
               // sql += " ORDER BY empresa_razaoSocial";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhuma empresa encontrada para o parÂmetro informado.");

                atendimentos = new List<GUARDIAO_STRUCTS.DATABASE.Atendimento>();
                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    atendimentos.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Atendimento>());
                }


            }
            catch (Exception ex)
            {
                atendimentos = null;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(Atendimento).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return atendimentos;
        }
    }
}
