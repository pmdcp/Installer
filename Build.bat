set bb.build.msbuild.exe=
for /D %%D in (%SYSTEMROOT%\Microsoft.NET\Framework\v4*) do set msbuild.exe=%%D\MSBuild.exe

%msbuild.exe% "framework-net/Net.sln"
%msbuild.exe% "Installer.sln"
Pause