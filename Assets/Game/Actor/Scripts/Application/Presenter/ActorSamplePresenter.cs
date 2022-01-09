#region

using Actor.Adapter.Controller;
using Game.Actor.Scripts.Application.Components;
using UniRx;
using UnityEngine;
using Zenject;

#endregion

namespace Actor.Application.Presenter
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

        public void CreateActor(ActorComponent actorComponent)
        {
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