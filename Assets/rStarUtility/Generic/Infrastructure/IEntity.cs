namespace rStarUtility.Generic.Infrastructure
{
    public interface IEntity<T>
    {
    #region Public Methods

        T GetId();

    #endregion
    }
}