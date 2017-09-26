@echo off
setlocal

set "psCommand="(new-object -COM 'Shell.Application')^
.BrowseForFolder(0,'Please choose a destination folder to install the FAF Client Development Environment.',0,0).self.path""

for /f "usebackq delims=" %%I in (`powershell %psCommand%`) do set "folder=%%I"

setlocal enabledelayedexpansion
echo %~dp0Setup-Bash.sh
"C:\Program Files\Git\git-bash.exe" %~dp0Setup-Bash.sh !folder!
endlocal
