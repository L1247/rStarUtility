#region

using rStarUtility.DDDCore.Implement.Abstract;
using rStarUtility.DDDCore.Implement.Core;

#endregion

namespace rStarUtility.DDDCore.Implement.Derived
{
    public sealed class RepositoryImpl<T> : AbstractRepository<T> where T : AggregateRoot { }
}