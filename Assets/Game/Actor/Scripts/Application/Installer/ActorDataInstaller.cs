#region

using Game.Actor.Scripts.Application.Presenter;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Actor.Scripts.Application.Installer
{
    public class ActorDataInstaller : ScriptableObjectInstaller
    {
    #region Private Variables

        [SerializeField]
        private ActorSamplePresenter.Settings actorSamplePresenter;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInstance(actorSamplePresenter);
        }

    #endregion
    }
}