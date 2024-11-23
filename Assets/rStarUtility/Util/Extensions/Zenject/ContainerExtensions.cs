#region

using rStarUtility.Util.Extensions.CSharp;
using Zenject;

#endregion

namespace rStarUtility.Util.Extensions.Zenject
{
    public static class ContainerExtensions
    {
    #region Public Methods

        public static T Bind_And_Resolve<T>(this DiContainer container)
        {
            Bind_IfNotBound<T>(container);
            return container.Resolve<T>();
        }

        public static void Bind_From_NewGameObject<T>(this DiContainer container) where T : class
        {
            container.Bind<T>().FromNewComponentOnNewGameObject().AsSingle().IfNotBound();
        }

        public static T Bind_From_NewGameObject_And_Resolve<T>(this DiContainer container) where T : class
        {
            container.Bind<T>().FromNewComponentOnNewGameObject().AsSingle().IfNotBound();
            return container.Resolve<T>();
        }

        public static void Bind_IfNotBound<T>(this DiContainer container)
        {
            if (container.HasBinding<T>()) return;
            container.Bind<T>().AsSingle().IfNotBound();
        }

        public static void Bind_Instance<T>(this DiContainer container , T instance , string id = "")
        {
            if (id.IsNullOrEmpty().IsFalse()) container.BindInstance(instance).WithId(id).IfNotBound();
            else container.BindInstance(instance).IfNotBound();
        }

        public static void Bind_InterfacesAndSelfTo<T>(this DiContainer container) where T : class
        {
            container.BindInterfacesAndSelfTo<T>().AsSingle().IfNotBound();
        }

        public static void Bind_InterfacesAndSelfTo_From_NewGameObject<T>(this DiContainer container) where T : class
        {
            container.BindInterfacesAndSelfTo<T>().FromNewComponentOnNewGameObject().AsSingle().IfNotBound();
        }

        public static void Bind_InterfacesTo<T>(this DiContainer container) where T : class
        {
            container.BindInterfacesTo<T>().AsSingle().IfNotBound();
        }

    #endregion
    }
}