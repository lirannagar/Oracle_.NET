
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
    /// Interaction logic for ShowAllProductsWindow.xaml
    /// </summary>
    public partial class ShowAllProductsWindow : Window
    {


        #region Control Mapping
        const string TABLE_NAME_UPDATE = "PRODUCTS";
        #endregion Control Mapping


        #region Members
        #endregion Members


        #region Constructor
        public ShowAllProductsWindow()
        {
            InitializeComponent();
            string showAllTableQuery = "SELECT *"
                                + " FROM PRODUCTS";
            UpdateTable(showAllTableQuery);
        }

        #endregion Constructor


        #region Private Methods
        private void UpdateTable(string query)
        {
            try
            {
                OracleSingletonComment.Instance.CommandText = query;
                OracleSingletonComment.Instance.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(OracleSingletonComment.Instance);
                da.SelectCommand = OracleSingletonComment.Instance;
                DataTable dt = new DataTable(TABLE_NAME_UPDATE);
                da.Fill(dt);
                GrideAllPeoducts.ItemsSource = dt.DefaultView;
                Logger.Instance.Info("Table Updated");
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Wrong Value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.Instance.Error("Exception while trying to update table\nDeatails: " + ex);
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

        private void BackToAdminPanelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
                Logger.Instance.Info("Open Admin Panel Window and Close Show All Product Window");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to open admin panel window and Close Show All Product Window \nDetails: " + ex);
            }
        }
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods


    }
}
