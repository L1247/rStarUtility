#region

using System.Collections.Generic;
using rStarUtility.Util;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : IEntity<string>
    {
    #region Public Variables

        public T this[string id]
        {
            get => Find(id).Value;
            set
            {
                RequiredId(id);
                entities[id] = value;
            }
        }

        public IEnumerable<string> Ids => entities.Keys;

        public IEnumerable<T> Entities => GetAll();

        public int Count => entities.Count;

    #endregion

    #region Protected Variables

        protected readonly Dictionary<string , T> entities = new Dictionary<string , T>();

    #endregion

    #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="newEntity"></param>
        /// <param name="overrideValueIfContain"></param>
        /// <returns>entity add is succeed or not</returns>
        public bool Add(T newEntity , bool overrideValueIfContain = false)
        {
            var id = newEntity.Id;
            RequiredId(id);
            var containsId = Contains(id);
            if (overrideValueIfContain == false && containsId) return false;
            if (containsId) entities[id] = newEntity;
            else entities.Add(id , newEntity);
            return Contains(id);
        }

        public virtual bool Contains(string id)
        {
            RequiredId(id);
            return entities.ContainsKey(id);
        }

        public Optional<T> Find(string id)
        {
            var contains         = Contains(id);
            var entity           = default(T);
            if (contains) entity = entities[id];
            return new Optional<T>(contains , entity);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.Values;
        }

        public bool Remove(string id)
        {
            if (Contains(id) == false) return false;
            entities.Remove(id);
            var success = Contains(id) == false;
            return success;
        }

        public void RemoveAll()
        {
            entities.Clear();
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