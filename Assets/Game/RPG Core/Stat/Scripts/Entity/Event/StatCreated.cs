#region

using DDDCore.Implement;

#endregion

namespace Stat.Entity.Event
{
    public class StatCreated : DomainEvent
    {
    #region Public Variables

        public string StatId { get; }

    #endregion

    #region Constructor

        public StatCreated(string statId)
        {
            StatId = statId;
        }

    #endregion
    }
}