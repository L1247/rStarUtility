#region

using System;

#endregion

namespace ThirtyParty.Utilities
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