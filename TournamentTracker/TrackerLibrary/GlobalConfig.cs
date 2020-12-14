using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections;

        // public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
      
        private static void SetConnections(List<IDataConnection> value)
        {
            Connections = new List<IDataConnection>();
        }

        public static void InitializeConnections(bool database, bool textFiles)
        {
            
            if (database)
            {
                // TODO - Set up SQL Connection
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
                
            }
            if (textFiles)
            {
                //TODO - Create textfile Connection
                TextConnection text = new TextConnection();
                Connections.Add(text);
            }
        }
    }
}
