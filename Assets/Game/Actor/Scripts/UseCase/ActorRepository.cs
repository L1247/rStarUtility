#region

using DDDCore.Implement;

#endregion

namespace Actor.Scripts.Core.UseCase
{
    public class ActorRepository : AbstractRepository<IActor> , IActorRepository { }
}