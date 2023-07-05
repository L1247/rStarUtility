using System;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace rStarUtility.Generic.Tests.Tests.Editor.Generic
{
    public class UlidTests
    {
        [Test]
        public void Random()
        {
            var ulid = Ulid.NewUlid().ToString();
            Debug.Log($"{ulid}");
        }
    }
}