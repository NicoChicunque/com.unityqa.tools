using System;
using UnityEditor;
using UnityEditor.Build.Reporting;

namespace UnityQA.Tools
{
    public static class Builder
    {
        [MenuItem("Build/Android")]
        public static void BuildAndroid()
        {
            BuildReport buildReport = BuildPipeline.BuildPlayer(
                new BuildPlayerOptions
                {
                    //scenes = new[] { "Assets/Scenes/Main.unity" },
                    locationPathName = "./Builds/BuildTarget.Android.apk",
                    target = BuildTarget.Android,                                
                });

            if (buildReport.summary.result.Equals(BuildResult.Succeeded)) { return; }

            throw new Exception("Failed to build Android Player. See log for details...");
        }
    }
}