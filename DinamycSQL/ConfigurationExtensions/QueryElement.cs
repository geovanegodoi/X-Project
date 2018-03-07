using System.Configuration;

namespace DinamycSQL.ConfigurationExtensions
{
    public class QueryElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsKey = true)]
        public string Id
        {
            get { return (string)this["id"]; }
        }

        [ConfigurationProperty("name", IsKey = true)]
        public string Name
        {
            get { return (string)this["name"]; }
        }

        [ConfigurationProperty("dataSource")]
        public QueryDataSourceSettings DataSource
        {
            get { return (QueryDataSourceSettings)this["dataSource"]; }
        }

        [ConfigurationProperty("script")]
        public QueryScriptSettings Script
        {
            get { return (QueryScriptSettings)this["script"]; }
        }

        [ConfigurationProperty("parameters")]
        [ConfigurationCollection(typeof(QueryParameterCollection), AddItemName = "add")]
        public QueryParameterCollection QueryParameters
        {
            get { return (QueryParameterCollection)base["parameters"]; }
        }
    }
}
