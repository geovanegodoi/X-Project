using System.Configuration;

namespace DinamycSQL.ConfigurationExtensions
{
    public class QueryParameterCollection : ConfigurationElementCollection
    {
        public QueryParameterCollection() { }

        protected override ConfigurationElement CreateNewElement()
        {
            return new QueryParameterElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((QueryParameterElement)element).Name;
        }
    }
}
