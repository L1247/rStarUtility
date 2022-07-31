#region

using System.Collections.Generic;

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
        /// <param name="id"></param>
        /// <param name="add"></param>
        /// <returns>is add succeed.</returns>
        bool Add(string id , T add);

        T                       AddOrSet(string   id , T add , T set);
        bool                    ContainsId(string id);
        void                    DeleteAll();
        bool                    DeleteById(string id);
        T                       FindById(string   id);
        IEnumerable<T>          GetAll();
        (bool exist , T entity) GetEntity(string id);
        bool                    Save(string      id , T entity);

    #endregion
    }
}