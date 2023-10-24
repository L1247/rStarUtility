#region

using System.Linq;
using System.Text.RegularExpressions;
using rStarUtility.Util.Extensions.Csharp;

#endregion

namespace rStarUtility.Util.Helper
{
    public static class CompareHelper
    {
    #region Public Methods

        public static int CompareString(string x , string y)
        {
            var order     = 0;
            var xIsInt    = int.TryParse(x , out var xInt);
            var yIsInt    = int.TryParse(y , out var yInt);
            var yIsNotInt = yIsInt.IsFalse();
            if (xIsInt && yIsNotInt) return -1;

            var xStarWithNumber = IsStartWithNumber(x);
            var yStarWithNumber = IsStartWithNumber(y);
            if (xStarWithNumber && yStarWithNumber) return GetNumOrder(x , y , order);
            if (x.Length > y.Length)
            {
                order = 1;

                return order;
            }

            if (x.Length == y.Length) return GetNumOrder(x , y , order);

            if (xIsInt && yIsInt)
            {
                var compareInt = CompareInt(xInt , yInt);
                // Debug.Log($"{x} , {y} , {compareInt}");
                return compareInt;
            }

            return -1;
        }

    #endregion

    #region Private Methods

        private static int CompareInt(int xInt , int yInt)
        {
            if (xInt > yInt) return 1;
            if (xInt < yInt) return -1;
            return 0;
        }

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
            // Debug.Log($"{x} ,{xNumeric} , {y} , {yNumeric} , {order}");
            return order;
        }

        private static bool IsStartWithNumber(string str)
        {
            var isDigit = str.Any(char.IsDigit);
            if (isDigit.IsFalse()) return false;
            if (str.Length == 0) return false;
            var firstChar = str[..1];
            var tryParse  = int.TryParse(firstChar , out _);
            return tryParse;
        }

    #endregion
    }
}