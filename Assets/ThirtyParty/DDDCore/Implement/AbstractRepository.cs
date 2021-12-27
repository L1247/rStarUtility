#region

using System.Collections.Generic;
using DDDCore.Event.Usecase;
using DDDCore.Model;

#endregion

namespace DDDCore.Implement
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : IAggregateRoot
    {
    #region Private Variables

        private readonly Dictionary<string , T> idEntities = new Dictionary<string , T>();

        private readonly List<T> entities = new List<T>();

    #endregion

    #region Public Methods

        public virtual bool ContainsId(string id)
        {
            return idEntities.ContainsKey(id);
        }

        public virtual void DeleteAll()
        {
            idEntities.Clear();
            entities.Clear();
        }

        public virtual void DeleteById(string id)
        {
            idEntities.Remove(id);
            entities.Remove(FindById(id));
        }

        public virtual T FindById(string id)
        {
            if (ContainsId(id)) return idEntities[id];
            return default;
        }

        public virtual List<T> GetAll()
        {
            return entities;
        }

        public virtual void Save(T entity)
        {
            idEntities.Add(entity.GetId() , entity);
            entities.Add(entity);
        }

    #endregion
    }
}