using OracalDBProject.Admin;
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

namespace OracalDBProject.Club_Member
{
    /// <summary>
    /// Interaction logic for ClubMemberWindow.xaml
    /// </summary>
    public partial class ClubMemberWindow : Window
    {

        #region Control Mapping
        #endregion Control Mapping

        #region Members
        #endregion Members

        #region Contructor
        public ClubMemberWindow()
        {
            InitializeComponent();
            Logger.Instance.Info("Club Member Window Opened");
        }
        #endregion Contructor

        #region Private Methods
        private void singUpClubMeberButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string roleId = Enums.GetDescription(ERole.CLUB_MEMBER_ROLE);
                string firstName = firstNameTextBox.Text;
                string lastName = lastNameTextBox.Text;
                string phoneNumber = phoneNumberTextBox.Text;
                string email = emailClubMemberTextBox.Text;
                string address = addressClubMemberTextBox.Text;
                string password = clubMemberPasswordBox.Password.ToString();
                User user = new User(roleId, firstName, lastName, phoneNumber, email, address, password);
                user.ExecuteToDatabase();
                string date = DateTime.Today.ToString("dd-MM-yyyy");
                ClubMember clubMember = new ClubMember(user.GetId(), date);
                clubMember.ExecuteToDatabase();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OracleSingletonConnection.Instance;
                cmd.CommandText = String.Format("CREATE USER {0} IDENTIFIED BY \"{1}\"", firstName, password);
                cmd.ExecuteNonQuery();
                cmd.CommandText = String.Format("GRANT SELECT ON PRODUCTS TO {0}", firstName);
                cmd.ExecuteNonQuery();
                CleanTextBoxes();
                Logger.Instance.Info("Club member Singed UP");
            }catch(Exception ex)
            {
                Logger.Instance.Error("Exception while trying to sing UP Club member \nDetails " + ex);
            }
    
        }
        private void CleanTextBoxes()
        {
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            clubMemberPasswordBox.Clear();
            addressClubMemberTextBox.Clear();
            emailClubMemberTextBox.Clear();
            phoneNumberTextBox.Clear();
        }
        private void backButtonClubMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminPanel win = new AdminPanel();
                win.Show();
                this.Close();
                Logger.Instance.Info("Club Member User Window Closed");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to close Club Member Window Details\n" + ex);
            }
        }
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods


    }
}
