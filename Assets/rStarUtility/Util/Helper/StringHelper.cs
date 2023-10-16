#region

using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace rStarUtility.Util.Helper
{
    public static class StringHelper
    {
    #region Public Methods

        public static int CompareString(string x , string y)
        {
            var order = 0;
            if (x.Length > y.Length)
            {
                order = 1;
                return GetNumOrder(x , y , order);
            }

            if (x.Length == y.Length) return GetNumOrder(x , y , order);

            return -1;
        }

    #endregion

    #region Private Methods

        private static int GetNumOrder(string x , string y , int order)
        {
            var xDigit       = x.Any(char.IsDigit);
            var yDigit       = y.Any(char.IsDigit);
            var anyAllString = xDigit == false || yDigit == false;
            if (anyAllString) return order;
            var xNumeric = int.Parse(Regex.Match(x , @"\d+").Value);
            var yNumeric = int.Parse(Regex.Match(y , @"\d+").Value);
            if (xNumeric > yNumeric) order      = 1;
            else if (xNumeric < yNumeric) order = -1;
            return order;
        }

    #endregion
    }
}