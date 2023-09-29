#region

using NSubstitute;
using NUnit.Framework;
using rStarUtility.Generic.Infrastructure;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;
using Zenject;

#endregion

public class BuildTests : DIUnitTestFixture
{
#region Test Methods

    [Test]
    public void Create_Obj_With_Builder()
    {
        BuildObj testObj = Builder.NewInstance().WithTest(1);
        testObj.Test.ShouldBe(1);
        var testObj2 = Builder.NewInstance().WithTest(2).Build();
        testObj2.Test.ShouldBe(2);
    }

    [Test]
    public void Create_Obj_With_Builder_And_DI()
    {
        var buildParameter = Bind_Mock_And_Resolve<BuildParameter>();
        buildParameter.GetTest().Returns(999);
        var      builder = Instantiate<Builder>();
        BuildObj obj     = builder;
        obj.Test.ShouldBe(999);
    }

#endregion
}

internal class BuildObj
{
#region Public Variables

    public int Test { get; }

#endregion

#region Constructor

    public BuildObj(int test)
    {
        Test = test;
    }

#endregion
}

public interface BuildParameter
{
#region Public Methods

    int GetTest();

#endregion
}

internal class Builder : AbstractBuilder<BuildObj , Builder>
{
#region Private Variables

    private          int            test;
    private readonly BuildParameter buildParameter;

#endregion

#region Constructor

    [Inject]
    public Builder(BuildParameter buildParameter)
    {
        this.buildParameter = buildParameter;
    }

    public Builder() { }

#endregion

#region Public Methods

    public override BuildObj Build()
    {
        test = buildParameter?.GetTest() ?? test;
        return new BuildObj(test);
    }

    public Builder WithTest(int test)
    {
        this.test = test;
        return this;
    }

#endregion
}