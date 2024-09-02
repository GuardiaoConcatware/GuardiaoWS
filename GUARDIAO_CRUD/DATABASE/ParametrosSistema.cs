using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUARDIAO_CRUD.DATABASE
{
    public class ParametrosSistema : DataBase
    {

        public GUARDIAO_STRUCTS.DATABASE.ParametrosSistema InsertParametrosSistema(GUARDIAO_STRUCTS.DATABASE.ParametrosSistema parametros)
        {
            string sql = "";
            int reg = 0;
            try
            {
                DeleteAllParametrosSistemas();
                sql = "INSERT INTO tblParametrosSistema";
                sql += " (parametroSistema_tempoMaximoEspera";
                sql += " ,parametroSistema_raioAtendimento";
                sql += " ,parametroSistema_atendimentosSimultaneos";
                sql += " ,parametroSistema_percentualGuardiao";
                sql += " ,parametroSistema_valorHora";
                sql += " ,parametroSistema_valorHoraPlantao";
                sql += " ,parametroSistema_cargaRecarga";
                sql += " ,parametroSistema_valorMinimoSaque";
                sql += " ,parametroSistema_valorMaximoSaque";
                sql += " ,parametroSistema_saldoMinimoAtendimento)";
                sql += " VALUES(?,?,?,?,?,?,?,?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"parametroSistema_tempoMaximoEspera", System.Data.OleDb.OleDbType.Numeric).Value = parametros.parametroSistema_tempoMaximoEspera;
                CM.Parameters.Add(@"parametroSistema_raioAtendimento", System.Data.OleDb.OleDbType.Numeric).Value = parametros.parametroSistema_raioAtendimento;
                CM.Parameters.Add(@"parametroSistema_atendimentosSimultaneos", System.Data.OleDb.OleDbType.Numeric).Value = parametros.parametroSistema_atendimentosSimultaneos;
                CM.Parameters.Add(@"parametroSistema_percentualGuardiao", System.Data.OleDb.OleDbType.Numeric).Value = parametros.parametroSistema_percentualGuardiao;
                CM.Parameters.Add(@"parametroSistema_valorHora", System.Data.OleDb.OleDbType.Decimal).Value = parametros.parametroSistema_valorHora;
                CM.Parameters.Add(@"parametroSistema_valorHoraPlantao", System.Data.OleDb.OleDbType.Decimal).Value = parametros.parametroSistema_valorHoraPlantao;
                CM.Parameters.Add(@"parametroSistema_cargaRecarga", System.Data.OleDb.OleDbType.Decimal).Value = parametros.parametroSistema_cargaRecarga;
                CM.Parameters.Add(@"parametroSistema_valorMinimoSaque", System.Data.OleDb.OleDbType.Decimal).Value = parametros.parametroSistema_valorMinimoSaque;
                CM.Parameters.Add(@"parametroSistema_valorMaximoSaque", System.Data.OleDb.OleDbType.Decimal).Value = parametros.parametroSistema_valorMaximoSaque;
                CM.Parameters.Add(@"parametroSistema_saldoMinimoAtendimento", System.Data.OleDb.OleDbType.Decimal).Value = parametros.parametroSistema_saldoMinimoAtendimento;

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao salvar parâmetros do sistema no servidor.");
            }
            catch (Exception ex)
            {
                if (parametros == null)
                    parametros = new GUARDIAO_STRUCTS.DATABASE.ParametrosSistema();
                parametros.resultCode = -1;
                parametros.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ParametrosSistema).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return parametros;
        }

        public GUARDIAO_STRUCTS.DATABASE.ParametrosSistema GetParametrosSistema()
        {
            string sql = "";
            DataSet ds = null;
            GUARDIAO_STRUCTS.DATABASE.ParametrosSistema parametros = null;
            try
            {
                sql = "SELECT parametroSistema_id";
                sql += " ,parametroSistema_tempoMaximoEspera";
                sql += " ,parametroSistema_raioAtendimento";
                sql += " ,parametroSistema_atendimentosSimultaneos";
                sql += " ,parametroSistema_percentualGuardiao";
                sql += " ,parametroSistema_valorHora";
                sql += " ,parametroSistema_valorHoraPlantao";
                sql += " ,parametroSistema_cargaRecarga";
                sql += " ,parametroSistema_valorMinimoSaque";
                sql += " ,parametroSistema_valorMaximoSaque";
                sql += " ,parametroSistema_saldoMinimoAtendimento";
                sql += " FROM tblParametrosSistema";

                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Nenhum parâmetro encontrado no servidor.");

                parametros = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.ParametrosSistema>();

            }
            catch (Exception ex)
            {
                if (parametros == null)
                    parametros = new GUARDIAO_STRUCTS.DATABASE.ParametrosSistema();
                parametros.resultCode = -1;
                parametros.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ParametrosSistema).Namespace);
            }

            return parametros;
        }

        private void DeleteAllParametrosSistemas()
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "DELETE FROM tblParametrosSistema";
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao apagar parâmetros do sistema no servidor.");
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ParametrosSistema).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
        }

    }
}
