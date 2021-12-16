#region

using System;
using System.Reflection;
using UnityEditor;

#endregion

namespace rStar.Tools.Editor
{
    public static class ClearConsoleLog
    {
    #region Private Methods

        [MenuItem("Tools/ClearLog %&c")]
        static void ClearLog()
        {
            Assembly   assembly = Assembly.GetAssembly(typeof(SceneView));
            Type       type     = assembly.GetType("UnityEditor.LogEntries");
            MethodInfo method   = type.GetMethod("Clear");
            method.Invoke(new object() , null);
        }

    #endregion
    }
}