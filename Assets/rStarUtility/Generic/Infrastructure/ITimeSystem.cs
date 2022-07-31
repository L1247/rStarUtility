namespace rStarUtility.Generic.Infrastructure
{
    public interface ITimeSystem
    {
    #region Public Methods

        float GetDeltaTime();
        float GetTotalTime();

    #endregion
    }
}