@echo off

SET CSCPATH=%SYSTEMROOT%\Microsoft.NET\Framework\v4.0.30319


if not exist ".\nuget.exe" powershell -Command "(new-object System.Net.WebClient).DownloadFile('https://nuget.org/nuget.exe', '.\nuget.exe')"
.\nuget.exe install src\DEFAULT.FincraDeveloperApi\packages.config -o packages

if not exist ".\bin" mkdir bin

copy packages\Newtonsoft.Json.8.0.2\lib\net45\Newtonsoft.Json.dll bin\Newtonsoft.Json.dll
copy packages\RestSharp.105.1.0\lib\net45\RestSharp.dll bin\RestSharp.dll

%CSCPATH%\csc /reference:bin\Newtonsoft.Json.dll;bin\RestSharp.dll /target:library /out:bin\DEFAULT.FincraDeveloperApi.dll /recurse:src\DEFAULT.FincraDeveloperApi\*.cs /doc:bin\DEFAULT.FincraDeveloperApi.xml
