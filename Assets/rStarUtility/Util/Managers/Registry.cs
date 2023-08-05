#region

using System.Collections.Generic;

#endregion

namespace rStarUtility.Util.Managers
{
    public class Registry<T>
    {
    #region Public Variables

        public IEnumerable<T> All => objs;

    #endregion

    #region Private Variables

        private readonly List<T> objs = new List<T>();

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