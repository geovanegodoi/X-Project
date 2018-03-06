using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamycSQL
{
    public class CustomQuery : ConfigurationSection
    {
        private CustomQuery() { }

        [ConfigurationProperty("name", DefaultValue = "")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("sourceFile")]
        public SourceFileSettings SourceFile
        {
            get { return (SourceFileSettings)this["sourceFile"]; }
        }

        [ConfigurationProperty("queryParameters")]
        [ConfigurationCollection(typeof(QueryParameterCollection), AddItemName = "add")]
        public QueryParameterCollection QueryParameters
        {
            get
            {
                return (QueryParameterCollection)base["queryParameters"];
            }
        }

        [ConfigurationProperty("queryScripts")]
        [ConfigurationCollection(typeof(QueryScriptCollection), AddItemName = "add")]
        public QueryScriptCollection QueryScripts
        {
            get
            {
                return (QueryScriptCollection)base["queryScripts"];
            }
        }
    }

    public class SourceFileSettings : ConfigurationElement
    {
        public SourceFileSettings() { }

        [ConfigurationProperty("name", DefaultValue = "")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("path", DefaultValue = "")]
        public string Path
        {
            get { return (string)this["path"]; }
            set { this["path"] = value; }
        }

        [ConfigurationProperty("separator", DefaultValue = "")]
        public string Separator
        {
            get { return (string)this["separator"]; }
            set { this["separator"] = value; }
        }
    }

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

    public class QueryScriptCollection : ConfigurationElementCollection
    {
        public QueryScriptCollection() { }

        protected override ConfigurationElement CreateNewElement()
        {
            return new QueryScriptElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((QueryScriptElement)element).Value;
        }
    }

    public class QueryScriptElement : ConfigurationElement
    {
        public QueryScriptElement() { }

        [ConfigurationProperty("value", DefaultValue = "")]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
}
