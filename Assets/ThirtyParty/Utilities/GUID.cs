using System;

namespace ThirtyParty.Utilities
{
    public class GUID
    {
        public static string NewGUID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}