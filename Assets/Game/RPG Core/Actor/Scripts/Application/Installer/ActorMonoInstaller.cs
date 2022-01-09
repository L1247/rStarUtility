#region

using Actor.Adapter.Interfaces;
using Actor.Application.Presenter;
using Zenject;

#endregion

namespace Game.Actor.Scripts.Application.Installer
{
    public class ActorMonoInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            ActorInstaller.Install(Container);
            Container.BindInterfacesAndSelfTo<ActorSamplePresenter>().AsSingle();
            Container.Bind<IActorFlow>().To<ActorFlow>().AsSingle();
        }

    #endregion
    }
}