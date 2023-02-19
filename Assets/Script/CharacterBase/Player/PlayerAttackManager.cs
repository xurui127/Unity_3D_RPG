using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [SerializeField] float gizmosSize;
    [SerializeField] public List<Enemy> enemies;
    [SerializeField] Enemy target;
    [SerializeField] float minDis = 2f;
    
    public Enemy Target => target;

    private CharacterController characterController;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, gizmosSize);
    }
    private void Update()
    {
 
    }
    void AddEnemyToList(Collider co)
    {
        if ( co.TryGetComponent<Enemy>(out Enemy enemy)&& !enemies.Contains(enemy))
        {
            
            enemies.Add(enemy); 

        }
    }
    void RemoveEnemyToList(Collider co)
    {
        if (co.TryGetComponent<Enemy>(out Enemy enemy) && enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }
    }
    
    //private void OnTriggerEnter(Collider co) => AddEnemyToList(co);
    ////private void OnTriggerStay(Collider co) => AddEnemyToList(co);
    //private void OnTriggerExit(Collider co) => RemoveEnemyToList(co);
    
}
