#region

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

#endregion

namespace rStarUtility.Util.Managers
{
    public class Registry<T>
    {
    #region Public Variables

        public IEnumerable<T> All => objs;

        public int Count => All.Count();

    #endregion

    #region Protected Variables

        protected readonly List<T> objs = new List<T>();

    #endregion

    #region Constructor

        public Registry()
        {
            Debug.Log("Registry");
        }

        [Inject]
        public Registry(IEnumerable<T> ts)
        {
            objs.AddRange(ts);
        }

    #endregion

    #region Public Methods

        public void Add(T obj)
        {
            objs.Add(obj);
        }

        public void Remove(T obj)
        {
            objs.Remove(obj);
        }

    #endregion
    }
}