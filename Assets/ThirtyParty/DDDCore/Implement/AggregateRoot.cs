#region

using DDDCore.Model;

#endregion

namespace DDDCore.Implement
{
    public abstract class AggregateRoot : IAggregateRoot
    {
    #region Protected Variables

        protected readonly string id;

    #endregion

    #region Constructor

        protected AggregateRoot(string id)
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