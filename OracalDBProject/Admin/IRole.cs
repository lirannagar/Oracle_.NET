using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject.Admin
{
    public interface IRole
    {
        void InsertIDRole(string idRole);
        void InsertNameRole(string nameRole);
        void ExecuteToDatabase();
    }
}
