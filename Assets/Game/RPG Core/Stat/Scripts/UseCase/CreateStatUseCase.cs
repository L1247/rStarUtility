#region

using DDDCore.Event;
using DDDCore.Implement;
using DDDCore.Usecase.CQRS;
using Stat.Entity;
using ThirtyParty.DDDCore.Usecase;
using Utilities.Contract;

#endregion

namespace Stat.UseCase
{
    public class CreateStatUseCase : UseCase<CreateStatInput , CqrsCommandOutput , IStatRepository>
    {
    #region Constructor

        public CreateStatUseCase(IDomainEventBus domainEventBus , IStatRepository repository) : base(domainEventBus , repository) { }

    #endregion

    #region Public Methods

        public override void Execute(CreateStatInput input , CqrsCommandOutput output)
        {
            var actorId = input.ActorId;
            Contract.RequireString(actorId , "actorId");
            var stat = StatBuilder.NewInstance().SetActorId(actorId).Build();
            repository.Save(stat);

            domainEventBus.PostAll(stat);

            output.SetId(stat.GetId());
            output.SetExitCode(ExitCode.SUCCESS);
        }

    #endregion
    }

    public class CreateStatInput : Input
    {
    #region Public Variables

        public string ActorId;

    #endregion
    }
}