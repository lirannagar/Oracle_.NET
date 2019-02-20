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
    /// Interaction logic for DeleteAdminWindow.xaml
    /// </summary>
    public partial class DeleteAdminWindow : Window
    {
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

        private void  ShowAllAdmins()
        {
            try
            {
                string searchQueryString = "SELECT ADMINISTRATOR.ADMIN_ID,USERS.FIRST_NAME,USERS.LAST_NAME,USERS.PASSWORD_ENCRYPTED,USERS.USER_EMAIL,USERS.USER_PHONE_NUMBER,ADMINISTRATOR.SALARY_NIS "
                                                + " FROM USERS INNER JOIN ADMINISTRATOR ON USERS.USER_ID = ADMINISTRATOR.USER_ID";
                UpdateTable(searchQueryString);
                Logger.Instance.Info("All Admins Shown");
            }catch(OracleException ex)
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
                if (select.Contains("By ID"))
                {
                    searchQueryString = "SELECT ADMINISTRATOR.ADMIN_ID,USERS.FIRST_NAME,USERS.LAST_NAME,USERS.PASSWORD_ENCRYPTED,USERS.USER_EMAIL,USERS.USER_PHONE_NUMBER,ADMINISTRATOR.SALARY_NIS "
                                + " FROM USERS INNER JOIN ADMINISTRATOR ON USERS.USER_ID = ADMINISTRATOR.USER_ID"
                                + " WHERE ADMINISTRATOR.USER_ID= " + textBoxSearchDeleteAdmin.Text + "";
                }
                else
                {
                    searchQueryString = "SELECT ADMINISTRATOR.ADMIN_ID,USERS.FIRST_NAME,USERS.LAST_NAME,USERS.PASSWORD_ENCRYPTED,USERS.USER_EMAIL,USERS.USER_PHONE_NUMBER,ADMINISTRATOR.SALARY_NIS "
                                + " FROM USERS INNER JOIN ADMINISTRATOR ON USERS.USER_ID = ADMINISTRATOR.USER_ID"
                                + " WHERE USERS.FIRST_NAME  = '" + textBoxSearchDeleteAdmin.Text + "'";
                }
                UpdateTable(searchQueryString);
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to search to Delete Product\nDeatails: " + ex);
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
                DataTable dt = new DataTable("USERS");
                da.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
                Logger.Instance.Info("Table Updated");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Wrong Value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void deleteButtonAdmin_Click(object sender, RoutedEventArgs e)
        {
            //SELECT ADMINISTRATOR.USER_ID FROM ADMINISTRATOR WHERE ADMIN_ID= 10022;
        }
    }
}
