#region

using System.Collections.Generic;
using System.Linq;
using DDDCore.Event.Usecase;
using DDDCore.Model;
using UnityEngine.Assertions;

#endregion

namespace DDDCore.Implement
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class , IAggregateRoot
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
            if (!ContainsId(id)) return false;
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

        public virtual void Save(T entity)
        {
            entities.Add(entity.GetId() , entity);
        }

    #endregion
    }
}