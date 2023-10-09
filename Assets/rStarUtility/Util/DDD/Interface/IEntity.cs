namespace rStarUtility.Generic.Infrastructure
{
    public interface IEntity<T>
    {
    #region Public Variables

        T Id { get; }

    #endregion
    }
}