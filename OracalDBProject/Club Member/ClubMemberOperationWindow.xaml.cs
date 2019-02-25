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

namespace OracalDBProject.Club_Member
{
    /// <summary>
    /// Interaction logic for ClubMemberOperationWindow.xaml
    /// </summary>
    public partial class ClubMemberOperationWindow : Window
    {
        public ClubMemberOperationWindow()
        {
            InitializeComponent();
        }

        private void StartBuying_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClubMemberStartBuying win = new ClubMemberStartBuying();
                win.Show();
                this.Close();
                Logger.Instance.Info("Club Member Start Buying Window opened");
            }
            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to show Club Member Start Buying window Details:\n" + ex);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mainWindowPanel = new MainWindow();
                mainWindowPanel.Show();
                this.Close();
                Logger.Instance.Info("Open main Window and Close Club member operation window  Window");
            }


            catch (Exception ex)
            {
                Logger.Instance.Error("Exception while trying to open main window and Close club member operation  Window \nDetails: " + ex);
            }
        }
    }
}
