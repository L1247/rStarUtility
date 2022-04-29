#region

using rStarUtility.DDD.Implement.Abstract;
using rStarUtility.DDD.Implement.Core;

#endregion

namespace rStarUtility.DDD.Implement.Derived
{
    public sealed class RepositoryImpl<T> : AbstractRepository<T> where T : AggregateRoot { }
}