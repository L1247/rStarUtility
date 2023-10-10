#region

using System.Collections.Generic;
using rStarUtility.Util;
using Zenject;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class ControllerForListRepository<E , R> where R : ListRepository<E> where E : IEntity<string>
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

        protected IEnumerable<E> GetEntities(string id)
        {
            RequireId(id);
            return repository.Get_All(id);
        }

        protected void RequireContains(string id)
        {
            Contract.Require(Contains(id) , $"entity is {id} no exist.");
        }

        protected void RequireId(string id)
        {
            Contract.RequireString(id);
        }

    #endregion
    }
}