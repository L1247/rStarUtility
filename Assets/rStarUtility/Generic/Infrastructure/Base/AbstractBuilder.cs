namespace rStarUtility.Generic.Infrastructure
{
    /// <summary>
    /// </summary>
    /// <typeparam name="Builder">Builder self</typeparam>
    /// <typeparam name="Object">Target's Class</typeparam>
    public abstract class AbstractBuilder<Object , Builder> where Builder : new() where Object : class
    {
    #region Public Methods

        public abstract Object Build();

        public static Builder NewInstance()
        {
            return new Builder();
        }

    #endregion
    }
}