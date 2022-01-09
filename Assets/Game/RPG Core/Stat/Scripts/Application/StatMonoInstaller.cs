#region

using Stat.Adapter;
using Zenject;

#endregion

namespace Stat.Application
{
    public class StatMonoInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            StatInstaller.Install(Container);
            Container.BindInterfacesTo<StatPresenter>().AsSingle();
        }

    #endregion
    }
}