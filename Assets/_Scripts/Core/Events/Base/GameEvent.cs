using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Core.Events.Base
{
    [CreateAssetMenu(fileName = "BaseGameEvent", menuName = "AdaBrain/BaseGameEvent")]
    public abstract class GameEvent<T> : ScriptableObject
    {
        private readonly List<GameEventListener<T>> listeners = new();

        public void Raise(T value)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
                listeners[i].OnEventRaised(value);
        }

        public void Register(GameEventListener<T> listener) => listeners.Add(listener);
        public void Unregister(GameEventListener<T> listener) => listeners.Remove(listener);
    }
}
