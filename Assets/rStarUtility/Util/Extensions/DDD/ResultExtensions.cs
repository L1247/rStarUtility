#region

using rStarUtility.Generic.Infrastructure;
using UnityEngine.Assertions;

#endregion

namespace rStarUtility.Util.Extensions.DDD
{
    public static class ResultExtensions
    {
    #region Public Methods

        public static void IsFailure(this ExitCode exitCode)
        {
            Assert.IsTrue(exitCode == ExitCode.FAILURE , $"exitCode[{exitCode}] is not ExitCode.FAILURE");
        }

        public static void IsFailure(this Output output)
        {
            output.GetExitCode().IsFailure();
        }

        public static void IsSuccess(this ExitCode exitCode)
        {
            Assert.IsTrue(exitCode == ExitCode.SUCCESS , $"exitCode[{exitCode}] is not ExitCode.SUCCESS");
        }

        public static void IsSuccess(this Output output)
        {
            output.GetExitCode().IsSuccess();
        }

    #endregion
    }
}