using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OracalDBProject.Admin
{
    public class Product : IProduct
    {
        #region Control Mapping
        #endregion Control Mapping

        #region Members
        private string _id;
        private string _name;
        private int _amount;
        #endregion Members

        #region Constructor
        public Product(string name,int number, string id = null)
        {
            InsertId(id);
            InsetName(name);
            InsertAmount(number);            
        }
        #endregion Constructor

        #region Private Methods
        #endregion Private Methods

        #region Public Methods
        public void InsertAmount(int amount)
        {
            this._amount = amount;
        }

        public void InsertId(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                try
                {
                    
                    OracleSingletonComment.Instance.CommandType = CommandType.Text;
                    OracleSingletonComment.Instance.CommandText = "SELECT product_seq.nextval from dual";
                    this._id = Convert.ToInt32(OracleSingletonComment.Instance.ExecuteScalar()).ToString();
                }
                catch (OracleException ex )
                {
                    Logger.Instance.Error("Error while trying to set id " + ex);
                }
                catch ( InvalidOperationException exe)
                {
                    Logger.Instance.Error("Error while trying to set id " + exe);
                }
                
            }
            else
            {
                this._id = id;
            }
        }

        public void InsetName(string name)
        {
            this._name = name;
        }
        public void ExecuteToDatabase()
        {
            try
            {               
                OracleSingletonComment.Instance.CommandType = CommandType.StoredProcedure;
                OracleSingletonComment.Instance.CommandText = "pkg_product.insertProducts";
                OracleSingletonComment.Instance.Parameters.Add("PRODUCT_ID", this._id);
                OracleSingletonComment.Instance.Parameters.Add("PRODUCT_NAME", this._name);
                OracleSingletonComment.Instance.Parameters.Add("PRODUCT_AMOUNT", this._amount);
                OracleSingletonComment.Instance.ExecuteNonQuery();
                OracleSingletonComment.Instance.Parameters.Clear();                
                Logger.Instance.Info("Product Executed");
                
            }
            catch(OracleException ex)
            {
                Logger.Instance.Error("Exceptoin while trying to execute product\nDetails:"  +ex);
            }
        }
        #endregion Public Methods

    }
}
