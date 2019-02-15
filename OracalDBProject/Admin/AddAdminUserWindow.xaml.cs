using Oracle.DataAccess.Client;
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

        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods

        private void singAdminButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string namerole = Enums.GetAttributeOfType(ERole.ADMIN_ROLE);
               // string roleId = namerole.ToName();
                string firstName = firstNameTextBox.Text;
                string lastName = lastNameTextBox.Text;
                string phoneNumber = phoneNumberTextBox.Text;
                string email =  emailTextBox.Text;
                string address = addressTextBox.Text;
                string password =  passwordBoxAdmin.ToString();
                User user = new User();

                Logger.Instance.Info("Admin Singed In");
            }catch(OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to Sing Admin Details\n" + ex);
            }
        }
    }
}
