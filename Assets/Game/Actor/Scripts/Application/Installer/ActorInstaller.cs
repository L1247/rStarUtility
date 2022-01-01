#region

using Actor.Adapter;
using Actor.Scripts.Core.UseCase;
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