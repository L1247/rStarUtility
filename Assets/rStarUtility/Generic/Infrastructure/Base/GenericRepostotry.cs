#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class GenericRepository<T> where T : ICloneable
    {
    #region Public Variables

        public ReadOnlyCollection<T> Contents => contents.AsReadOnly();

    #endregion

    #region Private Variables

        [SerializeField]
        private List<T> contents = new List<T>();

    #endregion

    #region Public Methods

        public T FindContent(Predicate<T> predicate)
        {
            return contents.Find(predicate);
        }

        public void SetContents(List<T> list)
        {
            contents = list;
        }

        public void SetContents(GenericRepository<T> genericRepository)
        {
            contents = genericRepository.contents.Select(content => (T)content.Clone()).ToList();
        }

    #endregion
    }
}