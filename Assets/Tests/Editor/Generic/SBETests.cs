using NUnit.Framework;
using rStarUtility.Generic.TestFrameWork;
using UnityEngine;

namespace rStarUtility.Generic.Tests.Tests.Editor.Generic
{
    public class SBETests : SimpleTest
    {
        [Test]
        public void _01_GWT_Practice()
        {
            var scenario = Scenario();
            scenario.Given("given two number " , () =>
                                                 {
                                                     Debug.Log($"given");
                                                 })
                    .When("Sum two number" , () =>
                                             {
                                                 Debug.Log($"when");
                                             })
                    .Then("get result of sum" , () => { Debug.Log($"then"); })
                    .Execute();
        }

        class Calculator { }
    }
}