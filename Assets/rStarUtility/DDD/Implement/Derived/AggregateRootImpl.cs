#region

using rStarUtility.DDD.Implement.Core;

#endregion

namespace rStarUtility.DDD.Implement.Derived
{
    public sealed class AggregateRootImpl : AggregateRoot
    {
    #region Constructor

        public AggregateRootImpl(string id) : base(id) { }

    #endregion
    }
}