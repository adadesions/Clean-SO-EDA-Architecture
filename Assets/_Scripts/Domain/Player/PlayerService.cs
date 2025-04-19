using _Scripts.Domain.Player.DTO;
using _Scripts.Domain.Player.Interfaces;
using _Scripts.Domain.Player.UseCases;
using UnityEngine;

namespace _Scripts.Domain.Player
{
    public class PlayerService : IPlayerService
    {
        public void AddPlayerToGame(PlayerDataDto playeData)
        {
            Debug.Log($"Add {playeData.PlayerName} to system");
        }
    }
}