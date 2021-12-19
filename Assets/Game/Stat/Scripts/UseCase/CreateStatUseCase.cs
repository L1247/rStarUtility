#region

using DDDCore.Event;
using DDDCore.Implement;
using DDDCore.Usecase.CQRS;
using ThirtyParty.DDDCore.Usecase;

#endregion

namespace Game.Stat.Scripts.UseCase
{
    public class CreateStatUseCase : UseCase<CreateStatInput , CqrsCommandOutput , IStatRepository>
    {
    #region Constructor

        public CreateStatUseCase(IDomainEventBus domainEventBus , IStatRepository repository) : base(domainEventBus , repository) { }

    #endregion

    #region Public Methods

        public override void Execute(CreateStatInput input , CqrsCommandOutput output) { }

    #endregion
    }

    public class CreateStatInput : Input { }
}