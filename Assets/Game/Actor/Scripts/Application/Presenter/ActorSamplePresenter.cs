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
            references.ShowActorCountButton.OnClickAsObservable()
                      .Subscribe(_ =>
                      {
                          var allActor = actorController.GetAllActor();
                          Debug.Log($"{allActor.Count}");
                          foreach (var actor in allActor)
                          {
                              Debug.Log($"{actor.GetId()}");
                              Debug.Log($"{actor.DataId}");
                          }
                      })
                      .AddTo(references);
            references.CreateActorButton.OnClickAsObservable()
                      .Subscribe(_ => actorController.CreateActor("123"))
                      .AddTo(references);
        }

    #endregion
    }
}