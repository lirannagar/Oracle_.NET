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

namespace OracalDBProject.Admin
{
    /// <summary>
    /// Interaction logic for ShowAllAdminWindow.xaml
    /// </summary>
    public partial class ShowAllAdminWindow : Window
    {



        #region Control Mapping
        const string TABLE_NAME_UPDATE = "USERS";
        #endregion Control Mapping


        #region Members
        #endregion Members


        #region Constructor
        public ShowAllAdminWindow()
        {
            InitializeComponent();
            ShowAllAdmins();
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
                GridAllAdminUsers.ItemsSource = dt.DefaultView;
                OracleSingletonComment.Instance.Cancel();
                Logger.Instance.Info("Table Updated");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Wrong Value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.Instance.Error("Exception while trying to update table\nDeatails: " + ex);
            }
        }
        private void BackToAdminPanelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
                Logger.Instance.Info("Open Admin Panel Window and Close show Admins Window");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to open admin panel window and Close show all Admin Window \nDetails: " + ex);
            }
        }


        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods


    }
}
