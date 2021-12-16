#region

using Actor.Scripts.Core.Entity;
using DDDCore.Event;
using DDDCore.Implement;
using Utilities.Contract;

#endregion

namespace Actor.Scripts.Core.UseCase
{
    public struct CreateActorInput
    {
        public string Id;
    }

    public class CreateActorUseCase : UseCase<CreateActorInput , IActorRepository>
    {
    #region Constructor

        public CreateActorUseCase(IDomainEventBus domainEventBus , IActorRepository repository) : base(
            domainEventBus , repository) { }

    #endregion

    #region Public Methods

        public override void Execute(CreateActorInput input)
        {
            var id = input.Id;
            Contract.RequireString(id , "id");

            var actor = ActorBuilder
                        .NewInstance()
                        .SetId(id)
                        .Build();
            repository.Save(actor);
        }

    #endregion
    }
}