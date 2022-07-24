#region

using rStarUtility.Generic.Model;

#endregion

namespace rStarUtility.Generic.Implement.Abstract
{
    // public abstract class AbstractRepository<T> : IRepository<T> where T : class , IEntity<string>
    public abstract class AbstractRepository<T> : GenericRepository<T> where T : class , IEntity<string>
    {
    #region Public Methods

        public bool Save(T t)
        {
            var id = t.GetId();
            return Save(id , t);
        }

    #endregion
    }
}