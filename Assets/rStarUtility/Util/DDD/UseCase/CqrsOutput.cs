#region

#endregion

namespace rStarUtility.Util.DDD.UseCase
{
    public class CqrsOutput : Output
    {
    #region Public Variables

        public bool IsFailure => GetExitCode() == ExitCode.FAILURE;
        public bool IsSuccess => GetExitCode() == ExitCode.SUCCESS;

    #endregion

    #region Private Variables

        private ExitCode exitCode;
        private string   message;
        private string   id;

    #endregion

    #region Constructor

        protected CqrsOutput(string id , ExitCode exitCode , string message = "")
        {
            Contract.Require(exitCode != ExitCode.NONE , "can't set to ExitCode.NONE");
            this.exitCode = exitCode;
            this.message  = message;
            this.id       = id;
        }

    #endregion

    #region Public Methods

        public static CqrsOutput CreateInstance(string id , ExitCode exitCode , string message = "")
        {
            return new CqrsOutput(id , exitCode , message);
        }

        public static CqrsOutput Failure(string id , string message = "")
        {
            return new CqrsOutput(id , ExitCode.FAILURE , message);
        }

        public ExitCode GetExitCode()
        {
            return exitCode;
        }

        public string GetId()
        {
            return id;
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

        public Output SetId(string id)
        {
            this.id = id;
            return this;
        }

        public virtual Output SetMessage(string message)
        {
            this.message = message;
            return this;
        }

        public static CqrsOutput Success(string id , string message = "")
        {
            return new CqrsOutput(id , ExitCode.SUCCESS , message);
        }

    #endregion
    }
}