#region

using System.Collections.Generic;
using DDDCore.Event;
using DDDCore.Implement;
using DDDCore.Usecase;
using DDDCore.Usecase.CQRS;
using ThirtyParty.DDDCore.Implement.CQRS;
using ThirtyParty.DDDCore.Usecase;
using Utilities.Contract;

#endregion

namespace Stat.UseCase
{
    public class GetStatContentUseCase : UseCase<GetStatContentInput , GetStatContentOutput , IStatRepository>
    {
    #region Constructor

        public GetStatContentUseCase(IDomainEventBus domainEventBus , IStatRepository repository) :
            base(domainEventBus , repository) { }

    #endregion

    #region Public Methods

        public override void Execute(GetStatContentInput input , GetStatContentOutput output)
        {
            var actorId = input.ActorId;
            Contract.RequireString(actorId , "actorId");
            var stats = repository.GetStatsByActorId(actorId);
            Contract.RequireNotNull(stats , "stats is null");
            var statDtos = ConvertStatToDto.Transform(stats);
            output.SetActorId(actorId)
                  .SetStats(statDtos)
                  .SetExitCode(ExitCode.SUCCESS);
        }

    #endregion
    }

    public interface GetStatContentOutput : Output
    {
    #region Public Methods

        GetStatContentOutput SetActorId(string      actorId);
        GetStatContentOutput SetStats(List<StatDto> statDtos);

    #endregion
    }

    public class GetStatContentPresenter : Result , GetStatContentOutput , Presenter<StatContentViewModel>
    {
    #region Private Variables

        private string        actorId;
        private List<StatDto> statDtos;

    #endregion

    #region Public Methods

        public StatContentViewModel BuildViewModel()
        {
            var statContentViewModel = new StatContentViewModel();
            statContentViewModel.ActorId = actorId;
            statContentViewModel.Stats   = statDtos;
            return statContentViewModel;
        }

        public GetStatContentOutput SetActorId(string actorId)
        {
            this.actorId = actorId;
            return this;
        }


        public GetStatContentOutput SetStats(List<StatDto> statDtos)
        {
            this.statDtos = statDtos;
            return this;
        }

    #endregion
    }

    public class StatContentViewModel : ViewModel
    {
    #region Public Variables

        public List<StatDto> Stats;
        public string        ActorId;

    #endregion
    }

    public class GetStatContentInput : Input
    {
    #region Public Variables

        public string ActorId;

    #endregion
    }
}