namespace rStarUtility.Generic.Infrastructure
{
    /// <summary>
    /// </summary>
    /// <typeparam name="Builder">Builder self</typeparam>
    /// <typeparam name="Object">Target's Class</typeparam>
    public abstract class AbstractBuilder<Object , Builder> where Object : class where Builder : new()
    {
    #region Public Methods

        public abstract Object Build();

        public static Builder NewInstance()
        {
            return new Builder();
        }

        public static implicit operator Object(AbstractBuilder<Object , Builder> builder)
        {
            return builder.Build();
        }

    #endregion
    }
}