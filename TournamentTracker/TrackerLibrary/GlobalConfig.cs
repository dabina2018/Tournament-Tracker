using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
      
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
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}
