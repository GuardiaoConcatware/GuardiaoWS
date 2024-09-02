using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.ASAAS
{
    public class QrCodeCrud : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida InsertQrCode(GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstatico qrCodeEstatico)
        {
            GUARDIAO_HELPER_ASAAS.REST.ApiHelper apiHelper = new GUARDIAO_HELPER_ASAAS.REST.ApiHelper();
            GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstatico qrCode = null;
            GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida qrCodeEstaticoSaida = null;
            GUARDIAO_STRUCTS.DATABASE.ASAAS.Errors errors = new GUARDIAO_STRUCTS.DATABASE.ASAAS.Errors();
            GUARDIAO_CRUD.ASAAS.ChavePixGuardiaoCrud chavePixGuardiaoCrud = null;

            string sql = "";
            int reg = 0;
            bool resul = true;
            try
            {
                qrCodeEstaticoSaida = apiHelper.QrcodeEstatico(qrCode);
                if (qrCodeEstatico == null)
                    throw new Exception(qrCodeEstatico.description);
                sql = "INSERT INTO tblQrCodeEstatico";
                sql += " (id";
                sql += " , encodeImage";
                sql += " , payload";
                sql += " , allowsMultiplePayments";
                sql += " , expirationDate";
                sql += " , externalReference)";
                sql += " VALUES(?,?,?,?,?,?)";
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"id", System.Data.OleDb.OleDbType.VarChar).Value = qrCodeEstaticoSaida.id;
                CM.Parameters.Add(@"encodeImage", System.Data.OleDb.OleDbType.LongVarChar).Value = qrCodeEstaticoSaida.encodedImage;
                CM.Parameters.Add(@"payload", System.Data.OleDb.OleDbType.VarChar).Value = qrCodeEstaticoSaida.payload;
                CM.Parameters.Add(@"allowsMultiplePayments", System.Data.OleDb.OleDbType.Boolean).Value = qrCodeEstaticoSaida.allowsMultiplePayments;
                CM.Parameters.Add(@"expirationDate", System.Data.OleDb.OleDbType.VarChar).Value = qrCodeEstaticoSaida.expirationDate;
                CM.Parameters.Add(@"externalReference", System.Data.OleDb.OleDbType.VarChar).Value = qrCodeEstaticoSaida.externalReference;
                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO SALVAR O QrCode");
            }
            catch (Exception ex)
            {

                if (qrCodeEstaticoSaida == null)
                {
                    qrCodeEstaticoSaida = new GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida();
                    //qrCodeEstatico.code = ex.Message;
                    errors.description = ex.Message;
                }
            }
            finally
            {
                CloseDataBase();
            }
            return qrCodeEstaticoSaida;
        }

        public GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida GetQrCode()
        {
            GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida qrCodeEstatico = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = " SELECT payload FROM tblQrCodeEstatico";
                ds = ExecuteSelect(sql);
                if (ds == null)
                {
                    throw new Exception("NENHUM QR CODE ENCONTRADO");
                }
                qrCodeEstatico = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida>();
            }
            catch (Exception ex)
            {
                if (qrCodeEstatico == null)
                {
                    qrCodeEstatico = new GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstaticoSaida();
                    //qrCodeEstatico.resultCode = -1;
                    //qrCodeEstatico.resultDescription = ex.Message;
                }
            }
            return qrCodeEstatico;
        }
        /*
        public GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstatico UpdateQrCode(GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstatico qrCodeEstatico)
        {
            string sql = "";
            int reg = 0;
            try
            {

                sql = "UPDATE tblQrCodeEstatico SET";
                sql += " (id";
                sql += " , encodeImage";
                sql += " , payload";
                sql += " , allowsMultiplePayments";
                sql += " , expirationDate";
                sql += " , externalReference";
                sql += " , addressKey";
                sql += " , description";
                sql += " , value";
                sql += " , format";
                sql += " , expirationSeconds)";
                sql += " VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                OpenDataBase();
                reg = CM.ExecuteNonQuery();
                if(reg == 0)
                {
                    throw new Exception("Ocorreu um erro ao atualizar o QRCode");
                }

            }
            catch (Exception ex)
            {
                if(qrCodeEstatico == null)
                {
                    qrCodeEstatico = new GUARDIAO_STRUCTS.DATABASE.ASAAS.QrCodeEstatico();
                    qrCodeEstatico.resultCode = -1;
                    qrCodeEstatico.resultDescription = ex.Message;
                }
            }
            return qrCodeEstatico;
        }
        */
    }
}
