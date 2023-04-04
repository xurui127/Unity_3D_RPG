using ObjectPool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField] Pool[] swordEffect;
    static  Dictionary<GameObject, Pool> dicPool;

    private void Start()
    {
        dicPool = new Dictionary<GameObject, Pool>();
        Init();
        InitPool(swordEffect);
    }
    void InitPool(Pool[] pools)
    {
        foreach (var pool in pools)
        {
            if (dicPool.ContainsKey(pool.Prefab))
            {
                Debug.Log("Same Prefab in multiple pools. Prefab: " + pool.Prefab.name);
                continue;
            }
            dicPool.Add(pool.Prefab,pool);
            Transform poolParent = new GameObject("Pool : " + pool.Prefab.name).transform;
            poolParent.parent = transform;
            pool.Init(poolParent);
        }
    }
    
    void CheckPoolSize(Pool[] pools)
    {
        foreach (var pool in pools)
        {
            if (pool.runTimeSize > pool.Size)
            {
                Debug.Log(string.Format("Pool: {0} has a runtime size {1} bigger than its initial size {2}",pool.Prefab.name,pool.runTimeSize,pool.Size));
            }
        }
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        CheckPoolSize(swordEffect); 
    }
    public static GameObject Release(GameObject prefab)
    {
        if (!dicPool.ContainsKey(prefab))
        {
            Debug.Log("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
        return dicPool[prefab].PreparedObject();
    }
    public static GameObject Release(GameObject prefab , Vector3 position)
    {
        if (!dicPool.ContainsKey(prefab))
        {
            Debug.Log("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
        return dicPool[prefab].PreparedObject(position);
    }

    public static GameObject Release(GameObject prefab, Vector3 position , Quaternion rotation)
    {
        if (!dicPool.ContainsKey(prefab))
        {
            Debug.Log("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
        return dicPool[prefab].PreparedObject(position, rotation);
    }
    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation, Vector3 localScale)
    {
        if (!dicPool.ContainsKey(prefab))
        {
            Debug.Log("Pool Manager could not find prefab: " + prefab.name);
            return null;
        }
        return dicPool[prefab].PreparedObject(position, rotation, localScale);
    }
}
