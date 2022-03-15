#!/usr/bin/env bash
frameworkVersion=net45
netfx=${frameworkVersion#net}

wget -nc https://nuget.org/nuget.exe;
mozroots --import --sync
mono nuget.exe install src/DEFAULT.FincraDeveloperApi/packages.config -o packages;
mkdir -p bin;

cp packages/Newtonsoft.Json.8.0.2/lib/net45/Newtonsoft.Json.dll bin/Newtonsoft.Json.dll;
cp packages/RestSharp.105.1.0/lib/net45/RestSharp.dll bin/RestSharp.dll;

mcs -sdk:${netfx} -r:bin/Newtonsoft.Json.dll,\
bin/RestSharp.dll,\
System.Runtime.Serialization.dll \
-target:library \
-out:bin/DEFAULT.FincraDeveloperApi.dll \
-recurse:'src/DEFAULT.FincraDeveloperApi/*.cs' \
-doc:bin/DEFAULT.FincraDeveloperApi.xml \
-platform:anycpu
