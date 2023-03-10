using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected static T instance;

    public static T Instance { get { return instance; } }
    protected bool shouldDestroy = true;
    protected virtual void Awake()
    {
       
    }

    public static bool IsInitialize
    {
        get { return instance != null; }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    public static T GetInstance()
    {
        return instance;
    }
    protected void Init()
    {
      
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = (T)this;
            if (shouldDestroy)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
