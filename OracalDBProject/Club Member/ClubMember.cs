using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject.Club_Member
{
    public class ClubMember :IClubMember
    {
        #region Control Mapping

        #endregion Control Mapping

        #region Members
        private string _idClubMember;
        private string _idUserId;
        private string _date;
        #endregion Members

        #region Constructor
        public ClubMember(string idUserId, string date, string idClubMember = null)
        {

        }

        #endregion Constructor

        #region Private Methods
        #endregion Private Methods

        #region Public Methods
        public void InsertClubMemberID(string idClubMember)
        {
            if (string.IsNullOrEmpty(idClubMember))
            {
                try
                {
                    OracleSingletonComment.Instance.CommandType = CommandType.Text;
                    OracleSingletonComment.Instance.CommandText = "SELECT club_member_seq.nextval from dual";
                    this._idClubMember = Convert.ToInt32(OracleSingletonComment.Instance.ExecuteScalar()).ToString();
                }
                catch (OracleException ex)
                {
                    Logger.Instance.Error("Error while trying to set id " + ex);
                }
                catch (InvalidOperationException exe)
                {
                    Logger.Instance.Error("Error while trying to set id " + exe);
                }
            }
            else
            {
                this._idClubMember = idClubMember;
            }
        }

        public void InsertUserID(string userId)
        {
            this._idUserId = userId;
        }

        public void InsertDate(string date)
        {
            this._date = date;
        }

        public void ExecuteToDatabase()
        {
          
        }
        #endregion Public Methods


    }
}
