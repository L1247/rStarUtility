#region

using UniRx;
using Zenject;

#endregion

namespace Game.Stat.Scripts.Adapter
{
    public class StatPresenter : IInitializable

    {
    #region Private Variables

        [Inject]
        private References references;

        [Inject]
        private StatController statController;

    #endregion

    #region Public Methods

        public void Initialize()
        {
            references.CreateStatButton.OnClickAsObservable()
                      .Subscribe(_ => { statController.CreateStat("123"); })
                      .AddTo(references);
        }

    #endregion
    }
}