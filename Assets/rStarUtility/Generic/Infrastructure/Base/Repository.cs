#region

using System;
using System.Collections.Generic;
using rStarUtility.Util;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
    #region Public Variables

        public T this[string key]
        {
            get => entities[key];
            set => entities[key] = value;
        }

        public IEnumerable<string> Keys => entities.Keys;

        public IEnumerable<T> Values => GetAll();

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
            var id = newEntity.GetId();
            RequiredId(id);
            var containsId = Contains(id);
            if (overrideValueIfContain == false && containsId) return false;
            if (containsId) entities[id] = newEntity;
            else entities.Add(id , newEntity);
            return Contains(id);
        }

        public virtual bool Contains(string id)
        {
            var isNullOrEmpty = string.IsNullOrEmpty(id);
            if (isNullOrEmpty) throw new ArgumentException("id is NullOrEmpty.");
            return entities.ContainsKey(id);
        }

        public Optional<T> Find(string id)
        {
            var contains         = Contains(id);
            T   entity           = null;
            if (contains) entity = entities[id];
            return new Optional<T>(contains , entity);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.Values;
        }

        public virtual bool Remove(string id)
        {
            if (Contains(id) == false) return false;
            entities.Remove(id);
            var success = Contains(id) == false;
            return success;
        }

        public virtual void RemoveAll()
        {
            entities.Clear();
        }

    #endregion

    #region Private Methods

        private void RequiredId(string id)
        {
            Contract.RequireString(id , $"id: {id}");
        }

    #endregion
    }
}