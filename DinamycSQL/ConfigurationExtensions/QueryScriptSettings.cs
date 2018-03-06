using System.Configuration;

namespace DinamycSQL.ConfigurationExtensions
{
    public class QueryScriptSettings : ConfigurationElement
    {
        [ConfigurationProperty("data", IsKey = true)]
        public string Data
        {
            get { return (string)this["data"];  }
            set { this["data"] = value;         }
        }
    }
}
