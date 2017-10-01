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

namespace FAFDevEnv
{
    public partial class MainWindow : Window
    {
        #region Data Structures

        public static class ScriptNames
        {
            public const String CreateEnv = "Setup-Bash";
            public const String LaunchBuild = "StartClient";
        }

        #endregion

        #region Members

        String strInstallationPath,
               strBashPath = "",
               strLaunchScriptPath = "",
               strPythonURL = "https://www.python.org/downloads/",
               strGitForWindows = "https://git-scm.com/download/win",
               strBashPathX64 = @"C:\Program Files\Git\bin\bash.exe",
               strBashPathX86 = @"C:/Program Files (x86)/Git/bin/bash.exe",
               strInstalledDirsPath = Directory.GetCurrentDirectory() + @"\createdDirs.txt",
               strInstallScriptPath = Directory.GetCurrentDirectory() + @"\scripts\Setup-Bash.sh";
        
        Boolean bashPathExists = false,
                installPathExists = false,
                clienDirNotCreated = false;

        #endregion

        #region Initialization

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            CheckForGitBash();
            
            if (File.Exists(strInstalledDirsPath))
            {
                using (StreamReader reader = new StreamReader(strInstalledDirsPath))
                {
                    String[] strsfilePaths = reader.ReadToEnd().Split(',');
                    if (strsfilePaths.Length < 1)
                    {
                        buttonLaunchClient.IsEnabled = false;
                        buttonLaunchClient.ToolTip = "There are no client source directories installed.";
                    }
                }
            }
        }

        #endregion

        #region Methods

        protected String PromptUserForInstallPath()
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

        protected Boolean CheckInstallationPath()
        {
            strInstallationPath = textboxFilePath.Text.Trim();
            return Directory.Exists(strInstallationPath) && !Directory.Exists(strInstallationPath + @"\client");
        }

        protected void CheckForGitBash()
        {
            if (File.Exists(strBashPathX64))
            {
                strBashPath = strBashPathX64;
            }
            else if (File.Exists(strBashPathX86))
            {
                strBashPath = strBashPathX86;
            }

            if (String.IsNullOrEmpty(strBashPath))
            {
                // TODO: Git-Bash is not installed. Show a popup telling them to install it
            }
            else { bashPathExists = true; }
        }

        protected void LaunchClientBuild(String strClientSourceDirectory)
        {
            String strArguments = Directory.GetCurrentDirectory() + @"\scripts\" + ScriptNames.LaunchBuild + ".sh" + " " + strClientSourceDirectory;
            ExecuteBashScript(strArguments);
        }

        protected void ExecuteBashScript(String strArguments)
        {
            Process proc;
            ProcessStartInfo procInfo;
            String strProcOutput;

            if (bashPathExists)
            {
                #region Create the Client Directory

                //String s = Assembly.GetExecutingAssembly().Location; //testing file path

                procInfo = new ProcessStartInfo
                {
                    FileName = strBashPath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    //CreateNoWindow = true,
                    Arguments = strArguments
                };

                proc = Process.Start(procInfo);
                strProcOutput = proc.StandardOutput.ReadToEnd();

                proc.WaitForExit();

                #endregion
            }
        }

        protected void SaveInstallDirectory()
        {
            String strPathsCSV;

            if (!File.Exists(strInstalledDirsPath))
            {
                File.Create(strInstalledDirsPath).Close();
            }

            using (StreamReader readText = new StreamReader(strInstalledDirsPath))
            {
                strPathsCSV = readText.ReadToEnd().Trim();
            }

            using (StreamWriter stream = new StreamWriter(strInstalledDirsPath, false))
            {
                if (!String.IsNullOrEmpty(strPathsCSV))
                {
                    strPathsCSV += ",";
                }

                strPathsCSV += strInstallationPath;
                stream.Write(strPathsCSV);
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
            Process.Start(strGitForWindows);
        }

        private void buttonDownloadPy_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(strPythonURL);
        }

        private void buttonBrowse_Click(object sender, RoutedEventArgs e)
        {
            textboxFilePath.Text = PromptUserForInstallPath();
        }

        private void buttonCreatEnv_Click(object sender, RoutedEventArgs e)
        {
            String strBashArguments;

            if (CheckInstallationPath())
            {
                strBashArguments = Directory.GetCurrentDirectory() + @"\scripts\" + ScriptNames.CreateEnv + ".sh" + " " + strInstallationPath;
                ExecuteBashScript(strBashArguments);
                SaveInstallDirectory();
            }
            else { /* TODO: Directory is invalid. Show a popup telling them so.*/ }
        }

        private void buttonLaunchBuild_Click(object sender, RoutedEventArgs e)
        {
            String[] strsfilePaths;

            using (StreamReader reader = new StreamReader(strInstalledDirsPath))
            {
                strsfilePaths = reader.ReadToEnd().Split(',');
            }

            switch (strsfilePaths.Length)
            {
                case 0:
                    #region
                    {
                        buttonLaunchClient.IsEnabled = false;
                        buttonLaunchClient.ToolTip = "There are no client source directories installed.";
                    }
                    #endregion
                    break;

                case 1:
                    #region
                    {
                        LaunchClientBuild(strsfilePaths[0]);
                    }
                    #endregion
                    break;

                default:
                    #region
                    {
                        lstboxInstallPaths.Items.Clear();
                        foreach (String path in strsfilePaths)
                        {
                            lstboxInstallPaths.Items.Add(path);
                        }

                        popupFiles.IsOpen = true;
                    }
                    #endregion
                    break;
            }
        }

        private void popupFiles_lstboxInstallPaths_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Object SelectedItem = (sender as System.Windows.Controls.ListBox).SelectedItem;
            if ((sender as System.Windows.Controls.ListBox).SelectedItem != null)
            {
                LaunchClientBuild(SelectedItem.ToString());
                popupFiles.IsOpen = false;
            }
        }

        #endregion
    }
}
