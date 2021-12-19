#region

using Actor.Scripts.Core.Entity;
using DDDCore.Implement;

#endregion

namespace Actor.Scripts.Core.UseCase
{
    public class ActorRepository : AbstractRepository<IActor> , IActorRepository { }
}