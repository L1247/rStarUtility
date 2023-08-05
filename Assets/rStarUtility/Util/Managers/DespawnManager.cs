#region

using System;
using System.Linq;

#endregion

namespace rStarUtility.Util.Managers
{
    public class DespawnManager<Registry , T> where Registry : Registry<T> where T : IDisposable
    {
    #region Private Variables

        private readonly Registry registry;

    #endregion

    #region Constructor

        protected DespawnManager(Registry registry)
        {
            this.registry = registry;
        }

    #endregion

    #region Public Methods

        public void DeSpawnAll()
        {
            foreach (var obj in registry.All.ToList()) obj.Dispose();
        }

    #endregion
    }
}