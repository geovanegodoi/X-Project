using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamycSQL
{
    public enum FileAccess { Anoninoums, Credentials };

    public static class ConfigFile
    {
        public static string FileName
        {
            get
            {
                return ReadConfig<string>("FILE_NAME");
            }
        }

        public static string FilePath
        {
            get
            {
                var tempPath = ReadConfig<string>("FILE_PATH");
                return $"{(string.IsNullOrEmpty(tempPath) ? string.Empty : tempPath + "/")}{FileName}";
            }
        }

        public static FileAccess FileAccess
        {
            private set
            {

            }
            get
            {
                return ReadConfig<FileAccess>("FILE_ACCESS");
            }
        }

        public static string UserName
        {
            get
            {
                return ReadConfig<string>("USER_NAME");
            }
        }

        public static string Password
        {
            get
            {
                return ReadConfig<string>("PASSWORD");
            }
        }

        public static int HeaderRow
        {
            get
            {
                return ReadConfig<int>("HEADER_ROW");
            }
        }

        public static char HeaderSeparator
        {
            get
            {
                return ReadConfig<char>("HEADER_SEPARATOR");
            }
        }

        public static char RowSeparator
        {
            get
            {
                return ReadConfig<char>("ROW_SEPARATOR");
            }
        }

        private static T ReadConfig<T>(string keyName)
        {
            object readKey = null;

            try
            {
                object config = ConfigurationManager.AppSettings[keyName];

                if (typeof(T) == typeof(string))
                {
                    readKey = Convert.ToString(config);
                }
                else if (typeof(T) == typeof(char))
                {
                    readKey = Convert.ToChar(config);
                }
                else if (typeof(T) == typeof(int))
                {
                    readKey = Convert.ToInt32(config);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return (T)readKey;
        }
    }
}
