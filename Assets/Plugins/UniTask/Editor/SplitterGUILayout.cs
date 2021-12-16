#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

#region

using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

#endregion

namespace Cysharp.Threading.Tasks.Editor
{
    // reflection call of UnityEditor.SplitterGUILayout
    internal static class SplitterGUILayout
    {
        private static readonly BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                                     BindingFlags.Static;

        private static readonly Lazy<Type> splitterStateType = new Lazy<Type>(() =>
        {
            var type = typeof(EditorWindow).Assembly.GetTypes().First(x => x.FullName == "UnityEditor.SplitterState");
            return type;
        });

        private static readonly Lazy<ConstructorInfo> splitterStateCtor = new Lazy<ConstructorInfo>(() =>
        {
            var type = splitterStateType.Value;
            return type.GetConstructor(flags , null , new[] { typeof(float[]) , typeof(int[]) , typeof(int[]) } , null);
        });

        private static readonly Lazy<Type> splitterGUILayoutType = new Lazy<Type>(() =>
        {
            var type = typeof(EditorWindow).Assembly.GetTypes().First(x => x.FullName == "UnityEditor.SplitterGUILayout");
            return type;
        });

        private static readonly Lazy<MethodInfo> beginVerticalSplit = new Lazy<MethodInfo>(() =>
        {
            var type = splitterGUILayoutType.Value;
            return type.GetMethod("BeginVerticalSplit" , flags , null , new[] { splitterStateType.Value , typeof(GUILayoutOption[]) } ,
                                  null);
        });

        private static readonly Lazy<MethodInfo> endVerticalSplit = new Lazy<MethodInfo>(() =>
        {
            var type = splitterGUILayoutType.Value;
            return type.GetMethod("EndVerticalSplit" , flags , null , Type.EmptyTypes , null);
        });

        public static object CreateSplitterState(float[] relativeSizes , int[] minSizes , int[] maxSizes)
        {
            return splitterStateCtor.Value.Invoke(new object[] { relativeSizes , minSizes , maxSizes });
        }

        public static void BeginVerticalSplit(object splitterState , params GUILayoutOption[] options)
        {
            beginVerticalSplit.Value.Invoke(null , new[] { splitterState , options });
        }

        public static void EndVerticalSplit()
        {
            endVerticalSplit.Value.Invoke(null , Type.EmptyTypes);
        }
    }
}