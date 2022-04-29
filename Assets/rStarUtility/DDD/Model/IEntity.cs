namespace rStarUtility.DDD.Model
{
    public interface IEntity<T>
    {
    #region Public Methods

        T GetId();

    #endregion
    }
}