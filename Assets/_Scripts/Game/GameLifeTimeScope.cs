using _Scripts.Core.Events.CustomTypes;
using _Scripts.Core.Events.Types;
using _Scripts.Domain.Player;
using _Scripts.Domain.Player.Interfaces;
using _Scripts.Domain.Player.UseCases;
using _Scripts.Features.PlayerLogin;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Game
{
    public class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] private PlayerDataEvent playerDataEvent;
        [SerializeField] private BoolEvent onPlayerAdded;

        protected override void Configure(IContainerBuilder builder)
        {
            // Domain + Infra
            builder.Register<PlayerService>(Lifetime.Singleton).As<IPlayerService>();
            builder.Register<AddPlayerToGameUseCase>(Lifetime.Transient);

            // Features (MonoBehaviours)
            builder.RegisterComponentInHierarchy<AddPlayerToGame>();

            // SOs (SO-EDA)
            builder.RegisterInstance(playerDataEvent).As<PlayerDataEvent>();
            builder.RegisterInstance(onPlayerAdded).As<BoolEvent>();
            
        }
    }
}