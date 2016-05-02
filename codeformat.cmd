@echo off

REM There are more options awailable for you.  
REM When you use tools\narrange\narrange-console.exe directly

set TAB=    
set FILENAME=codeformat.cmd
if -%1-==-- goto help

tools\narrange\narrange-console.exe %1

exit /b %errorlevel%

:help

 echo %TAB% Usage : codeformat.cmd 
 @echo:
 echo %TAB% Run recursively from the current directory. 
 echo %TAB% ^> %FILENAME% . %TAB% the [.] is required.

 @echo:
 @echo:
 echo %TAB% Run against a single file. 
 echo %TAB% ^> %FILENAME% src/MyCoolLibrary/Library.cs
 
 exit /b
