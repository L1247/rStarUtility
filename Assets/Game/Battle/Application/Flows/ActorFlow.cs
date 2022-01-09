#region

using Actor.Adapter.Interfaces;
using UnityEngine;

#endregion

namespace Game.Battle.Application.Flows
{
    public class ActorFlow : IActorFlow
    {
    #region Public Methods

        public void WhenActorCreated()
        {
            Debug.Log("WhenActorCreated");
        }

    #endregion
    }
}