﻿using System;
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
using FAFDevEnv.Common;

namespace FAFDevEnv.Pages
{
    public partial class pageClient : Page
    {
        #region Data Structures

        public static class ScriptNames
        {
            public const String CreateEnv = "initClientRepo";
            public const String LaunchBuild = "launchClient";
        }

        public static class FileBrowserModes
        {
            public const String Install = "INSTALLPATH";
            public const String ExistingInstall = "EXISTINGINSTALL";
        }

        #endregion

        #region Members

        String strInstallationPath,
               strBashPath = "",
               strPythonURL = "https://www.python.org/ftp/python/3.6.2/python-3.6.2-amd64.exe",
               strGitForWindows = "https://git-scm.com/download/win",
               strBashPathX64 = @"C:\Program Files\Git\bin\bash.exe",
               strBashPathX86 = @"C:/Program Files (x86)/Git/bin/bash.exe",
               strInstalledDirsPath = Directory.GetCurrentDirectory() + @"\createdDirs.txt",
               strInstallScriptPath = Directory.GetCurrentDirectory() + @"\scripts\" + ScriptNames.CreateEnv + ".sh",
               strLaunchScriptPath = Directory.GetCurrentDirectory() + @"\scripts\" + ScriptNames.LaunchBuild + ".sh",
               strLogFilePath = Directory.GetCurrentDirectory() + @"\Log.txt";

        Boolean bashPathExists = false,
                installPathExists = false,
                clienDirNotCreated = false;

        Window mainWindow;

        #endregion

        #region Initialization

        public pageClient()
        {
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

            mainWindow = Window.GetWindow(this);
        }

        #endregion

        #region Methods

        public String RequesDirectory(String Mode)
        {
           String path = MiscUtils.ShowFileBrowser(mainWindow as IWin32Window);

            popupFiles.IsOpen = false;
            if (path.ToUpper() != "CANCEL")
            {
                return path;
            }
            else
            {
                switch (Mode.ToUpper())
                {
                    case FileBrowserModes.Install:
                        #region
                        {
                            return textboxFilePath.Text;
                        }
                        #endregion

                    case FileBrowserModes.ExistingInstall:
                        #region
                        {
                            popupFiles.IsOpen = false;
                            return path;
                        }
                        #endregion

                    default:
                        return "";
                }
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
            if (Directory.Exists(strClientSourceDirectory) && Directory.Exists(strClientSourceDirectory + @"client\"))
            {
                String strArguments = Directory.GetCurrentDirectory() + @"\scripts\" + ScriptNames.LaunchBuild + ".sh" + " " + strClientSourceDirectory;
                ExecuteBashScript(strArguments);
            }
            else { /* TODO: Show popup warning user that the selected directory is not valid. */}
        }

        protected void ExecuteBashScript(String strArguments)
        {
            Process proc;
            ProcessStartInfo procInfo;

            if (bashPathExists)
            {
                #region Create the Client Directory

                procInfo = new ProcessStartInfo
                {
                    FileName = strBashPath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    //CreateNoWindow = true, //Failure with this active
                    Arguments = strArguments
                };

                proc = Process.Start(procInfo);
                proc.OutputDataReceived += (sender, args) => LogLine(args.Data);
                proc.BeginOutputReadLine();

                proc.WaitForExit();

                #endregion
            }
        }

        private void LogLine(String logLine)
        {
            using (StreamWriter stream = new StreamWriter(strLogFilePath, false))
            {
                stream.WriteLine(stream.NewLine + " " + logLine);
            }
        }

        protected void SaveInstallDirectory(String strAlternatePath = "")
        {
            List<String> lstPaths;
            String strPathsCSV;

            if (!String.IsNullOrEmpty(strAlternatePath))
            {
                strInstallationPath = strAlternatePath;
            }

            if (!File.Exists(strInstalledDirsPath))
            {
                File.Create(strInstalledDirsPath).Close();
            }

            using (StreamReader readText = new StreamReader(strInstalledDirsPath))
            {
                strPathsCSV = readText.ReadToEnd().Trim();
            }

            using (StreamReader reader = new StreamReader(strInstalledDirsPath))
            {
                lstPaths = reader.ReadToEnd().Split(',').Select(x => x.Trim()).ToList();
            }

            if (!lstPaths.Contains(strInstallationPath.Trim()))
            {
                using (StreamWriter stream = new StreamWriter(strInstalledDirsPath, false))
                {
                    if (!String.IsNullOrEmpty(strPathsCSV))
                    {
                        strPathsCSV += ",";
                    }

                    strPathsCSV += strInstallationPath.Trim();
                    stream.Write(strPathsCSV);
                }
            }
        }

        #endregion

        #region Events

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
            textboxFilePath.Text = RequesDirectory(FileBrowserModes.Install);
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
            List<String> strsfilePaths;

            using (StreamReader reader = new StreamReader(strInstalledDirsPath))
            {
                strsfilePaths = reader.ReadToEnd().Split(',').Select(x => x.Trim()).ToList();
            }

            lstboxInstallPaths.Items.Clear();
            foreach (String path in strsfilePaths)
            {
                lstboxInstallPaths.Items.Add(path);
            }
            lstboxInstallPaths.Items.Add("Locate Existing Directory...");

            popupFiles.IsOpen = true;
        }

        private void popupFiles_lstboxInstallPaths_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            popupFiles.IsOpen = false;
            String strSelectedItemText = (sender as System.Windows.Controls.ListBox).SelectedItem.ToString();

            switch (strSelectedItemText.ToUpper().Trim())
            {
                case "LOCATE EXISTING DIRECTORY...":
                    #region
                    {
                        String directory = RequesDirectory(FileBrowserModes.ExistingInstall);
                        directory = directory.Replace(@"client", "");

                        if (directory.ToUpper() != "CANCEL" && Directory.Exists(directory))
                        {
                            SaveInstallDirectory(directory);
                            LaunchClientBuild(directory);
                        }
                    }
                    #endregion
                    break;

                default:
                    #region
                    {
                        if ((sender as System.Windows.Controls.ListBox).SelectedItem != null)
                        {
                            LaunchClientBuild(strSelectedItemText);
                            popupFiles.IsOpen = false;
                        }
                    }
                    #endregion
                    break;
            }
        }

        #endregion
    }
}
