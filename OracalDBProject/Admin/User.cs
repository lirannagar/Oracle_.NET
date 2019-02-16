using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject.Admin
{
    public class User:IUser
    {
        #region Control Mapping
        #endregion Control Mapping

        #region Members
        private string _userId;
        private string _roleId;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _email;
        private string _address;
        private string _password;
        #endregion Members

        #region Constructor
        public User(string roleId,string firstName,string lastName,string phoneNumber,string email,string address,string password,string userId = null)
        {
            IsertUserID(userId);
            IsertRoleID(roleId);
            IsertFirstName(firstName);
            IsertLastName(lastName);
            IsertPhoneNumber(phoneNumber);
            IsertEmail(email);
            IsertAddress(address);
            IsertPassword(password);    
        }
        #endregion Constructor

        #region Private Methods
        #endregion Private Methods

        #region Public Mathods
        public void IsertAddress(string address)
        {
            this._address = address;
        }

        public void IsertEmail(string email)
        {
            this._email = email;
        }

        public void IsertFirstName(string firstName)
        {
            this._firstName = firstName;
        }

        public void IsertLastName(string lastName)
        {
            this._lastName = lastName;
        }

        public void IsertPassword(string password)
        {
            this._password = password;
        }

        public void IsertPhoneNumber(string phoneNumber)
        {
            this._phoneNumber = phoneNumber;
        }

        public void IsertRoleID(string roleId)
        {
            this._roleId = roleId;
        }

        public void IsertUserID(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                try
                {
                    OracleSingletonComment.Instance.CommandType = CommandType.Text;
                    OracleSingletonComment.Instance.CommandText = "SELECT user_seq.nextval from dual";
                    this._userId = Convert.ToInt32(OracleSingletonComment.Instance.ExecuteScalar()).ToString();
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
                this._userId = userId;
            }
        }

        public string GetId()
        {           
           return _userId;
        }

        public void ExecuteToDatabase()
        {
            try
            {
                OracleSingletonComment.Instance.CommandType = CommandType.StoredProcedure;
                OracleSingletonComment.Instance.CommandText = "pkg_user.insertUsers";
                OracleSingletonComment.Instance.Parameters.Add("USER_ID", this._userId);
                OracleSingletonComment.Instance.Parameters.Add("ROLE_ID", this._roleId);
                OracleSingletonComment.Instance.Parameters.Add("FIRST_NAME", this._firstName);
                OracleSingletonComment.Instance.Parameters.Add("LAST_NAME", this._lastName);
                OracleSingletonComment.Instance.Parameters.Add("USER_PHONE_NUMBER", this._phoneNumber);
                OracleSingletonComment.Instance.Parameters.Add("USER_EMAIL", this._email);
                OracleSingletonComment.Instance.Parameters.Add("USER_ADDRESS", this._address);
                OracleSingletonComment.Instance.Parameters.Add("PASSWORD_ENCRYPTED", this._password);
                OracleSingletonComment.Instance.ExecuteNonQuery();
                OracleSingletonComment.Instance.Parameters.Clear();
                Logger.Instance.Info("User " + this._firstName + " Executed");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exceptoin while trying to execute User\nDetails:" + ex);
            }catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                Logger.Instance.Error("Exceptoin while trying to execute User\nDetails:" + ex);
            }
        }
        #endregion Public Mathods
    }
}
