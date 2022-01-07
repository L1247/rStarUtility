#region

using System.Collections.Generic;
using System.Linq;
using Actor.ExposedActor.Interfaces;
using Actor.Scripts.Core.UseCase;
using UnityEngine;

#endregion

namespace Game.Actor.Scripts.Adapter.Gateway.Repository
{
    public class ActorRepository : IActorRepository
    {
    #region Private Variables

        private readonly Dictionary<string , IActorReadModel> entities = new Dictionary<string , IActorReadModel>();

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

        public IActorReadModel FindById(string id)
        {
            if (ContainsId(id)) return entities[id];
            return null;
        }

        public List<IActorReadModel> GetAll()
        {
            return entities.Values.ToList();
        }

        public void Save(IActorReadModel entity)
        {
            var id = entity.GetId();
            if (ContainsId(id) == false) entities.Add(id , entity);
            else Debug.LogError($"id {id} exist.");
        }

    #endregion
    }
}