#region

using Actor.ExposedActor.Interfaces;
using DDDCore.Event.Usecase;

#endregion

namespace Actor.Scripts.Core.UseCase
{
    public interface IActorRepository : IRepository<IActorReadModel> { }
}