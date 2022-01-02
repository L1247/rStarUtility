#region

using Actor.Scripts.Core.UseCase;
using Game.Actor.Scripts.Adapter.Controller;
using Game.Actor.Scripts.Adapter.Gateway.Eventbus;
using Game.Actor.Scripts.Adapter.Gateway.Repository;
using Zenject;

#endregion

namespace Game.Actor.Scripts.Application.Installer
{
    public class ActorInstaller : Installer<ActorInstaller>
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<ActorController>().AsSingle();
            Container.Bind<CreateActorUseCase>().AsSingle();
            Container.Bind<ActorEventHandler>().AsSingle().NonLazy().IfNotBound();
            Container.Bind<IActorRepository>().To<ActorRepository>().AsSingle();
        }

    #endregion
    }
}