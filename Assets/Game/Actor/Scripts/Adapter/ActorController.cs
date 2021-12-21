#region

using System;
using Actor.Scripts.Core.UseCase;
using ThirtyParty.DDDCore.Implement.CQRS;
using Zenject;

#endregion

namespace Game.Actor.Scripts.Adapter
{
    public class ActorController
    {
    #region Private Variables

        [Inject]
        private CreateActorUseCase createActorUseCase;

        private readonly CreateActorInput     createActorInput;
        private readonly CqrsCommandPresenter createActorOutput;

    #endregion

    #region Constructor

        public ActorController()
        {
            createActorInput  = new CreateActorInput();
            createActorOutput = new CqrsCommandPresenter();
        }

    #endregion

    #region Public Methods

        public void CreateActor()
        {
            createActorInput.Id = Guid.NewGuid().ToString();
            createActorUseCase.Execute(createActorInput , createActorOutput);
        }

    #endregion
    }
}