using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_CRUD
{
    public class DataBase
    {
        protected OleDbConnection CN = null;
        protected OleDbCommand CM = null;
        protected OleDbDataAdapter DA = null;

        private string SERVER = GUARDIAO_COMMOM.RWIni.IniReadValue(GUARDIAO_COMMOM.Directory.CONFIG_PATH + @"guardiaoCnfgIni.ini", "DATABASE", "SERVER");
        private string DATABASE = GUARDIAO_COMMOM.RWIni.IniReadValue(GUARDIAO_COMMOM.Directory.CONFIG_PATH + @"guardiaoCnfgIni.ini", "DATABASE", "DATABASE");
        private string USER = GUARDIAO_COMMOM.RWIni.IniReadValue(GUARDIAO_COMMOM.Directory.CONFIG_PATH + @"guardiaoCnfgIni.ini", "DATABASE", "USER");
        private string PASSWORDS = GUARDIAO_COMMOM.Crypto.DecryptSentence(GUARDIAO_COMMOM.RWIni.IniReadValue(GUARDIAO_COMMOM.Directory.CONFIG_PATH + @"\guardiaoCnfgIni.ini", "DATABASE", "PASSWORD"));
        private string TIMEOUT = GUARDIAO_COMMOM.RWIni.IniReadValue(GUARDIAO_COMMOM.Directory.CONFIG_PATH + @"guardiaoCnfgIni.ini", "DATABASE", "TIMEOUT");

        private string strConnection = "";


        public DataBase()
        {
            strConnection = @"Provider=SQLOLEDB.1;Password=" + PASSWORDS + ";Persist Security Info=True;User ID=" + USER + ";Initial Catalog=" + DATABASE + ";Data Source=" + SERVER;
        }

        protected bool OpenDataBase()
        {
            bool resul = true;
            try
            {

                if (CN != null)
                {
                    if (CN.State != System.Data.ConnectionState.Closed)
                    {
                        CN.Close();
                        CN.Dispose();
                    }
                    CN = null;
                }

                CN = new OleDbConnection(strConnection);
                CN.Open();
            }
            catch (Exception ex)
            {
                resul = false;
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(DataBase).Namespace);
            }
            return resul;
        }

        protected void CloseDataBase()
        {
            try
            {
                if (CN != null)
                {
                    if (CN.State != System.Data.ConnectionState.Closed)
                    {
                        CN.Close();
                        CN.Dispose();
                    }
                    CN = null;
                }

                if (CM != null)
                    CM.Dispose();
                if (DA != null)
                    DA.Dispose();

                CM = null;
                DA = null;
            }
            catch (Exception ex)
            {
                GUARDIAO_COMMOM.Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(DataBase).Namespace);
            }
        }

        protected DataSet ExecuteSelect(string qry)
        {
            DataSet ds = new DataSet();
            try
            {
                OpenDataBase();
                CM = new OleDbCommand(qry, CN);
                DA = new OleDbDataAdapter(CM);
                DA.Fill(ds, "T");
                CloseDataBase();

                if (ds == null)
                    throw new Exception("OCORREU UM PROBLEMA AO BUSCAR ITENS NO DATA CENTER.");
                if (!ds.Tables.Contains("T"))
                    throw new Exception("OCORREU UM PROBLEMA AO BUSCAR ITENS NO DATA CENTER.");
                if (ds.Tables["T"].Rows.Count == 0)
                    throw new Exception("NEHUM ITEM ENCONTRADO NO DATA CENTER.\nSQL:" + qry);

            }
            catch (Exception ex)
            {
                ds = null;

            }

            return ds;
        }
    }
}
