#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace rStarUtility.Util.Managers
{
    public class Registry<T>
    {
    #region Public Variables

        public IEnumerable<T> All => objs;

        public int Count => All.Count();

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