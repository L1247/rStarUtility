#region

using System.Collections.Generic;
using rStarUtility.Util;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class ListRepository<T> where T : IEntity<string>
    {
    #region Public Variables

        public int Count => entities.Count;

    #endregion

    #region Protected Variables

        protected readonly Dictionary<string , List<T>> entities = new Dictionary<string , List<T>>();

    #endregion

    #region Public Methods

        public bool Add(T entity)
        {
            var id = entity.Id;
            RequiredId(id);
            if (Contains(id))
            {
                var list = entities[id];
                list.Add(entity);
                return true;
            }

            entities.Add(id , new List<T>() { entity });
            return Contains(id);
        }

        public bool Contains(string id)
        {
            RequiredId(id);
            return entities.ContainsKey(id);
        }

    #endregion

    #region Private Methods

        private void RequiredId(string id)
        {
            Contract.RequireString(id , "id");
        }

    #endregion
    }
}