using UnityEditor;

public class BuildScript
{
    public static void PerformBuild()
    {
        string[] scenes = {"Assets/Scenes/SampleScene.unity"};
        BuildPipeline.BuildPlayer(scenes, "build/build.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
    }
}