﻿using System;
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
using OracalDBProject.Club_Member;
using System.ComponentModel;
using System.Data;

namespace OracalDBProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Control Mapping
        const string CONNECTION_STRING = "DATA SOURCE = localhost:1521/xe;USER ID = SYSTEM; PASSWORD=chenliran123";

        const string ADMIN_USER_NAME_FIRST = "LIRAN_ADMIN";
        const string ADMIN_PASSWORD_FIRST  = "123123";
        const string ADMIN_ROLE_NAME = "Administrator";
        const string CLUB_MEMBER_ROLE_NAME = "Club Member";

        #endregion Control Mapping

        #region Members

        public OracleConnection con;
        private OracleCommand cmd;
        private OracleDataReader dr;

        #endregion Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            Logger.Instance.Info("-------------------------PROGRAM STARTED-------------------");
            OpenConnection();
             CreateAdminUsers();              
            UserConnectionSwitch(ADMIN_USER_NAME_FIRST, ADMIN_PASSWORD_FIRST);
            //CreateFunctions();

            //CreatePackages();
            //CreateTables();
            //CreateSequences();
            //CreateViews();
            //InitializeRoles();

            try
            {
                InitializeComponent();
                Logger.Instance.Info("LogIn window opened");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to open main window\nDetails:\n" + ex);
            }
            TextUserName.Text = "ASDA";
            passwordBox.Text = "123123";
        }
        #endregion Constructor

        #region Private Methods
        private void CreateProductsView()
        {
            try
            {
                string createViewString = "CREATE VIEW vw_products AS "
                                            + " SELECT PRODUCTS.PRODUCT_ID, PRODUCTS.PRODUCT_NAME, PRODUCTS.PRODUCT_AMOUNT"
                                            + " FROM PRODUCTS";
                OracleSingletonComment.Instance.CommandText = createViewString;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Products View Created");
            }
            catch
            {
                Logger.Instance.Info("Products View already exist");
            }


        }
        private void CreateAdminView()
        {
            try
            {
                string createViewString = "CREATE VIEW vw_admins AS "
                                            + " SELECT ADMINISTRATOR.ADMIN_ID,USERS.FIRST_NAME,USERS.LAST_NAME,USERS.PASSWORD_ENCRYPTED,USERS.USER_EMAIL,USERS.USER_PHONE_NUMBER,ADMINISTRATOR.SALARY_NIS "
                                            + " FROM USERS INNER JOIN ADMINISTRATOR ON USERS.USER_ID = ADMINISTRATOR.USER_ID";
                OracleSingletonComment.Instance.CommandText = createViewString;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Admin View Created");
            }
            catch
            {
                Logger.Instance.Info("Admin View already exist");
            }
        }
        private void CreateClubMemberView()
        {
            try
            {
                string createViewString = "CREATE VIEW vw_club_member AS "
                                            + " SELECT CLUB_MEMBER.MEMBER_ID,USERS.FIRST_NAME,USERS.LAST_NAME,USERS.PASSWORD_ENCRYPTED,USERS.USER_EMAIL,USERS.USER_PHONE_NUMBER,CLUB_MEMBER.JOIN_DATE "
                                            + " FROM USERS INNER JOIN CLUB_MEMBER ON USERS.USER_ID = CLUB_MEMBER.USER_ID";
                OracleSingletonComment.Instance.CommandText = createViewString;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Club Member View Created");
            }
            catch
            {
                Logger.Instance.Info("Club Member View already exist");
            }
        }
        private void CreateViews()
        {
            try
            {
                CreateProductsView();
                CreateAdminView();
                CreateClubMemberView();
            }
            catch
            {
                Logger.Instance.Info("Trying to create views but thay are already exist");

            }


        }
        private void InitializeRoles()
        {
            try
            {
                string adminId = Enums.GetDescription(ERole.ADMIN_ROLE);
                string adminName = "Administrator";
                Role adminRole = new Role(adminId, adminName);
                adminRole.ExecuteToDatabase();
                string clubMemberId = Enums.GetDescription(ERole.CLUB_MEMBER_ROLE);
                string clubMemberName = "Club_Member";
                Role clubMemberRole = new Role(clubMemberId, clubMemberName);
                clubMemberRole.ExecuteToDatabase();
                Logger.Instance.Info("Initialized Roles");
            }
            catch
            {
                Logger.Instance.Info("Roles already exist");
            }
        }
        public void DropSequences()
        {
            try
            {
                string productsStringDropSequence = "drop  SEQUENCE LIRAN_ADMIN.PRODUCT_SEQ";
                string clubMemberStringDropSequence = "drop SEQUENCE  LIRAN_ADMIN.club_member_seq";
                string administratorStringDropSequence = "DROP SEQUENCE LIRAN_ADMIN.ADMIN_SEQ";
                string userStringDropSequence = "drop SEQUENCE LIRAN_ADMIN.user_seq";

                OracleSingletonComment.Instance.CommandText = productsStringDropSequence;
                OracleSingletonComment.Instance.ExecuteNonQuery();
                Logger.Instance.Info("SEQUENCE product_seq DROPED");
                OracleSingletonComment.Instance.CommandText = clubMemberStringDropSequence;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("SEQUENCE club_member_seq DROPED");
                OracleSingletonComment.Instance.CommandText = administratorStringDropSequence;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("SEQUENCE admin_seq DROPED");
                OracleSingletonComment.Instance.CommandText = userStringDropSequence;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("SEQUENCE user_seq DROPED");
            }
            catch
            {
                Logger.Instance.Info("Some of the Sequences are not exist");
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
            catch
            {
                Logger.Instance.Info("Admin User Sequence already exist");
            }
        }
        private void CreateClubMemberSequence()
        {
            try
            {
                string adminUserSequenceString = "CREATE SEQUENCE club_member_seq"
                                + " START WITH     10000"
                                + " INCREMENT BY   1"
                                + " NOCACHE"
                                + " NOCYCLE";
                OracleSingletonComment.Instance.CommandText = adminUserSequenceString;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Club Member Sequence Created");
            }
            catch
            {
                Logger.Instance.Info("Club Member Sequence already exist");
            }
        }
        private void CreateSequences()
        {
            try
            {
                CreateProductSequence();
                CreateUserSequence();
                CreateAdminUserSequence();
                CreateClubMemberSequence();
                Logger.Instance.Info("All Sequences Created");
            }
            catch
            {
                Logger.Instance.Info("Trying to create Sequences but the Sequences already exist");
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
            catch
            {
                Logger.Instance.Info("User Sequence already exist");
            }
        }
        private void CreateProductSequence()
        {
            try
            {
                string productSequenceString = "CREATE SEQUENCE product_seq"
                                                + " START WITH     100"
                                                + " INCREMENT BY   1"
                                                + " NOCACHE"
                                                + " NOCYCLE";
                OracleSingletonComment.Instance.CommandText = productSequenceString;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Product Sequence Created");
            }
            catch
            {
                Logger.Instance.Info("Product Sequence already exist");
            }
        }
        private void CreateAdminPackage()
        {
            try
            {
                string declareAdminPackageStirng = "create or replace package pkg_admin is"
                                     + " PROCEDURE insertAdmin(admin_id number,user_id number,salary_nis number);"
                                     + " FUNCTION get_admin_user_id(iduser IN number) RETURN number;"
                                     + " end pkg_admin;";
                string bodyAdminPackageStirng = "create or replace package body pkg_admin is"
                  + " FUNCTION get_admin_user_id(iduser IN number) RETURN NUMBER IS res_value NUMBER(11,2);"
                  + " BEGIN"
                  + "   SELECT ADMINISTRATOR.USER_ID INTO res_value FROM ADMINISTRATOR WHERE ADMIN_ID = iduser;  RETURN(res_value);"
                  + " END; "
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
            catch (OracleException ex)
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
            catch (OracleException ex)
            {
                throw new Exception("Exception during create Products Package", ex);
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
                throw new Exception("Exception during create Role Package", ex);
            }
        }
        private void CreateClubMemberPackage()
        {
            try
            {
                string declareClubMemberPackageStirng = "create or replace package pkg_club_member is"
                                                     + " PROCEDURE insertClubMember(member_id number,user_id number,join_date varchar2);"
                                                     + " FUNCTION get_club_member_user_id(iduser IN number) RETURN number;"
                                                     + " end pkg_club_member;";
                string bodyClubMemberPackageStirng = "create or replace package body pkg_club_member is"
                                                   + " FUNCTION get_club_member_user_id(iduser IN number) RETURN NUMBER IS res_value NUMBER(11,2);"
                                                  + " BEGIN"
                                                  + "   SELECT CLUB_MEMBER.USER_ID INTO res_value FROM CLUB_MEMBER WHERE MEMBER_ID = iduser;  RETURN(res_value);"
                                                  + " END; "
                                                  + " PROCEDURE insertClubMember("
                                                  + " member_id number,"
                                                  + " user_id number,"
                                                  + " join_date varchar2)"
                                                  + " IS"
                                                  + " BEGIN"
                                                  + " INSERT INTO CLUB_MEMBER (\"MEMBER_ID\", \"USER_ID\", \"JOIN_DATE\")"
                                                  + " VALUES (MEMBER_ID, USER_ID, JOIN_DATE);"
                                                  + " END;"
                                                  + " end pkg_club_member;";
                OracleSingletonComment.Instance.CommandText = declareClubMemberPackageStirng;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                OracleSingletonComment.Instance.CommandText = bodyClubMemberPackageStirng;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("Package Club Member Created");

            }
            catch (OracleException ex)
            {
                throw new Exception("Exception during create Club Member Package", ex);
            }
        }
        private void CreatePackages()
        {
            try
            {
                CreateProductsPackage();
                CreateUserPackage();
                CreateAdminPackage();
                CreateRolePackage();
                CreateClubMemberPackage();
            }
            catch
            {
                Logger.Instance.Info("Trying to create packages but the packages exist");
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
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exption while trying to chenge admin user\n Details:\n" + ex);
            }
        }
        private void UserConnectionSwitch(string loginName, string password)
        {
            OracleSingletonConnection.Instance.Close();
            OracleSingletonConnection.Instance.ConnectionString = "DATA SOURCE = localhost:1521/xe;USER ID = " + loginName + "; PASSWORD=" + password + "";
            OracleSingletonConnection.Instance.Open();
            Logger.Instance.Info("User Switched to " + loginName);
        }
        private void CreateFunctions()
        {
            try
            {
                string roleFunctionDeclare =
                                        "create or replace FUNCTION get_role_user(iduser IN VARCHAR2) RETURN VARCHAR2 IS res_value VARCHAR2(4000);"
                                      + " BEGIN"
                                      + "   SELECT USERS.role_id INTO res_value FROM USERS WHERE FIRST_NAME = iduser;  RETURN(res_value);"
                                      + " END; ";
                OracleSingletonComment.Instance.CommandText = roleFunctionDeclare;
                OracleSingletonComment.Instance.ExecuteNonQuery();
                Logger.Instance.Info("get_role_user Function created");
                string userFunctionDeclare =
                                     "create or replace FUNCTION get_user_id(iduser IN VARCHAR2) RETURN NUMBER IS res_value NUMBER(20);"
                                     + " BEGIN"
                                     + "   SELECT USERS.USER_ID INTO res_value FROM USERS WHERE FIRST_NAME = iduser;  RETURN(res_value);"
                                     + " END; ";
                OracleSingletonComment.Instance.CommandText = userFunctionDeclare;
                OracleSingletonComment.Instance.ExecuteNonQuery();
                Logger.Instance.Info("get_role_user Function created");
            }
            catch
            {
                Logger.Instance.Info("Functions already exist");
            }

        }
        private string GetRoleUser(string userFirstName)
        {
            try
            {
                OracleSingletonComment.Instance.CommandText = "get_role_user";
                OracleSingletonComment.Instance.CommandType = CommandType.StoredProcedure;
                OracleSingletonComment.Instance.Parameters.Add("res_value", OracleDbType.Varchar2, 3000).Direction = ParameterDirection.ReturnValue;
                OracleSingletonComment.Instance.Parameters.Add("iduser", OracleDbType.Varchar2).Value = userFirstName;
                OracleSingletonComment.Instance.ExecuteNonQuery();
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to Get Role User" + ex);
            }
            return OracleSingletonComment.Instance.Parameters["res_value"].Value.ToString();
        }
        private string GetUserId(string userFirstName)
        {
            string nameID = "";
            try
            {                
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = OracleSingletonConnection.Instance;
                string user = "select LIRAN_ADMIN.USERS.USER_ID " 
                              + " FROM LIRAN_ADMIN.USERS "
                              + " WHERE LIRAN_ADMIN.USERS.FIRST_NAME like '"+ userFirstName + "' ";
                cmd.CommandText = user;
                nameID = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to Get User ID" + ex);
            }
            return nameID;
        }
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            string loginName = TextUserName.Text;
            string password = passwordBox.Text;
            string roleUserName = GetRoleUser(loginName);
            string userId = GetUserId(loginName);
            string select = comboBox.SelectedItem.ToString();
            try
            {
                if (select.Contains(ADMIN_ROLE_NAME) && select.Contains(ADMIN_USER_NAME_FIRST) && roleUserName.Equals(Enums.GetDescription(ERole.ADMIN_ROLE)) && !string.IsNullOrEmpty(userId))
                {
                    UserConnectionSwitch(loginName, password);
                    AdminPanel win = new AdminPanel();
                    win.Show();
                    this.Close();
                }
                else if (select.Contains(CLUB_MEMBER_ROLE_NAME) && roleUserName.Equals(Enums.GetDescription(ERole.CLUB_MEMBER_ROLE)) && !string.IsNullOrEmpty(userId))
                {
                    UserConnectionSwitch(loginName, password);
                    ClubMemberOperationWindow win = new ClubMemberOperationWindow();
                    win.Show();
                    this.Close();
                }
                else {
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


        }
        private void DropAllUsers()
        {
            try
            {

                //// string adminUserOne = "drop user " + ADMIN_USER_NAME_FIRST + " CASCADE";
                // string adminUserTwo = "drop user " + ADMIN_USER_NAME_SECOND + " CASCADE";


                // //OracleSingletonComment.Instance.CommandText = adminUserOne;
                // //dr = OracleSingletonComment.Instance.ExecuteReader();
                // //Logger.Instance.Info("User " + ADMIN_USER_NAME_FIRST + " DROPED");
                // cmd.CommandText = adminUserTwo;
                // cmd.ExecuteNonQuery();
                // Logger.Instance.Info("User " + ADMIN_USER_NAME_SECOND + " DROPED");
            }
            catch
            {
                Logger.Instance.Info("Some users are exist in the Database");
            }

        }


        private void CreateAdminUsers()
        {
            try
            {


                OracleSingletonComment.Instance.CommandText = String.Format("CREATE USER {0} IDENTIFIED BY \"{1}\"", ADMIN_USER_NAME_FIRST, ADMIN_PASSWORD_FIRST);
                OracleSingletonComment.Instance.ExecuteNonQuery();
               
                OracleSingletonComment.Instance.CommandText = String.Format("GRANT dba to {0}", ADMIN_PASSWORD_FIRST);
                OracleSingletonComment.Instance.ExecuteNonQuery();
                Logger.Instance.Info("Admin User created seccefully");
            }
            catch
            {
                Logger.Instance.Info("Trying to create admin user but already exist");
            }
        }
        public void DropTables()
        {
            try
            {
                string paymentStringDropTable = "drop table LIRAN_ADMIN.Payment";
                string transactionDetailsStringDropTable = "drop table LIRAN_ADMIN.transaction_details";
                string productsStringDropTable = "drop table LIRAN_ADMIN.products";
                string transactionStringDropTable = "drop table LIRAN_ADMIN.TRANSACTION";
                string clubMemberStringDropTable = "drop table LIRAN_ADMIN.club_member";
                string administratorStringDropTable = "drop table LIRAN_ADMIN.administrator";
                string userStringDropTable = "drop table LIRAN_ADMIN.users";
                string rolesStringDropTable = "drop table LIRAN_ADMIN.roles";

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
            catch
            {
                Logger.Instance.Info("Some of the table are not exist");
            }
        }
        public void DropPackages()
        {
            try
            {

                string productsStringDropPACKAGE = "drop PACKAGE LIRAN_ADMIN.products";

                string clubMemberStringDropPACKAGE = "drop PACKAGE LIRAN_ADMIN.club_member";
                string administratorStringDropPACKAGE = "drop PACKAGE LIRAN_ADMIN.administrator";
                string userStringDropPACKAGE = "drop PACKAGE LIRAN_ADMIN.users";
                string rolesStringDropPACKAGE = "drop PACKAGE LIRAN_ADMIN.roles";


                Logger.Instance.Info("PACKAGE transaction_details DROPED");
                OracleSingletonComment.Instance.CommandText = productsStringDropPACKAGE;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("PACKAGE products DROPED");
                OracleSingletonComment.Instance.CommandText = clubMemberStringDropPACKAGE;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("PACKAGE club_member DROPED");
                OracleSingletonComment.Instance.CommandText = administratorStringDropPACKAGE;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("PACKAGE administrator DROPED");
                OracleSingletonComment.Instance.CommandText = userStringDropPACKAGE;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("PACKAGE users DROPED");
                OracleSingletonComment.Instance.CommandText = rolesStringDropPACKAGE;
                dr = OracleSingletonComment.Instance.ExecuteReader();
                Logger.Instance.Info("PACKAGE roles DROPED");
            }
            catch
            {
                Logger.Instance.Info("Some of the PACKAGEs are not exist");
            }
        }
        private void CreateTables()
        {
            try
            {
                string rolesStringTable = "create table Roles" +
                    "("
                    + "role_ID VARCHAR2(20) not null,"
                    + "role_Name VARCHAR2(20) not null,"
                    + "CONSTRAINT Roles_pk PRIMARY KEY (role_ID)"
                    + ")";
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
                    + "join_date VARCHAR2(20) not null,"
                    + "CONSTRAINT Club_member_pk PRIMARY KEY (member_id),"
                    + "CONSTRAINT fk_Userss"
                      + " FOREIGN KEY (user_id)"
                      + " REFERENCES Users (user_id)"
                    + ")";
                string transactionStringTable = "create table Transaction" +
                    "("
                    + "Transaction_id number(20) not null,"
                    + "member_id number(20) ,"
                    + "date_transaction VARCHAR2(20) not null,"
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
                    + "payment_date VARCHAR2(20) not null,"
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
            catch
            {
                Logger.Instance.Info("Trying to create Tables but the tables exist");
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
