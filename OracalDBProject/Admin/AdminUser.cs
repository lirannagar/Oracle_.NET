using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject.Admin
{
    public class AdminUser :IAdmin
    {

        #region Control Mapping
        #endregion Control Mapping

        #region Members
        private string _adminId;
        private string _userId;
        private int _salaryNIS;
        #endregion Members

        #region Constructor
        public AdminUser( string userId, int salaryNIS, string adminId =  null)
        {
            InsertUserID(userId);
            InsertSalary(salaryNIS);
            InsertAdminID(adminId);
        }
        #endregion Constructor

        #region Private Methods
        #endregion Private Methods

        #region Public Mathods
        public void InsertUserID(string userId)
        {
            this._userId = userId;
        }

        public void InsertAdminID(string adminId)
        {
            if (string.IsNullOrEmpty(adminId))
            {
                try
                {
                    OracleSingletonComment.Instance.CommandType = CommandType.Text;
                    OracleSingletonComment.Instance.CommandText = "SELECT admin_seq.nextval from dual";
                    this._adminId = Convert.ToInt32(OracleSingletonComment.Instance.ExecuteScalar()).ToString();
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
                this._adminId = adminId;
            }
        }

        public void InsertSalary(int salaryNIS)
        {
            this._salaryNIS = salaryNIS;
        }

        public void ExecuteToDatabase()
        {
            try
            {
                OracleSingletonComment.Instance.CommandType = CommandType.StoredProcedure;
                OracleSingletonComment.Instance.CommandText = "pkg_admin.insertAdmin";
                OracleSingletonComment.Instance.Parameters.Add("ADMIN_ID", this._adminId);
                OracleSingletonComment.Instance.Parameters.Add("USER_ID", this._userId);
                OracleSingletonComment.Instance.Parameters.Add("SALARY_NIS", this._salaryNIS);
                OracleSingletonComment.Instance.ExecuteNonQuery();
                OracleSingletonComment.Instance.Parameters.Clear();                
                Logger.Instance.Info("Admin User Executed");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exceptoin while trying to execute Admin User\nDetails:" + ex);
            }
        }
        #endregion Public Mathods
    }
}
