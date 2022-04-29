#region

using rStarUtility.DDDCore.Implement.Core;

#endregion

namespace rStarUtility.DDDCore.Implement.Derived
{
    public sealed class AggregateRootImpl : AggregateRoot
    {
    #region Constructor

        public AggregateRootImpl(string id) : base(id) { }

    #endregion
    }
}