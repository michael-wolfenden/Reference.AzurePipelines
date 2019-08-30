///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument<string>("target", "Default");
var configuration = Argument<string>("configuration", "Release");
var versionNumber = Argument<string>("versionNumber", "0.0.0");

///////////////////////////////////////////////////////////////////////////////
// VARIABLES
///////////////////////////////////////////////////////////////////////////////

var solution = GetFiles("./src/*.sln").First();
var artifactsDir = Directory("./artifacts");

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(_ =>
{
    Information("Target {0}", target);
    Information("Target {0}", target);
    Information("Configuration {0}", configuration);
    Information("Version {0}", versionNumber);
});

Teardown(_ =>
{
    Information("Finished running tasks");
});

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build")
    ;

Task("Build")
    .IsDependentOn("Run_dotnet_info")
    .IsDependentOn("Clean")
    .IsDependentOn("Build_solution")
    .IsDependentOn("Run_tests")
    .IsDependentOn("Package")
    ;

Task("Run_dotnet_info")
    .Does(() =>
{
    Information("dotnet --info");
    StartProcess("dotnet", new ProcessSettings { Arguments = "--info" });
});

Task("Clean")
    .Does(_ =>
{
    Information("Cleaning {0}, bin and obj folders", artifactsDir);

    CleanDirectory(artifactsDir);
    CleanDirectories("./src/**/bin");
    CleanDirectories("./src/**/obj");
});

Task("Build_solution")
    .Does(_ =>
{
    Information("Building solution {0} v{1}", solution.GetFilenameWithoutExtension(), versionNumber);

    DotNetCoreBuild(solution.FullPath, new DotNetCoreBuildSettings()
    {
        Configuration = configuration,
        MSBuildSettings = new DotNetCoreMSBuildSettings()
            .SetVersion(versionNumber)
            .SetFileVersion(versionNumber)
            // Only including a major version in the AssemblyVersion to reduce binding redirects
            // https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/versioning#assembly-version
            .WithProperty("AssemblyVersion", $"{Version.Parse(versionNumber).Major}.0.0")
            // 0 = use as many processes as there are available CPUs to build the project
            // see: https://develop.cakebuild.net/api/Cake.Common.Tools.MSBuild/MSBuildSettings/60E763EA
            .SetMaxCpuCount(0)
    });
});

Task("Run_tests")
    .Does(_ =>
{
    Information("Testing solution {0}", solution.GetFilenameWithoutExtension());

    DotNetCoreTest(solution.FullPath, new DotNetCoreTestSettings
    {
        Configuration = configuration,
        ResultsDirectory = artifactsDir,
        Logger = "trx",
        NoBuild = true,
        NoRestore = true
    });
});

Task("Package")
    .Does(_ =>
{
    Information("Packaging solution {0}", solution.GetFilenameWithoutExtension());

    DotNetCorePack(solution.FullPath, new DotNetCorePackSettings {
        Configuration = configuration,
        OutputDirectory = artifactsDir,
        NoBuild = true,
        NoRestore = true,
        MSBuildSettings = new DotNetCoreMSBuildSettings()
            .SetVersion(versionNumber)
    });
});

///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);
