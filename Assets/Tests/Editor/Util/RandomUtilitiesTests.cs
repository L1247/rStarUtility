#region

using System.Collections.Generic;
using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;
using rStarUtility.Util;

#endregion

[TestFixture]
public class RandomUtilitiesTests : DIUnitTestFixture
{
#region Private Variables

    private class TestRoundTable
    {
    #region Public Variables

        public int id;

    #endregion
    }

#endregion

#region Test Methods

    [Test(Description = "取得圓桌值物件")]
    public void _01_GetRoundTableValue()
    {
        var testRoundTable1 = new TestRoundTable() { id = 1 };
        var roundTable1     = new RoundTable<TestRoundTable>(100 , testRoundTable1);
        var testRoundTable2 = new TestRoundTable() { id = 2 };
        var roundTable2     = new RoundTable<TestRoundTable>(200 , testRoundTable2);
        var roundTables     = new List<RoundTable<TestRoundTable>>();
        roundTables.Add(roundTable1);
        roundTables.Add(roundTable2);

        var roundTableValue = RandomUtilities.GetRoundTableValue(roundTables , 100);
        roundTableValue.id.ShouldBe(1);
        roundTableValue.ShouldBe(testRoundTable1);

        roundTableValue = RandomUtilities.GetRoundTableValue(roundTables , 101);
        roundTableValue.id.ShouldBe(2);
        roundTableValue.ShouldBe(testRoundTable2);

        roundTables.CountShouldBe(2);
    }

#endregion
}