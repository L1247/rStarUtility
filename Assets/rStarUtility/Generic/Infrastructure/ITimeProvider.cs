namespace rStarUtility.Generic.Infrastructure
{
    public interface ITimeProvider
    {
    #region Public Methods

        float GetDeltaTime();
        float GetTotalTime();

    #endregion
    }
}