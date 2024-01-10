#region

using System;
using UnityEngine;

#endregion

namespace rStarUtility.Util
{
    [Serializable]
    public class Optional<T>
    {
    #region Public Variables

        public bool Present => present;
        public T    Value   => value;

    #endregion

    #region Private Variables

        [SerializeField]
        private bool present;

        [SerializeField]
        private T value;

    #endregion

    #region Constructor

        public Optional(bool enabled , T value = default)
        {
            Set(enabled , value);
        }

        public Optional()
        {
            present = false;
            value   = default;
        }

        public Optional(T value)
        {
            present    = true;
            this.value = value;
        }

    #endregion

    #region Public Methods

        public void Set(bool enabled , T value = default)
        {
            present    = enabled;
            this.value = value;
        }

        public void SetValue(T value)
        {
            present    = true;
            this.value = value;
        }

    #endregion
    }
}