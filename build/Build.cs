using System;
using System.Diagnostics.CodeAnalysis;
using CreativeCoders.NukeBuild;
using CreativeCoders.NukeBuild.BuildActions;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.GitVersion;

[PublicAPI]
[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
[SuppressMessage("ReSharper", "ConvertToAutoProperty")]
class Build : NukeBuild, IBuildInfo
{
    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
    
    [Parameter] string DevNuGetSource;
    
    [Parameter] string DevNuGetApiKey;
    
    [Parameter] string NuGetSource;
    
    [Parameter] string NuGetApiKey;

    [Solution] readonly Solution Solution;

    [GitRepository] readonly GitRepository GitRepository;

    [GitVersion] readonly GitVersion GitVersion;

    AbsolutePath SourceDirectory => RootDirectory / "source";

    AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    const string PackageProjectUrl = "https://github.com/CreativeCodersTeam/Core"; 

    Target Clean => _ => _
        .Before(Restore)
        .UseBuildAction<CleanBuildAction>(this);

    Target Restore => _ => _
        .Before(Compile)
        .UseBuildAction<RestoreBuildAction>(this);

    Target Compile => _ => _
        .DependsOn(Restore)
        .ProceedAfterFailure()
        .UseBuildAction<DotNetCompileBuildAction>(this);

    Target RunTests => _ => _
        .DependsOn(Compile)
        .UseBuildAction<UnitTestAction>(this,
            x => x
                .SetUnitTestsBasePath("UnitTests")
                .SetProjectsPattern("**/*.csproj")
                .SetResultsDirectory(ArtifactsDirectory / "test_results"));
    
    Target Pack => _ => _
        .DependsOn(Clean)
        .DependsOn(RunTests)
        .UseBuildAction<PackBuildAction>(this, x => x
            .SetPackageLicenseExpression(PackageLicenseExpressions.MIT)
            .SetPackageProjectUrl(PackageProjectUrl)
            .SetCopyright($"{DateTime.Now.Year} CreativeCoders"));

    Target Rebuild => _ => _
        .DependsOn(Clean)
        .DependsOn(Compile);

    Target PushDevNuGet => _ => _
        .DependsOn(Pack)
        .Requires(() => DevNuGetSource)
        .Requires(() => DevNuGetApiKey)
        .UseBuildAction<PushBuildAction>(this, 
            x => x
                .SetSource(DevNuGetSource)
                .SetApiKey(DevNuGetApiKey));

    Target PushNuGet => _ => _
        .DependsOn(Pack)
        .Requires(() => NuGetApiKey)
        .UseBuildAction<PushBuildAction>(this,
            x => x
                .SetSource(NuGetSource)
                .SetApiKey(NuGetApiKey));

    Configuration IBuildInfo.Configuration => Configuration;

    Solution IBuildInfo.Solution => Solution;

    GitRepository IBuildInfo.GitRepository => GitRepository;

    IVersionInfo IBuildInfo.VersionInfo => new GitVersionWrapper(GitVersion, "0.0.0", 1);

    AbsolutePath IBuildInfo.SourceDirectory => SourceDirectory;

    AbsolutePath IBuildInfo.ArtifactsDirectory => ArtifactsDirectory;
}
