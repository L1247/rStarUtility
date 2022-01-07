#region

using DDDCore.Model;

#endregion

namespace Actor.Entity
{
    public interface IActorReadModel : IEntity<string> { }

    public interface IActorCommand { }
}