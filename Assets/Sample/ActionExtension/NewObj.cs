#region

using UnityEngine;

#endregion

namespace Sample.ActionExtension
{
    public class NewObj : MonoBehaviour
    {
    #region Public Methods

        public void Function()
        {
            Debug.Log("NewObj");
            Destroy(this);
        }

    #endregion
    }
}