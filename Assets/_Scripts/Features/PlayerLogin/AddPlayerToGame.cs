using System;
using _Scripts.Core.Events.Types;
using _Scripts.Domain.Player.UseCases;
using UnityEngine;
using VContainer;

namespace _Scripts.Features.PlayerLogin
{
    public class AddPlayerToGame: MonoBehaviour
    {
        [SerializeField] private BoolEvent onPlayerAdded;

        private AddPlayerToGameUseCase _useCase;

        [Inject]
        public void Construct(AddPlayerToGameUseCase useCase)
        {
            _useCase = useCase;
        }

        public void TriggerAddPlayer(string playerName)
        {
            _useCase.Execute(playerName);
        }

        private void Start()
        {
            TriggerAddPlayer(gameObject.name);
        }
    }
}