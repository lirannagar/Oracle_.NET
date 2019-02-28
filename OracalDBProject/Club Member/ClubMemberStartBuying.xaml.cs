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
using Oracle.ManagedDataAccess.Client;
using OracalDBProject.Admin;
using OracalDBProject.Club_Member;
using System.Data;

namespace OracalDBProject.Club_Member
{
    /// <summary>
    /// Interaction logic for ClubMemberStartBuying.xaml
    /// </summary>
    public partial class ClubMemberStartBuying : Window
    {
        const string COMBOBOX_NAME_SEARCH = "By ID";
        const string TABLE_NAME_UPDATE = "LIRAN_ADMIN.PRODUCTS";

        private OracleCommand cmd;

        public ClubMemberStartBuying()
        {
            try
            {
                cmd = new OracleCommand();
                cmd.Connection = OracleSingletonConnection.Instance;
                InitializeComponent();
                Logger.Instance.Info("Club member start buying window opened");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to open Club member start buying window \nDetails:" + ex);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OracalDBProject.MarketsDBSource marketsDBSource = ((OracalDBProject.MarketsDBSource)(this.FindResource("marketsDBSource")));
            // Load data into the table PRODUCTS. You can modify this code as needed.
            OracalDBProject.MarketsDBSourceTableAdapters.PRODUCTSTableAdapter marketsDBSourcePRODUCTSTableAdapter = new OracalDBProject.MarketsDBSourceTableAdapters.PRODUCTSTableAdapter();
            marketsDBSourcePRODUCTSTableAdapter.Fill(marketsDBSource.PRODUCTS);
            System.Windows.Data.CollectionViewSource pRODUCTSViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pRODUCTSViewSource")));
            pRODUCTSViewSource.View.MoveCurrentToFirst();
        }

        private void BackButtonSearchProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClubMemberOperationWindow clubMembernPanel = new ClubMemberOperationWindow();
                clubMembernPanel.Show();
                this.Close();
                Logger.Instance.Info("Open Club Mmeber Operation Window and Close Search Product Window");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to open club member window and Close Search Product Window \nDetails: " + ex);
            }
        }

        private void ShowAllProductButton_Click(object sender, RoutedEventArgs e)
        {
            string showAllTableQuery = "CREATE OR REPLACE PROCEDURE AVAILBLE_PRODUCTS "
            + " IS"
            + " PROD_ID LIRAN_ADMIN.PRODUCTS.PRODUCT_ID % type;"
            + " PROD_NAME LIRAN_ADMIN.PRODUCTS.PRODUCT_NAME % type;"
            + " PROD_AMOUNT LIRAN_ADMIN.PRODUCTS.PRODUCT_AMOUNT % type;"
            + " CURSOR new_prod IS SELECT LIRAN_ADMIN.PRODUCTS.PRODUCT_ID, LIRAN_ADMIN.PRODUCTS.PRODUCT_NAME, LIRAN_ADMIN.PRODUCTS.PRODUCT_AMOUNT"
            + " FROM LIRAN_ADMIN.PRODUCTS WHERE LIRAN_ADMIN.PRODUCTS.PRODUCT_AMOUNT > 0;"
            + " BEGIN"
            + " OPEN new_prod;"
            + " FETCH new_prod INTO PROD_ID, PROD_NAME, PROD_AMOUNT;"
            + " WHILE new_prod% FOUND LOOP"
            + " FETCH new_prod INTO PROD_ID, PROD_NAME, PROD_AMOUNT;"
            + " END LOOP;"
            + " CLOSE new_prod;"
            + " END;";
            UpdateTable(showAllTableQuery);
        }

        private void SearchProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchQueryString = "";
                string select = searchComboBoxProduct.SelectedItem.ToString();
                if (select.Contains(COMBOBOX_NAME_SEARCH))
                {
                    searchQueryString = "SELECT LIRAN_ADMIN.PRODUCTS.PRODUCT_ID ,"
                                 + " SUM(PRODUCT_AMOUNT) OVER(ORDER BY LIRAN_ADMIN.PRODUCTS.PRODUCT_ID) AS  PRODUCT_AMOUNT"
                                 + " FROM LIRAN_ADMIN.PRODUCTS"
                                 + " WHERE LIRAN_ADMIN.PRODUCTS.PRODUCT_ID = '" + textBoxSearchProduct.Text + "'"
                                 + " ORDER BY LIRAN_ADMIN.PRODUCTS.PRODUCT_ID";
                }
                else
                {
                    searchQueryString = "SELECT LIRAN_ADMIN.PRODUCTS.PRODUCT_NAME , "
                                + " SUM(PRODUCT_AMOUNT) OVER(ORDER BY LIRAN_ADMIN.PRODUCTS.PRODUCT_NAME) AS  PRODUCT_AMOUNT"
                                + " FROM LIRAN_ADMIN.PRODUCTS"
                                + " WHERE LIRAN_ADMIN.PRODUCTS.PRODUCT_NAME = '" + textBoxSearchProduct.Text + "'"
                                + " ORDER BY LIRAN_ADMIN.PRODUCTS.PRODUCT_NAME";
                }
                UpdateTable(searchQueryString);
                Logger.Instance.Info("Search Product");
            }
            catch (OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to search Product for buying \nDeatails: " + ex);
            }
        }

        private void ChooseButton_Click(object sender, RoutedEventArgs e)
        {
            string chooseQuery = "UPDATE LIRAN_ADMIN.PRODUCTS"
                                + " SET PRODUCT_AMOUNT = PRODUCT_AMOUNT - 1"
                                + " WHERE (LIRAN_ADMIN.PRODUCTS.PRODUCT_AMOUNT > 0) AND  OR LIRAN_ADMIN.PRODUCTS.PRODUCT_ID = " + textBoxProduct.Text + "";
            UpdateTable(chooseQuery);
            string showAllTableQuery = "SELECT * FROM LIRAN_ADMIN.PRODUCTS";
            UpdateTable(showAllTableQuery);
        }

        private void UpdateTable(string query)
        {
            try
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.SelectCommand = cmd;
                DataTable dt = new DataTable(TABLE_NAME_UPDATE); 
                da.Fill(dt);
                GridProductTable.ItemsSource = dt.DefaultView;
                Logger.Instance.Info("Table Updated");
            }
            catch (OracleException ex)
            {               
                Logger.Instance.Error("Exception while trying to update table\nDeatails: " + ex);
            }
        }
    }
}
