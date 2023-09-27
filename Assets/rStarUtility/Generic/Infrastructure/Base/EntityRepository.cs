#region

using UnityEngine.Assertions;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class EntityRepository<T> : GenericRepository<T> where T : Entity<string>
    {
    #region Public Methods

        public T FindById(string id)
        {
            var (found , data) = FindContent(entity => entity.GetId() == id);
            Assert.IsTrue(found , $"{GetType()} can't find entity{typeof(T)} by id: {id}");
            return data;
        }

    #endregion
    }
}