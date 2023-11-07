#region

using rStarUtility.Util.Extensions.Csharp;
using UnityEngine;

#endregion

namespace Sample.ActionExtension
{
    public class ActionMono : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private NewObj newObj;

    #endregion

    #region Unity events

        private void Update()
        {
            newObj.Opt(_ => _.Function());
        }

    #endregion
    }
}