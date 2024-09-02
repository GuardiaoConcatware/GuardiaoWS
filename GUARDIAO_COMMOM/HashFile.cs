using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_COMMOM
{
    public static class HashFile
    {
        private static SHA256 sH256 = null;

        public static string GetHash256(string pathFile)
        {
            string resul = "";
            try
            {
                sH256 = SHA256.Create();
                using (FileStream stream = File.OpenRead(pathFile))
                {
                    resul = BytesToString(sH256.ComputeHash(stream));
                }
            }
            catch (Exception)
            {
                resul = "";
            }
            return resul;
        }
        public static string BytesToString(byte[] buffer)
        {
            string resul = "";
            try
            {
                foreach (byte b in buffer)
                    resul += b.ToString("x2");
            }
            catch (Exception)
            {
                resul = "";
            }
            return resul;
        }
    }
}
