#region

#endregion

namespace rStarUtility.Util.DDD.UseCase
{
    /// <summary>
    /// </summary>
    /// <typeparam name="I">Input</typeparam>
    /// <typeparam name="O">Output</typeparam>
    public interface Command<I , O> where I : Input where O : Output
    {
    #region Public Methods

        public O Execute(I input);

    #endregion
    }
}