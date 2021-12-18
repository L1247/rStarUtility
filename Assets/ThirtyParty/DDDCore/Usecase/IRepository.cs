#region

using System.Collections.Generic;
using DDDCore.Model;

#endregion

namespace DDDCore.Event.Usecase
{
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