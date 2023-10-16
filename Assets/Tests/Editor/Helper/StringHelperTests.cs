#region

using System.Collections.Generic;
using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Util.Helper;
using UnityEngine;

#endregion

public class StringHelperTests
{
#region Private Variables

    private class MyCompare : IComparer<string>
    {
    #region Public Methods

        public int Compare(string x , string y)
        {
            return StringHelper.CompareString(x , y);
        }

    #endregion
    }

#endregion

#region Test Methods

    [Test]
    public void _01_CompareString_1()
    {
        var strings = new List<string>();
        strings.Add("Test");
        strings.Add("ATK+20");
        strings.Add("ATK+100");
        strings.Add("ATK+50");
        strings.Add("HPRE+40");
        strings.Add("03_Sniper");
        strings.Add("01_Soldier");
        strings.Add("20");
        strings.Add("10");
        strings.Add("-5");
        strings.Sort(new MyCompare());
        // strings.ForEach(s => Debug.Log($"{s}"));
        var i = 0;
        strings[i++].ShouldBe("-5");
        strings[i++].ShouldBe("10");
        strings[i++].ShouldBe("20");
        strings[i++].ShouldBe("Test");
        strings[i++].ShouldBe("ATK+20");
        strings[i++].ShouldBe("ATK+50");
        strings[i++].ShouldBe("HPRE+40");
        strings[i++].ShouldBe("ATK+100");
        strings[i++].ShouldBe("01_Soldier");
        strings[i++].ShouldBe("03_Sniper");
    }

    [Test]
    public void _02_CompareString_2()
    {
        var strings = new List<string> { "02_肉蟲","14_快蟲" , "01_幼肉蟲" , "木頭人" , "04_盾肉蟲" };
        strings.Sort(new MyCompare());
        strings.ForEach(s => Debug.Log($"{s}"));
        var i = 0;
        strings[i++].ShouldBe("木頭人");
        strings[i++].ShouldBe("01_幼肉蟲");
        strings[i++].ShouldBe("02_肉蟲");
        strings[i++].ShouldBe("04_盾肉蟲");
        strings[i++].ShouldBe("14_快蟲");
    }

#endregion
}