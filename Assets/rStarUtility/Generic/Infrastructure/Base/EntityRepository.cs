#region

using UnityEngine.Assertions;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class EntityRepository<T> : GenericRepository<T> where T : Entity<string>
    {
    #region Public Methods

        public T Find(string id)
        {
            var (found , data) = FindContent(entity => entity.GetId() == id);
            Assert.IsTrue(found , $"{GetType()} can't find entity{typeof(T)} by id: {id}");
            return data;
        }

        public bool Remove(string id)
        {
            var count  = Count;
            var entity = Find(id);
            Remove(entity);
            var removeSuccessful = count == Count - 1;
            Assert.IsTrue(removeSuccessful , $"{GetType()} - remove entity fail by id: {id}");
            return true;
        }

    #endregion
    }
}