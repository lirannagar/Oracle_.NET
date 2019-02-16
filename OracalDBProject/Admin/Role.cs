using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject.Admin
{
    public class Role: IRole
    {
        #region Control Mapping
        #endregion Control Mapping

        #region Members
        private string _idRole;
        private string _nameRole;
        #endregion Members

        #region Constructor
        public Role(string idRole,string nameRole)
        {
            InsertIDRole(idRole);
            InsertNameRole(nameRole);
        }
        #endregion Constructor

        #region Private Methods
        #endregion Private Methods

        #region Public Methods
        public void InsertIDRole(string idRole)
        {
            this._idRole = idRole;
        }
        public void InsertNameRole(string nameRole)
        {
            this._nameRole = nameRole;
        }
        public void ExecuteToDatabase()
        {
            try
            {
                OracleSingletonComment.Instance.CommandType = CommandType.StoredProcedure;
                OracleSingletonComment.Instance.CommandText = "pkg_role.insertRole";
                OracleSingletonComment.Instance.Parameters.Add("ROLE_ID", this._idRole);
                OracleSingletonComment.Instance.Parameters.Add("ROLE_NAME", this._nameRole);
                OracleSingletonComment.Instance.ExecuteNonQuery();
                OracleSingletonComment.Instance.Parameters.Clear();
                Logger.Instance.Info("Role "+ this._nameRole + " Executed");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exceptoin while trying to execute Role\nDetails:" + ex);
            }
        }
        #endregion Public Methods

    }
}
