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
    /// Interaction logic for ShowAllClubMemberWindow.xaml
    /// </summary>
    public partial class ShowAllClubMemberWindow : Window
    {

        #region Control Mapping
        const string TABLE_NAME_UPDATE = "USERS";
        #endregion Control Mapping


        #region Members
        #endregion Members


        #region Constructor
        public ShowAllClubMemberWindow()
        {
            InitializeComponent();
            ShowClubMembers();
        }
        #endregion Constructor


        #region Private Methods
        private void ShowClubMembers()
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
                Logger.Instance.Error("Erorr while trying to show all Club Members \nDetails" + ex);
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
                GridAllClubMembers.ItemsSource = dt.DefaultView;
                OracleSingletonComment.Instance.Cancel();
                Logger.Instance.Info("Table Updated");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Wrong Value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.Instance.Error("Exception while trying to update table\nDeatails: " + ex);
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

        private void ButtonBackToAdminPanel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
                Logger.Instance.Info("Open Admin Panel Window and Close show Club Member Window");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to open admin panel window and Close show all Club Member Window \nDetails: " + ex);
            }
        }
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods


    }
}
