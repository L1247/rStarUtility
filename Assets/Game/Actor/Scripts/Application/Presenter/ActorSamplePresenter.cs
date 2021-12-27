#region

using System;
using Actor.Adapter;
using Game.Actor.Scripts.Data;
using UniRx;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

#endregion

namespace Game.Actor.Scripts.Application.Presenter
{
    public class ActorSamplePresenter : IInitializable
    {
    #region Private Variables

        [Inject]
        private References references;

        [Inject]
        private ActorController actorController;

        [Inject]
        private Settings settings;

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
            var actorPrefab = settings.actorData.actorPrefab;
            var unitCircle  = Random.onUnitSphere * 3;
            Object.Instantiate(actorPrefab , unitCircle , Quaternion.identity);
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class Settings
        {
        #region Public Variables

            public ActorData actorData;

        #endregion
        }

    #endregion
    }
}