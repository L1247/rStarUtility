#region

using UniRx;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Actor.Scripts.Adapter
{
    public class ActorSamplePresenter : IInitializable
    {
    #region Private Variables

        [Inject]
        private References references;

        [Inject]
        private ActorController actorController;

    #endregion

    #region Public Methods

        public void Initialize()
        {
            references.CreateActorButton.OnClickAsObservable()
                      .Subscribe(_ => { CreateActor(); }).AddTo(references);
        }

    #endregion

    #region Private Methods

        private void CreateActor()
        {
            Debug.Log("CreateActor");
            actorController.CreateActor();
        }

    #endregion
    }
}