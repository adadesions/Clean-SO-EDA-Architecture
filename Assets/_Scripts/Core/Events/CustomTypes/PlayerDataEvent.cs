using _Scripts.Core.Events.Base;
using _Scripts.Domain.Player.DTO;
using UnityEngine;

namespace _Scripts.Core.Events.CustomTypes
{
    [CreateAssetMenu(menuName = "AdaBrain/Events/PlayerData Event")]
    public class PlayerDataEvent: GameEvent<PlayerDataDto> { }
}