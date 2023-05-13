#region

using System.IO;
using UnityEngine;

#endregion

namespace rStarUtility.Util
{
    public class MyDebug
    {
    #region Public Variables

        public static bool    logEnabled;
        public static LogType logType;

    #endregion

    #region Private Variables

        private static TextWriter textWriter;

    #endregion

    #region Public Methods

        public static void Log(string message)
        {
            textWriter?.WriteLine(message);
            logType = LogType.Log;
            if (logEnabled) Debug.Log(message);
        }

        public static void LogError(string message)
        {
            textWriter?.WriteLine(message);
            logType = LogType.Error;
            if (logEnabled) Debug.LogError(message);
        }

        public static void SetOut(TextWriter textWriter)
        {
            MyDebug.textWriter = textWriter;
        }

    #endregion
    }
}