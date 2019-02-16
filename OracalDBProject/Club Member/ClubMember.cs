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
            InsertClubMemberID(idClubMember);
            InsertDate(date);
            InsertUserID(idUserId);
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
            try
            {
                OracleSingletonComment.Instance.CommandType = CommandType.StoredProcedure;
                OracleSingletonComment.Instance.CommandText = "pkg_club_member.insertClubMember";
                OracleSingletonComment.Instance.Parameters.Add("MEMBER_ID", this._idClubMember);
                OracleSingletonComment.Instance.Parameters.Add("USER_ID", this._idUserId);
                OracleSingletonComment.Instance.Parameters.Add("JOIN_DATE", this._date);
                OracleSingletonComment.Instance.ExecuteNonQuery();
                OracleSingletonComment.Instance.Parameters.Clear();
                Logger.Instance.Info("Club Member " + this._idUserId + " Executed");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exceptoin while trying to execute Club Member\nDetails:" + ex);
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                Logger.Instance.Error("Exceptoin while trying to execute Club Member\nDetails:" + ex);
            }
        }
        #endregion Public Methods


    }
}
