using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
using FAFDevEnv;
using FAFDevEnv.Pages;

namespace FAFDevEnv
{
    public partial class MainWindow : Window
    {
        #region Members

        public static class String_Constants
        {
            public static List<String> lstSetPages = new List<String>() { "Client", "FA" };

            public const String strPageClient = "CLIENT";
            public const String strPageFA = "FA";

        }

        pageClient pageClient = new pageClient();
        pageFA pageFA = new pageFA();

        #endregion

        #region Initialization

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            foreach (String page in String_Constants.lstSetPages)
            {
                comboPages.Items.Add(page);
            }
            comboPages.SelectedIndex = 0;

            mainFrame.Content = pageClient;
        }

        #endregion

        #region Events

        private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        #endregion

        private void comboPages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (sender as ComboBox);
            String strSelectedPage = cmb.SelectedItem.ToString().ToUpper();

            switch (strSelectedPage)
            {
                case String_Constants.strPageClient:
                    mainFrame.Content = pageClient;
                    break;

                case String_Constants.strPageFA:
                    mainFrame.Content = pageFA;
                    break;
            }
        }
    }
}
