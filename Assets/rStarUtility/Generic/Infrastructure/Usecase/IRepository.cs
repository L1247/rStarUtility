#region

using System.Collections.Generic;
using rStarUtility.Util;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    /// <summary>
    ///     未來可實作Peer儲存用
    ///     http://teddy-chen-tw.blogspot.com/2020/08/10repository.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
    #region Public Variables

        T this[string key] { get; set; }
        IEnumerable<string> Keys   { get; }
        IEnumerable<T>      Values { get; }

        int Count { get; }

    #endregion

    #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="newEntity"></param>
        /// <param name="overrideValueIfContain"></param>
        /// <param name="id"></param>
        /// <returns>is add succeed.</returns>
        bool Add(T newEntity , bool overrideValueIfContain = false);

        bool           Contains(string id);
        Optional<T>    Find(string     id);
        IEnumerable<T> GetAll();
        bool           Remove(string id);
        void           RemoveAll();

    #endregion
    }
}