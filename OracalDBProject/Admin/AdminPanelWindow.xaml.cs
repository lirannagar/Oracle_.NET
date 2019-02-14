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
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;
using OracalDBProject.Admin;

namespace OracalDBProject
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {

        #region Control Mapping
        #endregion Control Mapping

        #region Members
        #endregion Members

        #region Constructor
 
        public AdminPanel()
        {
            try
            {
                InitializeComponent();
                Logger.Instance.Info("Admin panel opened");
            }catch(OracleException ex)
            {
                Logger.Instance.Error("Exception while trying to open admin panel\nDetails:" + ex);
            }
            
        }
        #endregion Constructor

        #region Private Methods
        private void AddNewProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddProductWindow win = new AddProductWindow();
                win.Show();
                this.Close();
                Logger.Instance.Info("Admin panel close and product panel opened");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Error while trying to close admin panel and open product panel\nDetails:" + ex);
            }

        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DeleteProductWindow win = new DeleteProductWindow();
                win.Show();
                this.Close();
                Logger.Instance.Info("Delete Product Window Opened and Panel Window Closed");
            }catch(Exception ex)
            {
                Logger.Instance.Error("Error while trying to Open Product Window and close Panel Window\nDetails:  " +ex);
            }
        }
        private void AddNewClumMemberButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewAdminButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion Private Methods

        #region Public Methods

        #endregion Public Methods


    }
}
