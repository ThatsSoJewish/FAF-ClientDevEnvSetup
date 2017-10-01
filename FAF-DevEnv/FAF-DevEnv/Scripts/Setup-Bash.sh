#!/bin/sh

FilePath=("$@")
echo ------------------------------------------------------------
echo Changing Directory to $FilePath
echo ------------------------------------------------------------
cd $FilePath

echo ------------------------------------------------------------
echo Cloning FAF Client Repository
echo ------------------------------------------------------------
git clone https://github.com/FAForever/client.git

echo ------------------------------------------------------------
echo Changing Directory to "$FilePath"
echo ------------------------------------------------------------
cd "$FilePath\client"

echo ------------------------------------------------------------
echo Creating Virtual Environment
echo ------------------------------------------------------------
python -m venv clientvenv

echo ------------------------------------------------------------
echo Activating Virtual Environment 
echo ------------------------------------------------------------
source clientvenv/scripts/activate

echo ------------------------------------------------------------
echo Installing PyQT5
echo ------------------------------------------------------------
pip install pyqt5

echo ------------------------------------------------------------
echo Installing PyWin32
echo ------------------------------------------------------------
pip install https://github.com/FAForever/python-wheels/releases/download/2.0.0/pywin32-221-cp36-cp36m-win32.whl

echo ------------------------------------------------------------
echo Installing PyTest
echo ------------------------------------------------------------
pip install pytest

echo ------------------------------------------------------------
echo Installing dependencies from Requirements.txt
echo ------------------------------------------------------------
pip install -r requirements.txt

#echo ------------------------------------------------------------
#echo Adding 'clientvenv/Lib/site-packages/pywin32_system32' to the system path
#echo ------------------------------------------------------------
#export PATH="$FilePath/client/clientvenv/Lib/site-packages/pywin32_system32:$PATH"
