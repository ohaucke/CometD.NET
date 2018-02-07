@echo off
set SIGN=false
set NAME=cometd
set PATHTOFILE=bin\Release\cometd.dll

msbuild %NAME%.sln /t:rebuild /p:Configuration=Release
FOR /F "tokens=*" %%a in ('AssemblyVersion.exe "%PATHTOFILE%"') do SET VERSION=%%a
set VERSION=%VERSION:~0,5%
echo %VERSION%
if "%SIGN%" == "true" (
    call "D:\workspace\dev\ShellScripte\CodeSigning.bat" "%PATHTOFILE%"
)

nuget pack %NAME%.nuspec -Version %VERSION%
nuget add %NAME%.%VERSION%.nupkg -Source \\samba.host.0x59.de\sonstiges\Nuget.Packages
del %NAME%.%VERSION%.nupkg