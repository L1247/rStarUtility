#region

using System.Linq;
using System.Text.RegularExpressions;
using rStarUtility.Util.Extensions.Csharp;

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
                var xStarWithNumber = IsStarWithNumber(x);
                var yStarWithNumber = IsStarWithNumber(y);
                if (xStarWithNumber && yStarWithNumber) return GetNumOrder(x , y , order);

                return order;
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
            // Debug.Log($"{x} ,{xNumeric} , {y} , {yNumeric} , {order}");
            return order;
        }

        private static bool IsStarWithNumber(string str)
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