#region

using System;

#endregion

namespace rStartUtility.Utilities
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