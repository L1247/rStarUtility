#region

using rStarUtility.DDD.Model;

#endregion

namespace rStarUtility.DDD.Implement.Abstract
{
    // public abstract class AbstractRepository<T> : IRepository<T> where T : class , IEntity<string>
    public abstract class AbstractRepository<T> : GenericRepository<T> where T : class , IEntity<string>
    {
    #region Public Methods

        public void Save(T t)
        {
            var id = t.GetId();
            Save(id , t);
        }

    #endregion
    }
}