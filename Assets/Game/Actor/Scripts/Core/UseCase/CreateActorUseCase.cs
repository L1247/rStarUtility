using DDDCore.Event;
using DDDCore.Implement;

namespace Actor.Scripts.Core.UseCase
{
    public struct CreateActorInput { }

    public class CreateActorUseCase : UseCase<CreateActorInput , IActorRepository>
    {
    #region Constructor

        public CreateActorUseCase(IDomainEventBus domainEventBus , IActorRepository repository) : base(
            domainEventBus , repository) { }

    #endregion

    #region Public Methods

        public override void Execute(CreateActorInput input)
        {
            // var actor = ActorBuilder
            // .NewInstance()
            // .Build();
            // repository.Save(actor);
        }

    #endregion
    }
}