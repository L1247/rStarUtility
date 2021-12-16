#region

using System.Collections.Generic;

#endregion

namespace DDDCore.Event.Usecase
{
    public interface IRepository<T>
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