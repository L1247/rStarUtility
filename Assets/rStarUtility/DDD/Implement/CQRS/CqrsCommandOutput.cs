namespace rStarUtility.DDD.Usecase.CQRS
{
    public interface CqrsCommandOutput : Output
    {
    #region Public Methods

        string GetId();

        CqrsCommandOutput SetId(string id);

    #endregion
    }
}