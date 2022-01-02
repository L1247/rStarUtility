#region

using Actor.Adapter.Interfaces;
using Game.Actor.Scripts.Adapter.Controller;
using UniRx;
using UnityEngine;
using Zenject;

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
        private ActorFactory actorFactory;

    #endregion

    #region Public Methods

        public void CreateActor()
        {
            var actorComponent = actorFactory.Create();
            actorComponent.SetPosition(Random.onUnitSphere * 3);
        }

        public void Initialize()
        {
            references.CreateActorButton.OnClickAsObservable()
                      .Subscribe(_ => actorController.CreateActor()).AddTo(references);
        }

    #endregion
    }
}