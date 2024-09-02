using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.ASAAS
{
    public class ChavePixGuardiaoCrud : DataBase
    {

        public GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePixSaida InsertChavePix(GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePix createPix)
        {
            GUARDIAO_HELPER_ASAAS.REST.ApiHelper apiHelper = new GUARDIAO_HELPER_ASAAS.REST.ApiHelper();
            GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePixSaida createPixSaida = new GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePixSaida();
            GUARDIAO_STRUCTS.DATABASE.ASAAS.Errors erros = new GUARDIAO_STRUCTS.DATABASE.ASAAS.Errors();

            string sql = "";
            int reg = 0;
            bool resul = true;
            try
            {
                createPixSaida = apiHelper.CriarChavePix(createPix);
                if (createPix != null)
                    throw new Exception(erros.description);
                sql = " INSERT INTO tblChavePixGuardiao";
                sql += " ( id";
                sql += " , key";
                sql += " , type";
                sql += " , status";
                sql += " , dateCreated";
                sql += " , canBeDeleted";
                sql += " , cannotBeDeletedReason";
                sql += " , encodedImage";
                sql += " , payload)";
                sql += " VALUES(?,?,?,?,?,?,?,?,?)";
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"id", System.Data.OleDb.OleDbType.VarChar).Value = createPixSaida.id;
                CM.Parameters.Add(@"key", System.Data.OleDb.OleDbType.VarChar).Value = createPixSaida.key;
                CM.Parameters.Add(@"type", System.Data.OleDb.OleDbType.VarChar).Value = createPixSaida.type;
                CM.Parameters.Add(@"status", System.Data.OleDb.OleDbType.VarChar).Value = createPixSaida.status;
                CM.Parameters.Add(@"dateCreated", System.Data.OleDb.OleDbType.VarChar).Value = createPixSaida.dateCreated;
                CM.Parameters.Add(@"canBeDeleted", System.Data.OleDb.OleDbType.Boolean).Value = createPixSaida.canBeDeleted;
                CM.Parameters.Add(@"cannotBeDeletedReason", System.Data.OleDb.OleDbType.VarChar).Value = createPixSaida.cannotBeDeletedReason;
                CM.Parameters.Add(@"payload", System.Data.OleDb.OleDbType.VarChar).Value = createPixSaida.qrCode.payload;
                CM.Parameters.Add(@"encodedImage", System.Data.OleDb.OleDbType.VarChar).Value = createPixSaida.qrCode.encodedImage;
                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO SALVAR A CHAVE PIX");
            }
            catch (Exception ex)
            {
                if (createPixSaida == null)
                {
                    createPixSaida = new GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePixSaida();
                }
                //createPixSaida.code = ex.Message;
                //createPixSaida.description = ex.Message;
            }
            finally
            {
                CloseDataBase();
            }
            return createPixSaida;
        }

        public GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePix GetCreatePix()
        {
            GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePix createPix = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = " SELECT * FROM tblChavePixGuardiao";
                ds = ExecuteSelect(sql);
                if (ds == null)
                {
                    throw new Exception("NENHUMA CHAVE PIX ENCONTRADA");
                }
                createPix = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePix>();

            }
            catch (Exception ex)
            {
                if (createPix == null)
                {
                    createPix = new GUARDIAO_STRUCTS.DATABASE.ASAAS.CreatePix();
                    //createPix.resultCode = -1;
                    //createPix.description = ex.Message;
                }
            }
            return createPix;
        }
    }
}
