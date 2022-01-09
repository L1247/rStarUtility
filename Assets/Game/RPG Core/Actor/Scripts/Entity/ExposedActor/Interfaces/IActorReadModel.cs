#region

using DDDCore.Model;

#endregion

namespace Actor.ExposedActor.Interfaces
{
    public interface IActorReadModel : IEntity<string>
    {
    #region Public Variables

        string DataId { get; }

    #endregion
    }
}