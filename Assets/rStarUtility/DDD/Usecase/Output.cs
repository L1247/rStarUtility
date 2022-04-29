#region

using rStarUtility.DDD.Usecase.CQRS;

#endregion

namespace rStarUtility.DDD.Usecase
{
    public interface Output
    {
    #region Public Methods

        ExitCode GetExitCode();
        string   GetMessage();
        Output   SetExitCode(ExitCode exitCode);
        Output   SetMessage(string    message);

    #endregion
    }
}