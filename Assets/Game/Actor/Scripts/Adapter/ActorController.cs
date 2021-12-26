#region

using System;
using Actor.Scripts.Core.UseCase;
using DDDCore.Usecase.CQRS;
using ThirtyParty.DDDCore.Implement.CQRS;
using Utilities.Contract;
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
            var exitCode = createActorOutput.GetExitCode();
            Contract.Ensure(exitCode != ExitCode.FAILURE , "ExitCode is FAILURE");
            return createActorOutput;
        }

    #endregion
    }
}