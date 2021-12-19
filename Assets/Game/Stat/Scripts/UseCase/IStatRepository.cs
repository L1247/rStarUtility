#region

using DDDCore.Event.Usecase;

#endregion

namespace Game.Stat.Scripts.UseCase
{
    public interface IStatRepository : IRepository<global::Stat.Entity.Stat> { }
}