using Cinemachine;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

namespace Utility
{
    public class GameObjectFinder
    {
        public static GameObject FindChild(GameObject target, string name)
        {
            if (target == null)
            {
                return null;
            }

            GameObject result = null;

            if (target.name.Equals(name) == true)
            {
                return target;
            }

            for (int i = 0; i < target.transform.childCount; i++)
            {
                var child = target.transform.GetChild(i).gameObject;
                if (child.name.Equals(name) == true)
                {
                    return child;
                }
                else
                {
                    if (child.transform.childCount > 0)
                    {
                        result = FindChild(child, name);
                    }
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }
    }
    
}

