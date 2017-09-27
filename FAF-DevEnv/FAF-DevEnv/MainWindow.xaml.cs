using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

namespace FAFDevEnv
{
    public partial class MainWindow : Window
    {
        #region Initialization

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        #endregion

        #region Methods

        protected String RetrieveFilePath()
        {
            using (FolderBrowserDialog browser = new FolderBrowserDialog())
            {
                DialogResult result = browser.ShowDialog(this as IWin32Window);  
                
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    return browser.SelectedPath;
                }
                else { return textboxFilePath.Text; }
            }
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

        private void buttonDownloadGIT_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://git-scm.com/download/win");
        }

        private void buttonDownloadPy_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.python.org/downloads/");
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            textboxFilePath.Text = RetrieveFilePath();
        }

        private void buttonCreatEnv_Click(object sender, RoutedEventArgs e)
        {
            //Possibly skip the silly batch scripts all together with https://stackoverflow.com/questions/38880561/open-git-bash-process-without-window
            String filePath = textboxFilePath.Text.Trim();
            if (Directory.Exists(filePath) && !Directory.Exists(filePath + @"\client"))
            {
                ProcessStartInfo procInfo = new ProcessStartInfo()
                {
                    FileName = Directory.GetCurrentDirectory() + @"\scripts\Setup-Batch.bat",
                    CreateNoWindow = true,
                    Arguments = String.Format(@"{0}", filePath)
                };

                Process.Start(procInfo);
            }
        }

        #endregion
    }
}
