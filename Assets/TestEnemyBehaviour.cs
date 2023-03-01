using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyBehaviour : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //foreach (var col in other.GetComponentsInChildren<Collider>())
        //{
        //    if (col.gameObject.tag == "Weapon")
        //    {
        //        Debug.Log("in hit");
        //        var anim = GetComponent<AnimController>();
        //        anim.GetHit();
        //    }
        //}

    }
}
