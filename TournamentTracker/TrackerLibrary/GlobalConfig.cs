using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using System.Configuration;

namespace TrackerLibrary.DataAccess
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }               
        public static void InitializeConnections(DatabaseType db)
        {
            /*switch (db)
            {
                case DatabaseType.Sql:
                    break;
                case DatabaseType.Textfile:
                    break;
                default:
                    break;
            }*/
            if (db  == DatabaseType.Sql)
            {
                // TODO - Set up SQL Connection
                SqlConnector sql = new SqlConnector();
                Connection = sql;
                
            }
            else if (db == DatabaseType.TextFile)
            {
                //TODO - Create textfile Connection
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }
        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;

        }
    }
}
