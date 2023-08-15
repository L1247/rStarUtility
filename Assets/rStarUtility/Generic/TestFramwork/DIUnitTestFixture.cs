#region

using NUnit.Framework;
using rStarUtility.Util.Extensions.Csharp;
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

        protected void Bind_ComponentOnNewGameObject<T>() where T : class
        {
            Container.Bind<T>().FromNewComponentOnNewGameObject().AsSingle().IfNotBound();
        }

        protected T Bind_ComponentOnNewGameObject_And_Resolve<T>() where T : class
        {
            Container.Bind<T>().FromNewComponentOnNewGameObject().AsSingle().IfNotBound();
            return Resolve<T>();
        }

        protected T BindAndResolve<T>()
        {
            Bind<T>();
            return Resolve<T>();
        }

        protected T BindAndResolveFromSubstitute<T>() where T : class
        {
            BindFromSubstitute<T>();
            return Resolve<T>();
        }

        protected void BindFromSubstitute<T>() where T : class
        {
            Container.Bind<T>().FromSubstitute().IfNotBound();
        }

        protected void BindInstance<TContract>(TContract instance , string id = "")
        {
            if (id.IsNullOrEmpty() == false) Container.BindInstance(instance).WithId(id);
            else Container.BindInstance(instance);
        }

        protected T BindMockAndResolve<T>() where T : class
        {
            BindFromSubstitute<T>();
            return Resolve<T>();
        }

        protected bool HasBinding<T>()
        {
            return Container.HasBinding<T>();
        }

        protected T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

    #endregion
    }
}