#region

using System;
using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;

#endregion

public class UlidTests
{
#region Test Methods

    [Test]
    public void Random()
    {
        var uuid1 = Ulid.NewUlid().ToString();
        var uuid2 = Ulid.NewUlid().ToString();
        uuid1.ShouldNotBe(uuid2);
    }

#endregion
}