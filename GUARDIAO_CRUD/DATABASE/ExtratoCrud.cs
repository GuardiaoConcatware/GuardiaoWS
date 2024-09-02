using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.DATABASE
{
    public class ExtratoCrud : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.ExtratosList GetExtrato(long usuario_id)
        {
            GUARDIAO_STRUCTS.DATABASE.ExtratosList extrato = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT extrato_id";
                sql += " ,usuario_id";
                sql += " ,tipoExtrato_id";
                sql += " ,atendimento_id";
                sql += " ,extrato_valor";
                sql += " ,extrato_valorPercentual";
                sql += " ,extrato_tempo";
                sql += " ,extrato_totalMinutosOcioso";
                sql += " ,extrato_dataCadastro";
                sql += " FROM tblExtrato";
                sql += " WHERE usuario_id = " + usuario_id;
                sql += " ORDER BY extrato_id DESC";

                ds = ExecuteSelect(sql);
                if (ds == null)
                {
                    throw new Exception("NENHUM EXTRATO ENCONTRADO");

                }
                extrato = new GUARDIAO_STRUCTS.DATABASE.ExtratosList();
                extrato.extratoList = new List<GUARDIAO_STRUCTS.DATABASE.Extrato>();

                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    extrato.extratoList.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Extrato>());
                }
            }
            catch (Exception ex)
            {
                if (extrato == null)
                {
                    extrato = new GUARDIAO_STRUCTS.DATABASE.ExtratosList();
                    extrato.resultCode = -1;
                    extrato.resultDescription = ex.Message;
                }
            }
            return extrato;
        }

        public GUARDIAO_STRUCTS.DATABASE.Extrato InsertExtrato(GUARDIAO_STRUCTS.DATABASE.Extrato extrato)
        {
            string sql = "";
            int reg = 0;
            try
            {
                sql = "INSERT INTO tblExtrato";
                sql += " (usuario_id";
                sql += " ,tipoExtrato_id";
                sql += " ,atendimento_id";
                sql += " ,extrato_valor";
                sql += " ,extrato_valorPercentual";
                sql += " ,extrato_totalMinutosOcioso";
                sql += " ,extrato_tempo";
                sql += " ,extrato_dataCadastro)";
                sql += " VALUES(?,?,?,?,?,?,?,?)";

                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"usuario_id", System.Data.OleDb.OleDbType.Numeric).Value = extrato.usuario_id;
                CM.Parameters.Add(@"tipoExtrato_id", System.Data.OleDb.OleDbType.Numeric).Value = extrato.tipoExtrato_id;
                CM.Parameters.Add(@"atendimento_id", System.Data.OleDb.OleDbType.Numeric).Value = extrato.atendimento_id;
                CM.Parameters.Add(@"extrato_valor", System.Data.OleDb.OleDbType.Decimal).Value = extrato.extrato_valor;
                CM.Parameters.Add(@"extrato_valorPercentual", System.Data.OleDb.OleDbType.Decimal).Value = extrato.extrato_valorPercentual;
                CM.Parameters.Add(@"extrato_totalMinutosOcioso", System.Data.OleDb.OleDbType.VarChar).Value = extrato.extrato_totalMinutosOcioso;
                CM.Parameters.Add(@"extrato_tempo", System.Data.OleDb.OleDbType.VarChar).Value = extrato.extrato_tempo;
                CM.Parameters.Add(@"extrato_dataCadastro", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO SALVAR O EXTRATO NO SERVIDOR.");


            }
            catch (Exception ex)
            {
                if (extrato == null)
                    extrato = new GUARDIAO_STRUCTS.DATABASE.Extrato();
                extrato.resultCode = -1;
                extrato.resultDescription = ex.Message;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ExtratoCrud).Namespace);
            }
            finally
            {
                CloseDataBase();
            }
            return extrato;
        }

        public GUARDIAO_STRUCTS.DATABASE.ExtratosList GetExtratoByFiltro(GUARDIAO_STRUCTS.DATABASE.FiltroExtrato filtro)
        {
            GUARDIAO_STRUCTS.DATABASE.ExtratosList extrato = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "SELECT extrato_id";
                sql += " ,tblUsuario.usuario_id";
                sql += " ,tblUsuario.usuario_nome";
                sql += " ,tipoExtrato_id";
                sql += " ,atendimento_id";
                sql += " ,extrato_valor";
                sql += " ,extrato_valorPercentual";
                sql += " ,extrato_totalMinutosOcioso";
                sql += " ,extrato_tempo";
                sql += " ,extrato_dataCadastro";
                sql += " FROM tblExtrato";
                sql += " INNER JOIN tblUsuario ON tblUsuario.usuario_id = tblExtrato.usuario_id";
                sql += " WHERE CONVERT(CHAR(10) ,extrato_dataCadastro, 121) BETWEEN '" + Convert.ToDateTime(filtro.extrato_dataInicial).ToString("yyyy-MM-dd") + "' AND '" + Convert.ToDateTime(filtro.extrato_dataFinal).ToString("yyyy-MM-dd") + "'";

                if (filtro.usuario_id != 0)
                    sql += " AND tblUsuario.usuario_id = " + filtro.usuario_id;
                if (filtro.tipoExtrato_id != 0)
                    sql += " AND tipoExtrato_id = " + filtro.tipoExtrato_id;

                sql += "ORDER BY extrato_dataCadastro DESC";

                ds = ExecuteSelect(sql);
                if (ds == null)
                {
                    throw new Exception("NENHUM EXTRATO ENCONTRADO");

                }
                extrato = new GUARDIAO_STRUCTS.DATABASE.ExtratosList();
                extrato.extratoList = new List<GUARDIAO_STRUCTS.DATABASE.Extrato>();

                for (int i = 0; i < ds.Tables["T"].Rows.Count; i++)
                {
                    extrato.extratoList.Add(ds.Tables["T"].Rows[i].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.Extrato>());
                }
            }
            catch (Exception ex)
            {
                if (extrato == null)
                {
                    extrato = new GUARDIAO_STRUCTS.DATABASE.ExtratosList();
                    extrato.resultCode = -1;
                    extrato.resultDescription = ex.Message;
                }
            }
            return extrato;
        }
    }
}