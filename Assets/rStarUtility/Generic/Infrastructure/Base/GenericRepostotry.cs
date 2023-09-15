#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

#endregion

namespace rStarUtility.Generic.Infrastructure
{
    public class GenericRepository<T> where T : class
    {
    #region Public Variables

        public ReadOnlyCollection<T> Contents => contents.AsReadOnly();

    #endregion

    #region Private Variables

        [SerializeField]
        private List<T> contents = new List<T>();

    #endregion

    #region Public Methods

        public void Add(T obj)
        {
            contents.Add(obj);
        }

        public (bool found , List<T> foundContents) FindAll(Predicate<T> predicate)
        {
            var foundContents = contents.FindAll(predicate);
            return (foundContents.Count > 0 , foundContents);
        }

        public (bool contains , T obj) FindContent(Predicate<T> predicate)
        {
            var content  = contents.Find(predicate);
            var contains = content != null;
            return (contains , content);
        }

        public void Remove(T obj)
        {
            contents.Remove(obj);
        }

        public void SetContents(List<T> list)
        {
            contents = list;
        }

    #endregion
    }
}