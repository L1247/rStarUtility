﻿#region

using UnityEditor;
using UnityEngine;

#endregion

namespace rStarUtility.Util.Component
{
    public enum _2D_Collider_Type
    {
        Box , Circle , Edge ,
        Polygon
    }

    /// <summary>
    ///     Show_s 2D colliders in scene and game(enable gizmo) view , without selecting them. High Customizable Component.
    /// </summary>
    [ExecuteInEditMode]
    public class Show_2D_Collider : MonoBehaviour
    {
    #region Private Variables

        private bool in_collision;

        [Space(15)]
        [SerializeField]
        private bool show = true;

        [SerializeField]
        private bool volume = true;

        [SerializeField]
        private _2D_Collider_Type Collider_Type = _2D_Collider_Type.Box;

        [SerializeField]
        private Color static_color = new Color(0 , 1 , 0 , 1f);

        [SerializeField]
        private float thickness = 1;

        [Space(20)]
        [SerializeField]
        private bool color_in_collision;

        [SerializeField]
        private Color collision_color = new Color(1 , 0 , 0 , 1f);

        [SerializeField]
        [HideInInspector]
        private Transform trans;

    #endregion

    #region Public Methods

        public void SetThickness(int value)
        {
            thickness = Mathf.Clamp(value , 0.1f , int.MaxValue);
        }

    #endregion

    #if UNITY_EDITOR

        private void OnEnable()
        {
            if (trans == null) trans = transform;
        }

        // triggers
        private void OnTriggerEnter2D()
        {
            in_collision = true;
        }

        private void OnTriggerStay2D()
        {
            in_collision = true;
        }

        private void OnTriggerExit2D()
        {
            in_collision = false;
        }

        // collisions
        private void OnCollisionEnter2D()
        {
            in_collision = true;
        }

        private void OnCollisionStay2D()
        {
            in_collision = true;
        }

        private void OnCollisionExit2D()
        {
            in_collision = false;
        }

        [MenuItem("Tools/2DColliderPRO/Show 2D Collider" , false , 0)]
        private static void Add_Show_Collider()
        {
            if (Selection.gameObjects.Length != 0)
            {
                if (Selection.gameObjects.Length == 1)
                {
                    if (Selection.activeGameObject.GetComponent<Collider2D>() != null)
                    {
                        var show_coll = Selection.activeGameObject.AddComponent<Show_2D_Collider>();
                        if (show_coll.GetComponent<BoxCollider2D>() != null) show_coll.Collider_Type = _2D_Collider_Type.Box;
                        if (show_coll.GetComponent<CircleCollider2D>() != null) show_coll.Collider_Type = _2D_Collider_Type.Circle;
                        if (show_coll.GetComponent<EdgeCollider2D>() != null) show_coll.Collider_Type = _2D_Collider_Type.Edge;
                        if (show_coll.GetComponent<PolygonCollider2D>() != null) show_coll.Collider_Type = _2D_Collider_Type.Polygon;
                    }
                    else
                    {
                        Debug.Log("Selected gameobject does not have any 2D Collider");
                    }
                }
                else
                {
                    var k = 0;
                    foreach (var item in Selection.gameObjects)
                        if (item.GetComponent<Collider2D>() != null)
                        {
                            var show_coll = item.AddComponent<Show_2D_Collider>();
                            //Collider2D col2D = item.GetComponent<Collider2D> ();

                            if (item.GetComponent<BoxCollider2D>() != null) show_coll.Collider_Type     = _2D_Collider_Type.Box;
                            if (item.GetComponent<CircleCollider2D>() != null) show_coll.Collider_Type  = _2D_Collider_Type.Circle;
                            if (item.GetComponent<EdgeCollider2D>() != null) show_coll.Collider_Type    = _2D_Collider_Type.Edge;
                            if (item.GetComponent<PolygonCollider2D>() != null) show_coll.Collider_Type = _2D_Collider_Type.Polygon;
                        }
                        else
                        {
                            k++;
                        }

                    if (k > 0) Debug.Log(k + " of your selected gameobjects does not have any 2D Collider");
                }
            }
            else
            {
                Debug.Log("Select any gameobject(s) that have 2D Collider");
            }
        }

