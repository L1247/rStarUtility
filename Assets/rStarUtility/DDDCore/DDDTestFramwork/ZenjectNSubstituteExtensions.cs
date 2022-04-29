#region

#if UNITY_EDITOR && !UNITY_WEBPLAYER
using NSubstitute;
#endif

#endregion

namespace Zenject
{
    public static class ZenjectNSubstituteExtensions
    {
    #region Public Variables

        public static ConditionCopyNonLazyBinder FromSubstitute<TContract>(this FactoryFromBinder<TContract> binder)
        where TContract : class
        {
            //            return binder.FromInstance(Mock.Of<TContract>());
            return binder.FromInstance(Substitute.For<TContract>());
        }

        public static ScopeConcreteIdArgConditionCopyNonLazyBinder FromSubstitute<TContract>(this FromBinderGeneric<TContract> binder)
        where TContract : class
        {
        #if UNITY_EDITOR && !UNITY_WEBPLAYER
            //            return binder.FromInstance(Mock.Of<TContract>());
            return binder.FromInstance(Substitute.For<TContract>());
        #else
            Assert.That(false, "The use of 'ToMock' in web builds is not supported");
            return null;
        #endif
        }

    #endregion
    }
}