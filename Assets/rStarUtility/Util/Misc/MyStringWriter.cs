#region

using System.IO;

#endregion

namespace rStarUtility.Util
{
    public class MyStringWriter : StringWriter
    {
    #region Public Methods

        public string GetString()
        {
            var result = ToString().Trim();
            return result;
        }

        public string GetStringAndClear()
        {
            var result = GetString();
            Clear();
            return result;
        }

    #endregion

    #region Private Methods

        private void Clear()
        {
            GetStringBuilder().Clear();
        }

    #endregion
    }
}