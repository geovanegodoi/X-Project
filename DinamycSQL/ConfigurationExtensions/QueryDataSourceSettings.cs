using System.Configuration;

namespace DinamycSQL.ConfigurationExtensions
{
    public class QueryDataSourceSettings : ConfigurationElement
    {
        [ConfigurationProperty("source", IsKey = true)]
        public string Source
        {
            get { return (string)this["source"]; }
            set { this["source"] = value;        }
        }

        [ConfigurationProperty("path")]
        public string Path
        {
            get { return (string)this["path"]; }
            set { this["path"] = value;        }
        }

        [ConfigurationProperty("separator")]
        public char Separator
        {
            get { return (char)this["separator"]; }
            set { this["separator"] = value;      }
        }
    }
}
