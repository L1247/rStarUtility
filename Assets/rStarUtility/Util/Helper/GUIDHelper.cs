#region

using System;

#endregion

namespace rStarUtility.Util.Helper
{
    public static class GUIDHelper
    {
    #region Public Methods

        public static string GetRandomGuid()
        {
            return Ulid.NewUlid().ToString();
        }

    #endregion
    }
}