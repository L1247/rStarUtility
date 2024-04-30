#region

using System;

#endregion

namespace rStarUtility.Util.DDD.UseCase
{
    /// <summary>
    ///     UseCaseFailureException is the subclass of RuntimeException.
    ///     When a use case can not fulfill its specifications , UseCaseFailureException will be thrown.
    /// </summary>
    public class UseCaseFailureException : SystemException { }
}