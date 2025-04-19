using _Scripts.Core.Events.Base;
using UnityEngine;

namespace _Scripts.Core.Events.Types
{
    [CreateAssetMenu(menuName = "AdaBrain/Events/Bool Event")]
    public class BoolEvent : GameEvent<bool> { }
}