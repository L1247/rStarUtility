#region

using UniRx;
using UnityEngine;
using Zenject;

#endregion

namespace Actor.Adapter
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
            var actorOutput = actorController.CreateActor();
            Debug.Log($"CreateActor Result = {actorOutput.GetExitCode()} , id: {actorOutput.GetId()}");

        }

    #endregion
    }
}