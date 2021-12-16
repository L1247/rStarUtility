#region

using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

#endregion

namespace rStar.Tools.Editor
{
    public class TestRunnerEditor
    {
    #region Private Methods

        [MenuItem("Tools/RunUnitTestAll _F1")]
        static void RunUnitTestAll()
        {
            var testRunnerApi  = ScriptableObject.CreateInstance<TestRunnerApi>();
            var filterEditMode = new Filter();
            filterEditMode.testMode = TestMode.EditMode;
            var filterPlayMode = new Filter();
            filterPlayMode.testMode = TestMode.PlayMode;
            Filter[] apiFilter = { filterEditMode , filterPlayMode };
            testRunnerApi.Execute(new ExecutionSettings(apiFilter));
        }

    #endregion
    }
}