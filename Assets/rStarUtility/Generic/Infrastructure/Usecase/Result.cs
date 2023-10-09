namespace rStarUtility.Generic.Infrastructure
{
    public class Result : Output
    {
    #region Private Variables

        private ExitCode exitCode;
        private string   message;
        private string   id;

    #endregion

    #region Constructor

        public Result(ExitCode exitCode , string id , string message = "")
        {
            this.exitCode = exitCode;
            this.message  = message;
            this.id       = id;
        }

    #endregion

    #region Public Methods

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

    #endregion
    }
}