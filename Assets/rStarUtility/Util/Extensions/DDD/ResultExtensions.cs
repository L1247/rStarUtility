#region

using rStarUtility.Generic.Infrastructure;

#endregion

namespace rStarUtility.Util.Extensions.DDD
{
    public static class ResultExtensions
    {
    #region Public Methods

        public static void RequireFailure(this ExitCode exitCode)
        {
            Contract.Require(exitCode == ExitCode.FAILURE , $"exitCode[{exitCode}] is not ExitCode.FAILURE");
        }

        public static void RequireFailure(this Output output)
        {
            output.GetExitCode().RequireFailure();
        }

        public static void RequireSuccess(this ExitCode exitCode)
        {
            Contract.Require(exitCode == ExitCode.SUCCESS , $"exitCode[{exitCode}] is not ExitCode.SUCCESS");
        }

        public static void RequireSuccess(this Output output)
        {
            output.GetExitCode().RequireSuccess();
        }

    #endregion
    }
}