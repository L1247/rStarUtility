#region

using Actor.Scripts.Core.Entity;
using DDDCore.Event;
using DDDCore.Implement;
using DDDCore.Usecase.CQRS;
using ThirtyParty.DDDCore.Usecase;
using Utilities.Contract;

#endregion

namespace Actor.Scripts.Core.UseCase
{
    public struct CreateActorInput : Input
    {
        public string Id;
    }


    public class CreateActorUseCase : UseCase<CreateActorInput , CqrsCommandOutput , IActorRepository>
    {
    #region Constructor

        public CreateActorUseCase(IDomainEventBus domainEventBus , IActorRepository repository) : base(
            domainEventBus , repository) { }

    #endregion

    #region Public Methods

        public override void Execute(CreateActorInput input , CqrsCommandOutput output)
        {
            var id = input.Id;
            Contract.RequireString(id , "id");

            var actor = ActorBuilder
                        .NewInstance()
                        .SetId(id)
                        .Build();
            repository.Save(actor);

            domainEventBus.PostAll(actor);

            output.SetId(actor.GetId());
            output.SetExitCode(ExitCode.SUCCESS);
        }

    #endregion
    }
}