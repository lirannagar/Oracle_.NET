using Oracle.ManagedDataAccess.Client;


using System;
using System.Collections.Generic;
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
using static OracalDBProject.Admin.Enums;

namespace OracalDBProject.Admin
{
    /// <summary>
    /// Interaction logic for AddAdminUserWindow.xaml
    /// </summary>
    public partial class AddAdminUserWindow : Window
    {

        #region Control Mapping
        const int SALARY_ADMIN = 2000;
        #endregion Control Mapping

        #region Members
        #endregion Members

        #region Constructor
        public AddAdminUserWindow()
        {
            InitializeComponent();
            Logger.Instance.Info("Add Admin User Window Opened");
        }




        #endregion Constructor

        #region Private Methods
        private void backPanelAdminWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminPanel win = new AdminPanel();
                win.Show();
                this.Close();
                Logger.Instance.Info("Add Admin User Window Closed");
            }catch(Exception ex)
            {
                Logger.Instance.Error("Exception while trying to close Add Admin User Window Details\n" + ex);
            }
          

        }
        private void singAdminButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string roleId = Enums.GetDescription(ERole.ADMIN_ROLE);
                string firstName = firstNameTextBox.Text;
                string lastName = lastNameTextBox.Text;
                string phoneNumber = phoneNumberTextBox.Text;
                string email = emailTextBox.Text;
                string address = addressTextBox.Text;
                string password = passwordBoxAdmin.Password.ToString();
                User user = new User(roleId, firstName, lastName, phoneNumber, email, address, password);
                user.ExecuteToDatabase();
                AdminUser adminUser = new AdminUser(user.GetId(), SALARY_ADMIN);
                adminUser.ExecuteToDatabase();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OracleSingletonConnection.Instance;
                cmd.CommandText = String.Format("CREATE USER {0} IDENTIFIED BY \"{1}\"", firstName, password);
                cmd.ExecuteNonQuery();
                cmd.CommandText = String.Format("grant dba to {0}", firstName);
                cmd.ExecuteNonQuery();
                CleanTextBoxes();
                Logger.Instance.Info("Admin " + firstName + " Singed In");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to Sing Admin Details\n" + ex);
            }
        }

        private void CleanTextBoxes()
        {
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            passwordBoxAdmin.Clear();
            addressTextBox.Clear();
            emailTextBox.Clear();
            phoneNumberTextBox.Clear();
        }

        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods


    }
}
