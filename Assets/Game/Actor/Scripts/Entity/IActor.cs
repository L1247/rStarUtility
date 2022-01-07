#region

using DDDCore.Model;

#endregion

namespace Actor.Entity
{
    public interface IActorReadModel : IEntity<string>
    {
    #region Public Variables

        string DataId { get; }

    #endregion
    }

    public interface IActorCommand { }
}