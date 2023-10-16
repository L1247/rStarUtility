#region

using System.Collections.Generic;
using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Util.Helper;

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
    public void CompareString()
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

#endregion
}