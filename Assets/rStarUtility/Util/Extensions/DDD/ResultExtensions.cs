#region

using rStarUtility.Util.DDD.UseCase;

#endregion

namespace rStarUtility.Util.Extensions.DDD
{
    public static class ResultExtensions
    {
    #region Public Methods

        public static Output RequireSuccess(this Output output)
        {
            var exitCode = output.GetExitCode();
            var message  = output.GetMessage();
            Contract.Require(exitCode == ExitCode.SUCCESS , $"Output exit code is Failure , Cause {message}.");
            return output;
        }

    #endregion
    }
}