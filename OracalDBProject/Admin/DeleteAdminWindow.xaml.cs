﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OracalDBProject.Admin
{
    /// <summary>
    /// Interaction logic for DeleteAdminWindow.xaml
    /// </summary>
    public partial class DeleteAdminWindow : Window
    {


        #region Control Mapping
        const string COMBOBOX_NAME_SEARCH = "By ID";
        const string TABLE_NAME_UPDATE = "USERS";
        #endregion Control Mapping

        #region Members
        #endregion Members

        #region Constructor
        public DeleteAdminWindow()
        {
            try
            {
                InitializeComponent();
                ShowAllAdmins();
                Logger.Instance.Info("Delete Admin Window opened");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Erorr while trying to open Delete Admin Window \nDetails" + ex);
            }
        }
        #endregion Constructor

        #region Private Methods
        private void ShowAllAdmins()
        {
            try
            {
                string searchQueryString = "SELECT * FROM vw_admins";
                UpdateTable(searchQueryString);
                Logger.Instance.Info("All Admins Shown");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Erorr while trying to show all admins \nDetails" + ex);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OracalDBProject.MarketsDBSource marketsDBSource = ((OracalDBProject.MarketsDBSource)(this.FindResource("marketsDBSource")));
            // Load data into the table USERS. You can modify this code as needed.
            OracalDBProject.MarketsDBSourceTableAdapters.USERSTableAdapter marketsDBSourceUSERSTableAdapter = new OracalDBProject.MarketsDBSourceTableAdapters.USERSTableAdapter();
            marketsDBSourceUSERSTableAdapter.Fill(marketsDBSource.USERS);
            System.Windows.Data.CollectionViewSource uSERSViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSERSViewSource")));
            uSERSViewSource.View.MoveCurrentToFirst();
        }

        private void searchButtonDeleteWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchQueryString = "";
                string select = searchComboBoxDeleteAdmin.SelectedItem.ToString();
                string name = textBoxSearchDeleteAdmin.Text;
                if (select.Contains(COMBOBOX_NAME_SEARCH))
                {
                    searchQueryString = "SELECT ADMINISTRATOR.ADMIN_ID,USERS.FIRST_NAME,USERS.LAST_NAME,USERS.PASSWORD_ENCRYPTED,USERS.USER_EMAIL,USERS.USER_PHONE_NUMBER,ADMINISTRATOR.SALARY_NIS "
                                + " FROM USERS INNER JOIN ADMINISTRATOR ON USERS.USER_ID = ADMINISTRATOR.USER_ID"
                                + " WHERE ADMINISTRATOR.ADMIN_ID = " + Int32.Parse(name) + "";
                }
                else
                {
                    searchQueryString = "SELECT ADMINISTRATOR.ADMIN_ID,USERS.FIRST_NAME,USERS.LAST_NAME,USERS.PASSWORD_ENCRYPTED,USERS.USER_EMAIL,USERS.USER_PHONE_NUMBER,ADMINISTRATOR.SALARY_NIS "
                                + " FROM USERS INNER JOIN ADMINISTRATOR ON USERS.USER_ID = ADMINISTRATOR.USER_ID"
                                + " WHERE USERS.FIRST_NAME  = '" + name + "'";
                }
                UpdateTable(searchQueryString);
                Logger.Instance.Info("Search Admin Member");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to search to Delete Admin\nDeatails: " + ex);
            }
        }

        private void UpdateTable(string query)
        {
            try
            {
                OracleSingletonComment.Instance.CommandText = query;
                OracleSingletonComment.Instance.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(OracleSingletonComment.Instance);
                da.SelectCommand = OracleSingletonComment.Instance;
                DataTable dt = new DataTable(TABLE_NAME_UPDATE);
                da.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                OracleSingletonComment.Instance.Cancel();
                Logger.Instance.Info("Table Updated");
            }
            catch (OracleException ex)
            {                
                Logger.Instance.Error("Exception while trying to update table\nDeatails: " + ex);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
                Logger.Instance.Info("Open Admin Paenel Window and Close Delete Admin Window");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to open admin panel window and Close Delete Admin Window \nDetails: " + ex);
            }
        }

        private void showAllAdminsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowAllAdmins();
        }
        private void ClearTextBoxes()
        {
            textBoxSearchDeleteAdmin.Clear();
            deleteTextBox.Clear();
        }

        private void DeleteAdminFromUserDB(string name)
        {
            try
            {
                OracleSingletonComment.Instance.CommandText = "DROP USER " + name + "";
                OracleSingletonComment.Instance.ExecuteNonQuery();
                Logger.Instance.Info("Delete Admin From User DB");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to Delete Admin From User DB details: " + ex);
            }

        }
        private string GetAdminUserId(string adminUserId)
        {
            OracleSingletonComment.Instance.CommandText = "pkg_admin.get_admin_user_id";
            OracleSingletonComment.Instance.CommandType = CommandType.StoredProcedure;
            OracleSingletonComment.Instance.Parameters.Add("number", OracleDbType.Int32, ParameterDirection.ReturnValue);
            OracleSingletonComment.Instance.Parameters.Add("number", OracleDbType.Int32, ParameterDirection.Input).Value = Int32.Parse(adminUserId);
            OracleSingletonComment.Instance.ExecuteNonQuery();
            return OracleSingletonComment.Instance.Parameters["number"].Value.ToString();
        }

        private void deleteButtonAdmin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string adminUserId = deleteTextBox.Text;

                string userId = GetAdminUserId(adminUserId);
                OracleSingletonComment.Instance.CommandText = "SELECT USERS.FIRST_NAME FROM USERS WHERE USER_ID = " + Int32.Parse(userId) + "";
                string adminUserName = Convert.ToString(OracleSingletonComment.Instance.ExecuteScalar());
                string deleteQuery = "DELETE FROM ADMINISTRATOR"
                           + " WHERE ADMINISTRATOR.ADMIN_ID = " + adminUserId + "";
                UpdateTable(deleteQuery);
                deleteQuery = "DELETE FROM USERS"
                           + " WHERE USERS.USER_ID = " + userId + "";
                UpdateTable(deleteQuery);
                DeleteAdminFromUserDB(adminUserName);
                ShowAllAdmins();
                ClearTextBoxes();
                Logger.Instance.Info("Admin " + adminUserId + " with ID: " + adminUserName + " deleted");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to delete admin user details: " + ex);
            }


        }
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods



    }
}
