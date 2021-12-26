#region

using Actor.Adapter;
using Zenject;

#endregion

namespace Actor.Application
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