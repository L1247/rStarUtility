#region

using Actor.Scripts.Core.UseCase;
using Game.Actor.Scripts.Adapter;
using Zenject;

#endregion

namespace Actor.Application
{
    public class ActorInstaller : Installer
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<ActorController>().AsSingle();
            Container.Bind<CreateActorUseCase>().AsSingle();
            Container.Bind<IActorRepository>().To<ActorRepository>().AsSingle();
        }

    #endregion
    }
}