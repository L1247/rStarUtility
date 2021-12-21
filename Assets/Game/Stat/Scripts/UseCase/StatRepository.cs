#region

using System.Collections.Generic;
using DDDCore.Implement;
using Stat.Entity;

#endregion

namespace Stat.UseCase
{
    public class StatRepository : AbstractRepository<IStat> , IStatRepository
    {
    #region Public Methods

        public List<IStat> GetStatsByActorId(string actorId)
        {
            return GetAll().FindAll(stat => stat.ActorId.Equals(actorId));
        }

    #endregion
    }
}