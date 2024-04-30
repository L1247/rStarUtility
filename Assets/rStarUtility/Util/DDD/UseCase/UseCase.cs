namespace rStarUtility.Util.DDD.UseCase
{
    /// <summary>
    ///     UseCase is an interface for representing a use case in clean architecture.
    /// </summary>
    /// <typeparam name="I">the type parameter for representing a use case input the type parameter for representing a use case input</typeparam>
    /// <typeparam name="O">the type parameter for representing a use case output</typeparam>
    public interface UseCase<I , O> where I : Input where O : Output
    {
    #region Public Methods

        public O Execute(I input);

    #endregion
    }
}