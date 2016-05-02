#!/bin/sh

# There are more options awailable for you.  
# When you use tools\narrange\narrange-console.exe directly

if [ -z "$1" ]
then
    echo -e "\t Usage : codeformat.cmd"
    echo
    echo -e "\t Run recursively from the current directory."
    echo -e "\t $ codeformat.cmd . \t the [.] is required."

    echo 
    echo 
    echo -e "\t Run against a single file."
    echo -e "\t $ codeformat.cmd src/MyCoolLibrary/Library.cs" 
   
    exit 0
fi

mono tools/narrange/narrange-console.exe $1
