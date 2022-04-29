#region

using System;
using NUnit.Framework;

#endregion

namespace rStartUtility.DDD.DDDTestFrameWork
{
    public sealed class AssertEx
    {
    #region Public Variables

        public static void NoExceptionThrown<T>(Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T)
            {
                Assert.Fail("Expected no {0} to be thrown" , typeof(T).Name);
            }
        }

    #endregion
    }
}