using GUARDIAO_COMMOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD.ASAAS
{
    public class CustomerCrud : DataBase
    {
        public GUARDIAO_STRUCTS.DATABASE.ASAAS.CustomerSaida InsertCustomerCrud(GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer customer)
        {
            GUARDIAO_HELPER_ASAAS.REST.ApiHelper apiHelper = new GUARDIAO_HELPER_ASAAS.REST.ApiHelper();
            GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer customerInsert = null;
            GUARDIAO_STRUCTS.DATABASE.ASAAS.CustomerSaida customerInsertSaida = null;
            GUARDIAO_STRUCTS.DATABASE.ASAAS.Errors errors = new GUARDIAO_STRUCTS.DATABASE.ASAAS.Errors();
            string sql = "";
            int reg = 0;
            bool resul = true;
            try
            {
                customerInsertSaida = apiHelper.InsertCustomer(customer);
                if (customer == null)
                    throw new Exception(errors.code);
                sql = "INSERT INTO tblcustomer";
                sql += " (id";
                sql += " , name";
                sql += " , email";
                sql += " , phone";
                sql += " , addressNumber";
                sql += " , postalCode";
                sql += " , cpfCnpj";
                sql += " , personType";
                sql += " , deleted";
                sql += " , notificationDisabled";
                sql += " , canDelete";
                sql += " , cannotBeDeletedReason";
                sql += " , canEdit";
                sql += " , cannotEditReason)";
                sql += " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                OpenDataBase();
                CM = new System.Data.OleDb.OleDbCommand(sql, CN);
                CM.Parameters.Add(@"id", System.Data.OleDb.OleDbType.VarChar).Value = customerInsertSaida.id;
                CM.Parameters.Add(@"name", System.Data.OleDb.OleDbType.VarChar).Value = customerInsertSaida.name;
                CM.Parameters.Add(@"email", System.Data.OleDb.OleDbType.VarChar).Value = customerInsertSaida.email;
                CM.Parameters.Add(@"phone", System.Data.OleDb.OleDbType.VarChar).Value = customerInsertSaida.phone;
                CM.Parameters.Add(@"addressNumber", System.Data.OleDb.OleDbType.VarChar).Value = customerInsertSaida.addressNumber;
                CM.Parameters.Add(@"postalCode", System.Data.OleDb.OleDbType.VarChar).Value = customerInsertSaida.postalCode;
                CM.Parameters.Add(@"cpfCnpj", System.Data.OleDb.OleDbType.VarChar).Value = customerInsertSaida.cpfCnpj;
                CM.Parameters.Add(@"personType", System.Data.OleDb.OleDbType.VarChar).Value = customerInsertSaida.personType;
                CM.Parameters.Add(@"deleted", System.Data.OleDb.OleDbType.Boolean).Value = customerInsertSaida.deleted;
                CM.Parameters.Add(@"notificationDisabled", System.Data.OleDb.OleDbType.Boolean).Value = customerInsertSaida.notificationDisabled;
                CM.Parameters.Add(@"canDelete", System.Data.OleDb.OleDbType.Boolean).Value = customerInsertSaida.canDelete;
                CM.Parameters.Add(@"cannotBeDeletedReason", System.Data.OleDb.OleDbType.Boolean).Value = customerInsertSaida.cannotBeDeletedReason;
                CM.Parameters.Add(@"canEdit", System.Data.OleDb.OleDbType.Boolean).Value = customerInsertSaida.canEdit;
                CM.Parameters.Add(@"cannotEditReason", System.Data.OleDb.OleDbType.Boolean).Value = customerInsertSaida.cannotEditReason;
                reg = CM.ExecuteNonQuery();
                if (reg == 0)
                    throw new Exception("OCORREU UM PROBLEMA AO SALVAR O QrCode");
            }
            catch (Exception ex)
            {

                if (customerInsertSaida == null)
                {
                    customerInsertSaida = new GUARDIAO_STRUCTS.DATABASE.ASAAS.CustomerSaida();
                    //customer.code = ex.Message;
                   // customer.description = ex.Message;
                }
            }
            finally
            {
                CloseDataBase();
            }
            return customerInsertSaida;
        }

        public GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer GetCustomer()
        {
            GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer customer = null;
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = " SELECT * FROM tblcustomer";
                ds = ExecuteSelect(sql);
                if (ds == null)
                {
                    throw new Exception("NENHUM QR CODE ENCONTRADO");
                }
                customer = ds.Tables["T"].Rows[0].DataRowToBoject<GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer>();
            }
            catch (Exception ex)
            {
                if (customer == null)
                {
                    customer = new GUARDIAO_STRUCTS.DATABASE.ASAAS.Customer();
                    //customer.resultCode = -1;
                    //customer.code = ex.Message;
                }
            }
            return customer;
        }
    }
}
