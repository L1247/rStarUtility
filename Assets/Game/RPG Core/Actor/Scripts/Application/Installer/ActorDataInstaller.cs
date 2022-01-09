#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Actor.Scripts.Application.Installer
{
    public class ActorDataInstaller : ScriptableObjectInstaller
    {
    #region Private Variables

        [SerializeField]
        private ActorInstaller.Settings actorInstaller;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInstance(actorInstaller);
        }

    #endregion
    }
}