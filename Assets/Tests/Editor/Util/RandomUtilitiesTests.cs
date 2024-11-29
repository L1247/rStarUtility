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
        var roundTable1 = new RoundTable<TestRoundTable>(100 , new TestRoundTable() { id = 1 });
        var roundTable2 = new RoundTable<TestRoundTable>(200 , new TestRoundTable() { id = 2 });
        var roundTables = new List<RoundTable<TestRoundTable>> { roundTable1 , roundTable2 };

        var roundTableValue = RandomUtilities.GetRoundTableValue(roundTables , 100);
        roundTableValue.id.ShouldBe(1);

        roundTableValue = RandomUtilities.GetRoundTableValue(roundTables , 101);
        roundTableValue.id.ShouldBe(2);

        roundTables.CountShouldBe(2);
    }

    [Test(Description = "取得圓桌值物件_唯一")]
    public void _02_GetUniqueRoundTableValue()
    {
        var testRoundTable1    = new TestRoundTable() { id = 1 };
        var testRoundTable2    = new TestRoundTable() { id = 2 };
        var testRoundTable3    = new TestRoundTable() { id = 3 };
        var roundTable1        = new RoundTable<TestRoundTable>(100 , testRoundTable1);
        var roundTable2        = new RoundTable<TestRoundTable>(200 , testRoundTable2);
        var roundTable3        = new RoundTable<TestRoundTable>(300 , testRoundTable3);
        var roundTables        = new List<RoundTable<TestRoundTable>>() { roundTable1 , roundTable2 , roundTable3 };
        var compareRoundTables = new List<TestRoundTable>() { testRoundTable1 , testRoundTable2 , testRoundTable3 };

        var randomRoundTableValues = RandomUtilities.GetUniqueRoundTableValue(roundTables , 2);
        for (var index = randomRoundTableValues.Count - 1 ; index >= 0 ; index--)
        {
            var randomRoundTableValue = randomRoundTableValues[index];
            compareRoundTables.Contains(randomRoundTableValue).ShouldTrue();
            compareRoundTables.Remove(randomRoundTableValue);
        }

        compareRoundTables[0].id.ShouldBe(roundTables[0].Value.id);

        roundTables.CountShouldBe(1);
    }

#endregion
}