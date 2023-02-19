using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] public List<Enemy> enemies;
    Enemy target;
    [SerializeField]float minDis = 2.5f;
    [SerializeField] public GameObject player;
    public Enemy Target => GetNearestTarget();

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
   public Enemy GetNearestTarget()
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
            //float distance = (enemy.transform.position - transform.position).sqrMagnitude;
            float distance = (enemy.transform.position - player.transform.position).sqrMagnitude;

            if (distance <= minDis)
            {
                //minDis = distance;
                Debug.Log(target);
                return  target = enemy;
            }
        }
        return null;
    }
}
