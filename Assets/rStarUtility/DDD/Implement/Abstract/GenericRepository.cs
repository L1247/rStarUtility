#region

using System;
using System.Collections.Generic;
using rStarUtility.DDD.Event.Usecase;

#endregion

namespace rStarUtility.DDD.Implement.Abstract
{
    public class GenericRepository<T> : IRepository<T>
    {
    #region Public Variables

        public int Count => entities.Count;

    #endregion

    #region Private Variables

        private readonly Dictionary<string , T> entities = new Dictionary<string , T>();

    #endregion

    #region Public Methods

        public virtual bool ContainsId(string id)
        {
            var isNullOrEmpty = string.IsNullOrEmpty(id);
            if (isNullOrEmpty) throw new ArgumentException("id is NullOrEmpty.");
            return entities.ContainsKey(id);
        }

        public virtual void DeleteAll()
        {
            entities.Clear();
        }

        public virtual bool DeleteById(string id)
        {
            if (ContainsId(id) == false) return false;
            entities.Remove(id);
            var success = ContainsId(id) == false;
            return success;
        }

        public virtual T FindById(string id)
        {
            return ContainsId(id) ? entities[id] : default;
        }

        public IEnumerable<T> GetAll()
        {
            return entities.Values;
        }

        public (bool exist , T entity) GetEntity(string id)
        {
            var containsId    = ContainsId(id);
            var aggregateRoot = FindById(id);
            return (containsId , aggregateRoot);
        }

        public virtual bool Save(string id , T entity)
        {
            var containsId = ContainsId(id);
            // if (containsId) throw new ArgumentException($"the same key has already been added. key: {id}");
            if (containsId) entities[id] = entity;
            else entities.Add(id , entity);

            return ContainsId(id);
        }

    #endregion
    }
}