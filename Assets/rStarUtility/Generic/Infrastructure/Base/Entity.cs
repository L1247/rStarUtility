#region

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public abstract class Entity : IEntity<string>
    {
    #region Public Variables

        public string Id { get; }

    #endregion

    #region Constructor

        protected Entity(string id)
        {
            Id = id;
        }

    #endregion
    }
}