#region

using UnityEngine;

#endregion

namespace Game.Actor.Scripts.Data
{
    [CreateAssetMenu(fileName = "ActorData" , menuName = "ActorData" , order = 0)]
    public class ActorData : ScriptableObject
    {
    #region Public Variables

        public GameObject actorPrefab;

    #endregion
    }
}