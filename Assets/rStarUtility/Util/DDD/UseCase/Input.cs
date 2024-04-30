namespace rStarUtility.Util.DDD.UseCase
{
    public interface Input
    {
    #region Public Methods

        static NullInput OfNull()
        {
            return new NullInput();
        }

    #endregion

    #region Nested Types

        class NullInput : Input { }

    #endregion
    }
}