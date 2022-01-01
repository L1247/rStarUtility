#region

using System;
using Actor.Adapter;
using Actor.Adapter.Interfaces;
using Game.Actor.Scripts.Data;
using UniRx;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

#endregion

namespace Game.Actor.Scripts.Application.Presenter
{
    public class ActorSamplePresenter : IInitializable , IActorPresenter
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

        public void CreateActor()
        {
            var actorPrefab = settings.actorData.actorPrefab;
            var unitCircle  = Random.onUnitSphere * 3;
            Object.Instantiate(actorPrefab , unitCircle , Quaternion.identity);
        }

        public void Initialize()
        {
            references.CreateActorButton.OnClickAsObservable()
                      .Subscribe(_ => actorController.CreateActor()).AddTo(references);
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