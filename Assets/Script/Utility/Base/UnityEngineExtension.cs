using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

namespace UnityExtension
{
    public static class UnityEngineExtension
    {
        

        public static void InvokeFromNextFrame(this MonoBehaviour mb, UnityAction callBack)
        {
            Debug.Log("Called");
            mb.StartCoroutine(ProcessNextFrame(callBack));
        }
        private static IEnumerator ProcessNextFrame(UnityAction callBack)
        {
            yield return null;
            callBack();
        }
    }
}

