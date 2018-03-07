using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamycSQL.Config
{
    public static class ConfigFile
    {
        public static string FTPPath
        {
            get { return ReadConfig<string>("FTP_PATH"); }
        }

        public static string FTPUser
        {
            get { return ReadConfig<string>("FTP_USER"); }
        }

        public static string FTPPassword
        {
            get { return ReadConfig<string>("FTP_PASSWORD"); }
        }

        public static string LocalPath
        {
            get { return ReadConfig<string>("LOCAL_PATH"); }
        }

        public static char FileSeparator
        {
            get { return ReadConfig<char>("FILE_SEPARATOR"); }
        }

        private static T ReadConfig<T>(string keyName)
        {
            return ConvertValue<T, string>(ConfigurationManager.AppSettings[keyName]);
        }

        private static T ConvertValue<T, U>(U value) where U : IConvertible
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
