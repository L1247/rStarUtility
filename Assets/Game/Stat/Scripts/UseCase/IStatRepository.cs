#region

using DDDCore.Event.Usecase;
using Stat.Entity;

#endregion

namespace Stat.UseCase
{
    public interface IStatRepository : IRepository<IStat> { }
}