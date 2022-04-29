#region

using rStarUtility.DDDCore.Model;

#endregion

namespace rStarUtility.DDDCore.Implement.Core
{
    public abstract class Entity<T> : IEntity<T>
    {
    #region Protected Variables

        protected readonly T id;

    #endregion

    #region Constructor

        protected Entity(T id)
        {
            this.id = id;
        }

    #endregion

    #region Public Methods

        public T GetId()
        {
            return id;
        }

    #endregion
    }
}