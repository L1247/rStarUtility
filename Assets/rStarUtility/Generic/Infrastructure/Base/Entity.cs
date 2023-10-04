#region

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public abstract class Entity : IEntity<string>
    {
    #region Protected Variables

        protected readonly string id;

    #endregion

    #region Constructor

        protected Entity(string id)
        {
            this.id = id;
        }

    #endregion

    #region Public Methods

        public string GetId()
        {
            return id;
        }

    #endregion
    }
}