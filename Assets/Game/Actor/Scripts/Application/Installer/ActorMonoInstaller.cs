#region

using Game.Actor.Scripts.Application.Presenter;
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
            Container.BindInterfacesTo<ActorSamplePresenter>().AsSingle();
        }

    #endregion
    }
}