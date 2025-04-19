using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace _Scripts.Editor.Codegen
{
    public static class GameEventGenerator
    {
        [MenuItem("Tools/Generate GameEvents from Attributes")]
        public static void Generate()
        {
            var markerTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(t => t.GetCustomAttribute<GenerateGameEventAttribute>() != null);

            foreach (var type in markerTypes)
            {
                var attr = type.GetCustomAttribute<GenerateGameEventAttribute>();
                var eventType = attr.EventType;
                var eventName = attr.EventName;

                CreateGameEventScript(eventName, eventType);
                CreateGameEventListenerScript(eventName, eventType);
                CreateAssetFile(eventName);
            }

            AssetDatabase.Refresh();
        }

        private static void CreateGameEventScript(string eventName, Type eventType)
        {
            string path = $"Assets/_Scripts/Events/Generated/{eventName}Event.cs";
            if (File.Exists(path)) return;

            string content = $@"using _Scripts.Core.Events.Base;
using UnityEngine;

[CreateAssetMenu(menuName = ""Events/{eventName} Event"")]
public class {eventName}Event : GameEvent<{eventType.FullName}> {{ }}";

            File.WriteAllText(path, content);
        }

        private static void CreateGameEventListenerScript(string eventName, Type eventType)
        {
            string path = $"Assets/_Scripts/Events/Generated/{eventName}EventListener.cs";
            if (File.Exists(path)) return;

            string content = $@"using _Scripts.Core.Events.Base;

public class {eventName}EventListener : GameEventListener<{eventType.FullName}> {{ }}";

            File.WriteAllText(path, content);
        }
        
        private static void CreateAssetFile(string eventName)
        {
            string folderPath = "Assets/_Events";
            string assetPath = $"{folderPath}/{eventName}Event.asset";

            if (File.Exists(assetPath)) return;

            Directory.CreateDirectory(folderPath);

            var soType = Type.GetType($"{eventName}Event");
            var asset = ScriptableObject.CreateInstance(soType);
            AssetDatabase.CreateAsset(asset, assetPath);
            Debug.Log($"Created Event Asset: {assetPath}");
        }
    }
}