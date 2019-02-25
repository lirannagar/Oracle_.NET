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
        public ClubMemberStartBuying()
        {
            try
            {
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
            string showAllTableQuery = "CREATE OR REPLACE PROCEDURE AVAILBLE_PRODUCTS"
                          + "IS "
                        + " PROD_ID PRODUCT.PRODUCT_ID%type;"
                        + " PROD_NAME PRODUCT.PRODUCT_NAME%type;"
                        + " PROD_AMOUNT PRODUCT.PRODUCT_AMOUNT%type;"
                        + " CURSOR new_prod IS SELECT PRODUCT_ID,PRODUCT_NAME, PRODUCT_AMOUNT"
                        + "FROM PRODUCT WHERE PRODUCT_AMOUNT > 0 ;"
                       + "BEGIN"
                       + "OPEN new_prod;"
                       + "FETCH new_prod INTO PROD_ID, PROD_NAME, PROD_AMOUNT;"
                       + "WHILE new_prod%FOUND LOOP"
                       + "DBMS_OUTPUT.PUT_LINE('ID: ' || PROD_ID ||"
                       + " ', Name: ' || PROD_NAME ||"
                       + "', Amount: ' || PRODUCT_AMOUNT);"
                        + "FETCH new_prod INTO PROD_ID, PROD_NAME, PRODUCT_AMOUNT;"
                        + "END LOOP;"
                        + "CLOSE new_prod;"
                        + "END;";
            UpdateTable(showAllTableQuery);
        }

        private void SearchProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchQueryString = "";
                string select = searchComboBoxProduct.SelectedItem.ToString();
                if (select.Contains("By ID"))
                {
                    searchQueryString = "SELECT PRODUCT_ID ,"
                                + " SUM(PRODUCT_AMOUNT) OVER(ORDER BY PRODUCT_ID) AS  PRODUCT_AMOUNT"
                                 + " FROM PRODUCT"
                                 + " ORDER BY PRODUCT_ID" + textBoxSearchProduct.Text + "'";
                }
                else
                {
                    searchQueryString = "SELECT PRODUCT_NAME , "
                         + " SUM(PRODUCT_AMOUNT) OVER(ORDER BY PRODUCT_NAME) AS  PRODUCT_AMOUNT"
                                 + " FROM PRODUCT"
                                 + " ORDER BY PRODUCT_NAME" + textBoxSearchProduct.Text + "'";
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
            string deleteQuery = "DELETE FROM PRODUCTS"
                      + " WHERE PRODUCTS.PRODUCT_ID = '" + textBoxProduct.Text + "'";
            UpdateTable(deleteQuery);
            string showAllTableQuery = "SELECT *"
                                 + " FROM PRODUCTS";
            UpdateTable(showAllTableQuery);
        }

        private void UpdateTable(string query)
        {
            try
            {
                OracleSingletonComment.Instance.CommandText = query;
                OracleSingletonComment.Instance.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(OracleSingletonComment.Instance);
                da.SelectCommand = OracleSingletonComment.Instance;
                DataTable dt = new DataTable("PRODUCTS");
                da.Fill(dt);
                GridProductTable.ItemsSource = dt.DefaultView;
                Logger.Instance.Info("Table Updated");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Wrong Value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.Instance.Error("Exception while trying to update table\nDeatails: " + ex);
            }
        }
    }
}
