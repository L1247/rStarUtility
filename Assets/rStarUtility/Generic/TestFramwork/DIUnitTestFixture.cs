#region

using NUnit.Framework;
using rStarUtility.Util.Extensions.Zenject;
using UnityEngine;
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

    #region Public Methods

        public static int GetCountOfObjectInScene<T>() where T : Object
        {
            return GetAllObjectsInScene<T>().Length;
        }

    #endregion

    #region Protected Methods

        protected void Bind<T>()
        {
            if (HasBinding<T>()) return;

            Container.Bind_IfNotBound<T>();
        }

        protected T Bind_And_Resolve<T>()
        {
            return HasBinding<T>() ? Resolve<T>() : Container.Bind_And_Resolve<T>();
        }

        protected T Bind_And_Resolve_From_Substitute<T>() where T : class
        {
            Bind_From_Substitute<T>();
            return Resolve<T>();
        }

        protected void Bind_From_NewGameObject<T>() where T : class
        {
            Container.Bind_From_NewGameObject<T>();
        }

        protected T Bind_From_NewGameObject_And_Resolve<T>() where T : class
        {
            return Container.Bind_From_NewGameObject_And_Resolve<T>();
        }

        protected void Bind_From_Substitute<T>() where T : class
        {
            Container.Bind<T>().FromSubstitute().IfNotBound();
        }

        protected void Bind_Instance<TContract>(TContract instance , string id = "")
        {
            Container.Bind_Instance(instance , id);
        }

        protected void Bind_InterfacesAndSelfTo<T>() where T : class
        {
            if (HasBinding<T>()) return;
            Container.Bind_InterfacesAndSelfTo<T>();
        }

        protected void Bind_InterfacesAndSelfTo_From_NewGameObject<T>() where T : class
        {
            Container.Bind_InterfacesAndSelfTo_From_NewGameObject<T>();
        }

        protected void Bind_InterfacesTo<T>() where T : class
        {
            if (HasBinding<T>()) return;
            Container.Bind_InterfacesTo<T>();
        }

        protected T Bind_Mock_And_Resolve<T>() where T : class
        {
            Bind_From_Substitute<T>();
            return Resolve<T>();
        }

        protected static T[] GetAllObjectsInScene<T>() where T : Object
        {
            return Object.FindObjectsOfType<T>();
        }

        protected static T GetObjectInScene<T>() where T : Object
        {
            return Object.FindObjectOfType<T>();
        }

        protected bool HasBinding<T>()
        {
            return Container.HasBinding<T>();
        }

        protected T Instantiate<T>() where T : class
        {
            return Container.Instantiate<T>();
        }

        protected T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

    #endregion
    }
}