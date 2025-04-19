using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Core.Events.Types
{
    public class VoidEventListener : MonoBehaviour
    {
        public VoidEvent Event;
        public UnityEvent Response;

        private void OnEnable() => Event?.RegisterListener(this);
        private void OnDisable() => Event?.UnregisterListener(this);
        public void OnEventRaised() => Response?.Invoke();
    }
}