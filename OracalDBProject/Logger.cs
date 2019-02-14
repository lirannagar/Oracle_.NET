using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace OracalDBProject
{
    public class Logger
    {
        private static SimpleLogger instance;

        public static SimpleLogger Instance
        {
            get
            {
                if (instance == null)
                {                   
                        instance = new SimpleLogger();                            
                }
                return instance;
            }
        }
    }
}
