namespace rStarUtility.Util
{
    public static class StringExtensions
    {
    #region Public Methods

        public static string ReplaceStringForForwardSlash(this string str)
        {
            var filePathWithCorrectSlash = str.Replace("\\" , StringUtility.ForwardSlash);
            return filePathWithCorrectSlash;
        }

    #endregion
    }
}