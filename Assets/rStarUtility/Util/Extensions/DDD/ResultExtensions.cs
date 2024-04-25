#region

using rStarUtility.Util.DDD.UseCase;

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

        public static Output RequireFailure(this Output output)
        {
            output.GetExitCode().RequireFailure();
            return output;
        }

        public static void RequireSuccess(this ExitCode exitCode)
        {
            Contract.Require(exitCode == ExitCode.SUCCESS , $"exitCode[{exitCode}] is not ExitCode.SUCCESS");
        }

        public static Output RequireSuccess(this Output output)
        {
            output.GetExitCode().RequireSuccess();
            return output;
        }

    #endregion
    }
}