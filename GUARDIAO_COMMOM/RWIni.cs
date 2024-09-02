using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_COMMOM
{
    public static class RWIni
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName,
            byte[] lpszReturnBuffer, int nSize, string lpFileName);

        public static void IniWriteValue(string path, string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        public static string IniReadValue(string path, string Section, string Key)
        {

            try
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp,
                                                255, path);
                return temp.ToString();
            }
            catch (Exception ex)
            {

                return "";
            }

        }

        public static List<string> GetKeysFromSection(string iniFile, string category)
        {

            try
            {
                byte[] buffer = new byte[2048];

                GetPrivateProfileSection(category, buffer, 2048, iniFile);
                String[] tmp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');

                List<string> result = new List<string>();

                foreach (String entry in tmp)
                {
                    result.Add(entry.Substring(0, entry.IndexOf("=")));
                }

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
