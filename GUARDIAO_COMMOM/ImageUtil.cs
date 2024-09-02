using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUARDIAO_COMMOM
{
    public static class ImageUtil
    {
        public static string ImageBase64ToFile(string base64, int tipo)
        {
            string pathFile = "";
            Image image = null;
            byte[] fileBytes;
            int tipoFile = 1;
            try
            {

                if (base64.IndexOf("png;") != -1 || base64.IndexOf("jpg;") != -1)
                    tipoFile = 1;
                else if (base64.IndexOf("mp4;") != -1)
                    tipoFile = 2;
                else
                    tipoFile = 3;


                base64 = base64.Replace("data:image/png;base64,", "").Replace("data:image/jpeg;base64,", "").Replace("data:video/mp4;base64,", "").Replace("data:application/pdf;base64,", "");
                fileBytes = Convert.FromBase64String(base64);

                switch (tipo)
                {
                    case 1:
                        pathFile = Directory.IMAGE_PATH + Guid.NewGuid().ToString() + ".jpg";
                        using (var imageFile = new FileStream(pathFile, FileMode.Create))
                        {
                            imageFile.Write(fileBytes, 0, fileBytes.Length);
                            imageFile.Flush();
                        }
                        break;
                    case 2:

                        if (tipoFile == 1)
                        {
                            pathFile = Directory.IMAGE_PATH + Guid.NewGuid().ToString() + ".jpg";
                            using (var imageFile = new FileStream(pathFile, FileMode.Create))
                            {
                                imageFile.Write(fileBytes, 0, fileBytes.Length);
                                imageFile.Flush();
                            }
                        }
                        else
                        {

                            pathFile = Directory.IMAGE_PATH + "/" + Guid.NewGuid().ToString() + ".mp4";
                            using (var videoFile = new FileStream(pathFile, FileMode.Create))
                            {
                                videoFile.Write(fileBytes, 0, fileBytes.Length);
                                videoFile.Flush();
                            }
                        }
                        break;
                    case 3:
                        if (tipoFile == 1)
                        {
                            pathFile = Directory.IMAGE_PATH + Guid.NewGuid().ToString() + ".jpg";
                            using (var imageFile = new FileStream(pathFile, FileMode.Create))
                            {
                                imageFile.Write(fileBytes, 0, fileBytes.Length);
                                imageFile.Flush();
                            }
                        }
                        else
                        {
                            pathFile = Directory.IMAGE_PATH + "/" + Guid.NewGuid().ToString() + ".pdf";
                            using (var pdfFile = new FileStream(pathFile, FileMode.Create))
                            {
                                pdfFile.Write(fileBytes, 0, fileBytes.Length);
                                pdfFile.Flush();
                            }
                        }
                        break;
                }


                if (!System.IO.File.Exists(pathFile))
                    throw new Exception("File não existe " + pathFile);
            }
            catch (Exception ex)
            {
                pathFile = "";
                Error.CreateLogError(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, typeof(ImageUtil).Namespace);
            }

            return pathFile;

        }
        private static void SaveJpeg(this Image img, string filename, int quality)
        {
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
            ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            img.Save(filename, jpegCodec, encoderParams);
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            var encoders = ImageCodecInfo.GetImageEncoders();
            var encoder = encoders.SingleOrDefault(c => string.Equals(c.MimeType, mimeType, StringComparison.InvariantCultureIgnoreCase));
            if (encoder == null) throw new Exception($"Encoder not found for mime type {mimeType}");
            return encoder;
        }
    }
}
