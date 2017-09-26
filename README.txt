Just run the 'Initializer' shortcut to start the process of building a new development environment. You will be prompted to choose a destination path.

-------------------------------------------------------------------------------------------------------------------------------------------------------
This is an initial attempt at creating a self initializing Windows Dev Environment for the FAF Client. It has loads of issues currently, but I'll work them out over time. 

Current issues: 
 - Does not automatically install Git for Windows or Py3
 
 - If a previous <venv> was set up elsewhere it wont install the dependencies. Instead it will say something like "Requirements have been satisfied." PyQT5,  PyWin32, and the requirements.txt need to be uninstalled and then reinstalled 
	during this process to function correctly
 
 - The batch script starts minimized because it is unnecessary other than to get the destination folder, which is a hack in my opinion. I attempted to create a Visual Basic Script to bypass the batch all together, 
	but I could't get the shell script to correctly call 'Setup-Bash.sh' AND pass the parameter 'FilePath'. I have included it in the 'Scripts' folder just in case someone knows more about VBS and PowerShell.

 - When prompted for a file path if the user hits cancel, the process clones the project then fails.

 - NOTHING is dynamic. Git-Bash MUST be installed at 'C:\Program Files\Git\git-bash.exe', if the url for 'PyWin32' changes it wont be installed, etc, etc

 - Definitely much more. 