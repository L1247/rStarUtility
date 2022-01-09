#region

using System.Collections.Generic;
using DDDCore.Event.Usecase;
using Stat.Entity;

#endregion

namespace Stat.UseCase
{
    public interface IStatRepository : IRepository<IStat>
    {
    #region Public Methods

        List<IStat> GetStatsByActorId(string actorId);

    #endregion
    }
}