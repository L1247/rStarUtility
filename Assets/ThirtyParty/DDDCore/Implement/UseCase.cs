#region

using DDDCore.Event;
using Zenject;

#endregion

namespace DDDCore.Implement
{
    /// <summary>
    /// </summary>
    /// <typeparam name="I">Input</typeparam>
    /// <typeparam name="R">Repository</typeparam>
    public abstract class UseCase<I , R>
    {
    #region Protected Variables

        protected readonly IDomainEventBus domainEventBus;

        protected R repository;

    #endregion

    #region Constructor

        [Inject]
        public UseCase(IDomainEventBus domainEventBus , R repository)
        {
            this.domainEventBus = domainEventBus;
            this.repository     = repository;
        }

    #endregion

    #region Public Methods

        public abstract void Execute(I input);

    #endregion
    }
}