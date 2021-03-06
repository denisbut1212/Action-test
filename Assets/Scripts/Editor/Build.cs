﻿using System.Linq;
using UnityEditor;

public class Build
{
    //build mehtod
    public static void Perform()
    {
        var scenes = EditorBuildSettings.scenes.Select(e => e.path).ToArray();
        var targetGroup = BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget);
        var initial = PlayerSettings.GetScriptingBackend(targetGroup);
        
        PlayerSettings.SetScriptingBackend(targetGroup, ScriptingImplementation.IL2CPP);
        PlayerSettings.SetIl2CppCompilerConfiguration(targetGroup, Il2CppCompilerConfiguration.Master);
        BuildPipeline.BuildPlayer(scenes, "build/build.exe",
            EditorUserBuildSettings.activeBuildTarget,
            BuildOptions.None);
        PlayerSettings.SetScriptingBackend(targetGroup, initial);
    }
}