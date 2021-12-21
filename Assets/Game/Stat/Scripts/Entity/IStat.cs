#region

using DDDCore.Model;

#endregion

namespace Stat.Entity
{
    public interface IStat : IAggregateRoot
    {
    #region Public Variables

        string ActorId { get; }

    #endregion
    }
}