using Load_bank_files.Class.config;
using conf = System.Configuration;

namespace Load_bank_files.Class.config
{
    public class variable_config : ConfigurationSettings
    {
		public static string sb_file_dir => (string)GetAppSetting(typeof(string), "sb_file_dir");
		public static string vtb_kld_file_dir => (string)GetAppSetting(typeof(string), "vtb_kld_file_dir");
		public static string gpb_msk_file_dir => (string)GetAppSetting(typeof(string), "gpb_msk_file_dir");
		public static string gpb_kld_file_dir => (string)GetAppSetting(typeof(string), "gpb_kld_file_dir");
		public static string year => (string)GetAppSetting(typeof(string), "year");
		public static string month => (string)GetAppSetting(typeof(string), "month");
		public static string ConnectionLocal => (string)conf.ConfigurationManager.ConnectionStrings["Load_bank_files.Properties.Settings.localConn"].ConnectionString;
		public static string ConnStrgingBase => (string)conf.ConfigurationManager.ConnectionStrings["ConnStrg"].ConnectionString;
		public static string sbNewFormat => (string)GetAppSetting(typeof(string), "sbNewFormat");
		public static string dirUploadFiles => (string)GetAppSetting(typeof(string), "dirUploadFiles");
		public static int timerProgressbar => (int)GetAppSetting(typeof(int), "timerProgressbar");
		public static string GetexpansionFile => (string)GetAppSetting(typeof(string), "expansionFile");
		public static string directorySAP => (string)GetAppSetting(typeof(string), "directorySAP");
	}
}
