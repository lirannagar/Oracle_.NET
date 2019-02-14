using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject.Admin
{
    public interface IAdmin
    {
        void InsertUserID(string userId);
        void InsertAdminID(string adminId);
        void InsertSalary(int salaryNIS);
        void ExecuteToDatabase();
    }
}
