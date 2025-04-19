using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Core.Events.Base
{
    public abstract class GameEventListener<T>: MonoBehaviour
    {
        public GameEvent<T> Event;
        public UnityEvent<T> Response;

        protected virtual void OnEnable() => Event?.Register(this);
        protected virtual void OnDisable() => Event?.Unregister(this);
        public void OnEventRaised(T value) => Response?.Invoke(value);
    }
}