#region

using rStarUtility.DDD.Usecase.CQRS;

#endregion

namespace rStarUtility.DDD.Usecase
{
    public class Result : Output
    {
    #region Private Variables

        private ExitCode exitCode;
        private string   message;

    #endregion

    #region Public Methods

        public ExitCode GetExitCode()
        {
            return exitCode;
        }

        public string GetMessage()
        {
            return message;
        }

        public Output SetExitCode(ExitCode exitCode)
        {
            this.exitCode = exitCode;
            return this;
        }

        public virtual Output SetMessage(string message)
        {
            this.message = message;
            return this;
        }

    #endregion
    }
}