
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
    /// Interaction logic for DeleteProductWindow.xaml
    /// </summary>
    public partial class DeleteProductWindow : Window
    {
        #region Control Mapping
        const string TABLE_NAME = "PRODUCTS";
        #endregion Control Mapping

        #region Members
        #endregion Members

        #region Constructor
        public DeleteProductWindow()
        {
            try
            {
                InitializeComponent();
                Logger.Instance.Info("Delete Product Window Opened");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to opened Delete Product Window\nDetails: "+ex);
            }            
        }
        #endregion Constructor

        #region Public Methods
        #endregion Public Methods

        #region Private Methods
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OracalDBProject.MarketsDBSource marketsDBSource = ((OracalDBProject.MarketsDBSource)(this.FindResource("marketsDBSource")));
            // Load data into the table PRODUCTS. You can modify this code as needed.
            OracalDBProject.MarketsDBSourceTableAdapters.PRODUCTSTableAdapter marketsDBSourcePRODUCTSTableAdapter = new OracalDBProject.MarketsDBSourceTableAdapters.PRODUCTSTableAdapter();
            marketsDBSourcePRODUCTSTableAdapter.Fill(marketsDBSource.PRODUCTS);
            System.Windows.Data.CollectionViewSource pRODUCTSViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pRODUCTSViewSource")));
            pRODUCTSViewSource.View.MoveCurrentToFirst();
        }

        private void SearchDeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchQueryString = "";
                string select = searchComboBoxDelteProduct.SelectedItem.ToString();
                if (select.Contains("By ID"))
                {
                    searchQueryString = "SELECT *"
                                + " FROM PRODUCTS"
                                + " WHERE PRODUCTS.PRODUCT_ID = '" + textBoxSearchDeleteProduct.Text + "'";
                }
                else
                {
                    searchQueryString = "SELECT *"
                                       + " FROM PRODUCTS"
                                       + " WHERE PRODUCTS.PRODUCT_NAME = '" + textBoxSearchDeleteProduct.Text + "'";                   
                }
                UpdateTable(searchQueryString);
                Logger.Instance.Info("Search Product");
            }
            catch(OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to search to Delete Product\nDeatails: " + ex);
            }
        }

        private void ShowAllProductButton_Click(object sender, RoutedEventArgs e)
        {
            string showAllTableQuery = "SELECT * FROM VW_PRODUCTS";
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
                DataTable dt = new DataTable(TABLE_NAME);
                da.Fill(dt);
                GridProductTable.ItemsSource = dt.DefaultView;
                Logger.Instance.Info("Table Updated");
            }
            catch (OracleException ex)
            {               
                Logger.Instance.Error("Exception while trying to update table\nDeatails: " + ex);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string deleteQuery = "DELETE FROM PRODUCTS"
                            + " WHERE PRODUCTS.PRODUCT_ID = '" + textBoxDeleteProduct.Text + "'";
            UpdateTable(deleteQuery);
            string showAllTableQuery = "SELECT *"
                                 + " FROM PRODUCTS";
            UpdateTable(showAllTableQuery);
        }

        private void BackButtonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
                Logger.Instance.Info("Open Admin Panel Window and Close Delete Product Window");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to open admin panel window and Close Delete Product Window \nDetails: " + ex);
            }
        }


        #endregion Private Methods


    }
}
