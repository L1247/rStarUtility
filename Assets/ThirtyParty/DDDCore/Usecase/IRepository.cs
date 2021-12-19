#region

using System.Collections.Generic;
using DDDCore.Model;

#endregion

namespace DDDCore.Event.Usecase
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
        void    DeleteById(string id);
        T       FindById(string   id);
        List<T> GetAll();
        void    Save(T entity);

    #endregion
    }
}