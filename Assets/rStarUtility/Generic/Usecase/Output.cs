#region

using rStarUtility.Generic.Usecase.CQRS;

#endregion

namespace rStarUtility.Generic.Usecase
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