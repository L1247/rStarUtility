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

        [MenuItem("Tools/RunEditModeTest _F1")]
        private static void RunEditorModeTestAll()
        {
            var testRunnerApi  = ScriptableObject.CreateInstance<TestRunnerApi>();
            var filterEditMode = new Filter();
            filterEditMode.testMode = TestMode.EditMode;
            Filter[] apiFilter = { filterEditMode };
            testRunnerApi.Execute(new ExecutionSettings(apiFilter));
        }

        // [MenuItem("Tools/RunPlayModeTest _F3")]
        private static void RunPlayModeTestAll()
        {
            var testRunnerApi  = ScriptableObject.CreateInstance<TestRunnerApi>();
            var filterEditMode = new Filter();
            filterEditMode.testMode = TestMode.PlayMode;
            Filter[] apiFilter = { filterEditMode };
            testRunnerApi.Execute(new ExecutionSettings(apiFilter));
        }

    #endregion
    }
}