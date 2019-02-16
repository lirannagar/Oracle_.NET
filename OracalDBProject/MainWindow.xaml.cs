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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using Oracle.ManagedDataAccess.Types;
using Logger;
using OracalDBProject.Admin;
using static OracalDBProject.Admin.Enums;

namespace OracalDBProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Control Mapping
        const string CONNECTION_STRING = "DATA SOURCE = localhost:1521/xe;USER ID = SYSTEM; PASSWORD=chenliran123";
        const string ADMIN_USER_NAME_FIRST = "CHEN_ADMIN";
        const string ADMIN_PASSWORD_FIRST = "123123";
        const string ADMIN_USER_NAME_SECOND = "LIRAN_ADMIN";
        const string ADMIN_PASSWORD_SECOND = "123123";
        #endregion Control Mapping

        #region Members

        public OracleConnection con;
        private OracleCommand cmd;
        private OracleDataReader dr;

        #endregion Members

        #region Constructor
        public MainWindow()
        {
            Logger.Instance.Info("-------------------------PROGRAM STARTED-------------------");
            OpenConnection();
           // CreateAdminUsers();
            SwitchAdminUser();       
            //CreateTables();
            //CreateSequences();
            //CreatePackages();
            //InitializeRoles();
            //DropTables();
            //CreateClubMemberUsers();
            try
            {          
                InitializeComponent();
                Logger.Instance.Info("LogIn window opened");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to open main window\nDetails:\n" + ex);
            }
            TextUserName.Text = "LIRAN_ADMIN";
            passwordBox.Text = "123123";

           



            // OracleSingletonConnection.Instance.Close();
        }
        #endregion Constructor

        #region Private Methods
        private void InitializeRoles()
        {
            try
            {
                string adminId = Enums.GetDescription(ERole.ADMIN_ROLE);
                string adminName = "Administrator";
                Role adminRole = new Role(adminId,adminName);
                adminRole.ExecuteToDatabase();
                string clubMemberId = Enums.GetDescription(ERole.CLUB_MEMBER_ROLE);
                string clubMemberName = "Club_Member";
                Role clubMemberRole = new Role(clubMemberId, clubMemberName);
                clubMemberRole.ExecuteToDatabase();
                Logger.Instance.Info("Initialized Roles");
            }catch(Exception ex)
            {
                Logger.Instance.Error("Exception while trying to Initialize Roles Details: " + ex );
            }
        }
        private void CreateAdminUserSequence()
        {
            try
            {
                string adminUserSequenceString = "CREATE SEQUENCE admin_seq"
                                + " START WITH     10000"
                                + " INCREMENT BY   1"
                                + " NOCACHE"
                                + " NOCYCLE";
                OracleSingletonComment.Instance.CommandText = adminUserSequenceString;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Admin Sequence Created");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to Create Admin Sequence\nDetails: " + ex);
            }
        }
        private void CreateSequences()
        {
            try
            {
                CreateProductSequence();
                CreateUserSequence();
                CreateAdminUserSequence();
                Logger.Instance.Info("All Sequences Created");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to add Sequence \nDetails: " +ex);
            }
        }
        private void CreateUserSequence()
        {
            try
            {
                string userSequenceString = "CREATE SEQUENCE user_seq"
                                + " START WITH     1000"
                                + " INCREMENT BY   1"
                                + " NOCACHE"
                                + " NOCYCLE";
                OracleSingletonComment.Instance.CommandText = userSequenceString;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("User Sequence Created");
            }
            catch(OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to Create User Sequence\nDetails: " + ex);
            }
        }
        private void  CreateProductSequence()
        {
            try
            {
                string productSequenceString = "CREATE SEQUENCE product_seq"
                                                +" START WITH     100"
                                                +" INCREMENT BY   1"
                                                +" NOCACHE"
                                                +" NOCYCLE";
                OracleSingletonComment.Instance.CommandText = productSequenceString;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Product Sequence Created");
            }
            catch(OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to Create Product Sequence \nDetails: " + ex);            
            }
        }
        private void CreateAdminPackage()
        {
            try
            {
                string declareAdminPackageStirng = "create or replace package pkg_admin is"
                                     + " PROCEDURE insertAdmin(admin_id number,user_id number,salary_nis number);"
                                     + " end pkg_admin;";
                string bodyAdminPackageStirng = "create or replace package body pkg_admin is"
                  + " PROCEDURE insertAdmin("
                  + " admin_id number,"
                  + " user_id number,"
                  + " salary_nis number)"
                  + " IS"
                  + " BEGIN"
                  + " INSERT INTO ADMINISTRATOR (\"ADMIN_ID\", \"USER_ID\", \"SALARY_NIS\")"
                  + " VALUES (ADMIN_ID,USER_ID,SALARY_NIS);"
                  + " END;"
                  + " end pkg_admin;";
                OracleSingletonComment.Instance.CommandText = declareAdminPackageStirng;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                OracleSingletonComment.Instance.CommandText = bodyAdminPackageStirng;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Admin Package Created");
            }
            catch (OracleException ex)
            {
                throw new Exception("Exception during create admin Package", ex);
            }
        }
        private void CreateUserPackage()
        {
            try
            {
                string declareUserPackageStirng = "create or replace package pkg_user is"
                                     + " PROCEDURE insertUsers(user_id number,role_id varchar2,first_name varchar2,last_name varchar2,user_phone_number varchar2,user_email varchar2,user_address varchar2,password_encrypted varchar2);"
                                     + " end pkg_user;";
                string bodyUsersPackageStirng = "create or replace package body pkg_user is"
                                  + " PROCEDURE insertUsers("
                                  + " user_id number,"
                                  + " role_id varchar2,"
                                  + " first_name varchar2,"
                                  + " last_name varchar2,"
                                  + " user_phone_number varchar2,"
                                  + " user_email varchar2,"
                                  + " user_address varchar2,"
                                  + " password_encrypted varchar2)"
                                  + " IS"
                                  + " BEGIN"
                                  + " INSERT INTO USERS (\"USER_ID\", \"ROLE_ID\", \"FIRST_NAME\", \"LAST_NAME\", \"USER_PHONE_NUMBER\", \"USER_EMAIL\", \"USER_ADDRESS\", \"PASSWORD_ENCRYPTED\")"
                                  + " VALUES (USER_ID,ROLE_ID,FIRST_NAME,LAST_NAME,USER_PHONE_NUMBER,USER_EMAIL,USER_ADDRESS,PASSWORD_ENCRYPTED);"
                                  + " END;"
                                  + " end pkg_user;";
                OracleSingletonComment.Instance.CommandText = declareUserPackageStirng;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                OracleSingletonComment.Instance.CommandText = bodyUsersPackageStirng;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("User Package Created");
            }
            catch(OracleException ex)
            {
                throw new Exception("Exception during create Products Package", ex);
            }

        }
        private void CreateProductsPackage()
        {
            try
            {
                string declareProductsPackageStirng = "create or replace package pkg_product is"
                                                     + " PROCEDURE insertProducts(product_id number,product_name varchar2,product_amount number);"
                                                     + " end pkg_product;";
                string bodyProductsPackageStirng = "create or replace package body pkg_product is"
                                                  + " PROCEDURE insertProducts("
                                                  + " product_id number,"
                                                  + " product_name varchar2,"
                                                  + " product_amount number)"
                                                  + " IS"
                                                  + " BEGIN"
                                                  + " INSERT INTO PRODUCTS (\"PRODUCT_ID\", \"PRODUCT_NAME\", \"PRODUCT_AMOUNT\")"
                                                  + " VALUES (PRODUCT_ID, PRODUCT_NAME,PRODUCT_AMOUNT);"
                                                  + " END;"
                                                  + " end pkg_product;";
                OracleSingletonComment.Instance.CommandText = declareProductsPackageStirng;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                OracleSingletonComment.Instance.CommandText = bodyProductsPackageStirng;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Products Package Created");

            }
            catch(OracleException ex)
            {
                throw new Exception("Exception during create Products Package" ,ex);
            }
        }
        private void CreateRolePackage()
        {
            try
            {
                string declareRolesPackageStirng = "create or replace package pkg_role is"
                                                     + " PROCEDURE insertRole(role_id varchar2,role_name varchar2);"
                                                     + " end pkg_role;";
                string bodyRolesPackageStirng = "create or replace package body pkg_role is"
                                                  + " PROCEDURE insertRole("
                                                  + " role_id varchar2,"                                                
                                                  + " role_name varchar2)"
                                                  + " IS"
                                                  + " BEGIN"
                                                  + " INSERT INTO ROLES (\"ROLE_ID\", \"ROLE_NAME\")"
                                                  + " VALUES (ROLE_ID, ROLE_NAME);"
                                                  + " END;"
                                                  + " end pkg_role;";
                OracleSingletonComment.Instance.CommandText = declareRolesPackageStirng;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                OracleSingletonComment.Instance.CommandText = bodyRolesPackageStirng;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Package Role Created");

            }
            catch (OracleException ex)
            {
                throw new Exception("Exception during create Role Package" ,  ex);
            }
        }
        private void CreatePackages()
        {
            try
            {
                //CreateProductsPackage();
                //CreateUserPackage();
                CreateAdminPackage();
                //CreateRolePackage();
            }
            catch(OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to create packeges\nDetails:" + ex);
            }

        }
        private void SwitchAdminUser()
        {
            try
            {             
                OracleSingletonConnection.Instance.Close();
                OracleSingletonConnection.Instance.ConnectionString = "DATA SOURCE = localhost:1521/xe;USER ID = LIRAN_ADMIN; PASSWORD=123123";
                OracleSingletonConnection.Instance.Open();
                Logger.Instance.Info("Admin User Switched");
            }
            catch(OracleException ex)
            {
                Logger.Instance.Error("Exption while trying to chenge admin user\n Details:\n" + ex);
            }
        }
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string loginName = TextUserName.Text;
            string password = passwordBox.Text;
            try
            {
                if (loginName.Equals(ADMIN_USER_NAME_FIRST) && password.Equals(ADMIN_PASSWORD_FIRST))
                {
                    AdminPanel adminWin = new AdminPanel();
                    adminWin.Show();
                    this.Close();
                }
                else if (loginName.Equals(ADMIN_USER_NAME_SECOND) && password.Equals(ADMIN_PASSWORD_SECOND))
                {
                    AdminPanel adminWin = new AdminPanel();
                    adminWin.Show();
                    this.Close();

                }
                else
                {
                    string messageBoxText = "the user name/password is not exist...please try again";
                    string caption = "ERROR";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Warning;
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }

            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exption while trying to open the right admin/customer \n Details:\n" + ex);
            }
            //Write queries here to check if the role is true            

        }
        private void CreateClubMemberUsers()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();                
                cmd.Connection = con;
               // cmd.CommandText = String.Format("CREATE USER {0} IDENTIFIED BY \"{1}\"", ADMIN_USER_NAME_FIRST, ADMIN_PASSWORD_FIRST);
                cmd.CommandText = String.Format("CREATE USER {0} IDENTIFIED BY \"{1}\"", ADMIN_USER_NAME_SECOND, ADMIN_PASSWORD_SECOND);
                dr = cmd.ExecuteReader();
               // cmd.CommandText = String.Format("grant create session to {0}", ADMIN_USER_NAME_FIRST);
                cmd.CommandText = String.Format("grant create session to {0}", ADMIN_USER_NAME_SECOND);
                dr = cmd.ExecuteReader();
                Logger.Instance.Info("Admin User created seccefully");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exeption while trying to create Admin User DB\nDetails:\n" + ex);
            }
        }
        private void CreateAdminUsers()
        {
            try
            {
                OracleCommand cmd = new OracleCommand();             
                cmd.Connection = con;
                cmd.CommandText = String.Format("CREATE USER {0} IDENTIFIED BY \"{1}\"", ADMIN_USER_NAME_FIRST, ADMIN_PASSWORD_FIRST);
                dr = cmd.ExecuteReader();
                cmd.CommandText = String.Format("CREATE USER {0} IDENTIFIED BY \"{1}\"", ADMIN_USER_NAME_SECOND, ADMIN_PASSWORD_SECOND);
                dr = cmd.ExecuteReader();
                cmd.CommandText = String.Format("grant dba to {0}", ADMIN_USER_NAME_FIRST);
                dr = cmd.ExecuteReader();              
                cmd.CommandText = String.Format("GRANT dba to {0}", ADMIN_USER_NAME_SECOND);
                dr = cmd.ExecuteReader();
                Logger.Instance.Info("Admin User created seccefully");
            }catch(OracleException ex)
            {
                Logger.Instance.Error("Exeption while trying to create Admin User DB\nDetails:\n" + ex);
            }
        }
        public void DropTables()
        {
            try
            {
                string paymentStringDropTable = "drop table Payment";
                string transactionDetailsStringDropTable ="drop table transaction_details";
                string productsStringDropTable = "drop table products";
                string transactionStringDropTable = "drop table TRANSACTION";
                string clubMemberStringDropTable = "drop table club_member";
                string administratorStringDropTable = "drop table administrator";
                string userStringDropTable = "drop table users";
                string rolesStringDropTable = "drop table roles";

                OracleSingletonComment.Instance.CommandText = paymentStringDropTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Table Payment DROPED");
                OracleSingletonComment.Instance.CommandText = transactionDetailsStringDropTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Table transaction_details DROPED");
                OracleSingletonComment.Instance.CommandText = productsStringDropTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Table products DROPED");
                OracleSingletonComment.Instance.CommandText = transactionStringDropTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Table TRANSACTION DROPED");
                OracleSingletonComment.Instance.CommandText = clubMemberStringDropTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Table club_member DROPED");
                OracleSingletonComment.Instance.CommandText = administratorStringDropTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Table administrator DROPED");
                OracleSingletonComment.Instance.CommandText = userStringDropTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Table users DROPED");
                OracleSingletonComment.Instance.CommandText = rolesStringDropTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Table roles DROPED");
            }
            catch(OracleException ex)
            {
                Logger.Instance.Error("Exeption while trying to drop tables\nDetails:\n" + ex);
            }
        }
        private void CreateTables()
        {
            try
            {
                string rolesStringTable = "create table Roles"+
                    "("
                    + "role_ID VARCHAR2(20) not null,"
                    + "role_Name VARCHAR2(20) not null,"
                    + "CONSTRAINT Roles_pk PRIMARY KEY (role_ID)" 
                    +")";
                string userStringTable = "create table Users" +
                    "("
                    + "User_id number(20) not null,"
                    + "role_id VARCHAR2(20) ,"
                    + "first_name VARCHAR2(20) not null,"
                    + "last_name VARCHAR2(20) not null,"
                    + "user_phone_number VARCHAR2(20) not null,"
                    + "user_email VARCHAR2(20) not null,"
                    + "user_address VARCHAR2(20) not null,"
                    + "password_encrypted VARCHAR2(40) not null,"
                    + "CONSTRAINT Users_pk PRIMARY KEY (User_id),"
                    + "CONSTRAINT fk_Roles"
                      + " FOREIGN KEY (role_id)"
                      + " REFERENCES Roles (role_id)"
                    + ")";
                string administratorStringTable = "create table Administrator" +
                    "("
                    + "admin_id number(20) not null,"
                    + "User_id number(20),"
                    + "salary_NIS number(38) not null,"
                    + "CONSTRAINT Administrator_pk PRIMARY KEY (admin_id),"
                    + "CONSTRAINT fk_Users"
                      + " FOREIGN KEY (User_id)"
                      + " REFERENCES Users (User_id)"
                    + ")";
                string clubMemberStringTable = "create table Club_member" +
                    "("
                    + "member_id number(20) not null,"
                    + "user_id number(20),"
                    + "join_date DATE DEFAULT (sysdate),"
                    + "CONSTRAINT Club_member_pk PRIMARY KEY (member_id),"
                    + "CONSTRAINT fk_Userss"
                      + " FOREIGN KEY (user_id)"
                      + " REFERENCES Users (user_id)"
                    + ")";
                string transactionStringTable = "create table Transaction" +
                    "("
                    + "Transaction_id number(20) not null,"
                    + "member_id number(20) ,"
                    + "date_transaction DATE DEFAULT (sysdate),"
                    + "CONSTRAINT Transaction_pk PRIMARY KEY (Transaction_id),"
                    + "CONSTRAINT fk_Club_member"
                      + " FOREIGN KEY (member_id)"
                      + " REFERENCES Club_member (member_id)"
                    + ")";
                string productsStringTable = "create table Products" +
                    "("
                    + "Product_id number(20) not null,"
                    + "product_name VARCHAR2(20) not null,"
                    + "product_amount number(38),"
                    + "CONSTRAINT Products_pk PRIMARY KEY (Product_id)"
                    + ")";
                string transactionDetailsStringTable = "create table Transaction_Details" +
                    "("
                  
                    + "Transaction_id number(20),"
                    + "Product_id number(20),"
                    + "CONSTRAINT fk_Transaction"
                      + " FOREIGN KEY (Transaction_id)"
                      + " REFERENCES Transaction (Transaction_id),"
                    + "CONSTRAINT fk_Products"
                      + " FOREIGN KEY (Product_id)"
                      + " REFERENCES Products (Product_id)"
                    + ")";
                string paymentStringTable = "create table Payment" +
                    "("
                    + "Payment_id number(20) not null,"
                    + "transaction_id number(20) ,"
                    + "payment_date DATE DEFAULT (sysdate),"
                    + "payment_total number(38) not null,"
                    + "credit_card VARCHAR2(30) not null,"
                    + "CONSTRAINT Payment_pk PRIMARY KEY (Payment_id),"
                    + "CONSTRAINT fk_Transactionn"
                      + " FOREIGN KEY (transaction_id)"
                      + " REFERENCES Transaction (transaction_id)"
                    + ")";
                OracleSingletonComment.Instance.CommandText = rolesStringTable;            
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("TABLE Roles was CREATED");
                OracleSingletonComment.Instance.CommandText = userStringTable;              
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("TABLE Users was CREATED");
                OracleSingletonComment.Instance.CommandText = administratorStringTable;              
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("TABLE Administrator was CREATED");
                OracleSingletonComment.Instance.CommandText = clubMemberStringTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("TABLE Club_member was CREATED");
                OracleSingletonComment.Instance.CommandText = transactionStringTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("TABLE Transaction was CREATED");
                OracleSingletonComment.Instance.CommandText = productsStringTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("TABLE Products was CREATED");
                OracleSingletonComment.Instance.CommandText = transactionDetailsStringTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("TABLE Transaction_Details was CREATED");
                OracleSingletonComment.Instance.CommandText = paymentStringTable;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("TABLE Payment was CREATED");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exeption while trying to CREATE TABLE\n Details:\n" + ex);
            }
        }
        private void OpenConnection()
        {
            try
            {                           
                cmd = new OracleCommand();
                OracleSingletonConnection.Instance.Open();
                Logger.Instance.Info("DB was opened seccefully");                         
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exeption while trying to open DB\n Details:\n" + ex);
            }
        }
        #endregion Private Methods
    }
}
