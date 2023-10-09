#region

using rStarUtility.Util;
using Zenject;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class Controller<E , R> where R : Repository<E> where E : IEntity<string>
    {
    #region Protected Variables

        [Inject]
        protected R repository;

    #endregion

    #region Protected Methods

        protected bool Contains(string id)
        {
            RequireId(id);
            var contains = repository.Contains(id);
            return contains;
        }

        protected E GetEntity(string id)
        {
            var optional = repository.Find(id);
            Contract.Require(optional.Present , $"can't find entity by id: {id}");
            return optional.Value;
        }

        protected static void RequireId(string id)
        {
            Contract.RequireString(id);
        }

    #endregion
    }
}