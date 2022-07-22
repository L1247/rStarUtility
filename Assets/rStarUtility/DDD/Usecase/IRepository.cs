#region

using System.Collections.Generic;

#endregion

namespace rStarUtility.DDD.Event.Usecase
{
    /// <summary>
    ///     未來可實作Peer儲存用
    ///     http://teddy-chen-tw.blogspot.com/2020/08/10repository.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
    #region Public Variables

        int Count { get; }

    #endregion

    #region Public Methods

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