using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] public List<Enemy> enemies;
    Enemy target;
    float minDis = 2.5f;
    public Enemy Target => GetNearestTarget();
    // Update is called once per frame
    void Update()
    {
        
    }
    Enemy GetNearestTarget()
    {

        if (enemies.Count == 0)
        {
            return null;
        }
        if (enemies.Count == 1)
        {
            return target = enemies[0];
           
        }

        foreach (var enemy in enemies)
        {
            float distance = (enemy.transform.position - transform.position).sqrMagnitude;

            if (distance <= minDis)
            {
                //minDis = distance;
              return  target = enemy;
            }
        }
        return null;
    }
}
