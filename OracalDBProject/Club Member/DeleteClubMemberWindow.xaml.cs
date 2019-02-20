using Oracle.ManagedDataAccess.Client;
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

namespace OracalDBProject.Club_Member
{





    /// <summary>
    /// Interaction logic for DeleteClubMemberWindow.xaml
    /// </summary>
    public partial class DeleteClubMemberWindow : Window
    {

        #region Control Mapping
        const string COMBOBOX_NAME_SEARCH = "By ID";
        const string TABLE_NAME_UPDATE = "USERS";
        #endregion Control Mapping


        #region Members
        #endregion Members


        #region Constructor
        public DeleteClubMemberWindow()
        {
            InitializeComponent();
            ShowAllClubMembers();
        }
        #endregion Constructor


        #region Private Methods
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OracalDBProject.MarketsDBSource marketsDBSource = ((OracalDBProject.MarketsDBSource)(this.FindResource("marketsDBSource")));
            // Load data into the table USERS. You can modify this code as needed.
            OracalDBProject.MarketsDBSourceTableAdapters.USERSTableAdapter marketsDBSourceUSERSTableAdapter = new OracalDBProject.MarketsDBSourceTableAdapters.USERSTableAdapter();
            marketsDBSourceUSERSTableAdapter.Fill(marketsDBSource.USERS);
            System.Windows.Data.CollectionViewSource uSERSViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uSERSViewSource")));
            uSERSViewSource.View.MoveCurrentToFirst();
        }

        private void ShowAllClubMemberButton_Click(object sender, RoutedEventArgs e)
        {
            ShowAllClubMembers();
        }
        private void ShowAllClubMembers()
        {
            try
            {
                string searchQueryString = "SELECT CLUB_MEMBER.MEMBER_ID,USERS.FIRST_NAME,USERS.LAST_NAME,USERS.PASSWORD_ENCRYPTED,USERS.USER_EMAIL,USERS.USER_PHONE_NUMBER,CLUB_MEMBER.JOIN_DATE "
                                                + " FROM USERS INNER JOIN CLUB_MEMBER ON USERS.USER_ID = CLUB_MEMBER.USER_ID";
                UpdateTable(searchQueryString);
                Logger.Instance.Info("All Club Members Shown");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Erorr while trying to show All Club Members\nDetails" + ex);
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
                MessageBox.Show("Wrong Value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.Instance.Error("Exception while trying to update table\nDeatails: " + ex);
            }
        }



        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string clubMemberUserId = textBoxDelete.Text;
                OracleSingletonComment.Instance.CommandText = "SELECT CLUB_MEMBER.USER_ID FROM CLUB_MEMBER WHERE MEMBER_ID = " + Int32.Parse(clubMemberUserId) + "";
                string userId = Convert.ToString(OracleSingletonComment.Instance.ExecuteScalar());
                OracleSingletonComment.Instance.CommandText = "SELECT USERS.FIRST_NAME FROM USERS WHERE USER_ID = " + Int32.Parse(userId) + "";
                string clubMemberUserName = Convert.ToString(OracleSingletonComment.Instance.ExecuteScalar());
                string deleteQuery = "DELETE FROM CLUB_MEMBER"
                           + " WHERE CLUB_MEMBER.MEMBER_ID = " + clubMemberUserId + "";
                UpdateTable(deleteQuery);
                deleteQuery = "DELETE FROM USERS"
                           + " WHERE USERS.USER_ID = " + userId + "";
                UpdateTable(deleteQuery);
                DeleteClubMemberFromUserDB(clubMemberUserName);
                ShowAllClubMembers();
                ClearTextBoxes();
                Logger.Instance.Info("Club Member " + clubMemberUserId + " with ID: " + clubMemberUserName + " deleted");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to Club Member  user details: " + ex);
            }
        }
        private void DeleteClubMemberFromUserDB(string name)
        {
            try
            {
                OracleSingletonComment.Instance.CommandText = "DROP USER " + name + "";
                OracleSingletonComment.Instance.ExecuteNonQuery();
                Logger.Instance.Info("Delete Club Member From User DB");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to Delete Club Member From User DB details: " + ex);
            }

        }
        private void ClearTextBoxes()
        {
            textBoxDelete.Clear();
            textBoxSearch.Clear();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchQueryString = "";
                string select = searchComboBoxDeleteClubMember.SelectedItem.ToString();
                string name = textBoxSearch.Text;
                if (select.Contains(COMBOBOX_NAME_SEARCH))
                {
                    searchQueryString = "SELECT CLUB_MEMBER.MEMBER_ID,USERS.FIRST_NAME,USERS.LAST_NAME,USERS.PASSWORD_ENCRYPTED,USERS.USER_EMAIL,USERS.USER_PHONE_NUMBER,CLUB_MEMBER.JOIN_DATE "
                                + " FROM USERS INNER JOIN CLUB_MEMBER ON USERS.USER_ID = CLUB_MEMBER.USER_ID"
                                + " WHERE CLUB_MEMBER.MEMBER_ID = " + Int32.Parse(name) + "";
                }
                else
                {
                    searchQueryString = "SELECT CLUB_MEMBER.MEMBER_ID,USERS.FIRST_NAME,USERS.LAST_NAME,USERS.PASSWORD_ENCRYPTED,USERS.USER_EMAIL,USERS.USER_PHONE_NUMBER,CLUB_MEMBER.JOIN_DATE "
                                + " FROM USERS INNER JOIN CLUB_MEMBER ON USERS.USER_ID = CLUB_MEMBER.USER_ID"
                                + " WHERE USERS.FIRST_NAME  = '" + name + "'";
                }
                UpdateTable(searchQueryString);
                Logger.Instance.Info("Search Club Member");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to search to Delete Club Member\nDeatails: " + ex);
            }

        }
        private void BackPanelAdminButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
                Logger.Instance.Info("Open Admin Paenel Window and Close Delete Club Member Window");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to open admin panel window and Close Club Member Window \nDetails: " + ex);
            }
        }

        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods


    }
}
