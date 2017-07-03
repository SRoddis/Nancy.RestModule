nuget install NUnit.Runners -Version 3.2.1 -OutputDirectory tools
nuget install OpenCover -Version 4.6.519 -OutputDirectory tools
nuget install coveralls.net -Version 0.6.0 -OutputDirectory tools
 
.\tools\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:.\tools\NUnit.ConsoleRunner.3.2.1\tools\nunit3-console.exe -targetargs:".\FlyingMigratory.Test\bin\Debug\FlyingMigratory.Test.dll" -filter:"+[FlyingMigratory]* -[FlyingMigratory.Test]*" -register:user
 
.\tools\coveralls.net.0.6.0\tools\csmacnz.Coveralls.exe --opencover -i .\results.xml