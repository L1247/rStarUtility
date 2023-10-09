namespace rStarUtility.Generic.Infrastructure
{
    public interface Output
    {
    #region Public Methods

        ExitCode GetExitCode();

        string GetId();
        string GetMessage();
        Output SetExitCode(ExitCode exitCode);
        Output SetId(string         id);
        Output SetMessage(string    message);

    #endregion
    }
}