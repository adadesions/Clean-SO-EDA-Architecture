using UnityEditor;

namespace _Scripts.Editor.Codegen
{
    [InitializeOnLoad]
    public static class GameEventAutoGenerate
    {
        static bool hasRun;

        static GameEventAutoGenerate()
        {
            EditorApplication.update += RunOnce;
        }

        private static void RunOnce()
        {
            if (hasRun) return;
            hasRun = true;
            GameEventGenerator.Generate();
        }
    }
}