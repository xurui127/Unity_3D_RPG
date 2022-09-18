using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHaddler : MonoBehaviour
{
    #region System

    private BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {

        }
    }
    #endregion
}
