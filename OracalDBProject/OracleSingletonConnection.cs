using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject
{
    public class OracleSingletonConnection
    {
        const string CONNECTION_STRING = "DATA SOURCE = localhost:1521/xe;USER ID = SYSTEM; PASSWORD=chenliran123";
        private static OracleConnection instance;

      

        public static OracleConnection Instance
        {
            get
            {
                if (instance == null)
                {                 
                        instance = new OracleConnection(CONNECTION_STRING);                  
                }
                return instance;
            }
        }
    }
}
