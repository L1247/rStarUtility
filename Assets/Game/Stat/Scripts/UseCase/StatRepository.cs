#region

using DDDCore.Implement;
using Stat.Entity;

#endregion

namespace Stat.UseCase
{
    public class StatRepository : AbstractRepository<IStat> , IStatRepository { }
}