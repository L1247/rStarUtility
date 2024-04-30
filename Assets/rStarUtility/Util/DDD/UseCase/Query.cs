namespace rStarUtility.Util.DDD.UseCase
{
    /// <summary>
    ///     Query is an interface to represent use case for query.
    /// </summary>
    /// <typeparam name="I">the type parameter for query input</typeparam>
    /// <typeparam name="O">the type parameter for query output</typeparam>
    public interface Query<I , O> : UseCase<I , O> where O : Output where I : Input { }
}