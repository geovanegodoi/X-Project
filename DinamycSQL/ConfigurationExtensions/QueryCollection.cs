using System;
using System.Configuration;

namespace DinamycSQL.ConfigurationExtensions
{
    public class QueryCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new QueryElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((QueryElement)element).Id;
        }
        protected override bool IsElementName(string elementName)
        {
            return !String.IsNullOrEmpty(elementName) && elementName == "query";
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        public QueryElement this[int index]
        {
            get { return base.BaseGet(index) as QueryElement; }
        }
        public new QueryElement this[string key]
        {
            get { return base.BaseGet(key) as QueryElement; }
        }
    }
}
