using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Core.Events.Types
{
    [CreateAssetMenu(menuName = "AdaBrain/Events/Void Event")]
    public class VoidEvent : ScriptableObject
    {
        private readonly List<VoidEventListener> listeners = new();

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised();
        }

        public void RegisterListener(VoidEventListener listener) => listeners.Add(listener);
        public void UnregisterListener(VoidEventListener listener) => listeners.Remove(listener);
    }
}