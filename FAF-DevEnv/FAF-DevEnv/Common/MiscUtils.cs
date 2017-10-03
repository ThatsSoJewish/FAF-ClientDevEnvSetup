using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAFDevEnv.Common
{
    public static class MiscUtils
    {
        /// <summary>
        /// This displays the minimalistic, built-in version of the windows file browser. 
        /// </summary>
        /// <param name="window">Pass in a reference to the Main Window so that the browser will display at its center.</param>
        /// <returns></returns>
        public static String ShowFileBrowser(IWin32Window window)
        {
            using (FolderBrowserDialog browser = new FolderBrowserDialog())
            {
                DialogResult result = browser.ShowDialog(window);

                if (result == DialogResult.OK)
                {
                    return browser.SelectedPath;
                }
                else { return "CANCEL"; }
            }
        }
    }
}
