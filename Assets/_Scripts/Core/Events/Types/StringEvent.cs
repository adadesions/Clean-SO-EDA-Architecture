using _Scripts.Core.Events.Base;
using UnityEngine;

namespace _Scripts.Core.Events.Types
{
    [CreateAssetMenu(menuName = "AdaBrain/Events/String Event")]
    public class StringEvent : GameEvent<string> { }
}