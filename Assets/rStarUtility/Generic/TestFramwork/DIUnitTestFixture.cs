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

        protected T Bind_And_Resolve<T>()
        {
            Bind<T>();
            return Resolve<T>();
        }

        protected T Bind_And_Resolve_From_Substitute<T>() where T : class
        {
            Bind_From_Substitute<T>();
            return Resolve<T>();
        }

        protected void Bind_From_NewGameObject<T>() where T : class
        {
            Container.Bind<T>().FromNewComponentOnNewGameObject().AsSingle().IfNotBound();
        }

        protected T Bind_From_NewGameObject_And_Resolve<T>() where T : class
        {
            Container.Bind<T>().FromNewComponentOnNewGameObject().AsSingle().IfNotBound();
            return Resolve<T>();
        }

        protected void Bind_From_Substitute<T>() where T : class
        {
            Container.Bind<T>().FromSubstitute().IfNotBound();
        }

        protected void Bind_Instance<TContract>(TContract instance , string id = "")
        {
            if (id.IsNullOrEmpty() == false) Container.BindInstance(instance).WithId(id).IfNotBound();
            else Container.BindInstance(instance).IfNotBound();
        }

        protected void Bind_InterfacesAndSelfTo_<T>() where T : class
        {
            Container.BindInterfacesAndSelfTo<T>().AsSingle().IfNotBound();
        }

        protected void Bind_InterfacesAndSelfTo_From_NewGameObject<T>() where T : class
        {
            Container.BindInterfacesAndSelfTo<T>().FromNewComponentOnNewGameObject().AsSingle().IfNotBound();
        }

        protected void Bind_InterfacesTo<T>() where T : class
        {
            Container.BindInterfacesTo<T>().AsSingle().IfNotBound();
        }

        protected T Bind_Mock_And_Resolve<T>() where T : class
        {
            Bind_From_Substitute<T>();
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