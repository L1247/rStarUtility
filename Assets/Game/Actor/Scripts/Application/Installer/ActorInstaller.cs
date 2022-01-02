#region

using System;
using Actor.Scripts.Core.UseCase;
using Game.Actor.Scripts.Adapter.Controller;
using Game.Actor.Scripts.Adapter.Gateway.Eventbus;
using Game.Actor.Scripts.Adapter.Gateway.Repository;
using Game.Actor.Scripts.Application.Components;
using Game.Actor.Scripts.Application.Presenter;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Actor.Scripts.Application.Installer
{
    public class ActorInstaller : Installer<ActorInstaller>
    {
    #region Private Variables

        [Inject]
        private Settings settings;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<ActorController>().AsSingle();
            Container.Bind<CreateActorUseCase>().AsSingle();
            Container.Bind<ActorEventHandler>().AsSingle().NonLazy().IfNotBound();
            Container.Bind<IActorRepository>().To<ActorRepository>().AsSingle();
            Container.Bind<ActorFactory>().AsSingle();
            Container.BindMemoryPool<ActorComponent , ActorComponent.Pool>()
                     .WithInitialSize(30)
                     .FromComponentInNewPrefab(settings.actorPrefab)
                     .UnderTransformGroup("ViewObjs");
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class Settings
        {
        #region Public Variables

            public GameObject actorPrefab;

        #endregion
        }

    #endregion
    }
}