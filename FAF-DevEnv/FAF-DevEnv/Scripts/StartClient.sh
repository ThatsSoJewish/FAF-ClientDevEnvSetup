#/bin/sh
sleep 10s
FilePath=("$@")
cd "$FilePath\client"

source clientvenv/scripts/activate

export PATH=clientvenv/Lib/site-packages/pywin32_system32:$PATH

python src
