#region

using NUnit.Framework;
using Zenject;

#endregion

namespace rStarUtility.Generic.TestFrameWork
{
    public class DIUnitTestFixture : SimpleTest
    {
    #region Protected Variables

        protected DiContainer Container { get; private set; }

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public virtual void Setup()
        {
            Container = new DiContainer(StaticContext.Container);
        }

        [TearDown]
        public virtual void Teardown()
        {
            StaticContext.Clear();
        }

    #endregion

    #region Protected Methods

        protected void Bind<T>()
        {
            Container.Bind<T>().AsSingle().IfNotBound();
        }

        protected T BindAndResolve<T>()
        {
            Bind<T>();
            return Resolve<T>();
        }

        protected void BindFromSubstitute<T>() where T : class
        {
            Container.Bind<T>().FromSubstitute().IfNotBound();
        }

        protected T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

    #endregion
    }
}