using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject.Admin
{
    public interface IUser
    {
        void IsertUserID(string userId);
        void IsertRoleID(string roleId);
        void IsertFirstName(string firstName);
        void IsertLastName(string lastName);
        void IsertPhoneNumber(string phoneNumber);
        void IsertEmail(string email);
        void IsertAddress(string address);
        void IsertPassword(string password);
        void ExecuteToDatabase();

    }
}
