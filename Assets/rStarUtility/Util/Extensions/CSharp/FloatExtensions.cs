#region

using System.Globalization;

#endregion

namespace rStarUtility.Util.Extensions.CSharp
{
    public static class FloatExtensions
    {
    #region Public Methods

        public static string ToStringCurrentCulture(this float value)
        {
            return value.ToString(CultureInfo.CurrentCulture);
        }

        public static string ToStringInvariantCulture(this float value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

    #endregion
    }
}