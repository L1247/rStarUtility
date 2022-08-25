#region

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

#endregion

namespace rStarUtility.Util.Editor
{
    public class CustomEditorUtility
    {
    #region Public Variables

    #if UNITY_EDITOR
        public static IEnumerable<string> GetAllStateNameByAnimator(AnimatorController animator)
        {
            var allStateName = new List<string>();
            var states       = animator.layers[0].stateMachine.states;
            foreach (var state in states)
            {
                var stateName = state.state.ToString()
                                     .Replace(" (UnityEngine.AnimatorState)" , "");
                allStateName.Add(stateName);
            }

            return allStateName;
        }
    #endif

        public static IEnumerable<string> GetAllStateNameByAnimatorPath(string actorAnimatorPath)
        {
            IEnumerable<string> allStateNameByAnimatorPath = null;
        #if UNITY_EDITOR
            var animator = LoadAssetAtPath<AnimatorController>(actorAnimatorPath);
            allStateNameByAnimatorPath = GetAllStateNameByAnimator(animator);
        #endif
            return allStateNameByAnimatorPath;
        }

        public static List<T> GetScriptableObjects<T>() where T : ScriptableObject
        {
            var ts   = new List<T>();
            var type = typeof(T);
        #if UNITY_EDITOR
            var guids2 = AssetDatabase.FindAssets($"t:{type}");
            foreach (var guid2 in guids2)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid2);
                ts.Add((T)AssetDatabase.LoadAssetAtPath(assetPath , type));
            }
        #endif
            return ts;
        }

        public static T GetScriptableObject<T>() where T : ScriptableObject
        {
            return GetScriptableObjects<T>().First();
        }

        public static T LoadAssetAtPath<T>(string path) where T : Object
        {
            var t = default(T);
        #if UNITY_EDITOR
            t = AssetDatabase.LoadAssetAtPath<T>(path);
        #endif
            return t;
        }

        public static void SaveAssets()
        {
            InternalSaveAsset();
        }

        public static void SelectObject(Object instance)
        {
        #if UNITY_EDITOR
            InternalSetSelectionActiveObject(instance);
        #endif
        }

        public static void SetDirty(Object data)
        {
        #if UNITY_EDITOR
            EditorUtility.SetDirty(data);
        #endif
        }

    #endregion

    #region Private Methods

        private static void InternalSaveAsset()
        {
        #if UNITY_EDITOR
            AssetDatabase.SaveAssets();
        #endif
        }

        private static void InternalSetSelectionActiveObject(Object asset)
        {
        #if UNITY_EDITOR
            Selection.activeObject = asset;
        #endif
        }

    #endregion
    }
}