#region

#endregion

namespace rStarUtility.Util.DDD.UseCase
{
    public interface Output
    {
    #region Public Variables

        bool IsFailure { get; }
        bool IsSuccess { get; }

    #endregion

    #region Public Methods

        ExitCode GetExitCode();
        string   GetId();
        string   GetMessage();
        Output   SetExitCode(ExitCode exitCode);
        Output   SetId(string         id);
        Output   SetMessage(string    message);

    #endregion
    }
}