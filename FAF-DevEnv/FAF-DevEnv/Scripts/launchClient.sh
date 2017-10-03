#!/bin/sh

FilePath=("$@")

#echo ------------------------------------------------------------
#echo Changing Directory to "$FilePath\client"
#echo ------------------------------------------------------------
cd "$FilePath\client"


#echo ------------------------------------------------------------
#echo Activating Virtual Environment 
#echo ------------------------------------------------------------
source clientvenv/scripts/activate

FPath="${FilePath//\\//}"

#echo $FilePath"client/clientvenv/Lib/site-packages/pywin32_system32":$PATH
export PATH=$FilePath"client/clientvenv/Lib/site-packages/pywin32_system32":$PATH

python src
