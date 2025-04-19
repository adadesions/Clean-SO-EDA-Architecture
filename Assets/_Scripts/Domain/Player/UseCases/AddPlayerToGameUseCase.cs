using _Scripts.Core.Events.Types;
using _Scripts.Domain.Player.DTO;
using _Scripts.Domain.Player.Interfaces;

namespace _Scripts.Domain.Player.UseCases
{
    public class AddPlayerToGameUseCase
    {
        private readonly IPlayerService playerService;
        private readonly BoolEvent _onPlayerAdded;

        public AddPlayerToGameUseCase(IPlayerService playerService, BoolEvent onPlayerAdded)
        {
            this.playerService = playerService;
            _onPlayerAdded = onPlayerAdded;
        }

        public void Execute(string name)
        {
            var playerData = new PlayerDataDto
            {
                PlayerName = name
            };

            _onPlayerAdded.Raise(true);
            playerService.AddPlayerToGame(playerData);
        }
    }
}