        [DrawGizmo(GizmoType.NotInSelectionHierarchy)]
        private void OnDrawGizmos()
        {
            if (!show || !enabled) return;

            // color region
            var c                                     = static_color;
            if (in_collision && color_in_collision) c = collision_color;

            var a = volume ? c.a / 4 : c.a;

            switch (Collider_Type)
            {
                // Draw box
                case _2D_Collider_Type.Box :
                    var b2D = GetComponent<BoxCollider2D>();
                    if (b2D == null) return;
                    var vb1 = new Vector3[4];
                    var vb2 = new Vector3[5];
                    vb2[0] = vb2[4] = vb1[0] = trans.TransformPoint(
                            new Vector3(b2D.offset.x - b2D.size.x / 2 , b2D.offset.y - b2D.size.y / 2 ,
                                        trans.position.z));
                    vb2[1] = vb1[1] = trans.TransformPoint(
                            new Vector3(b2D.offset.x + b2D.size.x / 2 , b2D.offset.y - b2D.size.y / 2 ,
                                        trans.position.z));
                    vb2[2] = vb1[2] = trans.TransformPoint(
                            new Vector3(b2D.offset.x + b2D.size.x / 2 , b2D.offset.y + b2D.size.y / 2 ,
                                        trans.position.z));
                    vb2[3] = vb1[3] = trans.TransformPoint(
                            new Vector3(b2D.offset.x - b2D.size.x / 2 , b2D.offset.y + b2D.size.y / 2 ,
                                        trans.position.z));
                    Handles.color = new Color(c.r , c.g , c.b , a);
                    // Handles.DrawPolyLine(vb2);
                    if (volume)
                    {
                        Handles.DrawAAConvexPolygon(vb1);
                    }
                    else
                    {
                        Handles.DrawLine(vb2[0] , vb2[1] , thickness);
                        Handles.DrawLine(vb2[1] , vb2[2] , thickness);
                        Handles.DrawLine(vb2[2] , vb2[3] , thickness);
                        Handles.DrawLine(vb2[3] , vb2[0] , thickness);
                    }

                    break;

                // Draw Circle
                case _2D_Collider_Type.Circle :
                    var c2D = GetComponent<CircleCollider2D>();
                    if (c2D == null) return;
                    var c_radius = c2D.radius * transform.lossyScale.x;
                    var c_offset = transform.TransformPoint(c2D.offset);
                    Handles.color = new Color(c.r , c.g , c.b , a);
                    if (volume) Handles.DrawSolidDisc(c_offset , Vector3.forward , c_radius);
                    else Handles.DrawWireDisc(c_offset , Vector3.forward , c_radius , thickness);
                    break;

                // Draw Edge
                case _2D_Collider_Type.Edge :
                    var e2D = GetComponent<EdgeCollider2D>();
                    if (e2D == null) return;
                    var ve                                      = new Vector3[e2D.points.Length];
                    for (var i = 0 ; i < ve.Length ; i++) ve[i] = trans.TransformPoint(e2D.points[i]);
                    Handles.color = new Color(c.r , c.g , c.b , a);
                    Handles.DrawPolyLine(ve);
                    break;

                // Draw Polygon
                case _2D_Collider_Type.Polygon :
                    var p2D = GetComponent<PolygonCollider2D>();
                    if (p2D == null) return;
                    var vp1                                       = new Vector3[p2D.points.Length];
                    var vp2                                       = new Vector3[p2D.points.Length + 1];
                    for (var i = 0 ; i < vp1.Length ; i++) vp2[i] = vp1[i] = trans.TransformPoint(p2D.points[i]);
                    vp2[vp1.Length] = vp2[0];
                    Handles.color   = new Color(c.r , c.g , c.b , a);
                    if (volume) Handles.DrawAAConvexPolygon(vp1);
                    else Handles.DrawPolyLine(vp2);
                    break;
            }
        }

        public void SetShow(bool usingShow)
        {
            show = usingShow;
        }

        public void SetVolume(bool usingVolume)
        {
            volume = usingVolume;
        }

        public void SetType(_2D_Collider_Type type)
        {
            Collider_Type = type;
        }

        public void SetStaticColor(Color color)
        {
            static_color = color;
        }

        public void SetColorInCollision(bool color_in_collision)
        {
            this.color_in_collision = color_in_collision;
        }

        public void SetCollisionColor(Color color)
        {
            collision_color = color;
        }
    #endif
    }
}