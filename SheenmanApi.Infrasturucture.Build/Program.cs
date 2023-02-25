//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers 
// Free ToUse Comfort and Peace 
//===================================================

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

var gitPepilene = new GithubPipeline
{
    Name = "Sheenman",

    OnEvents = new Events
    {
        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "Master" }
        },

        Push = new PushEvent
        {
            Branches = new string[] { "Master" }
        }
    },

    Jobs = new Jobs
    {
        Build = new BuildJob
        {
            RunsOn = BuildMachines.WindowsLatest,
            Steps = new List<ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.GithubTask>
                {
                   new CheckoutTaskV2
                   {
                       Name = "Checking"
                   },
                    new SetupDotNetTaskV1
                    {
                         Name = "Instal .Net",
                           TargetDotNetVersion = new TargetDotNetVersion
                           {
                               DotNetVersion = "7.0.200"
                           }
                    },

                    new RestoreTask
                    {
                         Name = "Restoring Nuget Patgetch"
                    },

                    new DotNetBuildTask
                    {
                         Name = "Bouilding Project"
                    },

                    new TestTask
                    {
                         Name = "Running Test"
                    },
            }

        }
    }
};

var clint = new ADotNetClient();
clint.SerializeAndWriteToFile(
    gitPepilene,
    path: "../../../../.github/workflows/build.yml");
