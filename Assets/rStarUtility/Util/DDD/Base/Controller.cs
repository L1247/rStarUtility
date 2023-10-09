#region

using rStarUtility.Util;
using Zenject;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class Controller<R , E> where R : Repository<E> where E : IEntity<string>
    {
    #region Protected Variables

        [Inject]
        protected R repository;

    #endregion

    #region Private Methods

        private bool Contains(string id)
        {
            RequireId(id);
            var contains = repository.Contains(id);
            return contains;
        }

        private E GetEntity(string id)
        {
            var optional = repository.Find(id);
            Contract.Require(optional.Present , $"can't find entity by id: {id}");
            return optional.Value;
        }

        private static void RequireId(string id)
        {
            Contract.RequireString(id);
        }

    #endregion
    }
}