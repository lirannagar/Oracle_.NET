using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject.Club_Member
{
    public interface IClubMember
    {
        void InsertClubMemberID(string idClubMember);
        void InsertUserID(string userId);
        void InsertDate(string date);
        void ExecuteToDatabase();

    }
}
