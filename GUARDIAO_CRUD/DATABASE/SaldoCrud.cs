using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class SaldoCrud : DataBase
    {
        public double GetSaldo(long usuario_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Saldo saldo = null;
            double saldoAtual = 0;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = " SELECT saldo FROM tblSaldo WHERE usuario_id = " + usuario_id;
                ds = ExecuteSelect(sql);
                if (ds == null)
                {
                    throw new Exception("SALDO NÃO ENCONTRADO");
                }
                saldo = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Saldo>();
                saldoAtual = Convert.ToDouble(saldo.saldo_valor);
            }
            catch (Exception ex)
            {
                if (saldo == null)
                {
                    saldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                    saldo.resultCode = -1;
                    saldo.resultDescription = ex.Message;
                }
            }
            return saldoAtual;
        }

        public GUARDIAO_STRUCTS.DATABASE.Saldo GetSaldoByUsuarioId(long usuario_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Saldo saldo = null;

            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT saldo_id";
                sql += " ,usuario_id";
                sql += " ,saldo_valor";
                sql += " ,saldo_horas";
                sql += " ,saldo_ultimaAtualizacao";
                sql += " FROM tblSaldo";
                sql += " WHERE usuario_id = " + usuario_id;
                ds = ExecuteSelect(sql);
                if (ds == null)
                {
                    throw new Exception("SALDO NÃO ENCONTRADO");
                }
                saldo = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Saldo>();
            }
            catch (Exception ex)
            {
                if (saldo == null)
                {
                    saldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                    saldo.resultCode = -1;
                    saldo.resultDescription = ex.Message;
                }
            }
            return saldo;
        }

        public GUARDIAO_STRUCTS.DATABASE.Saldo UpdateSaldo(GUARDIAO_STRUCTS.DATABASE.Extrato extrato)
        {
            string sql = "";
            long reg = 0;
            double valor = 0;
            //GUARDIAO_STRUCTS.DATABASE.Extrato extrato = new GUARDIAO_STRUCTS.DATABASE.Extrato();
            GUARDIAO_STRUCTS.DATABASE.Saldo saldo = null;
            try
            {
                sql = "UPDATE tblSaldo SET";
                sql += " usuario_id = ?";
                sql += " ,saldo = ?";
                sql += " WHERE usuario_id = " + extrato.usuario_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = extrato.usuario_id;
                switch (extrato.tipoExtrato_id)
                {
                    case 0:
                        valor = Convert.ToDouble(extrato.extrato_valor);
                        break;
                    case 1:
                        valor = Convert.ToDouble(extrato.extrato_valor);
                        break;
                    case 2:
                        valor = Convert.ToDouble(extrato.extrato_valor);
                        break;
                }
                CM.Parameters.Add(@"saldo", System.Data.OleDb.OleDbType.Double).Value = valor;

                reg = Convert.ToInt64(CM.ExecuteNonQuery());
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO ATUALIZAR O  SALDO NO SERVIDOR.");



            }
            catch (Exception ex)
            {
                if (extrato == null)
                    extrato = new GUARDIAO_STRUCTS.DATABASE.Extrato();
                extrato.resultCode = -1;
                extrato.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SaldoCrud).Namespace);
            }
            finally
            {
                CloseDataBase();
            }

            return saldo;
        }

        public GUARDIAO_STRUCTS.DATABASE.Saldo SaveSaldoUsuario(GUARDIAO_STRUCTS.DATABASE.Saldo saldo, long tipoExtrato_id)
        {
            try
            {
                if (VerificaSaldoUsuarioExiste(saldo.usuario_id))
                    saldo = UpDateSaldoUsuario(saldo, tipoExtrato_id);
                else
                    saldo = InsertSaldoUsuario(saldo);
            }
            catch (Exception ex)
            {
                if (saldo == null)
                    saldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                saldo.resultCode = -1;
                saldo.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SaldoCrud).Namespace);
            }
            return saldo;
        }

        private GUARDIAO_STRUCTS.DATABASE.Saldo UpDateSaldoUsuario(GUARDIAO_STRUCTS.DATABASE.Saldo saldo, long tipoExtrato_id)
        {
            string sql = "";
            int reg = 0;
            GUARDIAO_STRUCTS.DATABASE.Saldo saldoExtrato = null;
            try
            {


                saldoExtrato = saldo;
                saldo = CalculaSaldo(saldo, tipoExtrato_id);
                if (saldo.resultCode != 0)
                    throw new Exception(saldo.resultDescription);

                sql = "UPDATE tblSaldo";
                sql += " SET usuario_id = ?";
                sql += " , saldo_valor = ?";
                sql += " , saldo_horas = ?";
                sql += " , saldo_ultimaAtualizacao = ?";
                sql += " WHERE usuario_id = " + saldo.usuario_id;

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = saldo.usuario_id;
                CM.Parameters.Add(@"saldo_valor", System.Data.OleDb.OleDbType.Decimal).Value = saldo.saldo_valor;
                CM.Parameters.Add(@"saldo_horas", System.Data.OleDb.OleDbType.VarChar).Value = saldo.saldo_horas;
                CM.Parameters.Add(@"saldo_ultimaAtualizacao", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao incluir saldo do usuario no servidor.");
                if (tipoExtrato_id == 1)
                {
                    GUARDIAO_STRUCTS.DATABASE.Extrato extrato = SaveExtradoUsuario(saldoExtrato, tipoExtrato_id);
                    if (extrato.resultCode != 0)
                        throw new Exception("Saldo salvo com sucesso. Porém ocorreu um problema ao salvar extrato.");
                }


            }
            catch (Exception ex)
            {
                if (saldo == null)
                    saldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                saldo.resultCode = -1;
                saldo.resultDescription = ex.Message;
            }
            finally
            {
                CloseDataBase();
            }
            return saldo;
        }

        private GUARDIAO_STRUCTS.DATABASE.Saldo CalculaSaldo(GUARDIAO_STRUCTS.DATABASE.Saldo saldo, long tipoExtrato_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Saldo newSaldo = null;
            GUARDIAO_STRUCTS.DATABASE.Saldo oldSaldo = null;
            DateTime d1;
            DateTime d2;
            DateTime d3;

            try
            {
                newSaldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                oldSaldo = GetSaldoByUsuarioId(saldo.usuario_id);

                d1 = DateTime.Parse(oldSaldo.saldo_horas);
                d2 = DateTime.Parse(saldo.saldo_horas);
                d3 = d1.Add(d2.TimeOfDay);

                newSaldo.usuario_id = saldo.usuario_id;
                newSaldo.saldo_ultimaAtualizacao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                switch (tipoExtrato_id)
                {
                    //SOMA
                    case 1:
                    case 2:
                        newSaldo.saldo_valor = oldSaldo.saldo_valor + saldo.saldo_valor;
                        newSaldo.saldo_horas = d3.TimeOfDay.ToString();

                        break;
                    //SUBTRAI
                    case 3:
                        double auxTotal = (d1 - d2).TotalSeconds;
                        if (auxTotal < 0)
                            auxTotal *= -1;
                        TimeSpan timeSpan = TimeSpan.FromSeconds(auxTotal);
                        string tempo = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)timeSpan.TotalHours, (int)timeSpan.TotalMinutes, timeSpan.Seconds);
                        newSaldo.saldo_valor = oldSaldo.saldo_valor - saldo.saldo_valor;
                        newSaldo.saldo_horas = tempo;
                        break;
                    //SOMA
                    case 4:
                        newSaldo.saldo_valor = oldSaldo.saldo_valor + saldo.saldo_valor;
                        newSaldo.saldo_horas = d3.TimeOfDay.ToString();
                        break;
                    //SUBTRAI
                    case 5:
                        TimeSpan timeSpan2 = TimeSpan.FromSeconds((d1 - d2).TotalSeconds);
                        string tempo2 = string.Format("{0:D2}:{1:D2}:{2:D2}", (int)timeSpan2.TotalHours, (int)timeSpan2.TotalMinutes, timeSpan2.Seconds);
                        newSaldo.saldo_valor = oldSaldo.saldo_valor - saldo.saldo_valor;
                        newSaldo.saldo_horas = tempo2;
                        break;
                }


            }
            catch (Exception ex)
            {
                if (newSaldo == null)
                    newSaldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                newSaldo.resultCode = -1;
                newSaldo.resultDescription = ex.Message;
            }
            return newSaldo;
        }

        private GUARDIAO_STRUCTS.DATABASE.Saldo InsertSaldoUsuario(GUARDIAO_STRUCTS.DATABASE.Saldo saldo)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblSaldo";
                sql += " (usuario_id";
                sql += " ,saldo_valor";
                sql += " ,saldo_horas";
                sql += " ,saldo_ultimaAtualizacao)";
                sql += " VALUES(?,?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = saldo.usuario_id;
                CM.Parameters.Add(@"saldo_valor", System.Data.OleDb.OleDbType.Decimal).Value = saldo.saldo_valor;
                CM.Parameters.Add(@"saldo_horas", System.Data.OleDb.OleDbType.VarChar).Value = saldo.saldo_horas;
                CM.Parameters.Add(@"saldo_ultimaAtualizacao", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("Ocorreu um problema ao incluir saldo do usuario no servidor.");

                GUARDIAO_STRUCTS.DATABASE.Extrato extrato = SaveExtradoUsuario(saldo, 1);
                if (extrato.resultCode != 0)
                    throw new Exception("Saldo salvo com sucesso. Porém ocorreu um problema ao salvar extrato.");
            }
            catch (Exception ex)
            {
                if (saldo == null)
                    saldo = new GUARDIAO_STRUCTS.DATABASE.Saldo();
                saldo.resultCode = -1;
                saldo.resultDescription = ex.Message;
            }
            finally
            {
                CloseDataBase();
            }
            return saldo;
        }
        private bool VerificaSaldoUsuarioExiste(long usuario_id)
        {
            bool resul = true;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT COUNT(saldo_id) AS TOTAL FROM tblSaldo WHERE usuario_id = " + usuario_id;
                ds = ExecuteSelect(sql);
                if (ds == null)
                    throw new Exception("Ocorreu um problema ao salvar dados do saldo no servidor.");

                if (Convert.ToInt32(ds.Tables["T"].Rows[0]["TOTAL"]) == 0)
                    throw new Exception("Usuario não possui saldo.");
            }
            catch (Exception ex)
            {
                resul = false;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(SaldoCrud).Namespace);
            }
            return resul;
        }
        private GUARDIAO_STRUCTS.DATABASE.Extrato SaveExtradoUsuario(GUARDIAO_STRUCTS.DATABASE.Saldo saldo, long tipoExtrato_id)
        {
            GUARDIAO_STRUCTS.DATABASE.Extrato extrato = null;
            GUARDIAO_CRUD.DATABASE.ExtratoCrud objExtrato = null;
            try
            {
                extrato = new GUARDIAO_STRUCTS.DATABASE.Extrato();
                extrato.atendimento_id = 0;
                extrato.extrato_valor = saldo.saldo_valor;
                extrato.extrato_dataCadastro = "";
                extrato.extrato_tempo = "00:00";
                extrato.extrato_id = 0;
                extrato.extrato_valorPercentual = 0;
                extrato.extrato_totalMinutosOcioso = "0";
                extrato.tipoExtrato_id = tipoExtrato_id;
                extrato.usuario_id = saldo.usuario_id;
                extrato.usuario_nome = "";

                objExtrato = new ExtratoCrud();
                extrato = objExtrato.InsertExtrato(extrato);
            }
            catch (Exception ex)
            {
                if (extrato == null)
                    extrato = new GUARDIAO_STRUCTS.DATABASE.Extrato();
                extrato.resultCode = -1;
                extrato.resultDescription = ex.Message;
            }


            return extrato;
        }
    }
}