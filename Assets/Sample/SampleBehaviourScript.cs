#region

using rStarUtility.Util.Component;
using UnityEngine;

#endregion

public class SampleBehaviourScript : MonoBehaviour
{
#region Private Variables

    [SerializeField]
    private GameObject collider;

#endregion

#region Unity events

    // Start is called before the first frame update
    private void Start()
    {
        var show2DCollider = gameObject.AddComponent<Show_2D_Collider>();
    #if UNITY_EDITOR
        show2DCollider.SetType(_2D_Collider_Type.Box);
        show2DCollider.SetColorInCollision(false);
    #endif
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Instantiate(collider , Random.insideUnitSphere , Quaternion.identity , transform);
    }

#endregion
}