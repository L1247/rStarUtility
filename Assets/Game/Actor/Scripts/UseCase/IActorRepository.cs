#region

using Actor.Entity;
using DDDCore.Event.Usecase;

#endregion

namespace Actor.Scripts.Core.UseCase
{
    public interface IActorRepository : IRepository<IActor> { }
}