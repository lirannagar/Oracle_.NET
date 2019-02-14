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
using System.Data;

namespace OracalDBProject.Admin
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {

        #region Control Mapping
        #endregion Control Mapping

        #region Members
        #endregion Members

        #region Constructor
        public AddProductWindow()
        {
            try
            {
                InitializeComponent();
                string showAllTableQuery = "SELECT *"
                             + " FROM PRODUCTS";               
                Logger.Instance.Info("Add Product Window opened");
                UpdateTable(showAllTableQuery);
                
            }
            catch(Exception ex)
            {
                Logger.Instance.Error("Exception while trying to open Add Product Window\nDetails:" + ex);
            }
           
        }
        #endregion Constructor

        #region Private Methods
        private void BackButtonProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
                Logger.Instance.Info("Open Admin Paenel Window and Close Product Window");
            }catch(Exception ex)
            {
                Logger.Instance.Error("Exception while trying to open admin panel window and Close Product Window \nDetails: " +ex);
            }
          
        }
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nameProduct = NameProductTextBox.Text;
                int quantity =Int32.Parse(QuantityProducTextBox.Text);
                string id = IDProductTextBox.Text;
                Product p = new Product(nameProduct, quantity, id);
                p.ExecuteToDatabase();
                CleanTextBoxes();
                string showAllTableQuery = "SELECT *"
                              + " FROM PRODUCTS";
                UpdateTable(showAllTableQuery);

            }
            catch(OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to open Add Product\nDetails:" + ex);
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
                DataTable dt = new DataTable("PRODUCTS");
                da.Fill(dt);
                GridAddProduct.ItemsSource = dt.DefaultView;
              


                Logger.Instance.Info("Table Updated");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Wrong Value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.Instance.Error("Exception while trying to update table\nDeatails: " + ex);
            }
        }

        private void CleanTextBoxes()
        {
            try
            {
                NameProductTextBox.Clear();
                QuantityProducTextBox.Clear();
                IDProductTextBox.Clear();
                Logger.Instance.Info("Text box of Product cleared");

            }
            catch(Exception ex)
            {
                Logger.Instance.Error("Exception while trying clear Text box of Product  "  +ex);
            }

        }

        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            OracalDBProject.MarketsDBSource marketsDBSource = ((OracalDBProject.MarketsDBSource)(this.FindResource("marketsDBSource")));
            // Load data into the table PRODUCTS. You can modify this code as needed.
            OracalDBProject.MarketsDBSourceTableAdapters.PRODUCTSTableAdapter marketsDBSourcePRODUCTSTableAdapter = new OracalDBProject.MarketsDBSourceTableAdapters.PRODUCTSTableAdapter();
            marketsDBSourcePRODUCTSTableAdapter.Fill(marketsDBSource.PRODUCTS);
            System.Windows.Data.CollectionViewSource pRODUCTSViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pRODUCTSViewSource")));
            pRODUCTSViewSource.View.MoveCurrentToFirst();
        }
    }
}
