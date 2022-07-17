#region

using System;
using System.Collections.Generic;
using System.Linq;
using rStarUtility.DDD.Event.Usecase;
using rStarUtility.Util;
using UnityEngine.Assertions;

#endregion

namespace rStarUtility.DDD.Implement.Abstract
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
    #region Private Variables

        private readonly Dictionary<string , T> entities = new Dictionary<string , T>();

    #endregion

    #region Public Methods

        public virtual bool ContainsId(string id)
        {
            Assert.IsNotNull(id , "id is null.");
            Assert.IsFalse(string.IsNullOrEmpty(id) , "id is NullOrEmpty");
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
            return ContainsId(id) ? entities[id] : null;
        }

        public virtual List<T> GetAll()
        {
            return entities.Values.ToList();
        }

        public int GetCount()
        {
            return entities.Count;
        }

        public (bool exist , T aggregateRoot) GetEntity(string id)
        {
            var containsId    = ContainsId(id);
            var aggregateRoot = FindById(id);
            return (containsId , aggregateRoot);
        }

        public virtual void Save(string id , T entity)
        {
            Contract.RequireString(id , "id");
            var containsId = ContainsId(id);
            if (containsId) throw new ArgumentException($"the same key has already been added. key: {id}");
            entities.Add(id , entity);
        }

    #endregion
    }
}