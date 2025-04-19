using System;

namespace _Scripts.Editor.Codegen
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class GenerateGameEventAttribute: Attribute
    {
        public Type EventType;
        public string EventName;
        
        public GenerateGameEventAttribute(Type eventType, string eventName)
        {
            EventType = eventType;
            EventName = eventName;
        }
    }
}