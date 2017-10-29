@echo off

IF DEFINED APPVEYOR (
    REM dotnet test SteamGaugesApi.Test\SteamGaugesApi.Test.csproj -c Debug --no-build --logger \"trx;LogFileName=%APPVEYOR_BUILD_FOLDER%\TestResults.trx\"
    C:\ProgramData\chocolatey\lib\opencover.portable\tools\OpenCover.Console.exe -register:user -target:"c:\Program Files\dotnet\dotnet.exe" -targetargs:"test SteamGaugesApi.Test\SteamGaugesApi.Test.csproj -c Debug --no-build --logger \"trx;LogFileName=%APPVEYOR_BUILD_FOLDER%\TestResults.trx\" " -threshold:1 -oldStyle -returntargetcode -excludebyattribute:*.ExcludeFromCodeCoverage* -excludebyfile:*\*Designer.cs -hideskipped:All -mergebyhash -mergeoutput -output:.\coverage-dotnet.xml
    REM C:\ProgramData\chocolatey\lib\opencover.portable\tools\OpenCover.Console.exe -register:user -target:"%xunit20%\xunit.console.x86.exe" -targetargs:"SteamGaugesApi.Test\bin\Debug\netcoreapp2.0\SteamGaugesApi.Test.dll -noshadow -appveyor -xml .\xunit-results.xml" -threshold:1 -oldStyle -returntargetcode  -excludebyattribute:*.ExcludeFromCodeCoverage* -excludebyfile:*\*Designer.cs -hideskipped:All -mergebyhash -mergeoutput -output:.\coverage-dotnet.xml
) ELSE (
	echo No coverage without appveyor.
)
