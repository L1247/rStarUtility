#region

#endregion

#region

using System;

#endregion

namespace rStarUtility.Util.DDD.UseCase
{
    public class CqrsOutput<T> : Output where T : CqrsOutput<T>
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

        public CqrsOutput()
        {
            exitCode = ExitCode.SUCCESS;
            message  = string.Empty;
            id       = string.Empty;
        }

    #endregion

    #region Public Methods

        public static T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public T Fail()
        {
            SetExitCode(ExitCode.FAILURE);
            return Self();
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

        public T SetExitCode(ExitCode exitCode)
        {
            this.exitCode = exitCode;
            return Self();
        }

        public T SetId(string id)
        {
            this.id = id;
            return Self();
        }

        public T SetMessage(string message)
        {
            this.message = message;
            return Self();
        }

        public T Succeed()
        {
            SetExitCode(ExitCode.SUCCESS);
            return Self();
        }

    #endregion

    #region Private Methods

        private T Self()
        {
            return (T)this;
        }

    #endregion
    }
}