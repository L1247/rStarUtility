#region

using rStarUtility.Util;
using Zenject;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class Controller<E , R> where R : IRepository<E> where E : IEntity<string>
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

        protected void EnsureContains(string id , bool contain = true)
        {
            Contract.Ensure(Contains(id) == contain , $"entity is {id} no exist.");
        }

        protected Optional<E> FindEntity(string id)
        {
            RequireId(id);
            return repository.Find(id);
        }

        protected E GetEntity(string id)
        {
            RequireId(id);
            var optional = FindEntity(id);
            Contract.Require(optional.Present , $"can't find entity by id: {id}");
            return optional.Value;
        }

        protected void RequireContains(string id , bool contain = true)
        {
            Contract.Require(Contains(id) == contain , $"entity is {id} no exist.");
        }

        protected void RequireId(string id)
        {
            Contract.RequireString(id);
        }

    #endregion
    }
}