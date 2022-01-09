#region

using Actor.Adapter.Interfaces;
using Zenject;

#endregion

namespace Actor.Application.Presenter
{
    public class ActorFlow : IActorFlow
    {
    #region Private Variables

        [Inject]
        private ActorFactory actorFactory;

        [Inject]
        private ActorSamplePresenter actorPresenter;

    #endregion

    #region Public Methods

        public void WhenActorCreated()
        {
            var actorComponent = actorFactory.Create();
            actorPresenter.CreateActor(actorComponent);
        }

    #endregion
    }
}