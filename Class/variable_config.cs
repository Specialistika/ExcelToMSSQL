using Load_bank_files.Class.config;
using conf = System.Configuration;

namespace Load_bank_files.Class.config
{
    public class variable_config : ConfigurationSettings
    {
        public static string sb_file_dir
        {
            get { return (string)GetAppSetting(typeof(string), "sb_file_dir"); }
        }
        public static string vtb_kld_file_dir
        {
            get { return (string)GetAppSetting(typeof(string), "vtb_kld_file_dir"); }
        }
        public static string gpb_msk_file_dir
        {
            get { return (string)GetAppSetting(typeof(string), "gpb_msk_file_dir"); }
        }
        public static string gpb_kld_file_dir
        {
            get { return (string)GetAppSetting(typeof(string), "gpb_kld_file_dir"); }
        }
        public static string year
        {
            get { return (string)GetAppSetting(typeof(string), "year"); }
        }
        public static string month
        {
            get { return (string)GetAppSetting(typeof(string), "month"); }
        }
        public static string ConnectionLocal
        {
            get { return (string)conf.ConfigurationManager.ConnectionStrings["Load_bank_files.Properties.Settings.localConn"].ConnectionString; }
        }
        public static string ConnStrg
        {
            get { return (string)conf.ConfigurationManager.ConnectionStrings["ConnStrg"].ConnectionString; }
        }
        public static string sb_new_format
        {
            get { return (string)GetAppSetting(typeof(string), "sb_new_format"); }
        }
        public static string dir_initialisation
        {
            get { return (string)GetAppSetting(typeof(string), "dir_initialisation"); }
        }
        public static int timerProgressbar
        {
            get { return (int)GetAppSetting(typeof(int), "timerProgressbar"); }
        }
        
    }
}
