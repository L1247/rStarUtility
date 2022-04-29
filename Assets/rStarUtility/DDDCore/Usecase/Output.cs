#region

using rStarUtility.DDDCore.Usecase.CQRS;

#endregion

namespace rStarUtility.DDDCore.Usecase
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