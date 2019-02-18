using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject
{
    public class OracleSingletonComment
    {
        //
        private static OracleCommand instance;

        public static OracleCommand Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OracleCommand();
                    instance.Connection = OracleSingletonConnection.Instance;
                }
                return instance;
            }
        }
    }
}
