#addin "Cake.Npm"
#addin "Cake.Gulp"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./Source/UI/bin") + Directory(configuration);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./Source/kevin-main.com.sln");
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    MSBuild("./Source/kevin-main.com.sln", settings => settings.SetConfiguration(configuration)
        .WithProperty("Verbosity", "quiet"));
});

Task("Npm")
    .Does(() =>
{
    ((NpmRunner)Npm.WithLogLevel(NpmLogLevel.Silent)).Install(settings => settings.Package("gulp"));
});

 Task("BuildSite")
    .IsDependentOn("Build")
    .IsDependentOn("Npm")
    .Does(() => 
 {
    Gulp.Local.Execute(settings => settings.WithGulpFile("./Source/UI/gulpfile.js"));
 });

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("BuildSite");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
