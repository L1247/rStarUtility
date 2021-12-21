#region

using DDDCore.Event;
using DDDCore.Implement;
using Stat.Entity.Event;
using Zenject;

#endregion

namespace Game.Battle.Adapter.EventHandler
{
    public class StatEventHandler : DomainEventHandler , IInitializable
    {
    #region Constructor

        public StatEventHandler(IDomainEventBus domainEventBus) : base(domainEventBus) { }

    #endregion

    #region Public Methods

        public void Initialize()
        {
            Register<StatCreated>(OnStatCreated);
        }

    #endregion

    #region Private Methods

        private void OnStatCreated(StatCreated created) { }

    #endregion
    }
}