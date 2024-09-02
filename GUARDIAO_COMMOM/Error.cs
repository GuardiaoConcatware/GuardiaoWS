using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_COMMOM
{
    public static class Error
    {
        public static void CreateLogError(Exception ex, string metodo, string nameSpace)
        {

            try
            {
                FileLog.createFileLog(ex, metodo, nameSpace);
            }
            catch (Exception)
            {
                return;
            }
        }
        static class FileLog
        {
            public static string pathFile = Directory.LOGS_PATH;

            public static void createFileLog(Exception e, string metodo, string nameSpace)
            {
                string[] aux;
                try
                {

                    System.IO.TextWriter tw = new System.IO.StreamWriter(pathFile + @"\log_" + metodo + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".ini", true);
                    tw.WriteLine("[DETECTED ERROR]");
                    if (e.Source != null)
                        tw.WriteLine("SOURCE=" + e.Source.ToUpper());
                    if (e.StackTrace != null)
                    {
                        aux = e.StackTrace.Split('\r');
                        tw.WriteLine("STACKTRACE=" + aux[aux.Length - 1].Replace("\n", "").Trim().ToUpper());
                    }
                    if (e.Message != null)
                        tw.WriteLine("EXCEPTION=" + e.Message.ToUpper());
                    tw.WriteLine("NAMESPACE=" + nameSpace);
                    tw.WriteLine("METHODE=" + metodo.ToUpper());
                    tw.Close();
                }
                catch (Exception)
                {
                }

            }
            public static string GetCurrentMethod(Exception e)
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(e);
                return st.GetFrame(0).GetMethod().Name;
            }
        }
    }
}
