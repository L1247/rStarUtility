#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using Object = UnityEngine.Object;

#endregion

namespace rStarUtility.Util.Editor
{
    public class CustomEditorUtility
    {
    #region Public Variables

        public const           string AssetsPathWithSlash = UnityPathUtility.AssetsPathWithSlash;
        public const           string ForwardSlash        = StringUtility.ForwardSlash;
        public static readonly string EmptyString         = string.Empty;

    #endregion

    #region Public Methods

        public static T CreateAsset<T>(string path , string soName) where T : ScriptableObject
        {
            var asset = ScriptableObject.CreateInstance<T>();
            InternalCreateAsset(path , soName , asset);
            InternalSaveAssets();
            InternalFocusProjectWindow();
            InternalSetSelectionActiveObject(asset);
            return asset;
        }

        public static void CreateAsset<T>(T asset , string path) where T : Object
        {
        #if UNITY_EDITOR
            AssetDatabase.CreateAsset(asset , path);
        #endif
        }

        public static void CreateFileTypeIfNotExist<T>(string clipName , string folderPath)
        {
        #if UNITY_EDITOR
            //檢查是否已存在同名檔案
            //string ClipName = actorType + "_" + actorName + "_" + actorAct;
            var ClipPath     = folderPath + ForwardSlash + clipName + ".anim";
            var type         = typeof(T);
            var getExistClip = AssetDatabase.LoadAssetAtPath(ClipPath , type);
            if (getExistClip == null)
            {
                //產生動畫檔
                // AnimationClip clip     = new AnimationClip();
                var instance = Activator.CreateInstance<T>();
                var obj      = instance as Object;

                AssetDatabase.CreateAsset(obj , ClipPath);
            }
            else
            {
                Debug.Log("檔案 " + folderPath + ForwardSlash + clipName + ".anim 已經存在");
            }
        #endif
        }

        public static void DeleteAsset(string path)
        {
            InternalDeleteAsset(path);
            InternalSaveAssets();
        }

        public static void DeleteAsset(Object obj)
        {
            var instanceID = obj.GetInstanceID();
            var assetPath  = GetAssetPath(instanceID);
            DeleteAsset(assetPath);
        }

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

        public static IEnumerable<AnimationClip> GetAnimationClipByPath(string path , string containKeyWord)
        {
            var assets = AssetDatabase.FindAssets("t:AnimationClip " , new[] { path });
            var animationClipByPath = assets
                                     .Select(guid => LoadAssetAtPath<AnimationClip>(AssetDatabase.GUIDToAssetPath(guid)))
                                     .Where(clip => clip.name.Contains(containKeyWord));
            return animationClipByPath;
        }

        public static string GetAssetPath(int instanceID)
        {
            var path = EmptyString;
        #if UNITY_EDITOR
            path = AssetDatabase.GetAssetPath(instanceID);
        #endif
            return path;
        }

