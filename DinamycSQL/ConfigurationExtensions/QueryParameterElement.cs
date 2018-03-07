using System.Configuration;

namespace DinamycSQL.ConfigurationExtensions
{
    public class QueryParameterElement : ConfigurationElement
    {
        public QueryParameterElement() { }

        [ConfigurationProperty("name", DefaultValue = "")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("value", DefaultValue = "")]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }

        [ConfigurationProperty("position", DefaultValue = "0", IsRequired = true)]
        public int Position
        {
            get { return (int)this["position"]; }
            set { this["position"] = value; }
        }
    }
}