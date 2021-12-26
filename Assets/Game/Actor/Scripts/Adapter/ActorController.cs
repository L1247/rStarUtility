#region

using System;
using Actor.Scripts.Core.UseCase;
using ThirtyParty.DDDCore.Implement.CQRS;
using Zenject;

#endregion

namespace Actor.Adapter
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

        public CqrsCommandPresenter CreateActor()
        {
            createActorInput.Id = Guid.NewGuid().ToString();
            createActorUseCase.Execute(createActorInput , createActorOutput);
            return createActorOutput;
        }

    #endregion
    }
}