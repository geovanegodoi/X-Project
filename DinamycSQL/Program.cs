using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinamycSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataFile = new DataFile(ConfigFile.FilePath);
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CustomQuery qry = (CustomQuery)config.Sections["customQuery"];

            using (var context = new EntitiesContext())
            {
                var query = "INSERT INTO FXUSER.T_TEMP_01(F1, F2, F3, F4) VALUES(:SERIAL_NUMBER, :CUST_PART_NO, :EEE_CODE, :PART_NAME)";

                foreach (var data in dataFile.GetData())
                {
                    var param = new List<OracleParameter>();

                    foreach (var header in dataFile.GetHeader())
                    {
                        var oraParam = new OracleParameter($":{header.Value}", data[header.Value]);
                        param.Add(oraParam);
                    }
                    context.Database.ExecuteSqlCommand(query, param.ToArray());
                }
                context.SaveChanges();


                //var query  = "SELECT MAX(ID) FROM FXUSER.T_TEMP_01";

                //var nextid = context.Database.SqlQuery<int>(query).FirstOrDefault() + 1;

                //query = "INSERT INTO FXUSER.T_TEMP_01(ID, F1, F2, F3) VALUES(:ID, :F1, :F2, :F3)";

                //var param = new List<OracleParameter>
                //{
                //    new OracleParameter(":ID", nextid)
                //,   new OracleParameter(":F1", "param1")
                //,   new OracleParameter(":F2", "param2")
                //,   new OracleParameter(":F3", "param3")
                //}.ToArray();

            }
        }
    }
}
