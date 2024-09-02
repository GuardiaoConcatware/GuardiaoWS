using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_COMMOM
{
    public static class Util
    {
        public static int MmToPixel(double mm)
        {
            double pixel = mm * dpi / milimetresPerInch;
            return (int)Math.Round(pixel);
        }
        public static int PixeltoMM(double px)
        {
            double mm = (px * 10) / milimetresPerInch;
            return (int)Math.Round(mm);
        }

        public static T DataRowToBoject<T>(this DataRow dataRow)
         where T : new()
        {
            T item = new T();
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                try
                {

                    PropertyInfo property = item.GetType().GetProperty(column.ColumnName, BindingFlags.SetProperty | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (property != null && dataRow[column] != DBNull.Value)
                    {
                        object result = Convert.ChangeType(dataRow[column], property.PropertyType, new CultureInfo("pt-BR"));
                        property.SetValue(item, result, null);
                    }
                }
                catch (Exception)
                {

                }

            }

            return item;
        }

        public static string FirstLetterToUpper(this string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1).ToLower();

            return str.ToUpper();
        }

        public static string mascaraCNPJ(string cnpj)
        {
            try
            {
                string aux = ("00000000000000" + cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Trim()).Substring((cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Trim().Length + 14) - 14);
                aux = aux.Insert(2, ".");
                aux = aux.Insert(6, ".");
                aux = aux.Insert(10, "/");
                aux = aux.Insert(15, "-");
                return aux;

            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string mascaraCPF(string cpf)
        {
            try
            {
                string aux = ("00000000000" + cpf.Replace(".", "").Replace("-", "").Replace("/", "").Trim()).Substring((cpf.Replace(".", "").Replace("-", "").Replace("/", "").Trim().Length + 11) - 11);
                aux = aux.Insert(3, ".");
                aux = aux.Insert(7, ".");
                aux = aux.Insert(11, "-");
                return aux;

            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            cpf = ("00000000000" + cpf).Substring(("00000000000" + cpf).Length - 11);

            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            cnpj = ("00000000000000" + cnpj).Substring(("00000000000000" + cnpj).Length - 14);

            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
        public static bool IsValidDateTimeTest(string dateTime)
        {
            string[] formats = { "yyyy-MM-dd" };
            DateTime parsedDateTime;
            return DateTime.TryParseExact(dateTime, formats, new CultureInfo("pt-BR"),
                                           DateTimeStyles.None, out parsedDateTime);
        }

        #region CONSTANTES

        const double milimetresPerInch = 25.4; // as one inch is 25.4 mm
        const double dpi = 72;

        #endregion

        #region DATASET HELPER  
        private static bool ColumnEqual(object A, object B)
        {
            // Compares two values to see if they are equal. Also compares DBNULL.Value.             
            if (A == DBNull.Value && B == DBNull.Value) //  both are DBNull.Value  
                return true;
            if (A == DBNull.Value || B == DBNull.Value) //  only one is BNull.Value  
                return false;
            return (A.Equals(B)); // value type standard comparison  
        }
        public static DataTable SelectDistinct(DataTable SourceTable, string FieldName)
        {
            // Create a Datatable – datatype same as FieldName  
            DataTable dt = new DataTable(SourceTable.TableName);
            dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
            // Loop each row & compare each value with one another  
            // Add it to datatable if the values are mismatch  
            object LastValue = null;
            foreach (DataRow dr in SourceTable.Select("", FieldName))
            {
                if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])))
                {
                    LastValue = dr[FieldName];
                    dt.Rows.Add(new object[] { LastValue });
                }
            }
            return dt;
        }
        #endregion

        #region IMAGE

        public static string ImageToBase64(System.Drawing.Image image)
        {
            string base64 = "";
            try
            {
                System.IO.MemoryStream m = new System.IO.MemoryStream();
                image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = m.ToArray();
                base64 = Convert.ToBase64String(imageBytes);
                m.Close();
                m.Dispose();
            }
            catch (Exception ex)
            {
                base64 = "";
            }
            return base64;


        }

        #endregion

        public static string RemoveAccents(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public static string Base64ToVideo(string base64String)
        {
            string folderName = GUARDIAO_COMMOM.Directory.IMAGE_PATH;
            string FileName = "video_" + Guid.NewGuid().ToString() + ".mp4";
            byte[] imageBytes = Convert.FromBase64String(base64String);
            if (!System.IO.File.Exists(folderName + FileName))
            {
                System.IO.File.WriteAllBytes((folderName + FileName), imageBytes);
            }
            if (System.IO.File.Exists((folderName + FileName)))
                return FileName;
            else
                return "";
        }

        public static string Base64ToMp3(string base64String)
        {
            string folderName = GUARDIAO_COMMOM.Directory.IMAGE_PATH;
            string FileName = "audio_" + Guid.NewGuid().ToString() + ".mp3";
            byte[] imageBytes = Convert.FromBase64String(base64String);
            if (!System.IO.File.Exists(folderName + FileName))
            {
                System.IO.File.WriteAllBytes((folderName + FileName), imageBytes);
            }
            if (System.IO.File.Exists((folderName + FileName)))
                return FileName;
            else
                return "";
        }


        public static string Base64ToImage(string base64String)
        {
            string folderName = GUARDIAO_COMMOM.Directory.IMAGE_PATH;
            string FileName = "img_" + Guid.NewGuid().ToString() + ".jpg";
            byte[] imageBytes = Convert.FromBase64String(base64String);
            if (!System.IO.File.Exists(folderName + FileName))
            {
                System.IO.File.WriteAllBytes((folderName + FileName), imageBytes);
            }
            if (System.IO.File.Exists((folderName + FileName)))
                return FileName;
            else
                return "";
        }
    }
}
