#region

#endregion

#region

using System;

#endregion

namespace rStarUtility.Util.DDD.UseCase
{
    public class CqrsOutput : Output
    {
    #region Public Variables

        public bool IsFailure => GetExitCode() == ExitCode.FAILURE;
        public bool IsSuccess => GetExitCode() == ExitCode.SUCCESS;

    #endregion

    #region Protected Variables

        protected ExitCode exitCode;
        protected string   id;
        protected string   message;

    #endregion

    #region Constructor

        protected CqrsOutput()
        {
            exitCode = ExitCode.SUCCESS;
            message  = string.Empty;
            id       = string.Empty;
        }

    #endregion

    #region Public Methods

        public static CqrsOutput Create()
        {
            return new CqrsOutput();
        }

        public CqrsOutput Fail()
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

        public CqrsOutput SetExitCode(ExitCode exitCode)
        {
            this.exitCode = exitCode;
            return Self();
        }

        public CqrsOutput SetId(string id)
        {
            this.id = id;
            return Self();
        }

        public CqrsOutput SetMessage(string message)
        {
            this.message = message;
            return Self();
        }

        public CqrsOutput Succeed()
        {
            SetExitCode(ExitCode.SUCCESS);
            return Self();
        }

    #endregion

    #region Private Methods

        private CqrsOutput Self()
        {
            return this;
        }

    #endregion
    }

    public class CqrsOutput<T> : CqrsOutput where T : CqrsOutput<T>
    {
    #region Constructor

        protected CqrsOutput() { }

    #endregion

    #region Public Methods

        public new static T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public new T Fail()
        {
            SetExitCode(ExitCode.FAILURE);
            return Self();
        }

        public new T SetExitCode(ExitCode exitCode)
        {
            this.exitCode = exitCode;
            return Self();
        }

        public new T SetId(string id)
        {
            this.id = id;
            return Self();
        }

        public new T SetMessage(string message)
        {
            this.message = message;
            return Self();
        }

        public new T Succeed()
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