using System.Configuration;

namespace DinamycSQL.ConfigurationExtensions
{
    public class DinamycSQLSection : ConfigurationSection
    {
        //If you replace "employeeCollection" with "" then you do not need "employeeCollection" 
        //element as a wrapper node over employee nodes in config file.
        [ConfigurationProperty("", IsDefaultCollection = true, IsKey = false, IsRequired = true)]
        public QueryCollection Members
        {
            get { return base[""] as QueryCollection; }
            set { base[""] = value; }
        }
    }
}
