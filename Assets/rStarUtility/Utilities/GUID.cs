#region

using System;

#endregion

namespace rStarUtility.Utilities
{
    public class GUID
    {
    #region Public Variables

        public static string NewGUID()
        {
            return Guid.NewGuid().ToString();
        }

    #endregion
    }
}