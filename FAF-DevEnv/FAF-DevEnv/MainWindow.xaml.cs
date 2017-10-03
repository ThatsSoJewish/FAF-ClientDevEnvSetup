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
using System.Windows.Forms;
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
        #region Initialization

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            mainFrame.Content = new pageClient();
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
    }
}
