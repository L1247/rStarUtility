#region

using Stat.UseCase;
using ThirtyParty.DDDCore.Implement.CQRS;
using UnityEngine;
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

    #endregion

    #region Constructor

        public StatController()
        {
            createStatInput = new CreateStatInput();
        }

    #endregion

    #region Public Methods

        public void CreateStat(string actorId)
        {
            var createStatOutput = CqrsCommandPresenter.NewInstance();
            createStatInput.ActorId = actorId;
            createStatUseCase.Execute(createStatInput , createStatOutput);
            var id = createStatOutput.GetId();
            Debug.Log($"stat: {id}");
        }

    #endregion
    }
}