#region

#endregion

namespace rStarUtility.Util.DDD.UseCase
{
    /// <summary>
    /// Command is a marker interface for representing a command operation.
    /// </summary>
    /// <typeparam name="I">the type parameter for representing a use case input</typeparam>
    /// <typeparam name="O">the type parameter for representing a use case output</typeparam>
    public interface Command<I , O> : UseCase<I , O> where O : Output where I : Input { }
}