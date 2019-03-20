//build.cake
//  .\build.ps1 -t Coverage

#load build/settings.cake

//////////////////////////////////////////////////////////////////////
// TOOLS
//////////////////////////////////////////////////////////////////////

#tool nuget:?package=MSBuild.SonarQube.Runner.Tool
#tool nuget:?package=xunit.runner.console&version=2.2.0
#tool nuget:?package=xunit.runner.visualstudio&version=2.2.0
#tool nuget:?package=DocFx.Console
//#tool "nuget:?package=GitVersion.CommandLine"

//////////////////////////////////////////////////////////////////////
// ADDINS
//////////////////////////////////////////////////////////////////////

#addin nuget:?package=Cake.MiniCover&version=0.29.0-next20180721071547&prerelease
//#addin nuget:?package=Cake.NSwag.Console&version=0.2.0-unstable0000
#addin nuget:?package=Cake.Sonar
#addin nuget:?package=Cake.DocFx

SetMiniCoverToolsProject("./build/tools.csproj");

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("Target", "Default");
var configuration = Argument("configuration", "Release");
var login = Argument<String>("login", null);

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

//GitVersion versionInfo = null;

var projectName = Settings.ProjectName;
var projectDirectory =  Directory(".") +  Directory("src") +  Directory(projectName);

var artifactsDirectory = Directory("./artifacts");
var sonarDirectory = Directory("./.sonarqube");
var testResultsDirectory = Directory("./.test-results");
var coverageResultsDirectory = Directory("./coverage-html");
var publishirectory = Directory(".") + Directory("publish") + Directory(configuration);


///////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
	// Executed BEFORE the first task.
	Information("Running tasks...");
	//versionInfo = GitVersion();
	//Information("Building for version {0}", versionInfo.FullSemVer);
});


Teardown(ctx =>
{
	// Executed AFTER the last task.
	Information("Finished running tasks.");
});

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(artifactsDirectory);
        CleanDirectory(publishirectory);
        CleanDirectory(testResultsDirectory);
        CleanDirectory(coverageResultsDirectory);

        DeleteFiles("./*coverage*.*");
    });


Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetCoreRestore();
    });


 Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        var projects = GetFiles("./**/*.csproj");
        foreach(var project in projects)
        {
            DotNetCoreBuild(
                project.GetDirectory().FullPath,
                new DotNetCoreBuildSettings()
                {
                    Configuration = configuration
                });
        }
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        var projects = GetFiles("./test/**/*.csproj");
        foreach(var project in projects)
        {
           Information("Testing project " + project);  
           DotNetCoreTest(project.FullPath, new DotNetCoreTestSettings
           {
               Configuration = configuration,
               NoBuild = true,
               Logger = "trx;LogFileName=UnitTestResults.trx",
               ResultsDirectory = testResultsDirectory,
               ArgumentCustomization = args => args.Append($"--no-restore")
           });
        }
    });

Task("Coverage")
   .IsDependentOn("Test")
   .Does(() => 
   {
        Information("Code Coverage");  
        MiniCover(tool => 
        {
            foreach(var project in GetFiles("./test/**/*.csproj"))
            {
                DotNetCoreTest(project.FullPath, new DotNetCoreTestSettings
                {
                    Configuration = configuration,
                    NoRestore = true,
                    NoBuild = true
                });
            }
        },
        new MiniCoverSettings()
            .WithAssembliesMatching("./test/**/*.dll")
            .WithSourcesMatching("./src/**/*.cs")
            .WithNonFatalThreshold()
            .GenerateReport(ReportType.OPENCOVER |  ReportType.CONSOLE | ReportType.XML | ReportType.HTML)
        );
   });


Task("Publish")
    .IsDependentOn("Test")
    .Does(() =>
{
    DotNetCorePublish(
        projectDirectory,
        new DotNetCorePublishSettings()
        {
            Configuration = configuration,
            OutputDirectory = publishirectory
        });
});


Task("Generate-Docs")
    .IsDependentOn("Build")
    .Does(() => 
    {
        DocFxBuild("./docfx/docfx.json");
       // Zip("./docfx/_site/", artifactsDirectory + "/docfx.zip");
     });

Task("Clean-Sonarqube")
  .WithCriteria(BuildSystem.IsLocalBuild)
  .Does(()=>{
    CleanDirectory(sonarDirectory);
}); 



Task("Sonar")
  .IsDependentOn("Clean-Sonarqube")
  .IsDependentOn("SonarBegin")
  .IsDependentOn("Coverage")
  .IsDependentOn("SonarEnd");

Task("SonarBegin")
    .Does(() => { SonarBegin(new SonarBeginSettings {
        Url = Settings.SonarUrl,
        Key = Settings.SonarKey,
        Name = Settings.SonarName,
        ArgumentCustomization = args=>args
        .Append("/d:sonar.cs.opencover.reportsPaths=opencovercoverage.xml")
        .Append(Settings.SonarExclude)
        .Append(Settings.SonarExcludeDuplications)
    });
});
  
  
Task("SonarEnd")
    .Does(() => { 
        SonarEnd(new SonarEndSettings{});
    });

Task("Pack")
    .IsDependentOn("Coverage")
    .Does(() =>
    {
        foreach (var project in GetFiles("./src/**/*.csproj"))
        {
            DotNetCorePack(
                project.GetDirectory().FullPath,
                new DotNetCorePackSettings()
                {
                    Configuration = configuration,
                    OutputDirectory = artifactsDirectory
                });
        }
    });

    
//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Pack");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////
RunTarget(target);

