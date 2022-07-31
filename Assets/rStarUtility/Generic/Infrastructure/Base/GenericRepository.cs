#region

using System;
using System.Collections.Generic;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class GenericRepository<T> : IRepository<T>
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

        public T AddOrSet(string id , T add , T set)
        {
            var isInt   = typeof(T) == typeof(int);
            var isFloat = typeof(T) == typeof(float);
            if (isInt || isFloat)
            {
                if (ContainsId(id))
                {
                    var entity = FindById(id);
                    T   value;
                    if (isFloat)
                    {
                        var addValue    = Convert.ToSingle(add);
                        var entityValue = Convert.ToSingle(entity);
                        entityValue += addValue;
                        value       =  (T)(object)entityValue;
                    }
                    else
                    {
                        var addValue    = Convert.ToInt32(add);
                        var entityValue = Convert.ToInt32(entity);
                        entityValue += addValue;
                        value       =  (T)(object)entityValue;
                    }

                    Save(id , value);
                    return value;
                }

                Save(id , set);
                return set;
            }

            return default;
        }

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