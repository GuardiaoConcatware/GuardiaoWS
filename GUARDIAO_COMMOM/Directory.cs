using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GUARDIAO_COMMOM
{
    public static class Directory
    {
        private static string config_path = "guardiao_config";
        private static string temp_path = "guardiao_temp";
        private static string logs_path = "guardiao_logs";
        private static string pdf_path = "guardiao_pdfs";
        private static string images_path = "guardiao_images";
        private static string brandMark_path = "guardiao_brand";
        private static string xmlJson_path = "guardiao_xml_json";
        private static string certificate_path = "guardiao_certificate";

        public static string SOURCE_PATH
        {
            get { return HttpContext.Current.Request.PhysicalApplicationPath; }
            private set { }
        }
        public static string CONFIG_PATH
        {
            get { return HttpContext.Current.Request.PhysicalApplicationPath + config_path + "\\"; }
            private set { }
        }
        public static string LOGS_PATH
        {
            get { return HttpContext.Current.Request.PhysicalApplicationPath + logs_path + "\\"; }
            private set { }
        }
        public static string PDFS_PATH
        {
            get { return HttpContext.Current.Request.PhysicalApplicationPath + pdf_path + "\\"; }
            private set { }
        }
        public static string IMAGE_PATH
        {
            get { return HttpContext.Current.Request.PhysicalApplicationPath + images_path + "\\"; }
            private set { }
        }
        public static string PATH_BRAND
        {
            get { return HttpContext.Current.Request.PhysicalApplicationPath + brandMark_path + "\\"; }
            private set { }
        }
        public static string PATH_CERTIFICATE
        {
            get { return HttpContext.Current.Request.PhysicalApplicationPath + certificate_path + "\\"; }
            private set { }
        }
        public static string PATH_XML_JSON
        {
            get { return HttpContext.Current.Request.PhysicalApplicationPath + xmlJson_path + "\\"; }
            private set { }
        }


        public static void CreateSystemFolders()
        {
            if (!System.IO.Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + config_path))
                System.IO.Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + config_path);
            if (!System.IO.Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + temp_path))
                System.IO.Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + temp_path);
            if (!System.IO.Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + logs_path))
                System.IO.Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + logs_path);
            if (!System.IO.Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + pdf_path))
                System.IO.Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + pdf_path);
            if (!System.IO.Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + images_path))
                System.IO.Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + images_path);
            if (!System.IO.Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + brandMark_path))
                System.IO.Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + brandMark_path);
            if (!System.IO.Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + xmlJson_path))
                System.IO.Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + xmlJson_path);
            if (!System.IO.Directory.Exists(HttpContext.Current.Request.PhysicalApplicationPath + certificate_path))
                System.IO.Directory.CreateDirectory(HttpContext.Current.Request.PhysicalApplicationPath + certificate_path);

        }
    }
}
