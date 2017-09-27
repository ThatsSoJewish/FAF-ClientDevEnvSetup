

::set "psCommand="(new-object -COM 'Shell.Application')^
::.BrowseForFolder(0,'Please choose a destination folder to install the FAF Client Development Environment.',0,0).self.path""

::for /f "usebackq delims=" %%I in (`powershell %psCommand%`) do set "folder=%%I"

::setlocal enabledelayedexpansion
::(
::	echo #^!/bin/sh
::	echo FilePath^=^("$@"^)
::	echo cd "$FilePath"
::	echo source clientvenv/scripts/activate
::	echo export PATH^=clientvenv/Lib/site-packages/pywin32_system32:$PATH
::	echo python src
::	echo sleep 10s
::) > StartClient.txt
::
::move StartClient.txt StartClient.sh
::
::(	
::	echo @echo off
::	echo setlocal enabledelayedexpansion
::	echo "C:\Program Files\Git\git-bash.exe" %~dp0\StartClient.sh !folder!\client
::	echo endlocal
::	echo pause
::) > StartClient.bat
@echo off
setlocal enabledelayedexpansion
"C:\Program Files\Git\git-bash.exe" %~dp0Setup-Bash.sh %1
endlocal
