#region

using Stat.UseCase;
using ThirtyParty.DDDCore.Implement.CQRS;
using Zenject;

#endregion

namespace Game.Stat.Scripts.Adapter
{
    public class StatController
    {
    #region Private Variables

        [Inject]
        private CreateStatUseCase createStatUseCase;

        private readonly CreateStatInput createStatInput;

        [Inject]
        private GetStatContentUseCase getStatContentUseCase;

        private readonly GetStatContentInput getStatContentInput;

    #endregion

    #region Constructor

        public StatController()
        {
            createStatInput     = new CreateStatInput();
            getStatContentInput = new GetStatContentInput();
        }

    #endregion

    #region Public Methods

        public void CreateStat(string actorId)
        {
            var createStatOutput = CqrsCommandPresenter.NewInstance();
            createStatInput.ActorId = actorId;
            createStatUseCase.Execute(createStatInput , createStatOutput);
        }

        public StatContentViewModel GetStats(string actorId)
        {
            var getStatContentPresenter = new GetStatContentPresenter();
            getStatContentUseCase.Execute(getStatContentInput , getStatContentPresenter);
            return getStatContentPresenter.BuildViewModel();
        }

    #endregion
    }
}