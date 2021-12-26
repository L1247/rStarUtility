#region

using Actor.Adapter;
using UnityEngine;
using Zenject;

#endregion

namespace Actor.Application
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