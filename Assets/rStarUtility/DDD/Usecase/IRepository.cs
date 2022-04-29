#region

using System.Collections.Generic;
using rStarUtility.DDD.Model;

#endregion

namespace rStarUtility.DDD.Event.Usecase
{
    /// <summary>
    ///     未來可實作Peer儲存用
    ///     http://teddy-chen-tw.blogspot.com/2020/08/10repository.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IAggregateRoot
    {
    #region Public Methods

        bool    ContainsId(string id);
        bool    DeleteById(string id);
        T       FindById(string   id);
        List<T> GetAll();
        int     GetCount();
        void    Save(T entity);

    #endregion
    }
}