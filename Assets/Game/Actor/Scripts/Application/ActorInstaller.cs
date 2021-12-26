#region

using Actor.Scripts.Core.UseCase;
using Actor.Adapter;
using Zenject;

#endregion

namespace Actor.Application
{
    public class ActorInstaller : Installer<ActorInstaller>
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