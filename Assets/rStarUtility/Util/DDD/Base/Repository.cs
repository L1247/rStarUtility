#region

using System.Collections.Generic;
using rStarUtility.Util;
using rStarUtility.Util.DDD.UseCase;
using rStarUtility.Util.Extensions.CSharp;
using UnityEngine;
using Zenject;

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
        protected virtual  bool                   overrideValue => false;

    #endregion

    #region Constructor

        public Repository() { }

        [Inject]
        public Repository(List<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.Id.HasValue().IsFalse())
                {
                    Debug.LogError($"發生錯誤，資料有問題；從[{GetType().Name}]，資料為[{entity.Id}]");
                    continue;
                }

                Add(entity);
            }
        }

    #endregion

    #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="newEntity"></param>
        /// <returns>entity add is succeed or not</returns>
        public bool Add(T newEntity)
        {
            var id = newEntity.Id;
            RequiredId(id);
            var containsId = Contains(id);
            if (overrideValue.IsFalse() && containsId) return false;
            if (containsId) entities[id] = newEntity;
            else entities.Add(id , newEntity);
            return Contains(id);
        }

        public bool Contains(string id)
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

        public T Get(string id)
        {
            var optional = Find(id);
            if (optional.Present.IsFalse()) throw new KeyNotFoundException($"出錯了，{GetType().Name} - 找不到Id[{id}]的物件.");
            return optional.Value;
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