using DinamycSQL.ConfigurationExtensions;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace DinamycSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dataFile = new DataFileBO(ConfigFile.FilePath);
            //var configSection = ConfigurationManager.GetSection("dinamycSQLSection") as DinamycSQLSection;
            //foreach (var item in configSection.Members)
            //{
            //    var qry = (item as QueryElement);
            //    var datasource = qry.DataSource;
            //    var script = qry.Script;
            //    foreach (var p in qry.QueryParameters)
            //    {
            //        var parameter = (p as QueryParameterElement);
            //    }
            //}
            var connStrName = "FXConnString";
            var connectionString = ConfigurationManager.ConnectionStrings[connStrName].ConnectionString;
            var providerName     = ConfigurationManager.ConnectionStrings[connStrName].ProviderName;
            using (var conn  = CreateDbConnection(providerName, connectionString))
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "INSERT INTO FXUSER.T_TEMP_01(ID, F1, F2, F3, F4) VALUES(1, 'F1', 'F2', 'F3', 'F4')";
                    command.CommandType = CommandType.Text;

                    //var parameter = command.CreateParameter();
                    //parameter.ParameterName = "ParameterName";V 

                    //command.Parameters.Add(parameter);

                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }

            

            //using (var context = new EntitiesContext())
            //{


            //    var query = "INSERT INTO FXUSER.T_TEMP_01(F1, F2, F3, F4) VALUES(:SERIAL_NUMBER, :CUST_PART_NO, :EEE_CODE, :PART_NAME)";

            //    foreach (var data in dataFile.GetData())
            //    {
            //        var param = new List<OracleParameter>();

            //        foreach (var header in dataFile.GetHeader())
            //        {
            //            var oraParam = new OracleParameter($":{header.Value}", data[header.Value]);
            //            param.Add(oraParam);
            //        }
            //        context.Database.ExecuteSqlCommand(query, param.ToArray());
            //    }
            //    context.SaveChanges();


            //    //var query  = "SELECT MAX(ID) FROM FXUSER.T_TEMP_01";

            //    //var nextid = context.Database.SqlQuery<int>(query).FirstOrDefault() + 1;

            //    //query = "INSERT INTO FXUSER.T_TEMP_01(ID, F1, F2, F3) VALUES(:ID, :F1, :F2, :F3)";

            //    //var param = new List<OracleParameter>
            //    //{
            //    //    new OracleParameter(":ID", nextid)
            //    //,   new OracleParameter(":F1", "param1")
            //    //,   new OracleParameter(":F2", "param2")
            //    //,   new OracleParameter(":F3", "param3")
            //    //}.ToArray();

            //}
        }

        static DbConnection CreateDbConnection(string providerName, string connectionString)
        {
            // Assume failure.
            DbConnection connection = null;

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                    {
                        connection = null;
                    }
                    Console.WriteLine(ex.Message);
                }
            }
            // Return the connection.
            return connection;
        }
    }
}
