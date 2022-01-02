#region

using System.Collections.Generic;
using System.Linq;
using Actor.Entity;
using Actor.Scripts.Core.UseCase;
using UnityEngine;

#endregion

namespace Game.Actor.Scripts.Adapter.Gateway.Repository
{
    public class ActorRepository : IActorRepository
    {
    #region Private Variables

        private readonly Dictionary<string , IActor> entities = new Dictionary<string , IActor>();

    #endregion

    #region Public Methods

        public bool ContainsId(string id)
        {
            return entities.ContainsKey(id);
        }

        public void DeleteById(string id)
        {
            if (ContainsId(id)) entities.Remove(id);
        }

        public IActor FindById(string id)
        {
            if (ContainsId(id)) return entities[id];
            return null;
        }

        public List<IActor> GetAll()
        {
            return entities.Values.ToList();
        }

        public void Save(IActor entity)
        {
            var id = entity.GetId();
            if (ContainsId(id) == false) entities.Add(id , entity);
            else Debug.LogError($"id {id} exist.");
        }

    #endregion
    }
}