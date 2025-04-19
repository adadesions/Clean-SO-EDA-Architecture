using _Scripts.Domain.Player.DTO;

namespace _Scripts.Domain.Player.Interfaces
{
    public interface IPlayerService
    {
        void AddPlayerToGame(PlayerDataDto playerData);
    }
}