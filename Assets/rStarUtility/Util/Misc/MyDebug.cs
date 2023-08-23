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
        public static bool    logErrorEnabled;
        public static LogType logType;

    #endregion

    #region Private Variables

        private static TextWriter logTextWriter;
        private static TextWriter logErrorTextWriter;

    #endregion

    #region Public Methods

        public static void Log(string message)
        {
            logTextWriter?.WriteLine(message);
            logType = LogType.Log;
            if (logEnabled) Debug.Log(message);
        }

        public static void LogError(string message)
        {
            logErrorTextWriter?.WriteLine(message);
            logType = LogType.Error;
            if (logErrorEnabled) Debug.LogError(message);
        }

        public static void SetOut(TextWriter log , MyStringWriter logError)
        {
            logTextWriter      = log;
            logErrorTextWriter = logError;
        }

    #endregion
    }
}