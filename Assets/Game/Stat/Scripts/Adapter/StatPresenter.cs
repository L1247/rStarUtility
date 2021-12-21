#region

using UniRx;
using UnityEngine;
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
            var actorId = "123";
            references.CreateStatButton.OnClickAsObservable()
                      .Subscribe(_ => { statController.CreateStat(actorId); })
                      .AddTo(references);
            references.GetStatsButton.OnClickAsObservable()
                      .Subscribe(_ =>
                      {
                          var statContentViewModel = statController.GetStats(actorId);
                          foreach (var statDto in statContentViewModel.Stats) Debug.Log($"stat: {statDto.ActorId} , {statDto.Id}");
                      })
                      .AddTo(references);
        }

    #endregion
    }
}