#region

using System.Globalization;

#endregion

namespace rStarUtility.Util.Extensions.Csharp
{
    public static class DoubleExtensions
    {
    #region Public Methods

        public static string ToStringCurrentCulture(this double value)
        {
            return value.ToString(CultureInfo.CurrentCulture);
        }

        public static string ToStringInvariantCulture(this double value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

    #endregion
    }
}