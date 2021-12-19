#region

using Game.Battle.Adapter.Presenter;
using Zenject;

#endregion

namespace Game.Battle.Application
{
    public class BattleInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BattlePresenter>().AsSingle();
        }

    #endregion
    }
}