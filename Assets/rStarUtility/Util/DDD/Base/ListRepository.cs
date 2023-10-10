#region

using System.Collections.Generic;
using System.Linq;
using rStarUtility.Util;
using rStarUtility.Util.Extensions.Csharp;

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

        public IEnumerable<T> Get_All(string id)
        {
            RequiredId(id);
            return Contains(id).IsFalse() ? Enumerable.Empty<T>() : entities[id];
        }

        public IEnumerable<T> Get_All()
        {
            return entities.Values.SelectMany(ts => ts);
        }

        public bool Remove(string id)
        {
            RequiredId(id);
            entities.Remove(id);
            return Contains(id).IsFalse();
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