        public static List<Object> GetAssets(string assetName)
        {
            var ts = new List<Object>();
        #if UNITY_EDITOR
            var results = AssetDatabase.FindAssets(assetName);
            foreach (var guid2 in results)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid2);
                ts.Add(AssetDatabase.LoadAssetAtPath<Object>(assetPath));
            }
        #endif
            return ts;
        }

        public static T GetObjectAtPath<T>(string path , SearchOption searchOption = SearchOption.TopDirectoryOnly)
        where T : Object
        {
            var objectsAtPath = GetObjectsAtPath<T>(path , searchOption);
            return objectsAtPath.Count == 0 ? null : objectsAtPath[0];
        }

        public static List<T> GetObjectsAtPath<T>(string path , SearchOption searchOption = SearchOption.TopDirectoryOnly)
        where T : Object
        {
            var pathWithoutAssets = UnityPathUtility.GetPathWithoutAssetsPath(path);
            var dataPath          = UnityPathUtility.GetProjectPath();
            var fileEntries       = Directory.GetFiles(dataPath + ForwardSlash + pathWithoutAssets , "*.*" , searchOption);
            var files = fileEntries.Select(fileName =>
                                           {
                                               var filePath = AssetsPathWithSlash
                                                            + fileName.Replace(dataPath + ForwardSlash , EmptyString);
                                               var filePathWithForwardSlash = filePath.ReplaceStringForForwardSlash();
                                               var asset = AssetDatabase.LoadAssetAtPath(filePathWithForwardSlash , typeof(T));
                                               return asset;
                                           })
                                   .OfType<T>()
                                   .ToList();
            return files;
        }

        public static T GetScriptableObject<T>() where T : ScriptableObject
        {
            return GetScriptableObjects<T>().First();
        }

        public static List<T> GetScriptableObjectAndHaveType<T>(string interfaceName) where T : ScriptableObject
        {
            return GetScriptableObjects<T>()
                  .Where(t => t.GetType().GetInterface(interfaceName) != null)
                  .ToList();
        }

        public static List<ScriptableObject> GetScriptableObjects(Type type , string path)
        {
            var ts = new List<ScriptableObject>();
        #if UNITY_EDITOR
            var guids2       = AssetDatabase.FindAssets($"t:{type}");
            var pathNotEmpty = string.IsNullOrEmpty(path) == false;
            foreach (var guid2 in guids2)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid2);
                // path check
                if (pathNotEmpty)
                {
                    var notContainsPath = assetPath.Contains(path) == false;
                    if (notContainsPath) continue;
                }

                ts.Add(AssetDatabase.LoadAssetAtPath(assetPath , type) as ScriptableObject);
            }
        #endif
            return ts;
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

        public static List<Sprite> GetSpritesFromAnimator(AnimatorOverrideController anim)
        {
            var sprites = new List<Sprite>();
        #if UNITY_EDITOR
            foreach (var ac in anim.runtimeAnimatorController.animationClips) sprites.AddRange(GetSpritesFromClip(ac));
        #endif
            return sprites;
        }

        public static List<Sprite> GetSpritesFromClip(AnimationClip clip)
        {
            var sprites = new List<Sprite>();
        #if UNITY_EDITOR
            if (clip is null) return sprites;
            foreach (var binding in AnimationUtility.GetObjectReferenceCurveBindings(clip))
            {
                var keyframes = AnimationUtility.GetObjectReferenceCurve(clip , binding);
                foreach (var frame in keyframes) sprites.Add((Sprite)frame.value);
            }

        #endif
            return sprites;
        }

        public static Type GetType(string typeName , Type typeOfExistAssembly)
        {
            // var allTypesOfAssembly = typeOfExistAssembly.Assembly.GetTypes().ToList();
            // var types              = allTypesOfAssembly.FindAll(t => t.GetNiceName() == typeName);
            // var inGameDataStructure = types.FirstOrDefault(t =>
            // {
            //     var fullName = t.FullName;
            //     var contains = fullName.Contains("GameDataStructure") || fullName.Contains("ViewDataSo");
            //     return contains;
            // });
            // if (inGameDataStructure != null) return inGameDataStructure;
            // return types.Count > 0 ? types[0] : null;
            return null;
        }

        public static List<AnimationClip> LoadAllClipAtPath(string path)
        {
            var animationClips = new List<AnimationClip>();

        #if UNITY_EDITOR
            var dataPath          = Application.dataPath + path.Replace("Assets" , "");
            var allClipNameInPath = Directory.GetFiles(dataPath , "*.anim" , SearchOption.AllDirectories);
            foreach (var clipPath in allClipNameInPath)
            {
                var assetPath     = "Assets" + clipPath.Replace(Application.dataPath , "").Replace('\\' , '/');
                var animationClip = AssetDatabase.LoadAssetAtPath<AnimationClip>(assetPath);
                animationClips.Add(animationClip);
            }
        #endif
            return animationClips;
        }

        public static List<Material> LoadAllMaterialAtPath(string path)
        {
            var animationClips = new List<Material>();
        #if UNITY_EDITOR
            var dataPath     = Application.dataPath + path.Replace("Assets" , "");
            var allMatInPath = Directory.GetFiles(dataPath , "*.mat" , SearchOption.AllDirectories);
            foreach (var matPath in allMatInPath)
            {
                var assetPath = "Assets" + matPath.Replace(Application.dataPath , "").Replace('\\' , '/');
                var mateiral  = AssetDatabase.LoadAssetAtPath<Material>(assetPath);
                animationClips.Add(mateiral);
            }
        #endif
            return animationClips;
        }

        public static List<AnimatorOverrideController> LoadAllOverrideAtPath(string path)
        {
            var animationClips = new List<AnimatorOverrideController>();

        #if UNITY_EDITOR
            var dataPath = Application.dataPath + path.Replace("Assets" , "");
            var overrideInPath =
                    Directory.GetFiles(dataPath , "*.overrideController" , SearchOption.AllDirectories);
            foreach (var overridePath in overrideInPath)
            {
                var assetPath                  = "Assets" + overridePath.Replace(Application.dataPath , "").Replace('\\' , '/');
                var animatorOverrideController = AssetDatabase.LoadAssetAtPath<AnimatorOverrideController>(assetPath);
                animationClips.Add(animatorOverrideController);
            }
        #endif
            return animationClips;
        }

        public static T LoadAssetAtPath<T>(string path) where T : Object
        {
            var t = default(T);
        #if UNITY_EDITOR
            t = AssetDatabase.LoadAssetAtPath<T>(path);
        #endif
            return t;
        }

        public static void PingObject(Object instance)
        {
        #if UNITY_EDITOR
            EditorGUIUtility.PingObject(instance);
        #endif
        }

        public static void SaveAssets()
        {
            InternalSaveAssets();
        }

        public static void SelectObject(Object instance)
        {
        #if UNITY_EDITOR
            InternalSetSelectionActiveObject(instance);
        #endif
        }

        public static void SetDirty(Object obj)
        {
        #if UNITY_EDITOR
            EditorUtility.SetDirty(obj);
        #endif
        }

        public static void SetDirtyAndSave(Object obj , string name)
        {
        #if UNITY_EDITOR
            Undo.RegisterCompleteObjectUndo(obj , name);
            SetDirty(obj);
            InternalSaveAsset(obj);
        #endif
        }

    #endregion

    #region Private Methods

        private static void InternalCreateAsset<T>(string path , string soName , T asset) where T : ScriptableObject
        {
        #if UNITY_EDITOR
            AssetDatabase.CreateAsset(asset , $"{path}/{soName}.asset");
        #endif
        }

        private static void InternalDeleteAsset(string path)
        {
        #if UNITY_EDITOR
            AssetDatabase.DeleteAsset(path);
        #endif
        }

        private static void InternalFocusProjectWindow()
        {
        #if UNITY_EDITOR
            EditorUtility.FocusProjectWindow();
        #endif
        }

        private static void InternalSaveAsset(Object obj)
        {
        #if UNITY_EDITOR
            AssetDatabase.SaveAssetIfDirty(obj);
        #endif
        }

        private static void InternalSaveAssets()
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