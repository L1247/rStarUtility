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

        public bool Enabled => enabled;
        public T    Value   => value;

    #endregion

    #region Private Variables

        [SerializeField]
        private bool enabled;

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
            enabled = false;
            value   = default;
        }

        public Optional(T value)
        {
            enabled    = false;
            this.value = value;
        }

    #endregion

    #region Public Methods

        public void Set(bool enabled , T value = default)
        {
            this.enabled = enabled;
            this.value   = value;
        }

    #endregion
    }
}