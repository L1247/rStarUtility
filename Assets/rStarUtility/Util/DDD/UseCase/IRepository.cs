#region

using System.Collections.Generic;

#endregion

namespace rStarUtility.Util.DDD.UseCase
{
    /// <summary>
    ///     未來可實作Peer儲存用
    ///     http://teddy-chen-tw.blogspot.com/2020/08/10repository.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
    #region Public Variables

        T this[string id] { get; set; }
        IEnumerable<string> Ids      { get; }
        IEnumerable<T>      Entities { get; }
        int                 Count    { get; }

    #endregion

    #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="newEntity"></param>
        /// <param name="id"></param>
        /// <returns>is add succeed.</returns>
        bool Add(T newEntity);

        bool        Contains(string id);
        Optional<T> Find(string     id);

        /// <summary>
        ///     找不到的話應錯誤
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="KeyNotFoundException">Entity exist by default , else throw KeyNotFoundException.</exception>
        T Get(string id);

        IEnumerable<T> GetAll();
        bool           Remove(string id);
        void           RemoveAll();

    #endregion
    }
}